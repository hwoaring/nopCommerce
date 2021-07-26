/*----------------------------------------------------------------
    Copyright (C) 2020 Senparc
    
    文件名：CustomMessageHandler_Events.cs
    文件功能描述：自定义MessageHandler
    
    
    创建标识：Senparc - 20150312
----------------------------------------------------------------*/

//DPBMARK_FILE MP
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Senparc.NeuChar.Context;
using Senparc.Weixin.Exceptions;
using Senparc.CO2NET.Extensions;
using Senparc.Weixin.HttpUtility;
using Senparc.Weixin.MP.AdvancedAPIs;
using Senparc.Weixin.MP.Entities;
using Senparc.Weixin.MP.Helpers;
using Senparc.Weixin.MP.MessageHandlers;
using Senparc.Weixin.MP.CommonService.Download;
using Senparc.Weixin.MP.CommonService.Utilities;
using Senparc.NeuChar.Entities;
using Microsoft.AspNetCore.Http;

using Nop.Core;
using Nop.Core.Infrastructure;
using Nop.Core.Domain.Customers;
using Nop.Core.Domain.Weixin;
using Nop.Core.Domain.Suppliers;
using Nop.Core.Domain.Marketing;
using Nop.Services.Weixin;
using Nop.Services.Suppliers;
using Nop.Services.Marketing;
using Nop.Services.Helpers;


namespace Senparc.Weixin.MP.CommonService.CustomMessageHandler
{
    /// <summary>
    /// 自定义MessageHandler
    /// </summary>
    public partial class CustomMessageHandler
    {
        public override Task<IResponseMessageBase> OnEvent_ClickRequestAsync(RequestMessageEvent_Click requestMessage)
        {
            return Task.Factory.StartNew<IResponseMessageBase>(() =>
            {
                var syncResponseMessage = OnEvent_ClickRequest(requestMessage);//这里为了保持Demo的连贯性，结果先从同步方法获取，实际使用过程中可以在 OnEvent_ClickRequestAsync 中全部直接定义异步方法
                //常识获取Click事件的同步方法
                if (syncResponseMessage is ResponseMessageText)
                {
                    var textResponseMessage = syncResponseMessage as ResponseMessageText;
                    textResponseMessage.Content += "\r\n\r\n  -- 来自【异步MessageHandler】的回复";
                }

                return syncResponseMessage;
            });
        }

