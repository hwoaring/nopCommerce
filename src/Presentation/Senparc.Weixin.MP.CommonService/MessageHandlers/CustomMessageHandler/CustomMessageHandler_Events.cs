/*----------------------------------------------------------------
    Copyright (C) 2020 Senparc
    
    文件名：CustomMessageHandler_Events.cs
    文件功能描述：自定义MessageHandler
    
    
    创建标识：Senparc - 20150312
----------------------------------------------------------------*/

//DPBMARK_FILE MP
using Senparc.CO2NET;
using Senparc.CO2NET.Extensions;
using Senparc.CO2NET.Utilities;
using Senparc.NeuChar.Agents;
using Senparc.NeuChar.Entities;
using Senparc.Weixin.Exceptions;
using Senparc.Weixin.MP.AdvancedAPIs;
using Senparc.Weixin.MP.Entities;
using Senparc.Weixin.MP.CommonService.Download;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

using Nop.Core;
using Nop.Core.Infrastructure;
using Nop.Core.Domain.Customers;
using Nop.Core.Domain.Weixin;
using Nop.Core.Domain.Suppliers;
using Nop.Core.Domain.Marketing;
using Nop.Services.Customers;
using Nop.Services.Weixin;
using Nop.Services.Suppliers;
using Nop.Services.Marketing;
using Nop.Services.Helpers;
using Senparc.CO2NET.Helpers;

using Org.BouncyCastle.Ocsp;
using OfficeOpenXml.FormulaParsing.Excel.Functions.Math;

using Senparc.Weixin.MP.CommonService.Utilities;

namespace Senparc.Weixin.MP.CommonService.CustomMessageHandler
{
    /// <summary>
    /// 自定义MessageHandler
    /// </summary>
    public partial class CustomMessageHandler
    {
        private string GetWelcomeInfo()
        {
            //获取Senparc.Weixin.MP.dll版本信息
            //var filePath = ServerUtility.ContentRootMapPath("~/bin/Release/netcoreapp2.2/Senparc.Weixin.MP.dll");//本地测试路径
            var filePath = ServerUtility.ContentRootMapPath("~/Senparc.Weixin.MP.dll");//发布路径
            var fileVersionInfo = FileVersionInfo.GetVersionInfo(filePath);

            string version = fileVersionInfo == null
                ? "-"
                : string.Format("{0}.{1}.{2}", fileVersionInfo.FileMajorPart, fileVersionInfo.FileMinorPart, fileVersionInfo.FileBuildPart);

            return string.Format(@"欢迎关注【微信公众平台SDK】，当前运行版本：v{0}。", version);
        }

        private string GetDownloadInfo(CodeRecord codeRecord)
        {
            return string.Format(@"您已通过二维码验证，浏览器即将开始下载,当前选择的版本：v{0}（{1}）", codeRecord.Version, codeRecord.IsWebVersion ? "网页版" : ".chm文档版", SystemTime.Now.Year);
        }

        public override IResponseMessageBase OnTextOrEventRequest(RequestMessageText requestMessage)
        {
            // 预处理文字或事件类型请求。
            // 这个请求是一个比较特殊的请求，通常用于统一处理来自文字或菜单按钮的同一个执行逻辑，
            // 会在执行OnTextRequest或OnEventRequest之前触发，具有以下一些特征：
            // 1、如果返回null，则继续执行OnTextRequest或OnEventRequest
            // 2、如果返回不为null，则终止执行OnTextRequest或OnEventRequest，返回最终ResponseMessage
            // 3、如果是事件，则会将RequestMessageEvent自动转为RequestMessageText类型，其中RequestMessageText.Content就是RequestMessageEvent.EventKey

            if (requestMessage.Content == "OneClick")
            {
                var strongResponseMessage = CreateResponseMessage<ResponseMessageText>();
                strongResponseMessage.Content = "您点击了底部按钮。\r\n为了测试微信软件换行bug的应对措施，这里做了一个——\r\n换行";
                return strongResponseMessage;
            }
            return null;//返回null，则继续执行OnTextRequest或OnEventRequest
        }

