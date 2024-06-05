using Nop.Core.Domain.Common;

namespace Nop.Core.Domain.AntiFake;

/// <summary>
/// 瓶盖内码验证，代理商/销售商验证数量后可兑换指定的产品
/// </summary>
public partial class AntiFakeExchangeCode : BaseEntity
{
    /// <summary>
    /// 奖励设置AntiFakeExchangeConfig的ID
    /// </summary>
    public int AntiFakeExchangeConfigId { get; set; }

    /// <summary>
    /// 奖励绑定的密码：
    /// 以4开头的瓶盖内码
    /// </summary>
    public long RewardsCode { get; set; }

    /// <summary>
    /// 扫码验证的代理商ID
    /// </summary>
    public int VendorId { get; set; }

    /// <summary>
    /// 领取人ID
    /// </summary>
    public int ReceiveCustomerId { get; set; }

    /// <summary>
    /// 兑换日期（代理商满足兑换数量时，点击确认兑换的时间）
    /// </summary>
    public DateTime? ExchangedDateOnUtc { get; set; }

    /// <summary>
    /// 物品是否已兑换
    /// </summary>
    public bool Exchanged { get; set; }

    /// <summary>
    /// 瓶盖是否已回收
    /// </summary>
    public bool Recoveryed { get; set; }

    /// <summary>
    /// 是否可用
    /// </summary>
    public bool Actived { get; set; }
}