        /// <summary>
        /// 位置事件
        /// </summary>
        /// <param name="requestMessage"></param>
        /// <returns></returns>
        public override async Task<IResponseMessageBase> OnEvent_LocationRequestAsync(RequestMessageEvent_Location requestMessage)
        {
            //这里是微信客户端（通过微信服务器）自动发送过来的位置信息
            var locationService = EngineContext.Current.Resolve<IWxLocationService>();
            var currentCustomer = await _customerService.GetCustomerByOpenIdAsync(requestMessage.FromUserName);

            if (currentCustomer != null)
            {
                var location = await locationService.GetLocationByCustomerIdAsync(currentCustomer.Id);

                if (location != null &&
                CO2NET.Helpers.DateTimeHelper.GetUnixDateTime(requestMessage.CreateTime) - (long)location.CreateTime > 600 //10分钟内不更新
                )
                {
                    location.Latitude = Convert.ToDecimal(requestMessage.Latitude);
                    location.Longitude = Convert.ToDecimal(requestMessage.Longitude);
                    location.Precision = Convert.ToDecimal(requestMessage.Precision);
                    location.CreateTime = Convert.ToInt32(CO2NET.Helpers.DateTimeHelper.GetUnixDateTime(requestMessage.CreateTime));

                    //update
                    await locationService.UpdateLocationAsync(location);
                }
                else
                {
                    await locationService.InsertLocationAsync(new WxLocation
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
        /// 通过二维码扫描关注扫描事件(用户已经关注才能有这个事件)
        /// </summary>
        /// <param name="requestMessage"></param>
        /// <returns></returns>
        public override async Task<IResponseMessageBase> OnEvent_ScanRequestAsync(RequestMessageEvent_Scan requestMessage)
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
            var currentCustomer = await _customerService.GetCustomerByOpenIdAsync(requestMessage.FromUserName);
            if (currentCustomer == null)
            {
                //新建
                await _workContext.SetCustomerOpenIdAsync(requestMessage.FromUserName, currentCustomer);
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
                responseMessage = await GetQrCodeTempPassiveResponseMessageAsync(qrCodeSceneParam);
                if (responseMessage == null)
                    messageIds = await wxMessageBindService.GetMessageBindIdsAsync(scenicId, MessageBindSceneType.QrcodeTemp);
            }

            //永久二维码操作
            if (qrCodeSceneParam.IsQrCodeLimit)
            {
                int.TryParse(sceneStr, out scenicId);

                if (scenicId > 0)
                {
                    //获取永久二维码绑定的用户（指推荐人）
                    var qrcodeLimitBindUser = await qrcodeLimitUserService.GetActiveEntityByQrCodeLimitIdOrCustomerIdAsync(scenicId, 0);
                    if (qrcodeLimitBindUser != null)
                    {
                        if (qrcodeLimitBindUser.ExpireTime > DateTime.Now)
                        {
                            //永久二维码在指定过期时间前，分配给指定用户
                            referrerCustomer = await _customerService.GetCustomerByIdAsync(qrcodeLimitBindUser.CustomerId);
                            if (referrerCustomer != null)
                            {
                                qrCodeSceneParam.OpenIdReferee = referrerCustomer.OpenId;
                            }
                        }
                    }

                    //获取永久二维码一对一绑定信息

                    var qrCodeLimitBindingSource = await qrCodeLimitBindingSourceService.GetEntityByQrcodeLimitIdAsync(scenicId);
                    if (qrCodeLimitBindingSource != null)
                    {
                        qrCodeSceneParam.SceneType = qrCodeLimitBindingSource.SceneType;

                        if (qrCodeLimitBindingSource.MessageResponse)
                            responseMessage = await GetQrCodeLimitPassiveResponseMessageAsync(qrCodeLimitBindingSource);

                        if (qrCodeLimitBindingSource.MessageResponse && qrCodeLimitBindingSource.UseBindingMessage)
                        {
                            //获取绑定消息
                            messageIds = await wxMessageBindService.GetMessageBindIdsAsync(scenicId, MessageBindSceneType.QrcodeLimit);
                        }
                    }
                }
            }

            #endregion

            //绑定推荐人信息
            if (referrerCustomer != null)
                await _workContext.SetCustomerReferrerIdAsync(referrerCustomer.Id, currentCustomer);

            //更新或插入数据，判断当前用户是否已保存数据库
            #region 更新或插入数据，判断当前用户是否已保存数据库

            var currentWxUser = await _wxUserService.GetWxUserByOpenIdAsync(requestMessage.FromUserName);
            if(currentWxUser == null)
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
                await _wxUserService.InsertWxUserAsync(currentWxUser);

            }

            //设置用户绑定供应商/店铺信息
            //是否SupplierShop员工推荐的用户，绑定用户到SupplierShop
            var supplierUserAuthorityMapping = await supplierUserAuthorityMappingService.GetEntityByCustomerIdAsync(currentCustomer.ReferrerCustomerId);
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
            await _wxUserService.UpdateWxUserAsync(currentWxUser);

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
                var qrCodeSupplierVoucherCouponMappings = await qrCodeSupplierVoucherCouponMappingService.GetEntitiesByQrCodeIdAsync(scenicId, true, false);
                foreach (var item in qrCodeSupplierVoucherCouponMappings)
                    giftCardIds.Add(item.SupplierVoucherCouponId);
            }
            //向扫码人后台添加对应的卡券（判断是否已经领取）,并返回回复信息
            responseMessage = await GetAndSetSupplierVoucherCouponPassiveResponseMessageAsync(giftCardIds, qrCodeSceneParam, requestMessage.FromUserName);

            #endregion


            //回复消息
            #region 回复消息

            if (responseMessage == null)
                responseMessage = await GetResponseMessagesByIdsAsync(messageIds.ToList());

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
        public override async Task<IResponseMessageBase> OnEvent_ViewRequestAsync(RequestMessageEvent_View requestMessage)
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
        public override async Task<IResponseMessageBase> OnEvent_MassSendJobFinishRequestAsync(RequestMessageEvent_MassSendJobFinish requestMessage)
        {
            var responseMessage = CreateResponseMessage<ResponseMessageText>();
            responseMessage.Content = "接收到了群发完成的信息。";
            return responseMessage;
        }

        /// <summary>
        /// 订阅（关注）事件
        /// </summary>
        /// <returns></returns>
        public override async Task<IResponseMessageBase> OnEvent_SubscribeRequestAsync(RequestMessageEvent_Subscribe requestMessage)
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
            var currentCustomer = await _customerService.GetCustomerByOpenIdAsync(requestMessage.FromUserName);
            if (currentCustomer == null)
            {
                //新建
                await _workContext.SetCustomerOpenIdAsync(requestMessage.FromUserName, currentCustomer);
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
                responseMessage = await GetQrCodeTempPassiveResponseMessageAsync(qrCodeSceneParam);
                if (responseMessage == null)
                    messageIds = await wxMessageBindService.GetMessageBindIdsAsync(scenicId, MessageBindSceneType.QrcodeTemp);
            }

            //永久二维码操作
            if (qrCodeSceneParam.IsQrCodeLimit)
            {
                int.TryParse(sceneStr, out scenicId);

                if (scenicId > 0)
                {
                    //获取永久二维码绑定的用户（指推荐人）
                    var qrcodeLimitBindUser = await qrcodeLimitUserService.GetActiveEntityByQrCodeLimitIdOrCustomerIdAsync(scenicId, 0);
                    if (qrcodeLimitBindUser != null)
                    {
                        if (qrcodeLimitBindUser.ExpireTime > DateTime.Now)
                        {
                            //永久二维码在指定过期时间前，分配给指定用户
                            referrerCustomer = await _customerService.GetCustomerByIdAsync(qrcodeLimitBindUser.CustomerId);
                            if (referrerCustomer != null)
                            {
                                qrCodeSceneParam.OpenIdReferee = referrerCustomer.OpenId;
                            }
                        }
                    }

                    //获取永久二维码一对一绑定信息

                    var qrCodeLimitBindingSource = await qrCodeLimitBindingSourceService.GetEntityByQrcodeLimitIdAsync(scenicId);
                    if (qrCodeLimitBindingSource != null)
                    {
                        qrCodeSceneParam.SceneType = qrCodeLimitBindingSource.SceneType;

                        if (qrCodeLimitBindingSource.MessageResponse)
                            responseMessage = await GetQrCodeLimitPassiveResponseMessageAsync(qrCodeLimitBindingSource);

                        if (qrCodeLimitBindingSource.MessageResponse && qrCodeLimitBindingSource.UseBindingMessage)
                        {
                            //获取绑定消息
                            messageIds = await wxMessageBindService.GetMessageBindIdsAsync(scenicId, MessageBindSceneType.QrcodeLimit);
                        }
                    }
                }
            }

            #endregion

            //绑定推荐人信息
            if (referrerCustomer != null)
                await _workContext.SetCustomerReferrerIdAsync(referrerCustomer.Id, currentCustomer);

            // 添加/修改新用户信息
            #region // 添加/修改新用户信息

            var currentWxUser = await _wxUserService.GetWxUserByOpenIdAsync(requestMessage.FromUserName);
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
                await _wxUserService.InsertWxUserAsync(currentWxUser);
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
            var supplierUserAuthorityMapping = await supplierUserAuthorityMappingService.GetEntityByCustomerIdAsync(currentCustomer.ReferrerCustomerId);
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
            await _wxUserService.UpdateWxUserAsync(currentWxUser);

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
                var qrCodeSupplierVoucherCouponMappings = await qrCodeSupplierVoucherCouponMappingService.GetEntitiesByQrCodeIdAsync(scenicId, true, false);
                foreach (var item in qrCodeSupplierVoucherCouponMappings)
                    giftCardIds.Add(item.SupplierVoucherCouponId);
            }
            //向扫码人后台添加对应的卡券（判断是否已经领取）,并返回回复信息
            responseMessage = await GetAndSetSupplierVoucherCouponPassiveResponseMessageAsync(giftCardIds, qrCodeSceneParam, requestMessage.FromUserName);

            #endregion

            //回复消息
            #region 回复消息

            if (responseMessage == null)
                responseMessage = await GetResponseMessagesByIdsAsync(messageIds.ToList());

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
        public override async Task<IResponseMessageBase> OnEvent_UnsubscribeRequestAsync(RequestMessageEvent_Unsubscribe requestMessage)
        {
            var currentWxUser = await _wxUserService.GetWxUserByOpenIdAsync(requestMessage.FromUserName);
            if (currentWxUser != null)
            {
                currentWxUser.Subscribe = false;
                currentWxUser.UnSubscribeTime = (int)Nop.Core.Weixin.Helpers.DateTimeHelper.GetUnixDateTime(requestMessage.CreateTime);

                //update
                await _wxUserService.UpdateWxUserAsync(currentWxUser);

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
        public override async Task<IResponseMessageBase> OnEvent_ScancodePushRequestAsync(RequestMessageEvent_Scancode_Push requestMessage)
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
        public override async Task<IResponseMessageBase> OnEvent_ScancodeWaitmsgRequestAsync(RequestMessageEvent_Scancode_Waitmsg requestMessage)
        {
            var responseMessage = base.CreateResponseMessage<ResponseMessageText>();
            responseMessage.Content = "异步：事件之扫码推事件且弹出“消息接收中”提示框";
            return responseMessage;
        }

        /// <summary>
        /// 事件之弹出拍照或者相册发图（pic_photo_or_album）
        /// </summary>
        /// <param name="requestMessage"></param>
        /// <returns></returns>
        public override async Task<IResponseMessageBase> OnEvent_PicPhotoOrAlbumRequestAsync(RequestMessageEvent_Pic_Photo_Or_Album requestMessage)
        {
            var responseMessage = base.CreateResponseMessage<ResponseMessageText>();
            responseMessage.Content = "异步：事件之弹出拍照或者相册发图";
            return responseMessage;
        }

        /// <summary>
        /// 事件之弹出系统拍照发图(pic_sysphoto)
        /// 实际测试时发现微信并没有推送RequestMessageEvent_Pic_Sysphoto消息，只能接收到用户在微信中发送的图片消息。
        /// </summary>
        /// <param name="requestMessage"></param>
        /// <returns></returns>
        public override async Task<IResponseMessageBase> OnEvent_PicSysphotoRequestAsync(RequestMessageEvent_Pic_Sysphoto requestMessage)
        {
            var responseMessage = base.CreateResponseMessage<ResponseMessageText>();
            responseMessage.Content = "异步：事件之弹出系统拍照发图";
            return responseMessage;
        }

        /// <summary>
        /// 事件之弹出微信相册发图器(pic_weixin)
        /// </summary>
        /// <param name="requestMessage"></param>
        /// <returns></returns>
        public override async Task<IResponseMessageBase> OnEvent_PicWeixinRequestAsync(RequestMessageEvent_Pic_Weixin requestMessage)
        {
            var responseMessage = base.CreateResponseMessage<ResponseMessageText>();
            responseMessage.Content = "异步：事件之弹出微信相册发图器";
            return responseMessage;
        }

        /// <summary>
        /// 事件之弹出地理位置选择器（location_select）
        /// </summary>
        /// <param name="requestMessage"></param>
        /// <returns></returns>
        public override async Task<IResponseMessageBase> OnEvent_LocationSelectRequestAsync(RequestMessageEvent_Location_Select requestMessage)
        {
            var responseMessage = base.CreateResponseMessage<ResponseMessageText>();
            responseMessage.Content = "异步：事件之弹出地理位置选择器";
            return responseMessage;
        }

        #region 微信认证事件推送

        public override async Task<IResponseMessageBase> OnEvent_QualificationVerifySuccessRequestAsync(RequestMessageEvent_QualificationVerifySuccess requestMessage)
        {
            //以下方法可以强制定义返回的字符串值
            //TextResponseMessage = "your content";
            //return null;

            return new SuccessResponseMessage();//返回"success"字符串
        }

        #endregion

        /// <summary>
        /// 【异步方法】事件之发送模板消息返回结果
        /// </summary>
        /// <param name="requestMessage"></param>
        /// <returns></returns>
        public override async Task<IResponseMessageBase> OnEvent_TemplateSendJobFinishRequestAsync(RequestMessageEvent_TemplateSendJobFinish requestMessage)
        {
            switch (requestMessage.Status)
            {
                case "success":
                    //发送成功

                    break;
                case "failed:user block":
                    //送达由于用户拒收（用户设置拒绝接收公众号消息）而失败
                    break;
                case "failed: system failed":
                    //送达由于其他原因失败
                    break;
                default:
                    throw new WeixinException("未知模板消息状态：" + requestMessage.Status);
            }

            //注意：此方法内不能再发送模板消息，否则会造成无限循环！

            try
            {
                var msg = @"已向您发送模板消息,状态：{0},MsgId：{1}（这是一条来自MessageHandler的异步客服消息）".FormatWith(requestMessage.Status, requestMessage.MsgID);
                await CustomApi.SendTextAsync(_senparcWeixinSetting.WeixinAppId, OpenId, msg);//发送客服消息
            }
            catch (Exception e)
            {
                Senparc.Weixin.WeixinTrace.SendCustomLog("模板消息发送失败", e.ToString());
            }


            //无需回复文字内容
            //return requestMessage
            //    .CreateResponseMessage<ResponseMessageNoResponse>();
            return null;
        }
    }
}