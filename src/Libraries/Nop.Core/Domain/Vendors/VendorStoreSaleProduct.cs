namespace Nop.Core.Domain.Vendors;

/// <summary>
/// 分销人员个人销售的产品（个人产品或者分销产品）
/// </summary>
public partial class VendorStoreSaleProduct : BaseEntity
{
    /// <summary>
    /// 销售店铺id
    /// </summary>
    public int VendorStoreId { get; set; }

    /// <summary>
    /// 产品id
    /// </summary>
    public int VendorSaleProductId { get; set; }

    /// <summary>
    /// 排序
    /// </summary>
    public int DisplayOrder { get; set; }

    /// <summary>
    /// 个人推荐
    /// </summary>
    public bool Recommended { get; set; }

    /// <summary>
    /// 热销
    /// </summary>
    public bool HotSell { get; set; }

    /// <summary>
    /// 代理商控制是否启用
    /// </summary>
    public bool Enabled { get; set; }

    /// <summary>
    /// 平台控制是否通过审核
    /// </summary>
    public bool Approved { get; set; }

    /// <summary>
    /// 平台控制是否锁定，默认为不锁定（系统控制，不允许分销或销售本产品）
    /// </summary>
    public bool Locked { get; set; }
}
