using Nop.Core.Domain.Common;

namespace Nop.Core.Domain.Assets;

/// <summary>
/// 现金主卡账号信息
/// </summary>
public partial class AssetsCashs : BaseEntity, ISoftDeletedEntity
{
    /// <summary>
    /// 备用
    /// </summary>
    public int StoreId { get; set; }

    /// <summary>
    /// 对应人员ID（私人个人账户号）
    /// </summary>
    public int CustomerId { get; set; }

    /// <summary>
    /// 绑定的提现账号
    /// </summary>
    public int AssetsBankAccountId { get; set; }

    /// <summary>
    /// 本系统内的卡号信息
    /// </summary>
    public string CardNumber { get; set; }

    /// <summary>
    /// 余额
    /// </summary>
    public decimal Amounts { get; set; }

    /// <summary>
    /// 锁定的金额（不可使用，不可提现）
    /// </summary>
    public decimal LockedAmounts { get; set; }

    /// <summary>
    /// 保证金
    /// </summary>
    public decimal DepositAmounts { get; set; }

    /// <summary>
    /// 备注信息
    /// </summary>
    public string Remarks { get; set; }

    /// <summary>
    /// hash值
    /// </summary>
    public string HashCode { get; set; }

    /// <summary>
    /// 账户等级或星级（备用）
    /// </summary>
    public int Level { get; set; }

    /// <summary>
    /// 账户状态
    /// </summary>
    public bool Status { get; set; }

    /// <summary>
    /// 删除
    /// </summary>
    public bool Deleted { get; set; }

}
