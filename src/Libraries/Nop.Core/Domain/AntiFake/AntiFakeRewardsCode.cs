using Nop.Core.Domain.Common;

namespace Nop.Core.Domain.AntiFake;

/// <summary>
/// 防伪码（小码或盖内码）奖金（或产品）详细信息
/// </summary>
public partial class AntiFakeRewardsCode : BaseEntity, ISoftDeletedEntity
{
    /// <summary>
    /// 奖励设置AntiFakeRewardsConfig的ID
    /// </summary>
    public int AntiFakeRewardsConfigId { get; set; }

    /// <summary>
    /// 奖励绑定的密码：
    /// 以4开头的瓶盖内码
    /// 或以8开头的小码密码
    /// </summary>
    public long RewardsCode { get; set; }

    /// <summary>
    /// 条码类型：
    /// 8=防伪小码密码
    /// 4=瓶盖码（内）
    /// </summary>
    public int RewardsCodeType { get; set; }

    /// <summary>
    /// 总金额或总数量
    /// </summary>
    public decimal TotalAmount { get; set; }

    /// <summary>
    /// 已领取的金额或数量
    /// </summary>
    public decimal PaidAmount { get; set; }

    /// <summary>
    /// 可以领取总次数
    /// </summary>
    public int TotalCounts { get; set; }

    /// <summary>
    /// 已领取次数
    /// </summary>
    public int PaidCounts { get; set; }

    /// <summary>
    /// 已经拆分的金额数组，以逗号分开
    /// 拆分方式分为：随机和均分，各数量以逗号分开
    /// </summary>
    public string SplitedAmount { get; set; }

    /// <summary>
    /// 关键信息校验码
    /// （对应编码编号+奖励类型+产品ID+金额）
    /// </summary>
    public string HashCode { get; set; }

    /// <summary>
    /// 是否现金奖励（直接发送到微信钱包）
    /// 否则都是发送到个人卡券中（现金抵用券，产品兑换券等）
    /// </summary>
    public bool CashRewards { get; set; }

    /// <summary>
    /// 是否可用(可以指定批次或某个代理激活使用)
    /// </summary>
    public bool Actived { get; set; }

    /// <summary>
    /// 删除
    /// </summary>
    public bool Deleted { get; set; }
}