        /// <summary>
        /// 点击事件
        /// </summary>
        /// <param name="requestMessage">请求消息</param>
        /// <returns></returns>
        public override IResponseMessageBase OnEvent_ClickRequest(RequestMessageEvent_Click requestMessage)
        {
            IResponseMessageBase reponseMessage = null;
            //菜单点击，需要跟创建菜单时的Key匹配

            switch (requestMessage.EventKey)
            {
                case "OneClick":
                    {
                        //这个过程实际已经在OnTextOrEventRequest中命中“OneClick”关键字，并完成回复，这里不会执行到。
                        var strongResponseMessage = CreateResponseMessage<ResponseMessageText>();
                        reponseMessage = strongResponseMessage;
                        strongResponseMessage.Content = "您点击了底部按钮。\r\n为了测试微信软件换行bug的应对措施，这里做了一个——\r\n换行";
                    }
                    break;
                case "SubClickRoot_Text":
                    {
                        var strongResponseMessage = CreateResponseMessage<ResponseMessageText>();
                        reponseMessage = strongResponseMessage;
                        strongResponseMessage.Content = "您点击了子菜单按钮。";
                    }
                    break;
                case "SubClickRoot_News":
                    {
                        var strongResponseMessage = CreateResponseMessage<ResponseMessageNews>();
                        reponseMessage = strongResponseMessage;
                        strongResponseMessage.Articles.Add(new Article()
                        {
                            Title = "您点击了子菜单图文按钮",
                            Description = "您点击了子菜单图文按钮，这是一条图文信息。这个区域是Description内容\r\n可以使用\\r\\n进行换行。",
                            PicUrl = "https://sdk.weixin.senparc.com/Images/qrcode.jpg",
                            Url = "https://sdk.weixin.senparc.com"
                        });

                        //随机添加一条图文，或只输出一条图文信息
                        if (SystemTime.Now.Second % 2 == 0)
                        {
                            strongResponseMessage.Articles.Add(new Article()
                            {
                                Title = "这是随机产生的第二条图文信息，用于测试多条图文的样式",
                                Description = "这是随机产生的第二条图文信息，用于测试多条图文的样式",
                                PicUrl = "https://sdk.weixin.senparc.com/Images/qrcode.jpg",
                                Url = "https://sdk.weixin.senparc.com"
                            });
                        }
                    }
                    break;
                case "SubClickRoot_Music":
                    {
                        //上传缩略图


                        var filePath = "~/wwwroot/Images/Logo.thumb.jpg";

                        var uploadResult = AdvancedAPIs.MediaApi.UploadTemporaryMedia(_senparcWeixinSetting.WeixinAppId, UploadMediaFileType.thumb,
                                                                    ServerUtility.ContentRootMapPath(filePath));
                        //PS：缩略图官方没有特别提示文件大小限制，实际测试哪怕114K也会返回文件过大的错误，因此尽量控制在小一点（当前图片39K）

                        //设置音乐信息
                        var strongResponseMessage = CreateResponseMessage<ResponseMessageMusic>();
                        reponseMessage = strongResponseMessage;
                        strongResponseMessage.Music.Title = "天籁之音";
                        strongResponseMessage.Music.Description = "真的是天籁之音";
                        strongResponseMessage.Music.MusicUrl = "https://sdk.weixin.senparc.com/Content/music1.mp3";
                        strongResponseMessage.Music.HQMusicUrl = "https://sdk.weixin.senparc.com/Content/music1.mp3";
                        strongResponseMessage.Music.ThumbMediaId = uploadResult.thumb_media_id;
                    }
                    break;
                case "SubClickRoot_Image":
                    {
                        //上传图片
                        var filePath = "~/wwwroot/Images/Logo.jpg";
                        var uploadResult = AdvancedAPIs.MediaApi.UploadTemporaryMedia(_senparcWeixinSetting.WeixinAppId, UploadMediaFileType.image,
                                                                     ServerUtility.ContentRootMapPath(filePath));
                        //设置图片信息
                        var strongResponseMessage = CreateResponseMessage<ResponseMessageImage>();
                        reponseMessage = strongResponseMessage;
                        strongResponseMessage.Image.MediaId = uploadResult.media_id;
                    }
                    break;
                case "SendMenu"://菜单消息
                    {
                        //注意：
                        //1、此接口可以在任意地方调用（包括后台线程），此处演示为通过
                        //2、一下"s:"前缀只是 Senparc.Weixin 的内部约定，可以使用 OnTextRequest事件中的 requestHandler.SelectMenuKeyword() 方法自动匹配到后缀（如101）

                        var menuContentList = new List<SendMenuContent>(){
                            new SendMenuContent("101","满意"),
                            new SendMenuContent("102","一般"),
                            new SendMenuContent("103","不满意")
                        };
                        //使用异步接口
                        CustomApi.SendMenuAsync(_senparcWeixinSetting.WeixinAppId, OpenId, "请给出您的评价", menuContentList, "感谢您的参与！");

                        reponseMessage = new ResponseMessageNoResponse();//不返回任何消息
                    }
                    break;
                case "SubClickRoot_Agent"://代理消息
                    {
                        //获取返回的XML
                        var dt1 = SystemTime.Now;
                        reponseMessage = MessageAgent.RequestResponseMessage(this, SenparcDI.GetServiceProvider(), _senparcWeixinSetting.AgentUrl, _senparcWeixinSetting.AgentToken, RequestDocument.ToString());
                        //上面的方法也可以使用扩展方法：this.RequestResponseMessage(this,agentUrl, agentToken, RequestDocument.ToString());

                        var dt2 = SystemTime.Now;

                        if (reponseMessage is ResponseMessageNews)
                        {
                            (reponseMessage as ResponseMessageNews)
                                .Articles[0]
                                .Description += string.Format("\r\n\r\n代理过程总耗时：{0}毫秒", (dt2 - dt1).Milliseconds);
                        }
                    }
                    break;
                case "Member"://托管代理会员信息
                    {
                        //原始方法为：MessageAgent.RequestXml(this,agentUrl, agentToken, RequestDocument.ToString());//获取返回的XML
                        reponseMessage = this.RequestResponseMessage(SenparcDI.GetServiceProvider(), _senparcWeixinSetting.AgentUrl, _senparcWeixinSetting.AgentToken, RequestDocument.ToString());
                    }
                    break;
                case "OAuth"://OAuth授权测试
                    {
                        var strongResponseMessage = CreateResponseMessage<ResponseMessageNews>();

                        strongResponseMessage.Articles.Add(new Article()
                        {
                            Title = "OAuth2.0测试",
                            Description = "选择下面两种不同的方式进行测试，区别在于授权成功后，最后停留的页面。",
                            //Url = "https://sdk.weixin.senparc.com/oauth2",
                            //PicUrl = "https://sdk.weixin.senparc.com/Images/qrcode.jpg"
                        });

                        strongResponseMessage.Articles.Add(new Article()
                        {
                            Title = "OAuth2.0测试（不带returnUrl），测试环境可使用",
                            Description = "OAuth2.0测试（不带returnUrl）",
                            Url = "https://sdk.weixin.senparc.com/oauth2",
                            PicUrl = "https://sdk.weixin.senparc.com/Images/qrcode.jpg"
                        });

                        var returnUrl = "/OAuth2/TestReturnUrl";
                        strongResponseMessage.Articles.Add(new Article()
                        {
                            Title = "OAuth2.0测试（带returnUrl），生产环境强烈推荐使用",
                            Description = "OAuth2.0测试（带returnUrl）",
                            Url = "https://sdk.weixin.senparc.com/oauth2?returnUrl=" + returnUrl.UrlEncode(),
                            PicUrl = "https://sdk.weixin.senparc.com/Images/qrcode.jpg"
                        });

                        reponseMessage = strongResponseMessage;

                    }
                    break;
                case "SubClickRoot_PicPhotoOrAlbum":
                    {
                        var strongResponseMessage = CreateResponseMessage<ResponseMessageText>();
                        reponseMessage = strongResponseMessage;
                        strongResponseMessage.Content = "您点击了【微信拍照】按钮。系统将会弹出拍照或者相册发图。";
                    }
                    break;
                case "SubClickRoot_ScancodePush":
                    {
                        var strongResponseMessage = CreateResponseMessage<ResponseMessageText>();
                        reponseMessage = strongResponseMessage;
                        strongResponseMessage.Content = "您点击了【微信扫码】按钮。";
                    }
                    break;
                case "ConditionalMenu_Male":
                    {
                        var strongResponseMessage = CreateResponseMessage<ResponseMessageText>();
                        reponseMessage = strongResponseMessage;
                        strongResponseMessage.Content = "您点击了个性化菜单按钮，您的微信性别设置为：男。";
                    }
                    break;
                case "ConditionalMenu_Femle":
                    {
                        var strongResponseMessage = CreateResponseMessage<ResponseMessageText>();
                        reponseMessage = strongResponseMessage;
                        strongResponseMessage.Content = "您点击了个性化菜单按钮，您的微信性别设置为：女。";
                    }
                    break;
                case "GetNewMediaId"://获取新的MediaId
                    {
                        var strongResponseMessage = CreateResponseMessage<ResponseMessageText>();
                        try
                        {
                            var result = AdvancedAPIs.MediaApi.UploadForeverMedia(_senparcWeixinSetting.WeixinAppId, ServerUtility.ContentRootMapPath("~/Images/logo.jpg"));
                            strongResponseMessage.Content = result.media_id;
                        }
                        catch (Exception e)
                        {
                            strongResponseMessage.Content = "发生错误：" + e.Message;
                            WeixinTrace.SendCustomLog("调用UploadForeverMedia()接口发生异常", e.Message);
                        }
                    }
                    break;
                default:
                    {
                        reponseMessage = new SuccessResponseMessage();
                    }
                    break;
            }

            return reponseMessage;
        }

