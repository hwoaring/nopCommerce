using Nop.Core.Domain.Common;

namespace Nop.Core.Domain.AntiFake;

/// <summary>
/// 防伪现金奖励设置
/// </summary>
public partial class AntiFakeCashRewardsConfig : BaseEntity, ISoftDeletedEntity
{
    /// <summary>
    /// 所属销售公司ID
    /// </summary>
    public int AntiFakeVendorCompanyId { get; set; }

    /// <summary>
    /// 抽奖活动序列号（随机生成）
    /// </summary>
    public long CashRewardsSerialNumber { get; set; }

    /// <summary>
    /// 公证处公证书图片
    /// </summary>
    public int NotarialDeedPictureId { get; set; }

    /// <summary>
    /// 销售公司承诺书图片
    /// </summary>
    public int CommitmentPictureId { get; set; }

    /// <summary>
    /// 标题（客户不可看）
    /// </summary>
    public string Title { get; set; }

    /// <summary>
    /// 描述（备注，客户不可看）
    /// </summary>
    public string Description { get; set; }

    /// <summary>
    /// 内容（奖励内，客户可看）
    /// </summary>
    public string Content { get; set; }

    /// <summary>
    /// 奖励编码类型(1=使用防伪码密码，2=使用瓶盖内码)
    /// </summary>
    public int CashRewardsCodeType { get; set; }

    /// <summary>
    /// 奖励类型（1=现金，2=赠送某一产品）
    /// </summary>
    public int CashRewardsItemType { get; set; }

    /// <summary>
    /// 奖励产品ID
    /// </summary>
    public int RewardsProductId { get; set; }

    /// <summary>
    /// 奖励金额（只限制是导购才能领取奖励金额）
    /// </summary>
    public decimal SalesAmount { get; set; }

    /// <summary>
    /// 奖励金额（普通开瓶扫码奖励金额）
    /// </summary>
    public decimal Amount { get; set; }

    /// <summary>
    /// 奖励账户剩余金额（设置时候账户必须有金额）
    /// </summary>
    public decimal BalanceAmount { get; set; }

    /// <summary>
    /// 现金奖励可提现（不可提现时，奖金使用限制到该单品）
    /// </summary>
    public bool EnableWithdrawal { get; set; }

    /// <summary>
    /// 绑定确认时间（确认后不可取消）
    /// </summary>
    public DateTime? ConfirmDateUtc { get; set; }

    /// <summary>
    /// 奖励开始时间
    /// </summary>
    public DateTime? StartDateUtc { get; set; }

    /// <summary>
    /// 奖励结束时间
    /// </summary>
    public DateTime? EndDateUtc { get; set; }

    /// <summary>
    /// 创建时间
    /// </summary>
    public DateTime CreatDateUtc { get; set; }

    /// <summary>
    /// 系统控制（临时中止或暂停原因）
    /// </summary>
    public string Message { get; set; }

    /// <summary>
    /// 是否暂停（系统控制）
    /// </summary>
    public bool Suspended { get; set; }

    /// <summary>
    /// 是否激活（系统控制）
    /// </summary>
    public bool Actived { get; set; }

    /// <summary>
    /// 删除
    /// </summary>
    public bool Deleted { get; set; }
}
