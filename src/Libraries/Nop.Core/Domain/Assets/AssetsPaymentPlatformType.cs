namespace Nop.Core.Domain.Assets;

/// <summary>
/// 支付平台
/// </summary>
public enum AssetsPaymentPlatformType
{
    /// <summary>
    /// 微信支付
    /// </summary>
    WeChat = 1,

    /// <summary>
    /// 支付宝
    /// </summary>
    Alipay = 2,

    /// <summary>
    /// 银行卡
    /// </summary>
    BankCard = 3,

    /// <summary>
    /// 信用卡
    /// </summary>
    CreditCard = 4,

    /// <summary>
    /// 现金
    /// </summary>
    Cash = 5,
}
