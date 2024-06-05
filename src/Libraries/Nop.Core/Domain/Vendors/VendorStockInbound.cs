using System.Reflection.Emit;
using Nop.Core.Domain.Common;

namespace Nop.Core.Domain.Vendors;

/// <summary>
/// 代理商产品入库记录
/// </summary>
public partial class VendorStockInbound : BaseEntity, ISoftDeletedEntity
{
    /// <summary>
    /// 代理ID
    /// </summary>
    public int VendorId { get; set; }

    /// <summary>
    /// 入库序列号（可能几个产品品类是同一个序列号入库）
    /// </summary>
    public long SerialNumber { get; set; }

    /// <summary>
    /// 代理商库房ID（如果没有库房，可以填写0）
    /// </summary>
    public int VendorWarehouseId { get; set; }

    /// <summary>
    /// 入库产品品类ID
    /// </summary>
    public int VendorStockProductId { get; set; }

    /// <summary>
    /// 产品类型（成品，半成品，非卖品）
    /// </summary>
    public int VendorStockProductTypeId { get; set; }

    /// <summary>
    /// 入库整件数量（整包数）
    /// </summary>
    public decimal InboundBoxAmounts { get; set; }

    /// <summary>
    /// 入库单瓶数量（零散数）
    /// </summary>
    public decimal InboundUnitAmounts { get; set; }

    /// <summary>
    /// 入库外箱码编号（超出最大记录数量后，分多条记录入库）
    /// </summary>
    public string InboundAntiCodeBox { get; set; }

    /// <summary>
    /// 单瓶入库的外箱码编号（超出最大记录数量后，分多条记录入库）
    /// </summary>
    public string InboundAntiCodeItem { get; set; }

    /// <summary>
    /// （备用）
    /// </summary>
    public int Status { get; set; }

    /// <summary>
    /// 备注
    /// </summary>
    public string Notes { get; set; }

    /// <summary>
    /// 入库人ID
    /// </summary>
    public int InboundCustomerId { get; set; }

    /// <summary>
    /// 是否虚拟产品
    /// </summary>
    public bool VirtualProduct { get; set; }

    /// <summary>
    /// 是否退货入库
    /// </summary>
    public bool IsReturnIn { get; set; }

    /// <summary>
    /// 退货单号
    /// </summary>
    public string ReturnOrderNumber { get; set; }

    /// <summary>
    /// 是否品鉴支持（市场支持）的产品
    /// </summary>
    public bool TastingProduct { get; set; }

    /// <summary>
    /// 从其他代理的仓库入库（上级代理出库时候，直接向下级代理发送入库申请
    /// 下级代理同意后，上级自动出库成功，下级自动添加入库信息，并入库成功）
    /// 如果没有值，则表示是自己手动添加的入库信息
    /// </summary>
    public int FromVendorId { get; set; }

    /// <summary>
    /// 入库时间
    /// </summary>
    public DateTime CreatedOnUtc { get; set; }

    /// <summary>
    /// 是否无效（当自己代理商自己乱添加的入库，上级代理或者厂家可以判断为无效）
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
