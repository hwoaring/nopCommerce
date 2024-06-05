using Nop.Core.Domain.Seo;
using Nop.Core.Domain.Stores;

namespace Nop.Core.Domain.News;

/// <summary>
/// Represents a news item
/// </summary>
public partial class NewsItem : BaseEntity, ISlugSupported, IStoreMappingSupported
{
    /// <summary>
    /// Gets or sets the language identifier
    /// </summary>
    public int LanguageId { get; set; }

    /// <summary>
    /// Gets or sets the news title
    /// </summary>
    public string Title { get; set; }

    /// <summary>
    /// Gets or sets the short text
    /// </summary>
    public string Short { get; set; }

    /// <summary>
    /// Gets or sets the full text
    /// </summary>
    public string Full { get; set; }

    /// <summary>
    /// Gets or sets a value indicating whether the news item is published
    /// </summary>
    public bool Published { get; set; }

    /// <summary>
    /// Gets or sets the news item start date and time
    /// </summary>
    public DateTime? StartDateUtc { get; set; }

    /// <summary>
    /// Gets or sets the news item end date and time
    /// </summary>
    public DateTime? EndDateUtc { get; set; }

    /// <summary>
    /// Gets or sets a value indicating whether the news post comments are allowed 
    /// </summary>
    public bool AllowComments { get; set; }

    /// <summary>
    /// Gets or sets a value indicating whether the entity is limited/restricted to certain stores
    /// </summary>
    public bool LimitedToStores { get; set; }

    /// <summary>
    /// Gets or sets the meta keywords
    /// </summary>
    public string MetaKeywords { get; set; }

    /// <summary>
    /// Gets or sets the meta description
    /// </summary>
    public string MetaDescription { get; set; }

    /// <summary>
    /// Gets or sets the meta title
    /// </summary>
    public string MetaTitle { get; set; }

    /// <summary>
    /// Gets or sets the date and time of entity creation
    /// </summary>
    public DateTime CreatedOnUtc { get; set; }


    #region === 扩展属性 ===

    /// <summary>
    /// 新闻模板
    /// </summary>
    public int NewsTemplateId { get; set; }

    /// <summary>
    /// 新闻页面样式
    /// </summary>
    public int PageStyleTypeId { get; set; }

    /// <summary>
    /// 贡献人/发布人ID
    /// </summary>
    public int CustomerId { get; set; }

    /// <summary>
    /// 贡献者名称
    /// </summary>
    public string AuthorName { get; set; }

    /// <summary>
    /// 发布人IP位置
    /// </summary>
    public string PublisherArea { get; set; }

    /// <summary>
    /// 发布人IP
    /// </summary>
    public string PublisherIp { get; set; }

    /// <summary>
    /// 短名称
    /// </summary>
    public string SubTitle { get; set; }

    /// <summary>
    /// 封面图
    /// </summary>
    public int CoverImageId { get; set; }

    /// <summary>
    /// 原文来源（外部平台名称）
    /// </summary>
    public string SourceName { get; set; }

    /// <summary>
    /// 原文链接
    /// </summary>
    public string SourceUrl { get; set; }

    /// <summary>
    /// 进入后直接跳转到原文链接地址
    /// </summary>
    public bool JumpToSourceUrl { get; set; }

    /// <summary>
    /// 文章是否审核通过
    /// </summary>
    public bool IsApproved { get; set; }

    /// <summary>
    /// 开启浏览统计
    /// </summary>
    public bool EnableViewsCount { get; set; }

    /// <summary>
    /// 浏览量
    /// </summary>
    public int ViewsCount { get; set; }

    /// <summary>
    /// 是否广告（客户发布的内容是不是广告）
    /// </summary>
    public bool IsAdvert { get; set; }

    /// <summary>
    /// 置顶
    /// </summary>
    public bool AsTopNews { get; set; }

    /// <summary>
    /// 推荐
    /// </summary>
    public bool AsRedNews { get; set; }

    /// <summary>
    /// 热门
    /// </summary>
    public bool AsHotNews { get; set; }

    /// <summary>
    /// 幻灯片
    /// </summary>
    public bool AsSlideNews { get; set; }

    /// <summary>
    /// 向黑名单用户隐藏新闻或禁止阅读
    /// </summary>
    public bool DisplayToBlackList { get; set; }

    /// <summary>
    /// 更新时间
    /// </summary>
    public DateTime? UpdatedOnUtc { get; set; }

    #endregion
}