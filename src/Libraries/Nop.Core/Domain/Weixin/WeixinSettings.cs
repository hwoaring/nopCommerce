using Nop.Core.Configuration;

namespace Nop.Core.Domain.Weixin
{
    /// <summary>
    /// Weixin settings
    /// </summary>
    public class WeixinSettings : ISettings
    {
        /// <summary>
        /// 强制在微信浏览器中使用
        /// </summary>
        public bool ForcedAccessWeChatBrowser { get; set; }
        /// <summary>
        /// 是否预先检查微信浏览器
        /// </summary>
        public bool CheckWebBrowser { get; set; }

        /// <summary>
        /// 前端页面是否使用SnsapiBase模式
        /// </summary>
        public bool UseSnsapiBase { get; set; }

        /// <summary>
        /// 启用地理位置获取（常规页面）
        /// </summary>
        public bool GetLocation { get; set; }

        /// <summary>
        /// 启用页面排除（从排除表中载入排除检查微信浏览器的过程）
        /// </summary>
        public bool UseExcludePage { get; set; }

        /// <summary>
        /// 微信调试状态
        /// </summary>
        public bool Debug { get; set; }
        /// <summary>
        /// 微信日志跟踪状态
        /// </summary>
        public bool TraceLog { get; set; }
        /// <summary>
        /// JSSDK Debug 状态
        /// </summary>
        public bool JSSDKDebug { get; set; }

        /// <summary>
        /// JSSDK 注入接口的JsApiList
        /// </summary>
        public string JsApiList { get; set; }

    }
}