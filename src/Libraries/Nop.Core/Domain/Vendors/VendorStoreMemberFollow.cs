namespace Nop.Core.Domain.Vendors;

/// <summary>
/// 店铺对会员的回访记录
/// </summary>
public partial class VendorStoreMemberFollow : BaseEntity
{
    /// <summary>
    /// 会员信息ID（外键）
    /// </summary>
    public int VendorStoreMemberId { get; set; }

    /// <summary>
    /// 回访人ID（当前客服ID）
    /// </summary>
    public int FollowCustomerId { get; set; }

    /// <summary>
    /// 回访沟通内容
    /// </summary>
    public string Content { get; set; }

    /// <summary>
    /// 沟通效果评价（1-5）
    /// </summary>
    public int EffectLevel { get; set; }

    /// <summary>
    /// 对方是否回复
    /// </summary>
    public bool Replyed { get; set; }

    /// <summary>
    /// 下次回访时间
    /// </summary>
    public DateTime? NextVisitDateUtc { get; set; }

    /// <summary>
    /// 回访时间
    /// </summary>
    public DateTime? VisitDateUtc { get; set; }

    /// <summary>
    /// 创建时间
    /// </summary>
    public DateTime CreatOnUtc { get; set; }

}