        /// <summary>
        /// 进入事件
        /// </summary>
        /// <param name="requestMessage"></param>
        /// <returns></returns>
        public override IResponseMessageBase OnEvent_EnterRequest(RequestMessageEvent_Enter requestMessage)
        {
            var responseMessage = ResponseMessageBase.CreateFromRequestMessage<ResponseMessageText>(requestMessage);
            responseMessage.Content = "您刚才发送了ENTER事件请求。";
            return responseMessage;
        }

        /// <summary>
        /// 位置事件
        /// </summary>
        /// <param name="requestMessage"></param>
        /// <returns></returns>
        public override IResponseMessageBase OnEvent_LocationRequest(RequestMessageEvent_Location requestMessage)
        {
            //这里是微信客户端（通过微信服务器）自动发送过来的位置信息
            var locationService = EngineContext.Current.Resolve<IWxLocationService>();
            var currentCustomer =  _customerService.GetCustomerByOpenIdAsync(requestMessage.FromUserName).Result;

            if (currentCustomer != null)
            {
                var location =  locationService.GetLocationByCustomerIdAsync(currentCustomer.Id).Result;

                if (location != null &&
                CO2NET.Helpers.DateTimeHelper.GetUnixDateTime(requestMessage.CreateTime) - (long)location.CreateTime > 600 //10分钟内不更新
                )
                {
                    location.Latitude = Convert.ToDecimal(requestMessage.Latitude);
                    location.Longitude = Convert.ToDecimal(requestMessage.Longitude);
                    location.Precision = Convert.ToDecimal(requestMessage.Precision);
                    location.CreateTime = Convert.ToInt32(CO2NET.Helpers.DateTimeHelper.GetUnixDateTime(requestMessage.CreateTime));

                    //update
                    locationService.UpdateLocationAsync(location);
                }
                else
                {
                     locationService.InsertLocationAsync(new WxLocation
                    {
                        CustomerId = currentCustomer.Id,
                        Latitude = Convert.ToDecimal(requestMessage.Latitude),
                        Longitude = Convert.ToDecimal(requestMessage.Longitude),
                        Precision = Convert.ToDecimal(requestMessage.Precision),
                        CreateTime = Convert.ToInt32(CO2NET.Helpers.DateTimeHelper.GetUnixDateTime(requestMessage.CreateTime))
                    });
                }
            }

            return new SuccessResponseMessage();
        }

