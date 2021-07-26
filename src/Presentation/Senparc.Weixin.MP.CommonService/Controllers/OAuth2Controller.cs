using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Senparc.Weixin.MP.AdvancedAPIs;
using Senparc.Weixin.MP.AdvancedAPIs.OAuth;
using Senparc.Weixin.Entities;
using Nop.Core;
using Nop.Core.Http.Extensions;
using Nop.Core.Infrastructure;
using Nop.Core.Domain.Customers;
using Nop.Core.Domain.Weixin;
using Nop.Services.Customers;
using Nop.Services.Weixin;
using Senparc.Weixin.MP.CommonService.Utilities;
using StackExchange.Profiling.Internal;
using Nop.Services.Suppliers;

namespace Senparc.Weixin.MP.CommonService.Controllers
{
    public partial class OAuth2Controller : Controller
    {
        #region Fields

        private readonly INopFileProvider _fileProvider;
        private readonly SenparcWeixinSetting _senparcWeixinSetting;
        private readonly IWebHelper _webHelper;
        private readonly IWorkContext _workContext;
        private readonly IWxUserService _wUserService;
        private readonly ICustomerService _customerService;
        private readonly CustomerSettings _customerSettings;
        private readonly ISupplierUserAuthorityMappingService _supplierUserAuthorityMappingService;

        #endregion

        #region Ctor

        public OAuth2Controller(INopFileProvider fileProvider,
            IWxUserService wUserService,
            IWebHelper webHelper,
            IWorkContext workContext,
            ISupplierUserAuthorityMappingService supplierUserAuthorityMappingService,
            ICustomerService customerService,
            CustomerSettings customerSettings,
            SenparcWeixinSetting senparcWeixinSetting)
        {
            _fileProvider = fileProvider;
            _wUserService = wUserService;
            _webHelper = webHelper;
            _workContext = workContext;
            _supplierUserAuthorityMappingService = supplierUserAuthorityMappingService;
            _customerService = customerService;
            _customerSettings = customerSettings;
            _senparcWeixinSetting = senparcWeixinSetting;
        }

        #endregion

