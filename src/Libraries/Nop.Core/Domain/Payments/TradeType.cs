namespace Nop.Core.Domain.Payments;

/// <summary>
/// 交易类型
/// </summary>
public enum TradeType
{
    /// <summary>
    /// 公众号支付
    /// </summary>
    JSAPI = 1,
    /// <summary>
    /// 扫码支付
    /// </summary>
    NATIVE = 2,
    /// <summary>
    /// APP支付
    /// </summary>
    APP = 3,
    /// <summary>
    /// 付款码支付
    /// </summary>
    MICROPAY = 4,
    /// <summary>
    /// H5支付
    /// </summary>
    MWEB = 5,
    /// <summary>
    /// 刷脸支付
    /// </summary>
    FACEPAY = 6
}