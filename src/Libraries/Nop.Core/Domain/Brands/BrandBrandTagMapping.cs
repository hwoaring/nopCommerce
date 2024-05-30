namespace Nop.Core.Domain.Brands;

/// <summary>
/// 品牌标签映射
/// </summary>
public partial class BrandBrandTagMapping : BaseEntity
{
    /// <summary>
    /// 品牌id
    /// </summary>
    public int BrandId { get; set; }

    /// <summary>
    /// 品牌标签id
    /// </summary>
    public int BrandTagId { get; set; }
}