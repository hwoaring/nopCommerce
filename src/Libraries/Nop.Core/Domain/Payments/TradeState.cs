namespace Nop.Core.Domain.Payments;

/// <summary>
/// 交易状态
/// </summary>
public enum TradeState
{
    /// <summary>
    /// 支付成功
    /// </summary>
    SUCCESS = 1,
    /// <summary>
    /// 转入退款
    /// </summary>
    REFUND = 2,
    /// <summary>
    /// 未支付
    /// </summary>
    NOTPAY = 3,
    /// <summary>
    /// 已关闭
    /// </summary>
    CLOSED = 4,
    /// <summary>
    /// 已撤销（仅付款码支付会返回）
    /// </summary>
    REVOKED = 5,
    /// <summary>
    /// 用户支付中（仅付款码支付会返回）
    /// </summary>
    USERPAYING = 6,
    /// <summary>
    /// 支付失败（仅付款码支付会返回）
    /// </summary>
    PAYERROR = 7,
}