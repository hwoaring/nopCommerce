using Senparc.Weixin.MP.Helpers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Nop.Core.Domain.Weixins;
using Senparc.CO2NET;
using Senparc.Weixin.Entities;
using Nop.Core;

namespace Senparc.Weixin.CommonService.Controllers;

/// <summary>
/// JSSDK
/// </summary>
public partial class WeixinJSSDKController : WeixinBaseController
{
    #region Fields

    protected readonly SenparcSetting _senparcSetting;
    protected readonly SenparcWeixinSetting _senparcWeixinSetting;
    protected readonly WeixinSettings _weixinSettings;
    protected readonly WebHelper _webHelper;

    #endregion

    #region Ctor

    public WeixinJSSDKController(SenparcSetting senparcSetting,
        SenparcWeixinSetting senparcWeixinSetting,
        WeixinSettings weixinSettings,
        WebHelper webHelper)
    {
        _senparcSetting = senparcSetting;
        _senparcWeixinSetting = senparcWeixinSetting;
        _weixinSettings = weixinSettings;
        _webHelper = webHelper;
    }

    #endregion

    public virtual async Task<IActionResult> Index()
    {
        var jssdkUiPackage = await JSSDKHelper.GetJsSdkUiPackageAsync(_senparcWeixinSetting.WeixinAppId, _senparcWeixinSetting.WeixinAppSecret, Request.AbsoluteUri());
        //ViewData["JsSdkUiPackage"] = jssdkUiPackage;
        //ViewData["AppId"] = appId;
        //ViewData["Timestamp"] = jssdkUiPackage.Timestamp;
        //ViewData["NonceStr"] = jssdkUiPackage.NonceStr;
        //ViewData["Signature"] = jssdkUiPackage.Signature;

        //wx.config({
        //    debug: true, // 开启调试模式,调用的所有api的返回值会在客户端alert出来，若要查看传入的参数，可以在pc端打开，参数信息会通过log打出，仅在pc端时才会打印。
        //    appId: '', // 必填，公众号的唯一标识
        //    timestamp: , // 必填，生成签名的时间戳
        //    nonceStr: '', // 必填，生成签名的随机串
        //    signature: '',// 必填，签名
        //    jsApiList: [] // 必填，需要使用的JS接口列表
        //  });

        //是否调试状态
        var jSSDKDebug = _weixinSettings.JSSDKDebug;

        //JS接口列表值
        var jsApiList = _weixinSettings.JsApiList;

        //return Json(new { Result = true, Url = _webHelper.GetThisPageUrl(true), JssdkPackage = jssdkUiPackage });
        return View(jssdkUiPackage);
    }
}