        /// <summary>
        /// 通过二维码扫描关注扫描事件
        /// </summary>
        /// <param name="requestMessage"></param>
        /// <returns></returns>
        public override IResponseMessageBase OnEvent_ScanRequest(RequestMessageEvent_Scan requestMessage)
        {
            var scenicId = 0;    //场景值：永久二维码进入=二维码ID，临时二维码进入=背景图ID
            IList<int> messageIds = new List<int>();   //多个消息ID，以二维码消息优先，覆盖背景图消息。
            IResponseMessageBase responseMessage = null; //回复消息

            var wxMessageBindService = EngineContext.Current.Resolve<IWxMessageBindService>();
            var qrcodeLimitUserService = EngineContext.Current.Resolve<IQrCodeLimitUserService>();
            var qrCodeLimitBindingSourceService = EngineContext.Current.Resolve<IQrCodeLimitBindingSourceService>();
            var supplierUserAuthorityMappingService = EngineContext.Current.Resolve<ISupplierUserAuthorityMappingService>();

            //分析二维码参数，获取sceneId和推荐人ID
            #region 分析二维码参数，获取sceneId和推荐人ID

            if (string.IsNullOrEmpty(requestMessage.EventKey))
                return new SuccessResponseMessage();

            var sceneStr = requestMessage.EventKey.Replace("qrscene_", "");

            if (string.IsNullOrEmpty(sceneStr))
                return new SuccessResponseMessage();


            //获取当前用户
            var currentCustomer = _customerService.GetCustomerByOpenIdAsync(requestMessage.FromUserName).Result;
            if (currentCustomer == null)
            {
                //新建
                _workContext.SetCustomerOpenIdAsync(requestMessage.FromUserName, currentCustomer);
            }

            //推荐用户
            Customer referrerCustomer = null;

            Nop.Services.Weixin.QrCodeSceneString.QrCodeSceneParam qrCodeSceneParam = null;
            if (sceneStr.Contains("_"))
            {
                //临时二维码
                qrCodeSceneParam = Nop.Services.Weixin.QrCodeSceneString.GetTempSceneParams(sceneStr);
                qrCodeSceneParam.IsQrCodeLimit = false;
            }
            else
            {
                //纯数字，永久二维码 传递的参数初始化基础值
                qrCodeSceneParam = new QrCodeSceneString.QrCodeSceneParam()
                {
                    SceneType = SceneType.None,
                    IsQrCodeLimit = true,
                };
            }

            //临时二维码操作
            if (!qrCodeSceneParam.IsQrCodeLimit)
            {
                //获取绑定消息
                responseMessage = GetQrCodeTempPassiveResponseMessageAsync(qrCodeSceneParam).Result;
                if (responseMessage == null)
                    messageIds = wxMessageBindService.GetMessageBindIdsAsync(scenicId, MessageBindSceneType.QrcodeTemp).Result;
            }

            //永久二维码操作
            if (qrCodeSceneParam.IsQrCodeLimit)
            {
                int.TryParse(sceneStr, out scenicId);

                if (scenicId > 0)
                {
                    //获取永久二维码绑定的用户（指推荐人）
                    var qrcodeLimitBindUser = qrcodeLimitUserService.GetActiveEntityByQrCodeLimitIdOrCustomerIdAsync(scenicId, 0).Result;
                    if (qrcodeLimitBindUser != null)
                    {
                        if (qrcodeLimitBindUser.ExpireTime > DateTime.Now)
                        {
                            //永久二维码在指定过期时间前，分配给指定用户
                            referrerCustomer = _customerService.GetCustomerByIdAsync(qrcodeLimitBindUser.CustomerId).Result;
                            if (referrerCustomer != null)
                            {
                                qrCodeSceneParam.OpenIdReferee = referrerCustomer.OpenId;
                            }
                        }
                    }

                    //获取永久二维码一对一绑定信息

                    var qrCodeLimitBindingSource = qrCodeLimitBindingSourceService.GetEntityByQrcodeLimitIdAsync(scenicId).Result;
                    if (qrCodeLimitBindingSource != null)
                    {
                        qrCodeSceneParam.SceneType = qrCodeLimitBindingSource.SceneType;

                        if (qrCodeLimitBindingSource.MessageResponse)
                            responseMessage = GetQrCodeLimitPassiveResponseMessageAsync(qrCodeLimitBindingSource).Result;

                        if (qrCodeLimitBindingSource.MessageResponse && qrCodeLimitBindingSource.UseBindingMessage)
                        {
                            //获取绑定消息
                            messageIds = wxMessageBindService.GetMessageBindIdsAsync(scenicId, MessageBindSceneType.QrcodeLimit).Result;
                        }
                    }
                }
            }

            #endregion

            //绑定推荐人信息
            if (referrerCustomer != null)
                _workContext.SetCustomerReferrerIdAsync(referrerCustomer.Id, currentCustomer);

            //更新或插入数据，判断当前用户是否已保存数据库
            #region 更新或插入数据，判断当前用户是否已保存数据库

            var currentWxUser = _wxUserService.GetWxUserByOpenIdAsync(requestMessage.FromUserName).Result;
            if (currentWxUser == null)
            {
                //本地未保存，插入
                currentWxUser = new WxUser
                {
                    CustomerId = currentCustomer.Id,
                    OpenId = requestMessage.FromUserName,
                    CheckInType = CheckInType.Subscribe,  //每个渠道不同
                    LanguageType = LanguageType.ZH_CN,
                    Sex = 0,
                    RoleType = RoleType.Visitor,
                    SceneType = SceneType.None,
                    Status = 0,
                    SupplierShopId = 0,  //需要参数传入重新赋值
                    QrScene = 0,
                    Subscribe = true,
                    AllowResponse = true,
                    AllowNotice = false,
                    AllowOrderNotice = false,
                    InBlackList = false,
                    SubscribeTime = (int)Nop.Core.Weixin.Helpers.DateTimeHelper.GetUnixDateTime(DateTime.Now),
                    UnSubscribeTime = 0,
                    UpdateTime = DateTime.Now.AddDays(-30),
                    CreatTime = DateTime.Now
                };

                //更新SceneType
                currentWxUser.SceneType = qrCodeSceneParam.SceneType;
                //更新SceneId
                int.TryParse(qrCodeSceneParam.Value, out var qrcodeTempValue);
                currentWxUser.QrScene = qrCodeSceneParam.IsQrCodeLimit ? scenicId : (1000000 + qrcodeTempValue);

                //insert
                _wxUserService.InsertWxUserAsync(currentWxUser);

            }

            //设置用户绑定供应商/店铺信息
            //是否SupplierShop员工推荐的用户，绑定用户到SupplierShop
            var supplierUserAuthorityMapping = supplierUserAuthorityMappingService.GetEntityByCustomerIdAsync(currentCustomer.ReferrerCustomerId).Result;
            if (supplierUserAuthorityMapping != null)
                currentWxUser.SupplierShopId = supplierUserAuthorityMapping.SupplierShopId ?? 0;

            //拉取用户信息
            if (currentWxUser.UpdateTime.AddMinutes(60) < DateTime.Now)
            {
                var userInfo = AdvancedAPIs.UserApi.Info(_senparcWeixinSetting.WeixinAppId, requestMessage.FromUserName);
                if (userInfo != null && userInfo.errcode == ReturnCode.请求成功)
                {
                    currentWxUser.UnionId = userInfo.unionid;
                    currentWxUser.NickName = userInfo.nickname;
                    currentWxUser.Province = userInfo.province;
                    currentWxUser.City = userInfo.city;
                    currentWxUser.Country = userInfo.country;
                    currentWxUser.HeadImgUrlShort = HeadImageUrlHelper.GetHeadImageUrlKey(userInfo.headimgurl);
                    currentWxUser.Remark = userInfo.remark;
                    currentWxUser.GroupId = userInfo.groupid.ToString();
                    currentWxUser.TagIdList = string.Join(",", userInfo.tagid_list) + (userInfo.tagid_list.Length > 0 ? "," : "");
                    currentWxUser.Sex = Convert.ToByte(userInfo.sex);
                    currentWxUser.LanguageType = Enum.TryParse(typeof(LanguageType), userInfo.language, true, out var wLanguageType) ? (LanguageType)wLanguageType : LanguageType.ZH_CN;
                    currentWxUser.SubscribeSceneType = Enum.TryParse(typeof(SubscribeSceneType), userInfo.subscribe_scene, true, out var wSubscribeSceneType) ? (SubscribeSceneType)wSubscribeSceneType : SubscribeSceneType.ADD_SCENE_OTHERS;
                    currentWxUser.UpdateTime = Nop.Core.Weixin.Helpers.DateTimeHelper.GetDateTimeFromXml(userInfo.subscribe_time);
                    currentWxUser.SubscribeTime = (int)userInfo.subscribe_time;
                }
            }


            //确保关注状态
            currentWxUser.Subscribe = true;
            //更新
            _wxUserService.UpdateWxUserAsync(currentWxUser);

            #endregion

            //处理二维码绑定的赠送卡券
            #region 处理二维码绑定的赠送卡券

            var giftCardIds = new List<int>();
            //临时二维码参数赋值操作
            if (!qrCodeSceneParam.IsQrCodeLimit && qrCodeSceneParam.SceneType == SceneType.GiftCard)
            {
                int.TryParse(qrCodeSceneParam.Value, out var giftCardId);
                if (giftCardId > 0)
                    giftCardIds.Add(giftCardId);
            }

            //永久二维码绑定的卡券ID赋值操作
            if (qrCodeSceneParam.IsQrCodeLimit)
            {
                var qrCodeSupplierVoucherCouponMappingService = EngineContext.Current.Resolve<IQrCodeSupplierVoucherCouponMappingService>();
                var qrCodeSupplierVoucherCouponMappings = qrCodeSupplierVoucherCouponMappingService.GetEntitiesByQrCodeIdAsync(scenicId, true, false).Result;
                foreach (var item in qrCodeSupplierVoucherCouponMappings)
                    giftCardIds.Add(item.SupplierVoucherCouponId);
            }
            //向扫码人后台添加对应的卡券（判断是否已经领取）,并返回回复信息
            responseMessage = GetAndSetSupplierVoucherCouponPassiveResponseMessageAsync(giftCardIds, qrCodeSceneParam, requestMessage.FromUserName).Result;

            #endregion


            //回复消息
            #region 回复消息

            if (responseMessage == null)
                responseMessage = GetResponseMessagesByIdsAsync(messageIds.ToList()).Result;

            if (responseMessage != null)
                return responseMessage;

            #endregion

            return new SuccessResponseMessage();
        }

