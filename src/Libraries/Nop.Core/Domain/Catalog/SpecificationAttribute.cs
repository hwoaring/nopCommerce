using Nop.Core.Domain.Localization;

namespace Nop.Core.Domain.Catalog;

/// <summary>
/// Represents a specification attribute
/// </summary>
public partial class SpecificationAttribute : BaseEntity, ILocalizedEntity
{
    /// <summary>
    /// Gets or sets the name
    /// </summary>
    public string Name { get; set; }

    /// <summary>
    /// Gets or sets the display order
    /// </summary>
    public int DisplayOrder { get; set; }

    /// <summary>
    /// Gets or sets the specification attribute group identifier
    /// </summary>
    public int? SpecificationAttributeGroupId { get; set; }


    #region
    /// <summary>
    /// 小图标ID
    /// </summary>
    public int PictureId { get; set; }

    /// <summary>
    /// 短名称
    /// </summary>
    public string ShortName { get; set; }

    /// <summary>
    /// 描述
    /// </summary>
    public string Description { get; set; }

    /// <summary>
    /// 内容
    /// </summary>
    public string Content { get; set; }

    #endregion
}
