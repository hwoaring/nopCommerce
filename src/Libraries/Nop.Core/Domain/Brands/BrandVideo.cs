namespace Nop.Core.Domain.Brands;

/// <summary>
/// 品牌视频
/// </summary>
public partial class BrandVideo : BaseEntity
{
    /// <summary>
    /// 品牌ID
    /// </summary>
    public int BrandId { get; set; }

    /// <summary>
    /// 视频ID
    /// </summary>
    public int VideoId { get; set; }

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
