namespace Nop.Core.Domain.Shares;

/// <summary>
/// 自定义分享场景（用于统计个人或者Vendor的二维码宣传场景，区分渠道）
/// </summary>
public partial class ShareScene : BaseEntity
{
    /// <summary>
    /// Customer Id
    /// </summary>
    public int CustomerId { get; set; }

    /// <summary>
    /// 是否绑定到Vendor
    /// </summary>
    public int VendorId { get; set; }

    /// <summary>
    /// 场景名称
    /// </summary>
    public string Name { get; set; }

    /// <summary>
    /// 场景值（主要用于指定场景用户的邀请码等）
    /// </summary>
    public long Value { get; set; }

    /// <summary>
    /// 场景值（备用）
    /// </summary>
    public string StrValue { get; set; }
}