        /// <summary>
        /// 打开网页事件
        /// </summary>
        /// <param name="requestMessage"></param>
        /// <returns></returns>
        public override IResponseMessageBase OnEvent_ViewRequest(RequestMessageEvent_View requestMessage)
        {
            //说明：这条消息只作为接收，下面的responseMessage到达不了客户端，类似OnEvent_UnsubscribeRequest
            //可以处理一些计数操作或用户状态操作
            switch (requestMessage.EventKey)
            {
                case "00":
                    break;
                default:
                    break;
            }
            return new SuccessResponseMessage();

            //var responseMessage = CreateResponseMessage<ResponseMessageText>();
            //responseMessage.Content = "您点击了view按钮，将打开网页：" + requestMessage.EventKey;
            //return responseMessage;
        }

        /// <summary>
        /// 群发完成事件
        /// </summary>
        /// <param name="requestMessage"></param>
        /// <returns></returns>
        public override IResponseMessageBase OnEvent_MassSendJobFinishRequest(RequestMessageEvent_MassSendJobFinish requestMessage)
        {
            var responseMessage = CreateResponseMessage<ResponseMessageText>();
            responseMessage.Content = "接收到了群发完成的信息。";
            return responseMessage;
        }

        /// <summary>
        /// 订阅（关注）事件
        /// </summary>
        /// <returns></returns>
        public override IResponseMessageBase OnEvent_SubscribeRequest(RequestMessageEvent_Subscribe requestMessage)
        {
            var scenicId = 0;    //场景值：永久二维码进入=二维码ID，临时二维码进入=背景图ID
            IList<int> messageIds = new List<int>();   //多个消息ID，以二维码消息优先，覆盖背景图消息。
            IResponseMessageBase responseMessage = null; //回复消息

            var wxMessageBindService = EngineContext.Current.Resolve<IWxMessageBindService>();
            var qrcodeLimitUserService = EngineContext.Current.Resolve<IQrCodeLimitUserService>();
            var qrCodeLimitBindingSourceService = EngineContext.Current.Resolve<IQrCodeLimitBindingSourceService>();
            var supplierUserAuthorityMappingService = EngineContext.Current.Resolve<ISupplierUserAuthorityMappingService>();

            //分析二维码参数，获取sceneId和推荐人ID
            #region 分析二维码参数，获取sceneId和推荐人ID

            if (string.IsNullOrEmpty(requestMessage.EventKey))
                return new SuccessResponseMessage();

            var sceneStr = requestMessage.EventKey.Replace("qrscene_", "");
            if (string.IsNullOrEmpty(sceneStr))
                return new SuccessResponseMessage();

            //获取当前用户
            var currentCustomer = _customerService.GetCustomerByOpenIdAsync(requestMessage.FromUserName).Result;
            if (currentCustomer == null)
            {
                //新建
                _workContext.SetCustomerOpenIdAsync(requestMessage.FromUserName, currentCustomer);
            }

            //推荐用户
            Customer referrerCustomer = null;

            QrCodeSceneString.QrCodeSceneParam qrCodeSceneParam;
            if (sceneStr.Contains("_"))
            {
                //临时二维码
                qrCodeSceneParam = Nop.Services.Weixin.QrCodeSceneString.GetTempSceneParams(sceneStr);
                qrCodeSceneParam.IsQrCodeLimit = false;
            }
            else
            {
                //纯数字，永久二维码 传递的参数初始化基础值
                qrCodeSceneParam = new QrCodeSceneString.QrCodeSceneParam()
                {
                    SceneType = SceneType.None,
                    IsQrCodeLimit = true,
                };
            }

            //临时二维码操作
            if (!qrCodeSceneParam.IsQrCodeLimit)
            {
                //获取绑定消息
                responseMessage = GetQrCodeTempPassiveResponseMessageAsync(qrCodeSceneParam).Result;
                if (responseMessage == null)
                    messageIds = wxMessageBindService.GetMessageBindIdsAsync(scenicId, MessageBindSceneType.QrcodeTemp).Result;
            }

            //永久二维码操作
            if (qrCodeSceneParam.IsQrCodeLimit)
            {
                int.TryParse(sceneStr, out scenicId);

                if (scenicId > 0)
                {
                    //获取永久二维码绑定的用户（指推荐人）
                    var qrcodeLimitBindUser = qrcodeLimitUserService.GetActiveEntityByQrCodeLimitIdOrCustomerIdAsync(scenicId, 0).Result;
                    if (qrcodeLimitBindUser != null)
                    {
                        if (qrcodeLimitBindUser.ExpireTime > DateTime.Now)
                        {
                            //永久二维码在指定过期时间前，分配给指定用户
                            referrerCustomer = _customerService.GetCustomerByIdAsync(qrcodeLimitBindUser.CustomerId).Result;
                            if (referrerCustomer != null)
                            {
                                qrCodeSceneParam.OpenIdReferee = referrerCustomer.OpenId;
                            }
                        }
                    }

                    //获取永久二维码一对一绑定信息

                    var qrCodeLimitBindingSource = qrCodeLimitBindingSourceService.GetEntityByQrcodeLimitIdAsync(scenicId).Result;
                    if (qrCodeLimitBindingSource != null)
                    {
                        qrCodeSceneParam.SceneType = qrCodeLimitBindingSource.SceneType;

                        if (qrCodeLimitBindingSource.MessageResponse)
                            responseMessage = GetQrCodeLimitPassiveResponseMessageAsync(qrCodeLimitBindingSource).Result;

                        if (qrCodeLimitBindingSource.MessageResponse && qrCodeLimitBindingSource.UseBindingMessage)
                        {
                            //获取绑定消息
                            messageIds = wxMessageBindService.GetMessageBindIdsAsync(scenicId, MessageBindSceneType.QrcodeLimit).Result;
                        }
                    }
                }
            }

            #endregion

            //绑定推荐人信息
            if (referrerCustomer != null)
                _workContext.SetCustomerReferrerIdAsync(referrerCustomer.Id, currentCustomer);

            // 添加/修改新用户信息
            #region // 添加/修改新用户信息

            var currentWxUser = _wxUserService.GetWxUserByOpenIdAsync(requestMessage.FromUserName).Result;
            if (currentWxUser == null)
            {
                //本地未保存，插入
                currentWxUser = new WxUser
                {
                    CustomerId = currentCustomer.Id,
                    OpenId = requestMessage.FromUserName,
                    CheckInType = CheckInType.Subscribe,  //每个渠道不同
                    LanguageType = LanguageType.ZH_CN,
                    Sex = 0,
                    RoleType = RoleType.Visitor,
                    SceneType = SceneType.None,
                    Status = 0,
                    SupplierShopId = 0,  //需要参数传入重新赋值
                    QrScene = 0,
                    Subscribe = true,
                    AllowResponse = true,
                    AllowNotice = false,
                    AllowOrderNotice = false,
                    InBlackList = false,
                    SubscribeTime = (int)Nop.Core.Weixin.Helpers.DateTimeHelper.GetUnixDateTime(DateTime.Now),
                    UnSubscribeTime = 0,
                    UpdateTime = DateTime.Now.AddDays(-30),
                    CreatTime = DateTime.Now
                };

                //insert
                _wxUserService.InsertWxUserAsync(currentWxUser);
            }


            //拉取用户信息
            if (currentWxUser.UpdateTime.AddMinutes(60) < DateTime.Now)
            {
                var userInfo = AdvancedAPIs.UserApi.Info(_senparcWeixinSetting.WeixinAppId, requestMessage.FromUserName);
                if (userInfo != null && userInfo.errcode == ReturnCode.请求成功)
                {
                    currentWxUser.UnionId = userInfo.unionid;
                    currentWxUser.NickName = userInfo.nickname;
                    currentWxUser.Province = userInfo.province;
                    currentWxUser.City = userInfo.city;
                    currentWxUser.Country = userInfo.country;
                    currentWxUser.HeadImgUrlShort = HeadImageUrlHelper.GetHeadImageUrlKey(userInfo.headimgurl);
                    currentWxUser.Remark = userInfo.remark;
                    currentWxUser.GroupId = userInfo.groupid.ToString();
                    currentWxUser.TagIdList = string.Join(",", userInfo.tagid_list) + (userInfo.tagid_list.Length > 0 ? "," : "");
                    currentWxUser.Sex = Convert.ToByte(userInfo.sex);
                    currentWxUser.LanguageType = Enum.TryParse(typeof(LanguageType), userInfo.language, true, out var wLanguageType) ? (LanguageType)wLanguageType : LanguageType.ZH_CN;
                    currentWxUser.SubscribeSceneType = Enum.TryParse(typeof(SubscribeSceneType), userInfo.subscribe_scene, true, out var wSubscribeSceneType) ? (SubscribeSceneType)wSubscribeSceneType : SubscribeSceneType.ADD_SCENE_OTHERS;
                    currentWxUser.UpdateTime = Nop.Core.Weixin.Helpers.DateTimeHelper.GetDateTimeFromXml(userInfo.subscribe_time);
                    currentWxUser.SubscribeTime = (int)userInfo.subscribe_time;
                }
            }

            //设置用户绑定供应商/店铺信息
            //是否SupplierShop员工推荐的用户，绑定用户到SupplierShop
            var supplierUserAuthorityMapping = supplierUserAuthorityMappingService.GetEntityByCustomerIdAsync(currentCustomer.ReferrerCustomerId).Result;
            if (supplierUserAuthorityMapping != null)
                currentWxUser.SupplierShopId = supplierUserAuthorityMapping.SupplierShopId ?? 0;

            //设置关注
            currentWxUser.Subscribe = true;

            //更新SceneType
            currentWxUser.SceneType = qrCodeSceneParam.SceneType;

            //更新SceneId
            int.TryParse(qrCodeSceneParam.Value, out var qrcodeTempValue);
            currentWxUser.QrScene = qrCodeSceneParam.IsQrCodeLimit ? scenicId : (1000000 + qrcodeTempValue);

            //更新
            _wxUserService.UpdateWxUserAsync(currentWxUser);

            #endregion

            //处理二维码绑定的赠送卡券
            #region 处理二维码绑定的赠送卡券

            var giftCardIds = new List<int>();
            //临时二维码参数赋值操作
            if (!qrCodeSceneParam.IsQrCodeLimit && qrCodeSceneParam.SceneType == SceneType.GiftCard)
            {
                int.TryParse(qrCodeSceneParam.Value, out var giftCardId);
                if (giftCardId > 0)
                    giftCardIds.Add(giftCardId);
            }
            //永久二维码绑定的卡券ID赋值操作
            if (qrCodeSceneParam.IsQrCodeLimit)
            {
                var qrCodeSupplierVoucherCouponMappingService = EngineContext.Current.Resolve<IQrCodeSupplierVoucherCouponMappingService>();
                var qrCodeSupplierVoucherCouponMappings = qrCodeSupplierVoucherCouponMappingService.GetEntitiesByQrCodeIdAsync(scenicId, true, false).Result;
                foreach (var item in qrCodeSupplierVoucherCouponMappings)
                    giftCardIds.Add(item.SupplierVoucherCouponId);
            }
            //向扫码人后台添加对应的卡券（判断是否已经领取）,并返回回复信息
            responseMessage = GetAndSetSupplierVoucherCouponPassiveResponseMessageAsync(giftCardIds, qrCodeSceneParam, requestMessage.FromUserName).Result;

            #endregion

            //回复消息
            #region 回复消息

            if (responseMessage == null)
                responseMessage = GetResponseMessagesByIdsAsync(messageIds.ToList()).Result;

            if (responseMessage != null)
                return responseMessage;

            #endregion

            return new SuccessResponseMessage();
        }

