using Nop.Core.Domain.Localization;
using Nop.Core.Domain.Seo;

namespace Nop.Core.Domain.News;

/// <summary>
/// Represents a 新闻Tag
/// </summary>
public partial class NewsTag : BaseEntity, ILocalizedEntity, ISlugSupported
{
    /// <summary>
    /// Tag名称
    /// </summary>
    public string Name { get; set; }
}