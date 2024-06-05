using Nop.Core.Domain.Common;

namespace Nop.Core.Domain.Vendors;

/// <summary>
/// 代理商产品出库记录
/// </summary>
public partial class VendorStockOutbound : BaseEntity, ISoftDeletedEntity
{
    /// <summary>
    /// 代理ID
    /// </summary>
    public int VendorId { get; set; }

    /// <summary>
    /// 出库序列号（可能几个产品品类是同一个序列号出库）
    /// </summary>
    public long SerialNumber { get; set; }

    /// <summary>
    /// 发货记录ID
    /// </summary>
    public int ShipmentId { get; set; }

    /// <summary>
    /// 代理商库房ID（如果没有库房，可以填写0）
    /// </summary>
    public int VendorWarehouseId { get; set; }

    /// <summary>
    /// 出库产品品类ID
    /// </summary>
    public int VendorStockProductId { get; set; }

    /// <summary>
    /// 产品类型（成品，半成品，非卖品）
    /// </summary>
    public int VendorStockProductTypeId { get; set; }

    /// <summary>
    /// 应收款金额（备用：个人的备注）
    /// </summary>
    public decimal ReceivableAmount { get; set; }

    /// <summary>
    /// 已收款金额（备用：个人的备注）
    /// </summary>
    public decimal ReceivedAmount { get; set; }

    /// <summary>
    /// 出库整件数量（整包数）
    /// </summary>
    public decimal OutboundBoxAmounts { get; set; }

    /// <summary>
    /// 出库单瓶数量（零散数）
    /// </summary>
    public decimal OutboundUnitAmounts { get; set; }

    /// <summary>
    /// 整包出库的外箱码编号（超出最大记录数量后，分多条记录出库）
    /// </summary>
    public string OutboundAntiCodeBox { get; set; }

    /// <summary>
    /// 单瓶出库的外箱码编号（超出最大记录数量后，分多条记录出库）
    /// </summary>
    public string OutboundAntiCodeItem { get; set; }

    /// <summary>
    /// （备用）
    /// </summary>
    public int Status { get; set; }

    /// <summary>
    /// 备注
    /// </summary>
    public string Notes { get; set; }

    /// <summary>
    /// 是否虚拟产品
    /// </summary>
    public bool VirtualProduct { get; set; }

    /// <summary>
    /// 是否品鉴支持（市场支持）
    /// </summary>
    public bool TastingProduct { get; set; }

    /// <summary>
    /// 是否向下级经销商出库
    /// </summary>
    public bool IsToVendor { get; set; }

    /// <summary>
    /// 向下级代理仓库入库申请
    /// 下级代理同意后，上级自动出库成功，下级自动添加入库信息，并入库成功）
    /// 如果没有值，则表示是自己手动添加的入库信息
    /// </summary>
    public int ToVendorId { get; set; }

    /// <summary>
    /// 下级代理同意入库
    /// </summary>
    public bool ToVendorAccepted { get; set; }

    /// <summary>
    /// 出库人ID
    /// </summary>
    public int OutboundCustomerId { get; set; }

    /// <summary>
    /// 出库时间
    /// </summary>
    public DateTime CreatedOnUtc { get; set; }

    /// <summary>
    /// 是否无效
    /// </summary>
    public bool Invalid { get; set; }

    /// <summary>
    /// 删除
    /// </summary>
    public bool Deleted { get; set; }

    /// <summary>
    /// 产品类型（成品，半成品，非卖品）
    /// </summary>
    public VendorStockProductType VendorStockProductType
    {
        get => (VendorStockProductType)VendorStockProductTypeId;
        set => VendorStockProductTypeId = (int)value;
    }
}
