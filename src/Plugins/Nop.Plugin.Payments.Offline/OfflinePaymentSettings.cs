using Nop.Core.Configuration;

namespace Nop.Plugin.Payments.Offline
{
    /// <summary>
    /// Represents settings of "Offline" payment plugin
    /// </summary>
    public class OfflinePaymentSettings : ISettings
    {
        /// <summary>
        /// Gets or sets a description text
        /// </summary>
        public string DescriptionText { get; set; }
        /// <summary>
        /// 微信支付信息
        /// </summary>
        public string WechatPaymentInfo { get; set; }
        /// <summary>
        /// 支付宝支付信息
        /// </summary>
        public string AlipayPaymentInfo { get; set; }
        /// <summary>
        /// 银行转账支付信息
        /// </summary>
        public string BankCardPaymentInfo { get; set; }
        /// <summary>
        /// Gets or sets a value indicating whether to "additional fee" is specified as percentage. true - percentage, false - fixed value.
        /// </summary>
        public bool AdditionalFeePercentage { get; set; }

        /// <summary>
        /// Gets or sets an additional fee
        /// </summary>
        public decimal AdditionalFee { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether shippable products are required in order to display this payment method during checkout
        /// </summary>
        public bool ShippableProductRequired { get; set; }
    }
}
