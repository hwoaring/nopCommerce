using Nop.Core.Configuration;

namespace Nop.Core.Domain.News;

/// <summary>
/// News settings
/// </summary>
public partial class NewsSettings : ISettings
{
    /// <summary>
    /// Gets or sets a value indicating whether news are enabled
    /// </summary>
    public bool Enabled { get; set; }

    /// <summary>
    /// Gets or sets a value indicating whether not registered user can leave comments
    /// </summary>
    public bool AllowNotRegisteredUsersToLeaveComments { get; set; }

    /// <summary>
    /// Gets or sets a value indicating whether to notify about new news comments
    /// </summary>
    public bool NotifyAboutNewNewsComments { get; set; }

    /// <summary>
    /// Gets or sets a value indicating whether to show news on the main page
    /// </summary>
    public bool ShowNewsOnMainPage { get; set; }

    /// <summary>
    /// Gets or sets a value indicating news count displayed on the main page
    /// </summary>
    public int MainPageNewsCount { get; set; }

    /// <summary>
    /// Gets or sets the page size for news archive
    /// </summary>
    public int NewsArchivePageSize { get; set; }

    /// <summary>
    /// Enable the news RSS feed link in customers browser address bar
    /// </summary>
    public bool ShowHeaderRssUrl { get; set; }

    /// <summary>
    /// Gets or sets a value indicating whether news comments must be approved
    /// </summary>
    public bool NewsCommentsMustBeApproved { get; set; }

    /// <summary>
    /// Gets or sets a value indicating whether news comments will be filtered per store
    /// </summary>
    public bool ShowNewsCommentsPerStore { get; set; }


    #region === 扩展属性 ===

    /// <summary>
    /// 开启文章创建人贡献文章
    /// </summary>
    public bool EnableCreators { get; set; }

    /// <summary>
    /// 开启文章阅读计数（文章阅读数统计总开关）
    /// </summary>
    public bool EnableViewsCount { get; set; }

    /// <summary>
    /// 每人每天最多评论次数
    /// </summary>
    public int MaxCommentsOneDay { get; set; }

    #endregion

}