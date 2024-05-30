using Nop.Core.Domain.Localization;

namespace Nop.Core.Domain.Catalog;

/// <summary>
/// Represents a product attribute
/// </summary>
public partial class ProductAttribute : BaseEntity, ILocalizedEntity
{
    /// <summary>
    /// Gets or sets the name
    /// </summary>
    public string Name { get; set; }

    /// <summary>
    /// Gets or sets the description
    /// </summary>
    public string Description { get; set; }


    #region

    /// <summary>
    /// 短名称
    /// </summary>
    public string ShortName { get; set; }

    /// <summary>
    /// 内容
    /// </summary>
    public string Content { get; set; }

    #endregion
}
