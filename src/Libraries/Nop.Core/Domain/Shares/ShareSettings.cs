using Nop.Core.Configuration;

namespace Nop.Core.Domain.Shares;

/// <summary>
/// 广告设置
/// </summary>
public partial class ShareSettings : ISettings
{
    /// <summary>
    /// 开启推广总开关（计算推广阅读数）
    /// </summary>
    public bool EnablePromotion { get; set; }

    /// <summary>
    /// 开启海报创建人贡献
    /// </summary>
    public bool EnableCreators { get; set; }

    /// <summary>
    /// 广告单位名称
    /// </summary>
    public string PromotionUnit { get; set; } = "推广币";

    /// <summary>
    /// 最短统计时间（秒），进入页面几秒后才计入正常阅读
    /// </summary>
    public int MinViewsTime { get; set; }

    /// <summary>
    /// 阅读数据汇总后，保存阅读详细记录时间（单位：天，0=默认90天）
    /// </summary>
    public int PageViewSaveDays { get; set; }

    /// <summary>
    /// 阅读数据结算到个人资产后，保存阅读汇总数据保存时间（单位：天，0=默认90天）
    /// </summary>
    public int PageShareSaveDays { get; set; }

    /// <summary>
    /// 单张图片最大质量（0=未设置，单位Kb）
    /// </summary>
    public int MaxPictureQuality { get; set; }

    /// <summary>
    /// 创作人最大未审核条数（限制用户攻击刷单）
    /// </summary>
    public int CreatorUnApprovedCounts { get; set; }

    /// <summary>
    /// 广告代金券结算后，有效使用时间间隔（如365天）
    /// </summary>
    public int BalanceExpireDays { get; set; }

    /// <summary>
    /// 品牌产品上架上线申请，最大未处理条数，超过条数不能提交新申请，等待处理完成后才能提交
    /// </summary>
    public int ShareProductApplyCount { get; set; }
}