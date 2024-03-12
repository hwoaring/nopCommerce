using Nop.Core.Domain.Common;
using Nop.Core.Domain.Localization;
using Nop.Core.Domain.Seo;

namespace Nop.Core.Domain.Vendors;

/// <summary>
/// 店铺定义黑名单
/// </summary>
public partial class VendorStoreBlackList : BaseEntity
{
    /// <summary>
    /// 店铺id
    /// </summary>
    public int VendorStoreId { get; set; }

    /// <summary>
    /// 黑名单客人ID
    /// </summary>
    public int CustomerId { get; set; }

    /// <summary>
    /// 黑名单标签
    /// </summary>
    public int VendorTagId { get; set; }

    /// <summary>
    /// 黑名单电话
    /// </summary>
    public string Phone { get; set; }

    /// <summary>
    /// 备注
    /// </summary>
    public string Notes { get; set; }
}
