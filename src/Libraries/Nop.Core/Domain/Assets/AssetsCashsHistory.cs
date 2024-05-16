﻿using Nop.Core.Domain.Common;

namespace Nop.Core.Domain.Assets;

/// <summary>
/// 个人（现金资产）
/// </summary>
public partial class AssetsCashsHistory : BaseEntity, ISoftDeletedEntity
{
    /// <summary>
    /// 主卡ID号
    /// </summary>
    public int AssetsCashsId { get; set; }

    /// <summary>
    /// 系统现金结算流水号（本系统内）
    /// </summary>
    public long SerialNumber { get; set; }

    /// <summary>
    /// 操作员ID
    /// </summary>
    public int OperatorCustomerId { get; set; }

    /// <summary>
    /// 创建方式
    /// </summary>
    public int AssetsCreatedTypeId { get; set; }

    /// <summary>
    /// 交易平台：微信，支付宝，银行卡，现金
    /// </summary>
    public int AssetsPaymentPlatformTypeId { get; set; }

    /// <summary>
    /// 是否可退款（提现）如果提现，只能原路返回
    ///（特殊用图现金不可提现，只能平台使用，比如充值等，防止非法刷单套现）
    /// </summary>
    public bool WithdrawalEnable { get; set; }

    /// <summary>
    /// 是否收入（收支标识：收入还是支出）
    /// </summary>
    public bool IsIncome { get; set; }

    /// <summary>
    /// 收入金额
    /// </summary>
    public decimal IncomeAmounts { get; set; }

    /// <summary>
    /// 支出金额
    /// </summary>
    public decimal ExpendAmounts { get; set; }

    /// <summary>
    /// 当前余额
    /// </summary>
    public decimal Amounts { get; set; }

    /// <summary>
    /// 通过哪个订单创建/或消费
    /// </summary>
    public Guid? CreatedWithOrder { get; set; }

    /// <summary>
    /// 对方银行代码（银行代码ICBC，ABC，WECHAT，ALIPAY等）
    /// </summary>
    public string BankCode { get; set; }

    /// <summary>
    /// 对方银行行号
    /// </summary>
    public string BankNumber { get; set; }

    /// <summary>
    /// 对方账号（银行账号或支付宝、微信账号，数字账号或邮箱）
    /// </summary>
    public string BankAccount { get; set; }

    /// <summary>
    /// 对方名称/单位名称
    /// </summary>
    public string PayeeName { get; set; }

    /// <summary>
    /// 对方交易流水号（第三方交易流水号）
    /// </summary>
    public string PayeeSerialNumber { get; set; }

    /// <summary>
    /// 摘要
    /// </summary>
    public string Remark { get; set; }

    /// <summary>
    /// 用途
    /// </summary>
    public string Purpose { get; set; }

    /// <summary>
    /// 个性化信息
    /// </summary>
    public string Message { get; set; }

    /// <summary>
    /// hash值，校验码，验证码本条数据的：收入+消费+余额+生成日期的hash值，避免人为修改数据
    /// 收入+消费+余额+生成日期等生产的hash值（校验规则暂未定）
    /// </summary>
    public string HashCode { get; set; }

    /// <summary>
    /// 创建时间/交易时间
    /// </summary>
    public DateTime CreatedOnUtc { get; set; }

    /// <summary>
    /// 锁定原因备注
    /// </summary>
    public string LockRemark { get; set; }

    /// <summary>
    /// 是否锁定
    /// </summary>
    public bool Locked { get; set; }

    /// <summary>
    /// 删除
    /// </summary>
    public bool Deleted { get; set; }

}
