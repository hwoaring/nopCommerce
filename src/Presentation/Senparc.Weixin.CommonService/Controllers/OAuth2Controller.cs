using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Senparc.Weixin.Exceptions;
using Senparc.CO2NET.Extensions;

using Senparc.Weixin.Entities;
using Senparc.Weixin.HttpUtility;
using Senparc.Weixin.MP.AdvancedAPIs;
using Senparc.Weixin.MP.AdvancedAPIs.OAuth;
using Senparc.Weixin.MP.CommonAPIs;
using System.Text;
using Senparc.Weixin.MP;
using Nop.Core;
using Nop.Core.Http.Extensions;
using Nop.Core.Infrastructure;
using Nop.Core.Domain.Customers;
using Nop.Core.Domain.Weixins;
using Nop.Services.Weixins;
using Nop.Services.Customers;
using Nop.Services.Helpers;

namespace Senparc.Weixin.CommonService.Controllers
{
    public partial class OAuth2Controller : WeixinBaseController
    {
        #region Fields

        private readonly INopFileProvider _fileProvider;
        private readonly SenparcWeixinSetting _senparcWeixinSetting;
        private readonly IWebHelper _webHelper;
        private readonly IWorkContext _workContext;
        private readonly ICustomerService _customerService;
        private readonly IWeixinUserService _weixinUserService;
        private readonly CustomerSettings _customerSettings;

        #endregion

        #region Ctor

        public OAuth2Controller(INopFileProvider fileProvider,
            IWebHelper webHelper,
            IWorkContext workContext,
            ICustomerService customerService,
            IWeixinUserService weixinUserService,
            CustomerSettings customerSettings,
            SenparcWeixinSetting senparcWeixinSetting)
        {
            _fileProvider = fileProvider;
            _webHelper = webHelper;
            _workContext = workContext;
            _customerService = customerService;
            _weixinUserService = weixinUserService;
            _customerSettings = customerSettings;
            _senparcWeixinSetting = senparcWeixinSetting;
        }

        #endregion


