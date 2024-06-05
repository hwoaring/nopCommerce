using Nop.Core.Domain.Common;

namespace Nop.Core.Domain.Assets;

/// <summary>
/// 公司或个人结算提现账号管理(需要实名绑定，防止刷单)
/// </summary>
public partial class AssetsBankAccount : BaseEntity
{
    /// <summary>
    /// 对应的系统现金账户ID
    /// </summary>
    public int AssetsCashsId { get; set; }

    /// <summary>
    /// 个人银行代码（银行代码ICBC，ABC，WECHAT，ALIPAY等）
    /// </summary>
    public string BankCode { get; set; }

    /// <summary>
    /// 银行行号（备用）
    /// </summary>
    public string BankNumber { get; set; }

    /// <summary>
    /// 个人账号（银行账号，支付宝、微信账号，可以是数字账号或者邮箱）
    /// </summary>
    public string BankAccount { get; set; }

    /// <summary>
    /// 个人账号名称/单位名称
    /// </summary>
    public string BankAccountName { get; set; }

    /// <summary>
    /// hash值，校验码，验证码本条数据的：收入+消费+余额+生成日期的hash值，避免人为修改数据
    /// 收入+消费+余额+生成日期等生产的hash值（校验规则暂未定）
    /// </summary>
    public string HashCode { get; set; }

    /// <summary>
    /// 摘要
    /// </summary>
    public string Remark { get; set; }

    /// <summary>
    /// 银行账号验证金额（向对方打款几分）
    /// </summary>
    public decimal BankVerifyAmount { get; set; }

    /// <summary>
    /// 银行是否验证
    /// </summary>
    public bool BankVerified { get; set; }

    /// <summary>
    /// 验证时间
    /// </summary>
    public DateTime? VerifiedOnUtc { get; set; }

    /// <summary>
    /// 创建时间/交易时间
    /// </summary>
    public DateTime CreatedOnUtc { get; set; }
}
