using Humanizer;
using Nop.Core.Domain.Common;
using Nop.Core.Domain.Payments;
using Nop.Core.Domain.Shipping;
using Nop.Core.Domain.Tax;

namespace Nop.Core.Domain.Orders;

/// <summary>
/// Represents an order
/// </summary>
public partial class Order : BaseEntity, ISoftDeletedEntity
{
    #region Properties

    /// <summary>
    /// Gets or sets the order identifier
    /// </summary>
    public Guid OrderGuid { get; set; }

    /// <summary>
    /// Gets or sets the store identifier
    /// </summary>
    public int StoreId { get; set; }

    /// <summary>
    /// Gets or sets the customer identifier
    /// </summary>
    public int CustomerId { get; set; }

    /// <summary>
    /// Gets or sets the billing address identifier
    /// </summary>
    public int BillingAddressId { get; set; }

    /// <summary>
    /// Gets or sets the shipping address identifier
    /// </summary>
    public int? ShippingAddressId { get; set; }

    /// <summary>
    /// Gets or sets the pickup address identifier
    /// </summary>
    public int? PickupAddressId { get; set; }

    /// <summary>
    /// Gets or sets a value indicating whether a customer chose "pick up in store" shipping option
    /// </summary>
    public bool PickupInStore { get; set; }

    /// <summary>
    /// Gets or sets an order status identifier
    /// </summary>
    public int OrderStatusId { get; set; }

    /// <summary>
    /// Gets or sets the shipping status identifier
    /// </summary>
    public int ShippingStatusId { get; set; }

    /// <summary>
    /// Gets or sets the payment status identifier
    /// </summary>
    public int PaymentStatusId { get; set; }

    /// <summary>
    /// Gets or sets the payment method system name
    /// </summary>
    public string PaymentMethodSystemName { get; set; }

    /// <summary>
    /// Gets or sets the customer currency code (at the moment of order placing)
    /// </summary>
    public string CustomerCurrencyCode { get; set; }

    /// <summary>
    /// Gets or sets the currency rate
    /// </summary>
    public decimal CurrencyRate { get; set; }

    /// <summary>
    /// Gets or sets the customer tax display type identifier
    /// </summary>
    public int CustomerTaxDisplayTypeId { get; set; }

    /// <summary>
    /// Gets or sets the VAT number (the European Union Value Added Tax)
    /// </summary>
    public string VatNumber { get; set; }

    /// <summary>
    /// Gets or sets the order subtotal (include tax)
    /// </summary>
    public decimal OrderSubtotalInclTax { get; set; }

    /// <summary>
    /// Gets or sets the order subtotal (exclude tax)
    /// </summary>
    public decimal OrderSubtotalExclTax { get; set; }

    /// <summary>
    /// Gets or sets the order subtotal discount (include tax)
    /// </summary>
    public decimal OrderSubTotalDiscountInclTax { get; set; }

    /// <summary>
    /// Gets or sets the order subtotal discount (exclude tax)
    /// </summary>
    public decimal OrderSubTotalDiscountExclTax { get; set; }

    /// <summary>
    /// Gets or sets the order shipping (include tax)
    /// </summary>
    public decimal OrderShippingInclTax { get; set; }

    /// <summary>
    /// Gets or sets the order shipping (exclude tax)
    /// </summary>
    public decimal OrderShippingExclTax { get; set; }

    /// <summary>
    /// Gets or sets the payment method additional fee (incl tax)
    /// </summary>
    public decimal PaymentMethodAdditionalFeeInclTax { get; set; }

    /// <summary>
    /// Gets or sets the payment method additional fee (exclude tax)
    /// </summary>
    public decimal PaymentMethodAdditionalFeeExclTax { get; set; }

    /// <summary>
    /// Gets or sets the tax rates
    /// </summary>
    public string TaxRates { get; set; }

    /// <summary>
    /// Gets or sets the order tax
    /// </summary>
    public decimal OrderTax { get; set; }

    /// <summary>
    /// Gets or sets the order discount (applied to order total)
    /// </summary>
    public decimal OrderDiscount { get; set; }

    /// <summary>
    /// Gets or sets the order total
    /// </summary>
    public decimal OrderTotal { get; set; }

    /// <summary>
    /// Gets or sets the refunded amount
    /// </summary>
    public decimal RefundedAmount { get; set; }

    /// <summary>
    /// Gets or sets the reward points history entry identifier when reward points were earned (gained) for placing this order
    /// </summary>
    public int? RewardPointsHistoryEntryId { get; set; }

    /// <summary>
    /// Gets or sets the checkout attribute description
    /// </summary>
    public string CheckoutAttributeDescription { get; set; }

    /// <summary>
    /// Gets or sets the checkout attributes in XML format
    /// </summary>
    public string CheckoutAttributesXml { get; set; }

    /// <summary>
    /// Gets or sets the customer language identifier
    /// </summary>
    public int CustomerLanguageId { get; set; }

    /// <summary>
    /// Gets or sets the affiliate identifier
    /// </summary>
    public int AffiliateId { get; set; }

    /// <summary>
    /// Gets or sets the customer IP address
    /// </summary>
    public string CustomerIp { get; set; }

    /// <summary>
    /// Gets or sets a value indicating whether storing of credit card number is allowed
    /// </summary>
    public bool AllowStoringCreditCardNumber { get; set; }

    /// <summary>
    /// Gets or sets the card type
    /// </summary>
    public string CardType { get; set; }

    /// <summary>
    /// Gets or sets the card name
    /// </summary>
    public string CardName { get; set; }