        /// <summary>
        /// 用户登录回调页面
        /// </summary>
        /// <param name="code"></param>
        /// <param name="state"></param>
        /// <param name="returnUrl"></param>
        /// <returns></returns>
        public virtual async Task<IActionResult> Index(string code, string state, string returnUrl)
        {
            if (string.IsNullOrEmpty(code))
                return Content("您拒绝了授权！");

            var stateSession = HttpContext.Session.GetString(NopWeixinDefaults.WeixinOAuthState);
            if (string.IsNullOrEmpty(stateSession) || state != stateSession)
                return Content("验证失败！");

            //判断是否使用的userinfo的Oauth授权
            var isUserInfoOAuthType = state.StartsWith("userinfo", StringComparison.InvariantCultureIgnoreCase);

            //为了安全清除session
            await HttpContext.Session.RemoveAsync(NopWeixinDefaults.WeixinOAuthState);

            OAuthAccessTokenResult result;

            //通过，用code换取access_token
            try
            {
                result = await OAuthApi.GetAccessTokenAsync(_senparcWeixinSetting.WeixinAppId, _senparcWeixinSetting.WeixinAppSecret, code);
                if (result == null || result.errcode != ReturnCode.请求成功)
                    return Content("错误：" + result.errmsg);
            }
            catch (Exception ex)
            {
                WeixinTrace.SendCustomLog("Oauth2Callback发生错误 GetAccessToken：", ex.ToString());
                return Content(ex.Message);
            }

            //初始化基础Session信息
            var oauthSession = new WeixinOAuthSession
            {
                //ReturnUrl = "",
                UnionId = result.unionid,
                OpenId = result.openid,
                AccessToken = result.access_token,
                RefreshToken = result.refresh_token,
                Scope = result.scope,
                IsSnapshotuser = result.is_snapshotuser,
                ExpiresIn = result.expires_in,
                CreatTime = DateTime.UtcNow
            };

            //保存基础session信息
            await HttpContext.Session.SetAsync(NopWeixinDefaults.WeixinOAuthSession, oauthSession);
            var currentCustomer = await _workContext.GetCurrentCustomerAsync();
            //openid绑定到用户
            currentCustomer = await _workContext.SetCurrentCustomerOpenIdAsync(currentCustomer, oauthSession.OpenId, oauthSession.IsSnapshotuser);

            //虚拟账号不进行绑定，不进行用户信息获取
            if (!result.is_snapshotuser.HasValue || 1!=result.is_snapshotuser.Value)
            {
                //获取UserInfo信息，因为这里还不确定用户是否关注本微信，所以只能试探性地获取一下
                OAuthUserInfo oAuthUserInfo;
                try
                {
                    //拉取用户信息(需scope为 snsapi_userinfo)或已关注用户
                    oAuthUserInfo = await OAuthApi.GetUserInfoAsync(result.access_token, result.openid);

                    if (oAuthUserInfo != null && !string.IsNullOrWhiteSpace(oAuthUserInfo.nickname))
                    {
                        //获取WeixinUser
                        var weixinUser = await _weixinUserService.GetWeixinUserByOpenIdAsync(result.openid);
                        if (weixinUser != null && weixinUser.UpdatedOnUtc.AddMinutes(10) < DateTime.UtcNow)//更新，10分钟内不更新
                        {
                            if (weixinUser.CustomerId == 0)
                                weixinUser.CustomerId = currentCustomer.Id;

                            weixinUser.Subscribe = (oAuthUserInfo.subscribe == 1);
                            weixinUser.NickName = oAuthUserInfo.nickname;
                            //weixinUser.Sex = oAuthUserInfo.sex; //接口不再返回信息
                            //weixinUser.Province = oAuthUserInfo.province; //接口不再返回信息
                            //weixinUser.City = oAuthUserInfo.city; //接口不再返回信息
                            //weixinUser.Country = oAuthUserInfo.country; //接口不再返回信息
                            //weixinUser.Language = oAuthUserInfo.language; //接口不再返回信息
                            weixinUser.HeadimgUrl = oAuthUserInfo.headimgurl;
                            weixinUser.Privilege = oAuthUserInfo.privilege.Length > 0 ? string.Join(",", oAuthUserInfo.privilege) : string.Empty;
                            //weixinUser.SubscribeTime = DateTimeHelper.GetDateTimeFromXml(oAuthUserInfo.subscribe_time);  //不需要更新

                            if (!string.IsNullOrEmpty(oAuthUserInfo.unionid) && string.IsNullOrEmpty(weixinUser.UnionId))
                                weixinUser.UnionId = oAuthUserInfo.unionid;
                            
                            weixinUser.Remark = oAuthUserInfo.remark;
                            weixinUser.GroupId = oAuthUserInfo.groupid;
                            weixinUser.TagidList = oAuthUserInfo.tagid_list.Length > 0 ? string.Join(",", oAuthUserInfo.tagid_list) : string.Empty;
                            //weixinUser.SubscribeSceneType = Enum.TryParse<SubscribeSceneType>(oAuthUserInfo.subscribe_scene, true, out var sceneResult) ? sceneResult : SubscribeSceneType.ADD_SCENE_OTHERS;  //不需要更新
                            //weixinUser.QrScene = oAuthUserInfo.qr_scene;  //不需要更新
                            //weixinUser.QrSceneStr = oAuthUserInfo.qr_scene_str;  //不需要更新
                            weixinUser.UpdatedOnUtc = DateTime.UtcNow;

                            await _weixinUserService.UpdateWeixinUserAsync(weixinUser);
                        }
                        else //插入
                        {
                            weixinUser = new WeixinUser()
                            {
                                CustomerId = currentCustomer.Id,//绑定Customer Id
                                Subscribe = oAuthUserInfo.subscribe == 1,
                                OpenId = oAuthUserInfo.openid,
                                NickName = oAuthUserInfo.nickname,
                                //Sex = oAuthUserInfo.sex, //接口不再返回信息
                                //Province = oAuthUserInfo.province, //接口不再返回信息
                                //City = oAuthUserInfo.city, //接口不再返回信息
                                //Country = oAuthUserInfo.country, //接口不再返回信息
                                //Language = oAuthUserInfo.language, //接口不再返回信息
                                HeadimgUrl = oAuthUserInfo.headimgurl,
                                Privilege = oAuthUserInfo.privilege.Length > 0 ? string.Join(",", oAuthUserInfo.privilege) : string.Empty,
                                SubscribeTime = WeixinDateTimeHelper.GetDateTimeFromXml(oAuthUserInfo.subscribe_time),
                                UnionId = oAuthUserInfo.unionid,
                                Remark = oAuthUserInfo.remark,
                                GroupId = oAuthUserInfo.groupid,
                                TagidList = oAuthUserInfo.tagid_list.Length > 0 ? string.Join(",", oAuthUserInfo.tagid_list) : string.Empty,
                                SubscribeSceneType = Enum.TryParse<SubscribeSceneType>(oAuthUserInfo.subscribe_scene, true, out var sceneResult) ? sceneResult : SubscribeSceneType.ADD_SCENE_OTHERS,
                                QrScene = oAuthUserInfo.qr_scene,
                                QrSceneStr = oAuthUserInfo.qr_scene_str,
                                UpdatedOnUtc = DateTime.UtcNow,
                                CreatedOnUtc = DateTime.UtcNow
                            };
                            await _weixinUserService.InsertWeixinUserAsync(weixinUser);
                        }
                    }
                }
                catch (ErrorJsonResultException ex)
                {
                    //这里的 ex.JsonResult 可能为："{\"errcode\":40003,\"errmsg\":\"invalid openid\"}"
                    //return Content("用户已授权，授权Token：" + result, "text/html", Encoding.UTF8);
                }
            }
                
            //跳转到访问页面
            if (!string.IsNullOrEmpty(returnUrl))
                return Redirect(returnUrl);

            //默认消息
            return Content("SUCCESS.");
        }

    }
}