namespace Nop.Core.Domain.Shipping;

/// <summary>
/// Represents a shipment
/// </summary>
public partial class Shipment : BaseEntity
{
    /// <summary>
    /// Gets or sets the order identifier
    /// </summary>
    public int OrderId { get; set; }

    /// <summary>
    /// Gets or sets the tracking number of this shipment
    /// </summary>
    public string TrackingNumber { get; set; }

    /// <summary>
    /// Gets or sets the total weight of this shipment
    /// It's nullable for compatibility with the previous version of nopCommerce where was no such property
    /// </summary>
    public decimal? TotalWeight { get; set; }

    /// <summary>
    /// Gets or sets the shipped date and time
    /// </summary>
    public DateTime? ShippedDateUtc { get; set; }

    /// <summary>
    /// Gets or sets the delivery date and time
    /// </summary>
    public DateTime? DeliveryDateUtc { get; set; }

    /// <summary>
    /// Gets or sets the ready for pickup date and time
    /// </summary>
    public DateTime? ReadyForPickupDateUtc { get; set; }

    /// <summary>
    /// Gets or sets the admin comment
    /// </summary>
    public string AdminComment { get; set; }

    /// <summary>
    /// Gets or sets the entity creation date
    /// </summary>
    public DateTime CreatedOnUtc { get; set; }

    #region ===== 扩展信息 =====

    /// <summary>
    /// 发货公司ID或发货类型ID（顺丰、韵达，自提，厂家发货等）
    /// </summary>
    public int ShippingCompanyId { get; set; }

    /// <summary>
    /// 代理商出库序列号
    /// </summary>
    public long VendorOutboundSerialNumber { get; set; }

    /// <summary>
    /// 单独指定某个运输订单的运费（以便向代理商结算）
    /// </summary>
    public decimal ShippingCost { get; set; }

    /// <summary>
    /// 发货信息创建人ID
    /// </summary>
    public int CreatCustomerId { get; set; }

    #endregion
}