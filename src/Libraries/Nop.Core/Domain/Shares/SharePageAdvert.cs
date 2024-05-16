using Nop.Core.Domain.Common;
namespace Nop.Core.Domain.Shares;

/// <summary>
/// 用户创建分享页的现金广告
/// </summary>
public partial class SharePageAdvert : BaseEntity, ISoftDeletedEntity
{
    /// <summary>
    /// SharePage的ID
    /// </summary>
    public int SharePageId { get; set; }

    /// <summary>
    /// 广告创建人
    /// </summary>
    public int CustomerId { get; set; }

    /// <summary>
    /// 浏览计数比：访客浏览一次计算多少现金比例
    /// （任何一个人阅读获得的金额）
    /// </summary>
    public decimal CashCommissionRatio { get; set; }

    /// <summary>
    /// 限定区域内发布有效
    /// </summary>
    public bool EnablePublishArea { get; set; }

    /// <summary>
    /// 限定区域设置
    /// </summary>
    public string PublishArea { get; set; }

    /// <summary>
    /// 设置最大消费金额（只能预估，以实际消费为准）
    /// </summary>
    public decimal MaxAmounts { get; set; }

    /// <summary>
    /// 公开展示结束日期
    /// </summary>
    public DateTime? EndDateOnUtc { get; set; }

    /// <summary>
    /// 创建日期
    /// </summary>
    public DateTime CreatedOnUtc { get; set; }

    /// <summary>
    /// 删除
    /// </summary>
    public bool Deleted { get; set; }

}
