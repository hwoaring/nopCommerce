using Nop.Core.Domain.Localization;
using Nop.Core.Domain.Seo;

namespace Nop.Core.Domain.Brands;

/// <summary>
/// 品牌标签（可以当话题标签使用）
/// </summary>
public partial class BrandTag : BaseEntity, ILocalizedEntity, ISlugSupported
{
    /// <summary>
    /// 标签名称
    /// </summary>
    public string Name { get; set; }
}