        /// <summary>
        /// 退订
        /// 实际上用户无法收到非订阅账号的消息，所以这里可以随便写。
        /// unsubscribe事件的意义在于及时删除网站应用中已经记录的OpenID绑定，消除冗余数据。并且关注用户流失的情况。
        /// </summary>
        /// <returns></returns>
        public override IResponseMessageBase OnEvent_UnsubscribeRequest(RequestMessageEvent_Unsubscribe requestMessage)
        {
            var currentWxUser = _wxUserService.GetWxUserByOpenIdAsync(requestMessage.FromUserName).Result;
            if (currentWxUser != null)
            {
                currentWxUser.Subscribe = false;
                currentWxUser.UnSubscribeTime = (int)Nop.Core.Weixin.Helpers.DateTimeHelper.GetUnixDateTime(requestMessage.CreateTime);

                //update
                _wxUserService.UpdateWxUserAsync(currentWxUser);

                //短时间取关，扣除用户奖励或推荐奖励
                if (currentWxUser.UnSubscribeTime - currentWxUser.SubscribeTime < 86400) //24小时=86,400秒,2天=172,800‬，3天=259,200
                {

                }
            }

            //用户无法收到非订阅账号的消息，所以这里可以随便写
            return new SuccessResponseMessage();
        }

        /// <summary>
        /// 事件之扫码推事件(scancode_push)
        /// </summary>
        /// <param name="requestMessage"></param>
        /// <returns></returns>
        public override IResponseMessageBase OnEvent_ScancodePushRequest(RequestMessageEvent_Scancode_Push requestMessage)
        {
            var responseMessage = base.CreateResponseMessage<ResponseMessageText>();
            responseMessage.Content = "事件之扫码推事件";
            return responseMessage;
        }

