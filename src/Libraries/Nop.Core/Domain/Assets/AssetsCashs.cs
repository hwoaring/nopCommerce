﻿using Nop.Core.Domain.Common;

namespace Nop.Core.Domain.Assets;

/// <summary>
/// 现金卡账号信息
/// </summary>
public partial class AssetsCashs : BaseEntity, ISoftDeletedEntity
{
    /// <summary>
    /// 备用
    /// </summary>
    public int StoreId { get; set; }

    /// <summary>
    /// 创建人，拥有人（私人个人账户号）
    /// 私人账户只能有一个
    /// </summary>
    public int CustomerId { get; set; }

    /// <summary>
    /// 是否Vendor现金账户（如果是）
    /// Vendor账户只能有一个。
    /// 一个Customer只能有一个私人账户和一个Vendor账户。
    /// Customer表中映射了同一个Vendor时，映射的人都能看到这个Vendor的账户信息。
    /// </summary>
    public bool IsVendorAccount { get; set; }

    /// <summary>
    /// 如果是Vendor账户，绑定VendorId
    /// </summary>
    public int VendorId { get; set; }

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
    /// 是否使用短信随机密码（可以不设置支付密码，由绑定的手机号获取短信随机密码，密码只能使用一次）
    /// </summary>
    public bool SMSRandomPassword { get; set; }

    /// <summary>
    /// 支付密码（并非银行等支付密码，设置密码时候明确告知用户）
    /// </summary>
    public string Password { get; set; }

    /// <summary>
    /// 账户等级或星级，针对整个系统的等级（备用）
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
