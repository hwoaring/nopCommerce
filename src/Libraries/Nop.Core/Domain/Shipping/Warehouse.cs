namespace Nop.Core.Domain.Shipping;

/// <summary>
/// Represents a shipment
/// </summary>
public partial class Warehouse : BaseEntity
{
    /// <summary>
    /// Gets or sets the warehouse name
    /// </summary>
    public string Name { get; set; }

    /// <summary>
    /// Gets or sets the admin comment
    /// </summary>
    public string AdminComment { get; set; }

    /// <summary>
    /// Gets or sets the address identifier of the warehouse
    /// </summary>
    public int AddressId { get; set; }

    #region ===== 扩展信息 =====

    /// <summary>
    /// 设置提货地址是否属于某个Vendor（可为空）
    /// </summary>
    public int VendorId { get; set; }

    /// <summary>
    /// 提货联系电话
    /// </summary>
    public string PickupContactNumber { get; set; }

    /// <summary>
    /// 是否支持自提
    /// </summary>
    public bool SupportSelfPickup { get; set; }

    /// <summary>
    /// 是否地图展示出来（客户搜索时候可以展示位置坐标点）
    /// </summary>
    public bool DisplayMapInfo { get; set; }

    /// <summary>
    /// 是否展示电话
    /// </summary>
    public bool DisplayContactNumber { get; set; }

    #endregion
}