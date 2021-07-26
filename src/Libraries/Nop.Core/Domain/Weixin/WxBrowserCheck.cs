namespace Nop.Core.Domain.Weixin
{
    /// <summary>
    /// Represents an 微信浏览器页面检查排除页面
    /// </summary>
    public partial class WxBrowserCheck : BaseEntity
    {
        /// <summary>
        /// 要排除页面的链接（排除检查或者需要检查的页面），当启用页面检查时候，这里是排除检查
        /// </summary>
        public string Url { get; set; }

        /// <summary>
        /// 是否包含匹配，否则完全匹配
        /// </summary>
        public bool ContainPattern { get; set; }

        /// <summary>
        /// 是否发布
        /// </summary>
        public bool Published { get; set; }

    }
}
