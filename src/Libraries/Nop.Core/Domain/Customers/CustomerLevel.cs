using Nop.Core.Domain.Common;

namespace Nop.Core.Domain.Customers;

/// <summary>
/// 用户的全局等级
/// </summary>
public partial class CustomerLevel : BaseEntity
{
    /// <summary>
    /// 备用
    /// </summary>
    public int StoreId { get; set; }

    /// <summary>
    /// 用户ID
    /// </summary>
    public int CustomerId { get; set; }

    /// <summary>
    /// 用户当前等级
    /// </summary>
    public int Level { get; set; }

    /// <summary>
    /// 用户最高等级（记录用户曾经最高达到的等级）
    /// </summary>
    public int MaxLevel { get; set; }

    /// <summary>
    /// 基础VIP过期时间（过期后需重新购买会员卡或充值）
    /// </summary>
    public DateTime? ExpireTimeOnUtc { get; set; }

    /// <summary>
    /// 最后升级时间
    /// </summary>
    public DateTime? UpgradeTimeOnUtc { get; set; }

    /// <summary>
    /// 是否用户有升级申请
    /// </summary>
    public bool UpgradeApplication { get; set; }

}