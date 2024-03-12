using Nop.Core.Domain.Common;
using Nop.Core.Domain.Localization;
using Nop.Core.Domain.Seo;

namespace Nop.Core.Domain.Vendors;

/// <summary>
/// 销售可以自定义推广产品分组数量（便于和朋友圈分组隐私对应）
/// </summary>
public partial class VendorProductGroup : BaseEntity
{
    /// <summary>
    /// 销售员ID
    /// </summary>
    public int VendorId { get; set; }

    /// <summary>
    /// 分组名称
    /// </summary>
    public string Name { get; set; }

    /// <summary>
    /// 个人控制：公开展示，或直接显示推荐的联系方式,客户可以直接联系，表明自己是供应商
    /// </summary>
    public bool DisplayContactInfo { get; set; }
}
