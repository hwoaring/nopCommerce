using System.Net.NetworkInformation;
using Nop.Core.Domain.Common;
using Nop.Core.Domain.Seo;
using Nop.Core.Domain.Stores;

namespace Nop.Core.Domain.News
{
    /// <summary>
    /// Represents a news item
    /// </summary>
    public partial class NewsItem : BaseEntity, ISlugSupported, IStoreMappingSupported, ISoftDeletedEntity
    {
        /// <summary>
        /// Gets or sets the language identifier
        /// </summary>
        public int LanguageId { get; set; }

        /// <summary>
        /// 发布人ID
        /// </summary>
        public int CustomerId { get; set; }

        /// <summary>
        /// 作者名称
        /// </summary>
        public string AuthorName { get; set; }

        /// <summary>
        /// 发布人IP位置
        /// </summary>
        public string PublishArea { get; set; }

        /// <summary>
        /// 发布人IP
        /// </summary>
        public string PublisherIp { get; set; }

        /// <summary>
        /// Gets or sets the news title
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// 短名称
        /// </summary>
        public string SubTitle { get; set; }

        /// <summary>
        /// Gets or sets the short text
        /// </summary>
        public string Short { get; set; }

        /// <summary>
        /// Gets or sets the full text
        /// </summary>
        public string Full { get; set; }

        /// <summary>
        /// 封面图
        /// </summary>
        public string CoverImage { get; set; }

        /// <summary>
        /// 原文链接
        /// </summary>
        public string SourceUrl { get; set; }

        /// <summary>
        /// 文章标签，逗号隔开
        /// </summary>
        public string Tags { get; set; }

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
        /// 微信分享标题
        /// </summary>
        public string ShareTitle { get; set; }

        /// <summary>
        /// 微信分享描述
        /// </summary>
        public string ShareDesc { get; set; }

        /// <summary>
        /// 微信分享链接
        /// </summary>
        public string ShareLink { get; set; }

        /// <summary>
        /// 微信分享图片
        /// </summary>
        public string ShareImgUrl { get; set; }

        /// <summary>
        /// 阅读次数
        /// </summary>
        public int ViewCount { get; set; }

        /// <summary>
        /// 分享次数
        /// </summary>
        public int Forks { get; set; }

        /// <summary>
        /// 点赞次数
        /// </summary>
        public int Likes { get; set; }

        /// <summary>
        /// 标记为在看次数
        /// </summary>
        public int Looks { get; set; }

        /// <summary>
        /// 状态：0正常，1未审核，2锁定
        /// </summary>
        public int Status { get; set; }

        /// <summary>
        /// Gets or sets a display order.
        /// This value is used when sorting associated products (used with "grouped" products)
        /// This value is used when sorting home page products
        /// </summary>
        public int DisplayOrder { get; set; }

        /// <summary>
        /// 置顶
        /// </summary>
        public bool IsTop { get; set; }

        /// <summary>
        /// 推荐
        /// </summary>
        public bool IsRed { get; set; }

        /// <summary>
        /// 热门
        /// </summary>
        public bool IsHot { get; set; }

        /// <summary>
        /// 幻灯片
        /// </summary>
        public bool IsSlide { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether the news post comments are allowed 
        /// </summary>
        public bool AllowComments { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether the entity is limited/restricted to certain stores
        /// </summary>
        public bool LimitedToStores { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether the entity is published
        /// </summary>
        public bool Published { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether the entity has been deleted
        /// </summary>
        public bool Deleted { get; set; }

        /// <summary>
        /// Gets or sets the news item start date and time
        /// </summary>
        public DateTime? StartDateUtc { get; set; }

        /// <summary>
        /// Gets or sets the news item end date and time
        /// </summary>
        public DateTime? EndDateUtc { get; set; }

        /// <summary>
        /// 更新时间
        /// </summary>
        public DateTime? UpdatedOnUtc { get; set; }

        /// <summary>
        /// Gets or sets the date and time of entity creation
        /// </summary>
        public DateTime CreatedOnUtc { get; set; }
    }
}