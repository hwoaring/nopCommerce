using Nop.Core.Domain.Common;

namespace Nop.Core.Domain.AntiFake;

/// <summary>
/// 奖励领取黑名单
/// </summary>
public partial class AntiFakeRewardsBlackList : BaseEntity
{
    /// <summary>
    /// 产品ID（ID=0时，所有产品加入黑名单）
    /// </summary>
    public int AntiFakeProductId { get; set; }

    /// <summary>
    /// 用户ID
    /// </summary>
    public int CustomerId { get; set; }

}
