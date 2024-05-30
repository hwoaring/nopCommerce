namespace Nop.Core.Domain.News;

/// <summary>
/// Represents a 新闻标签mapping
/// </summary>
public partial class NewsItemNewsTagMapping : BaseEntity
{
    /// <summary>
    /// 新闻ID
    /// </summary>
    public int NewsItemId { get; set; }

    /// <summary>
    /// 新闻标签ID
    /// </summary>
    public int NewsTagId { get; set; }
}