        /// <summary>
        /// 事件之扫码推事件且弹出“消息接收中”提示框(scancode_waitmsg)
        /// </summary>
        /// <param name="requestMessage"></param>
        /// <returns></returns>
        public override IResponseMessageBase OnEvent_ScancodeWaitmsgRequest(RequestMessageEvent_Scancode_Waitmsg requestMessage)
        {
            var responseMessage = base.CreateResponseMessage<ResponseMessageText>();
            responseMessage.Content = "事件之扫码推事件且弹出“消息接收中”提示框";
            return responseMessage;
        }

        /// <summary>
        /// 事件之弹出拍照或者相册发图（pic_photo_or_album）
        /// </summary>
        /// <param name="requestMessage"></param>
        /// <returns></returns>
        public override IResponseMessageBase OnEvent_PicPhotoOrAlbumRequest(RequestMessageEvent_Pic_Photo_Or_Album requestMessage)
        {
            var responseMessage = base.CreateResponseMessage<ResponseMessageText>();
            responseMessage.Content = "事件之弹出拍照或者相册发图";
            return responseMessage;
        }

        /// <summary>
        /// 事件之弹出系统拍照发图(pic_sysphoto)
        /// 实际测试时发现微信并没有推送RequestMessageEvent_Pic_Sysphoto消息，只能接收到用户在微信中发送的图片消息。
        /// </summary>
        /// <param name="requestMessage"></param>
        /// <returns></returns>
        public override IResponseMessageBase OnEvent_PicSysphotoRequest(RequestMessageEvent_Pic_Sysphoto requestMessage)
        {
            var responseMessage = base.CreateResponseMessage<ResponseMessageText>();
            responseMessage.Content = "事件之弹出系统拍照发图";
            return responseMessage;
        }