        /// <summary>
        /// 
        /// </summary>
        /// <param name="code"></param>
        /// <param name="state"></param>
        /// <param name="returnUrl">用户尝试进入的需要登录的页面</param>
        /// <returns></returns>
        public async Task<IActionResult> Index(string code, string state, string returnUrl)
        {
            if (string.IsNullOrEmpty(code))
                return Content("您拒绝了授权！");

            var stateSession = HttpContext.Session.GetString(NopWeixinDefaults.WeixinOauthStateString);

            if (string.IsNullOrEmpty(stateSession) || state != stateSession)
                return Content("验证失败！");

            //判断是否使用的userinfo的Oauth授权
            var isUserInfoOauthType = state.StartsWith("userinfo", StringComparison.InvariantCultureIgnoreCase);

            //为了安全清除session
            HttpContext.Session.Remove(NopWeixinDefaults.WeixinOauthStateString);

            OAuthAccessTokenResult accessTokenResult;

            //通过，用code换取access_token
            try
            {
                accessTokenResult = await OAuthApi.GetAccessTokenAsync(_senparcWeixinSetting.WeixinAppId, _senparcWeixinSetting.WeixinAppSecret, code);
                if (accessTokenResult == null || accessTokenResult.errcode != ReturnCode.请求成功)
                {
                    return Content("错误：" + accessTokenResult.errmsg);
                }
            }
            catch (Exception ex)
            {
                WeixinTrace.SendCustomLog("Oauth2Callback发生错误 GetAccessToken：", ex.ToString());
                return Content(ex.Message);
            }

            //初始化基础Session信息
            var oauthSession = new OauthSession
            {
                OpenId = accessTokenResult.openid,
                AccessToken = accessTokenResult.access_token,
                RefreshToken = accessTokenResult.refresh_token,
                CreatTime = DateTime.Now
            };

            //保存基础session信息
            HttpContext.Session.Set(NopWeixinDefaults.WeixinOauthSession, oauthSession);

            //初始化用户数据库基础信息
            #region 初始化用户数据库基础信息
            var insertCurrentWxUser = false;  //是否需要插入WxUser到数据库（普通授权不需要插入）
            var needUpdateCurrentWxUser = false; //需要更新

            var currentCustomer = await _workContext.GetCurrentCustomerAsync(); //已自动绑定OpenId
            var currentWxUser = await _wUserService.GetWxUserByOpenIdAsync(oauthSession.OpenId);

            //获取当前Customer推荐人
            var charPosition = state.IndexOf("_"); //空值返回-1
            if (charPosition > 0) //第一个下划线出现位置
            {
                await _workContext.SetCustomerReferrerIdAsync(state.Substring(charPosition + 1), currentCustomer, refreshCache: true);
            }

            //初始化WxUser
            if (currentWxUser == null)
            {
                //需要插入数据
                insertCurrentWxUser = true;

                currentWxUser = new WxUser
                {
                    CustomerId = currentCustomer.Id,
                    OpenId = oauthSession.OpenId,
                    CheckInType = CheckInType.Oauth,  //每个渠道不同
                    LanguageType = LanguageType.ZH_CN,
                    Sex = 0,
                    RoleType = RoleType.Visitor,
                    SceneType = SceneType.None,
                    Status = 0,
                    SupplierShopId = 0,  //需要参数传入重新赋值
                    QrScene = 0,
                    Subscribe = false,
                    AllowResponse = true,
                    AllowNotice = false,
                    AllowOrderNotice = false,
                    InBlackList = false,
                    SubscribeTime = 0,
                    UnSubscribeTime = 0,
                    UpdateTime = DateTime.Now.AddDays(-30),
                    CreatTime = DateTime.Now
                };
            }

            //是否SupplierShop员工推荐的用户，绑定用户到SupplierShop
            var supplierUserAuthorityMapping = await _supplierUserAuthorityMappingService.GetEntityByCustomerIdAsync(currentCustomer.ReferrerCustomerId);
            if (supplierUserAuthorityMapping != null)
                currentWxUser.SupplierShopId = supplierUserAuthorityMapping.SupplierShopId ?? 0;

            #endregion

            //是否拉取最新微信用户信息
            if(currentWxUser.UpdateTime.AddMinutes(60) < DateTime.Now)
            {
                var apiGetSuccess = false; //UserApi获取是否成功

                try
                {
                    //尝试API方法更新
                    var userInfo = AdvancedAPIs.UserApi.Info(_senparcWeixinSetting.WeixinAppId, accessTokenResult.openid);
                    if (userInfo != null && userInfo.errcode == ReturnCode.请求成功)
                    {
                        needUpdateCurrentWxUser = true;// 需要更新

                        if (userInfo.subscribe == 1)
                        {
                            apiGetSuccess = true; //Api获取信息成功

                            currentWxUser.Subscribe = true;
                            currentWxUser.NickName = userInfo.nickname;
                            currentWxUser.Sex = Convert.ToByte(userInfo.sex);
                            currentWxUser.LanguageType = Enum.TryParse(typeof(LanguageType), userInfo.language, true, out var outLanguage) ? (LanguageType)outLanguage : LanguageType.ZH_CN;
                            currentWxUser.City = userInfo.city;
                            currentWxUser.Province = userInfo.province;
                            currentWxUser.Country = userInfo.country;
                            currentWxUser.HeadImgUrlShort = Utilities.HeadImageUrlHelper.GetHeadImageUrlKey(userInfo.headimgurl);
                            currentWxUser.SubscribeTime = (int)userInfo.subscribe_time;
                            currentWxUser.UpdateTime = DateTime.Now;
                            currentWxUser.UnionId = userInfo.unionid;
                            currentWxUser.Remark = userInfo.remark;
                            currentWxUser.GroupId = userInfo.groupid.ToString();
                            currentWxUser.TagIdList = string.Join(",", userInfo.tagid_list) + (userInfo.tagid_list.Length > 0 ? "," : "");
                            currentWxUser.SubscribeSceneType = Enum.TryParse(typeof(SubscribeSceneType), userInfo.subscribe_scene, true, out var wSubscribeSceneType) ? (SubscribeSceneType)wSubscribeSceneType : SubscribeSceneType.ADD_SCENE_OTHERS;
                        }
                        else
                        {
                            userInfo.subscribe = 0;
                        }
                    }

                    //尝试UserInfo方法更新
                    if (!apiGetSuccess && isUserInfoOauthType)
                    {
                        var userBaseInfo = await OAuthApi.GetUserInfoAsync(accessTokenResult.access_token, accessTokenResult.openid);
                        if (userBaseInfo != null && !string.IsNullOrEmpty(userBaseInfo.nickname))
                        {
                            needUpdateCurrentWxUser = true;// 需要更新

                            currentWxUser.NickName = userBaseInfo.nickname;
                            currentWxUser.Sex = Convert.ToByte(userBaseInfo.sex);
                            currentWxUser.City = userBaseInfo.city;
                            currentWxUser.Province = userBaseInfo.province;
                            currentWxUser.Country = userBaseInfo.country;
                            currentWxUser.HeadImgUrlShort = Utilities.HeadImageUrlHelper.GetHeadImageUrlKey(userBaseInfo.headimgurl);
                            currentWxUser.UnionId = userBaseInfo.unionid;
                            currentWxUser.UpdateTime = DateTime.Now;
                        }
                    }
                }
                catch
                {
                    //do nothing
                    //进入该步骤表示授权成功，能否获取用户基本信息不重要，这里不能影响跳转操作
                }
            }

            //更新oauthSession信息
            #region 更新oauthSession信息
            if (!string.IsNullOrEmpty(currentWxUser.NickName))
            {
                oauthSession.User.HeadImgUrl = HeadImageUrlHelper.GetHeadImageUrl(currentWxUser.HeadImgUrlShort);
                oauthSession.User.NickName = currentWxUser.NickName;
                oauthSession.User.OpenId = currentWxUser.OpenId;
                oauthSession.User.Subscribe = currentWxUser.Subscribe;
                oauthSession.User.SubscribeTime = currentWxUser.SubscribeTime;
                oauthSession.User.UnSubscribeTime = currentWxUser.UnSubscribeTime;
                oauthSession.User.UnionId = currentWxUser.UnionId;

                //更新Session
                HttpContext.Session.Set(NopWeixinDefaults.WeixinOauthSession, oauthSession);
            }
            #endregion

            //用户基础信息插入/更新
            #region 用户基础信息插入/更新
            if (insertCurrentWxUser)
                await _wUserService.InsertWxUserAsync(currentWxUser);
            else if (needUpdateCurrentWxUser)
                await _wUserService.UpdateWxUserAsync(currentWxUser);

            #endregion

            if (!string.IsNullOrEmpty(returnUrl))
            {
                return Redirect(returnUrl);
            }

            //默认消息
            return Content("SUCCESS.");
        }
    }
}
