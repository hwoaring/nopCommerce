namespace Nop.Core.Domain.Orders;

/// <summary>
/// Represents an order item
/// </summary>
public partial class OrderItem : BaseEntity
{
    /// <summary>
    /// Gets or sets the order item identifier
    /// </summary>
    public Guid OrderItemGuid { get; set; }

    /// <summary>
    /// Gets or sets the order identifier
    /// </summary>
    public int OrderId { get; set; }

    /// <summary>
    /// Gets or sets the product identifier
    /// </summary>
    public int ProductId { get; set; }

    /// <summary>
    /// Gets or sets the quantity
    /// </summary>
    public int Quantity { get; set; }

    /// <summary>
    /// Gets or sets the unit price in primary store currency (include tax)
    /// </summary>
    public decimal UnitPriceInclTax { get; set; }

    /// <summary>
    /// Gets or sets the unit price in primary store currency (exclude tax)
    /// </summary>
    public decimal UnitPriceExclTax { get; set; }

    /// <summary>
    /// Gets or sets the price in primary store currency (include tax)
    /// </summary>
    public decimal PriceInclTax { get; set; }

    /// <summary>
    /// Gets or sets the price in primary store currency (exclude tax)
    /// </summary>
    public decimal PriceExclTax { get; set; }

    /// <summary>
    /// Gets or sets the discount amount (include tax)
    /// </summary>
    public decimal DiscountAmountInclTax { get; set; }

    /// <summary>
    /// Gets or sets the discount amount (exclude tax)
    /// </summary>
    public decimal DiscountAmountExclTax { get; set; }

    /// <summary>
    /// Gets or sets the original cost of this order item (when an order was placed), qty 1
    /// </summary>
    public decimal OriginalProductCost { get; set; }

    /// <summary>
    /// Gets or sets the attribute description
    /// </summary>
    public string AttributeDescription { get; set; }

    /// <summary>
    /// Gets or sets the product attributes in XML format
    /// </summary>
    public string AttributesXml { get; set; }

    /// <summary>
    /// Gets or sets the download count
    /// </summary>
    public int DownloadCount { get; set; }

    /// <summary>
    /// Gets or sets a value indicating whether download is activated
    /// </summary>
    public bool IsDownloadActivated { get; set; }

    /// <summary>
    /// Gets or sets a license download identifier (in case this is a downloadable product)
    /// </summary>
    public int? LicenseDownloadId { get; set; }

    /// <summary>
    /// Gets or sets the total weight of one item
    /// It's nullable for compatibility with the previous version of nopCommerce where was no such property
    /// </summary>
    public decimal? ItemWeight { get; set; }

    /// <summary>
    /// Gets or sets the rental product start date (null if it's not a rental product)
    /// </summary>
    public DateTime? RentalStartDateUtc { get; set; }

    /// <summary>
    /// Gets or sets the rental product end date (null if it's not a rental product)
    /// </summary>
    public DateTime? RentalEndDateUtc { get; set; }



    #region

    /// <summary>
    /// 单个产品需要支付的积分
    /// </summary>
    public decimal UnitPoints { get; set; }

    /// <summary>
    /// 需要字符的总积分
    /// </summary>
    public decimal Points { get; set; }

    /// <summary>
    /// (备用)商品退款金额，在order中已有，在这里针对单个产品备用
    /// </summary>
    public decimal RefundAmount { get; set; }

    /// <summary>
    /// 单品的退款数量(备用)
    /// </summary>
    public int RefundQuantity { get; set; }

    /// <summary>
    /// 是否延期发货订单（进入顺位排序）
    /// </summary>
    public bool BackOrderItem { get; set; }

    /// <summary>
    /// 是否需要验证审核：本产品需要后台审核验证后才能付款
    /// </summary>
    public bool RequireVerify { get; set; }

    /// <summary>
    /// 电子发票入口开放标识
    /// </summary>
    public bool SupportFapiao { get; set; }

    /// <summary>
    /// 是否已经验证审核：本产品需要后台审核验证后才能付款
    /// </summary>
    public bool Verified { get; set; }

    /// <summary>
    /// 对外展示统一加密id（URL参数），作为单个产品的订单号
    /// </summary>
    public long UnifiedId { get; set; }

    /// <summary>
    /// DeliverCustomerId ，发货人ID，或者线下兑换人ID，用于记录谁发货货款结算给谁
    /// （卡券资产中也有兑换人，防伪码奖励中也有兑换人，怎么把3处兑换人合并到一张表）
    /// 同一订单，可能有不同的发货人
    /// </summary>
    public int DeliverCustomerId { get; set; }

    /// <summary>
    /// 线下取货，代发货：取货日期
    /// 同一订单，可能有不同的发货人
    /// </summary>
    public DateTime PickupDateOnUtc { get; set; }

    /// <summary>
    /// 订单优惠券，优惠卡属性（备用）
    /// </summary>
    public string CouponAttributesXML { get; set; }

    /// <summary>
    /// 订单优惠标记
    /// </summary>
    public string GoodsTag { get; set; }

    /// <summary>
    /// 订单产品备注信息
    /// </summary>
    public string Notes { get; set; }

    /// <summary>
    /// 使用时间（订单产品使用时间）
    /// </summary>
    public DateTime? UsageDateOnUtc { get; set; }

    /// <summary>
    /// 订单总邮费快递运费（向代理商结算运费）
    /// </summary>
    public decimal OrderShippingAmount { get; set; }

    /// <summary>
    /// 订单总邮费快递单号运单号
    /// </summary>
    public string OrderShippingNumber { get; set; }

    /// <summary>
    /// 产品订单备注选项，多项以逗号分开
    /// </summary>
    public string ProductOrderNoticeIdList { get; set; }

    /// <summary>
    /// 不在Order中记录，因为一个订单包括多个产品，每个产品的支付过期时间可能不同，
    /// 订单过期时间取所有产品的过期时间的最小值。
    /// 
    /// 交易结束时间,订单失效时间,延时支付分钟数
    /// （默认可以设置为为3天，如果产品单独设置后，采用产品设置）
    /// （过期前支付，产品单独设置主要用于抢购商品）
    /// 取默认设置和产品单独设置的最小时间
    /// </summary>
    public DateTime? DelayPaymentExpireDateUtc { get; set; }

    #endregion
}
