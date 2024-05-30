namespace Nop.Core.Domain.News;

/// <summary>
/// 新闻图片集
/// </summary>
public partial class NewsPicture : BaseEntity
{
    /// <summary>
    /// 新闻ID
    /// </summary>
    public int NewsItemId { get; set; }

    /// <summary>
    /// 图片ID
    /// </summary>
    public int PictureId { get; set; }

    /// <summary>
    /// 名称
    /// </summary>
    public string Name { get; set; }

    /// <summary>
    /// 简介
    /// </summary>
    public string Description { get; set; }

    /// <summary>
    /// 排序
    /// </summary>
    public int DisplayOrder { get; set; }
}
