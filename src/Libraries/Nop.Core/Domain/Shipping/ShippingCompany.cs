using Nop.Core.Domain.Common;

namespace Nop.Core.Domain.Shipping;

/// <summary>
/// 发货公司，物流公司
/// </summary>
public partial class ShippingCompany : BaseEntity,ISoftDeletedEntity
{
    /// <summary>
    /// 物流公司名
    /// </summary>
    public string Name { get; set; }

    /// <summary>
    /// 单号正则表达式
    /// </summary>
    public string TrackingNumberRegEx { get; set; }

    /// <summary>
    /// 排序
    /// </summary>
    public int DisplayOrder { get; set; }

    /// <summary>
    /// 是否需要发货
    /// </summary>
    public bool NeedShipping { get; set; }

    /// <summary>
    /// 是否可用
    /// </summary>
    public bool Actived { get; set; }

    /// <summary>
    /// 删除
    /// </summary>
    public bool Deleted { get; set; }
}