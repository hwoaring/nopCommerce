using Nop.Web.Framework.Models;
using Nop.Web.Framework.Mvc.ModelBinding;

namespace Nop.Web.Areas.Admin.Models.Settings;

/// <summary>
/// 微信设置
/// </summary>
public partial record WeixinSettingsModel : BaseNopModel, ISettingsModel
{
    #region Properties

    public int ActiveStoreScopeConfiguration { get; set; }

    [NopResourceDisplayName("Admin.Configuration.Settings.Weixin.WeChatOAuthEnable")]
    public bool WeChatOAuthEnable { get; set; }

    [NopResourceDisplayName("Admin.Configuration.Settings.Weixin.CheckWeChatBrowser")]
    public bool CheckWeChatBrowser { get; set; }

    [NopResourceDisplayName("Admin.Configuration.Settings.Weixin.PublicPageUseSnsapiBase")]
    public bool PublicPageUseSnsapiBase { get; set; }

    [NopResourceDisplayName("Admin.Configuration.Settings.Weixin.GetLocation")]
    public bool GetLocation { get; set; }

    [NopResourceDisplayName("Admin.Configuration.Settings.Weixin.UseExcludePage")]
    public bool UseExcludePage { get; set; }

    [NopResourceDisplayName("Admin.Configuration.Settings.Weixin.Debug")]
    public bool Debug { get; set; }

    [NopResourceDisplayName("Admin.Configuration.Settings.Weixin.EnableRequestLog")]
    public bool EnableRequestLog { get; set; }

    [NopResourceDisplayName("Admin.Configuration.Settings.Weixin.EnbleResponseLog")]
    public bool EnbleResponseLog { get; set; }

    [NopResourceDisplayName("Admin.Configuration.Settings.Weixin.SaveRequestMessageLog")]
    public bool SaveRequestMessageLog { get; set; }

    [NopResourceDisplayName("Admin.Configuration.Settings.Weixin.SaveResponseMessageLog")]
    public bool SaveResponseMessageLog { get; set; }

    [NopResourceDisplayName("Admin.Configuration.Settings.Weixin.TraceLog")]
    public bool TraceLog { get; set; }

    [NopResourceDisplayName("Admin.Configuration.Settings.Weixin.JSSDKDebug")]
    public bool JSSDKDebug { get; set; }

    [NopResourceDisplayName("Admin.Configuration.Settings.Weixin.JsApiList")]
    public string JsApiList { get; set; }

    #endregion
}