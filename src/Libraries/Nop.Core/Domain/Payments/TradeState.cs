namespace Nop.Core.Domain.Payments;

/// <summary>
/// 交易状态
/// </summary>
public enum TradeState
{
    /// <summary>
    /// 支付成功
    /// </summary>
    SUCCESS = 10,
    /// <summary>
    /// 转入退款
    /// </summary>
    REFUND = 20,
    /// <summary>
    /// 未支付
    /// </summary>
    NOTPAY = 30,
    /// <summary>
    /// 已关闭
    /// </summary>
    CLOSED = 40,
    /// <summary>
    /// 已撤销（仅付款码支付会返回）
    /// </summary>
    REVOKED = 50,
    /// <summary>
    /// 用户支付中（仅付款码支付会返回）
    /// </summary>
    USERPAYING = 60,
    /// <summary>
    /// 支付失败（仅付款码支付会返回）
    /// </summary>
    PAYERROR = 70,
}