        /// <summary>
        /// 事件之弹出微信相册发图器(pic_weixin)
        /// </summary>
        /// <param name="requestMessage"></param>
        /// <returns></returns>
        public override IResponseMessageBase OnEvent_PicWeixinRequest(RequestMessageEvent_Pic_Weixin requestMessage)
        {
            var responseMessage = base.CreateResponseMessage<ResponseMessageText>();
            responseMessage.Content = "事件之弹出微信相册发图器";
            return responseMessage;
        }

        /// <summary>
        /// 事件之弹出地理位置选择器（location_select）
        /// </summary>
        /// <param name="requestMessage"></param>
        /// <returns></returns>
        public override IResponseMessageBase OnEvent_LocationSelectRequest(RequestMessageEvent_Location_Select requestMessage)
        {
            var responseMessage = base.CreateResponseMessage<ResponseMessageText>();
            responseMessage.Content = "事件之弹出地理位置选择器";
            return responseMessage;
        }

        #region 微信认证事件推送

        public override IResponseMessageBase OnEvent_QualificationVerifySuccessRequest(RequestMessageEvent_QualificationVerifySuccess requestMessage)
        {
            //以下方法可以强制定义返回的字符串值
            //TextResponseMessage = "your content";
            //return null;

            return new SuccessResponseMessage();//返回"success"字符串
        }

        #endregion
    }
}