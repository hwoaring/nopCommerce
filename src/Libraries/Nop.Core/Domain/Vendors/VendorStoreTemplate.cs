namespace Nop.Core.Domain.Vendors;

/// <summary>
/// 供应商店铺模板
/// </summary>
public partial class VendorStoreTemplate : BaseEntity
{
    /// <summary>
    /// 模板名称
    /// </summary>
    public string Name { get; set; }

    /// <summary>
    /// 描述
    /// </summary>
    public string Discription { get; set; }

    /// <summary>
    /// 页面类型（首页、栏目，产品，联系，招商，表单，关于……）
    /// </summary>
    public int TemplateTypeId { get; set; }

    /// <summary>
    /// 模板路径
    /// </summary>
    public string ViewPath { get; set; }

    /// <summary>
    /// 是否绑定到VendorStoreId，绑定后，之后制定vendorstore可以使用
    /// </summary>
    public int BandToVendorStoreId { get; set; }

    /// <summary>
    /// 排序
    /// </summary>
    public int DisplayOrder { get; set; }
}
