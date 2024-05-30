using Nop.Core.Domain.Common;
using Nop.Core.Domain.Localization;
using Nop.Core.Domain.Seo;

namespace Nop.Core.Domain.Vendors;

/// <summary>
/// 相关店铺，适用于连锁店形式
/// </summary>
public partial class RelateVendorStoreMapping : BaseEntity
{
    /// <summary>
    /// 申请店铺ID
    /// </summary>
    public int VendorStoreId { get; set; }

    /// <summary>
    /// 关联店铺ID
    /// </summary>
    public int RelateVendorStoreId { get; set; }

    /// <summary>
    /// 申请店铺是否同意（可用于单方面临时关闭关联状态）
    /// </summary>
    public bool VendorStoreApproved { get; set; }

    /// <summary>
    /// 需要被关联店铺同意（可用于单方面临时关闭关联状态）
    /// </summary>
    public bool RelateVendorStoreApproved { get; set; }

    /// <summary>
    /// 排序
    /// </summary>
    public int DisplayOrder { get; set; }
}
