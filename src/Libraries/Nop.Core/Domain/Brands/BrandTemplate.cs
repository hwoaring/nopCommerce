namespace Nop.Core.Domain.Brands;

/// <summary>
/// 品牌模板
/// </summary>
public partial class BrandTemplate : BaseEntity
{
    /// <summary>
    /// 模板名称
    /// </summary>
    public string Name { get; set; }

    /// <summary>
    /// 模板路径
    /// </summary>
    public string ViewPath { get; set; }

    /// <summary>
    /// 排序
    /// </summary>
    public int DisplayOrder { get; set; }
}