    /// <summary>
    /// Gets or sets the card number
    /// </summary>
    public string CardNumber { get; set; }

    /// <summary>
    /// Gets or sets the masked credit card number
    /// </summary>
    public string MaskedCreditCardNumber { get; set; }

    /// <summary>
    /// Gets or sets the card CVV2
    /// </summary>
    public string CardCvv2 { get; set; }

    /// <summary>
    /// Gets or sets the card expiration month
    /// </summary>
    public string CardExpirationMonth { get; set; }

    /// <summary>
    /// Gets or sets the card expiration year
    /// </summary>
    public string CardExpirationYear { get; set; }

    /// <summary>
    /// Gets or sets the authorization transaction identifier
    /// </summary>
    public string AuthorizationTransactionId { get; set; }

    /// <summary>
    /// Gets or sets the authorization transaction code
    /// </summary>
    public string AuthorizationTransactionCode { get; set; }

    /// <summary>
    /// Gets or sets the authorization transaction result
    /// </summary>
    public string AuthorizationTransactionResult { get; set; }

    /// <summary>
    /// Gets or sets the capture transaction identifier
    /// </summary>
    public string CaptureTransactionId { get; set; }

    /// <summary>
    /// Gets or sets the capture transaction result
    /// </summary>
    public string CaptureTransactionResult { get; set; }

    /// <summary>
    /// Gets or sets the subscription transaction identifier
    /// </summary>
    public string SubscriptionTransactionId { get; set; }

    /// <summary>
    /// Gets or sets the paid date and time
    /// </summary>
    public DateTime? PaidDateUtc { get; set; }

    /// <summary>
    /// Gets or sets the shipping method
    /// </summary>
    public string ShippingMethod { get; set; }

    /// <summary>
    /// Gets or sets the shipping rate computation method identifier or the pickup point provider identifier (if PickupInStore is true)
    /// </summary>
    public string ShippingRateComputationMethodSystemName { get; set; }

    /// <summary>
    /// Gets or sets the serialized CustomValues (values from ProcessPaymentRequest)
    /// </summary>
    public string CustomValuesXml { get; set; }

    /// <summary>
    /// Gets or sets a value indicating whether the entity has been deleted
    /// </summary>
    public bool Deleted { get; set; }

    /// <summary>
    /// Gets or sets the date and time of order creation
    /// </summary>
    public DateTime CreatedOnUtc { get; set; }

    /// <summary>
    /// Gets or sets the custom order number without prefix
    /// </summary>
    public string CustomOrderNumber { get; set; }

    /// <summary>
    /// Gets or sets the reward points history record (spent by a customer when placing this order)
    /// </summary>
    public virtual int? RedeemedRewardPointsEntryId { get; set; }

    #endregion

        #region === 扩展属性 ===

        /// <summary>
        /// 推荐用户ID（该单的推荐购买人）
        /// </summary>
        public int ReferrerCustomerId { get; set; }

        /// <summary>
        /// 对外展示统一加密id（URL参数），作为订单号
        /// </summary>
        public long UnifiedId { get; set; }

        /// <summary>
        /// 订单备注
        /// </summary>
        public string Notes { get; set; }

        /// <summary>
        /// 是否需要开开票/发票
        /// </summary>
        public bool NeedInvoice { get; set; }

        /// <summary>
        /// 发票、开票信息ID
        /// </summary>
        public int OrderInvoiceId { get; set; }

        /// <summary>
        /// 订单总邮费快递运费（向代理商结算运费）
        /// </summary>
        public decimal OrderShippingAmount { get; set; }

        /// <summary>
        /// 邮费快递公司名称Id
        /// </summary>
        public int ExpressCompanyId { get; set; }

        /// <summary>
        /// 订单总邮费快递单号运单号
        /// </summary>
        public string OrderShippingNumber { get; set; }

        /// <summary>
        /// 第三方交易调用接口提交的交易类型
        /// </summary>
        public string TradeType { get; set; }

        /// <summary>
        /// 第三方交易单号
        /// </summary>
        public string TradeNumber { get; set; }

        /// <summary>
        /// 延时支付分钟数（默认=0未单独设置，默认为3天，如果产品单独设置后，采用产品设置）
        /// 订单支付过期秒数（过期前支付，产品单独设置主要用于抢购商品）
        /// 取默认设置和产品单独设置的最小时间
        /// </summary>
        public DateTime DelayPaymentExpireDateUtc { get; set; }


        #endregion

        #region Custom properties

    /// <summary>
    /// Gets or sets the order status
    /// </summary>
    public OrderStatus OrderStatus
    {
        get => (OrderStatus)OrderStatusId;
        set => OrderStatusId = (int)value;
    }

    /// <summary>
    /// Gets or sets the payment status
    /// </summary>
    public PaymentStatus PaymentStatus
    {
        get => (PaymentStatus)PaymentStatusId;
        set => PaymentStatusId = (int)value;
    }

    /// <summary>
    /// Gets or sets the shipping status
    /// </summary>
    public ShippingStatus ShippingStatus
    {
        get => (ShippingStatus)ShippingStatusId;
        set => ShippingStatusId = (int)value;
    }

    /// <summary>
    /// Gets or sets the customer tax display type
    /// </summary>
    public TaxDisplayType CustomerTaxDisplayType
    {
        get => (TaxDisplayType)CustomerTaxDisplayTypeId;
        set => CustomerTaxDisplayTypeId = (int)value;
    }

    #endregion
}