namespace Nop.Core.Domain.Vendors;

/// <summary>
/// 代理第三方平台的销售链接
/// </summary>
public partial class Vendor3rdSaleUrl : BaseEntity
{
    /// <summary>
    /// 代理商ID
    /// </summary>
    public int VendorId { get; set; }

    /// <summary>
    /// 产品ID
    /// </summary>
    public int ProductId { get; set; }

    /// <summary>
    /// 第三方平台类型ID，京东，淘宝，抖音等
    /// </summary>
    public int Product3rdSalePlatformId { get; set; }

    /// <summary>
    /// 分销商个人在三方分销平台的销售链接
    /// </summary>
    public string Url { get; set; }

    /// <summary>
    /// 是否为代理商店铺的三方平台购买URL
    /// </summary>
    public bool IsVendorStoreUrl { get; set; }

    /// <summary>
    /// 由代理商自己控制是否启用
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
