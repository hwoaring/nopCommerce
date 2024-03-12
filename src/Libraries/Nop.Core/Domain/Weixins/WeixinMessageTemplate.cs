using Nop.Core.Domain.Common;
using Nop.Core.Domain.Localization;
using Nop.Core.Domain.Seo;

namespace Nop.Core.Domain.Weixins;

/// <summary>
/// 微信模板消息
/// </summary>
public partial class WeixinMessageTemplate : BaseEntity
{
    /// <summary>
    /// 站点ID（区分公众号）
    /// </summary>
    public int StoreId { get; set; }

    /// <summary>
    /// 公众号平台的模板ID
    /// </summary>
    public string TemplateId { get; set; }

    /// <summary>
    /// 标题
    /// </summary>
    public string Title { get; set; }

    /// <summary>
    /// 账号设置的主营行业
    /// </summary>
    public string PrimaryIndustry { get; set; }

    /// <summary>
    /// 账号设置的副营行业
    /// </summary>
    public string DeputyIndustry { get; set; }

    /// <summary>
    /// 内容
    /// </summary>
    public string Content { get; set; }

    /// <summary>
    /// 示例
    /// </summary>
    public string Example { get; set; }

    /// <summary>
    /// 跳转链接
    /// </summary>
    public string Url { get; set; }

    /// <summary>
    /// 所需跳转到的小程序appid（该小程序appid必须与发模板消息的公众号是绑定关联关系，暂不支持小游戏）
    /// </summary>
    public string AppId { get; set; }

    /// <summary>
    /// 所需跳转到小程序的具体页面路径，支持带参数,（示例index?foo=bar），要求该小程序已发布，暂不支持小游戏
    /// </summary>
    public string PagePath { get; set; }
}
