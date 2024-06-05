
using Nop.Core.Domain.Common;

namespace Nop.Core.Domain.Vendors;

/// <summary>
/// 分销人员个人销售的产品（表示选择到自己的代理库中，并不表示该产品供应商属于该Vendor）
/// </summary>
public partial class VendorSaleProduct : BaseEntity, ISoftDeletedEntity
{
    /// <summary>
    /// 销售id
    /// </summary>
    public int VendorId { get; set; }

    /// <summary>
    /// 产品id
    /// </summary>
    public int ProductId { get; set; }

    /// <summary>
    /// 使用自定义价格
    /// </summary>
    public bool UseCustomerPrice { get; set; }

    /// <summary>
    /// 自定义销售价格
    /// </summary>
    public decimal CustomerPrice { get; set; }

    /// <summary>
    /// 排序
    /// </summary>
    public int DisplayOrder { get; set; }

    /// <summary>
    /// 默认不允许
    /// 该产品允许代理商自己出库发货（在代理商满足出库发货条件下）
    /// 允许从代理商仓库出库/发货
    /// Product中已有总控制，这里单独控制是否允许代理的产品自己出库
    /// </summary>
    public bool AllowVendorShipping { get; set; }

    /// <summary>
    /// 是否允许0库存出库、发货
    /// 代理商的库存在
    /// </summary>
    public bool AllowOutStockShipment { get; set; }

    /// <summary>
    /// 是否有该产品的分销权限（自己分销的页面展示自己的联系方式）
    /// 如果总供应商没有购买全套产品服务，那么个人也可以分销，个人分销需要购买本产品的分销权限
    /// </summary>
    public bool SharePermission { get; set; }

    /// <summary>
    /// 该产品分销权限（过期时间）
    /// </summary>
    public DateTime? SharePermissionExpireDateUtc { get; set; }

    /// <summary>
    /// 个人推荐
    /// </summary>
    public bool Recommended { get; set; }

    /// <summary>
    /// 热销
    /// </summary>
    public bool HotSell { get; set; }

    /// <summary>
    /// 是否品牌导购（品牌导购可以获得单独的导购奖励）
    /// 奖励分为两个，一个有上级供货商提供，一个由厂家提供。
    /// 奖励独立设置。
    /// </summary>
    public bool BrandSales { get; set; }

    /// <summary>
    /// 系统控制：是否只能展示线上下单
    /// </summary>
    public bool ForceOrderOnline { get; set; }

    /// <summary>
    /// 个人控制：是否线下下单，不展示商品购买链接（只能通过联系人购买）
    /// 在线下单，平台提取佣金，如果线下交易，个人需提前支付平台服务费（线下交易）。
    /// </summary>
    public bool OrderOffline { get; set; }

    /// <summary>
    /// 是否已支付平台服务费（线下交易）
    /// </summary>
    public bool OfflineFeePaid { get; set; }

    /// <summary>
    /// 平台服务费过期时间（线下交易）
    /// </summary>
    public DateTime? OfflineExpireDateUtc { get; set; }

    /// <summary>
    /// 销售商、代理商自己控制是否启用
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

    /// <summary>
    /// 删除
    /// </summary>
    public bool Deleted { get; set; }
}
