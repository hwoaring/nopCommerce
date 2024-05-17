namespace Nop.Core.Domain.Common;

/// <summary>
/// 用户搜素历史记录
/// </summary>
public partial class SearchTermHistory : BaseEntity
{
    /// <summary>
    /// 用户ID
    /// </summary>
    public int CustomerId { get; set; }

    /// <summary>
    /// Gets or sets the keyword
    /// </summary>
    public string Keyword { get; set; }

    /// <summary>
    /// Gets or sets search count
    /// </summary>
    public int Count { get; set; }

    /// <summary>
    /// 最后搜素日期
    /// </summary>
    public DateTime LastDateOnUtc { get; set; }
}