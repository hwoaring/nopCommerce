using Nop.Core.Domain.Common;
using Nop.Core.Domain.Localization;
using Nop.Core.Domain.Seo;

namespace Nop.Core.Domain.Vendors;

/// <summary>
/// 代理商产品区域代理信息绑定表
/// </summary>
public partial class VendorStoreRegionalAgent : BaseEntity
{
    /// <summary>
    /// 代理商店铺ID
    /// </summary>
    public int VendorStoreId { get; set; }

    /// <summary>
    /// 产品条码
    /// </summary>
    public long ProductBarCode { get; set; }

    /// <summary>
    /// 地址的区划代码ID
    /// </summary>
    public int RegionCodeId { get; set; }

    /// <summary>
    /// 锁定原因
    /// </summary>
    public string LockReason { get; set; }

    /// <summary>
    /// 是否锁定
    /// </summary>
    public bool Locked { get; set; }
}
