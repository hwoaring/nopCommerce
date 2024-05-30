namespace Nop.Core.Domain.Brands;

/// <summary>
/// 品牌图片
/// </summary>
public partial class BrandPicture : BaseEntity
{
    /// <summary>
    /// 品牌ID
    /// </summary>
    public int BrandId { get; set; }

    /// <summary>
    /// 图片ID
    /// </summary>
    public int PictureId { get; set; }

    /// <summary>
    /// 名称
    /// </summary>
    public string Name { get; set; }

    /// <summary>
    /// 描述
    /// </summary>
    public string Description { get; set; }

    /// <summary>
    /// 排序
    /// </summary>
    public int DisplayOrder { get; set; }
}
