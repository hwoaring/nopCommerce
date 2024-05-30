namespace Nop.Core.Domain.Brands;

/// <summary>
/// 品牌映射
/// </summary>
public partial interface IBrandMappingSupported
{
    /// <summary>
    /// 限制到品牌
    /// </summary>
    bool LimitedToBrands { get; set; }
}
