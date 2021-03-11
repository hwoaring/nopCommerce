using System;
using Nop.Core.Domain.Localization;
using Nop.Core.Domain.Security;
using Nop.Core.Domain.Seo;
using Nop.Core.Domain.Stores;

namespace Nop.Core.Domain.Topics
{
    /// <summary>
    /// Represents a topic
    /// </summary>
    public partial class Topic : BaseEntity, ILocalizedEntity, ISlugSupported, IStoreMappingSupported, IAclSupported
    {
        /// <summary>
        /// Gets or sets the name
        /// </summary>
        public string SystemName { get; set; }

        /// <summary>
        /// Gets or sets the value indicating whether this topic should be included in sitemap
        /// </summary>
        public bool IncludeInSitemap { get; set; }

        /// <summary>
        /// Gets or sets the value indicating whether this topic should be included in top menu
        /// </summary>
        public bool IncludeInTopMenu { get; set; }

        /// <summary>
        /// Gets or sets the value indicating whether this topic should be included in footer (column 1)
        /// </summary>
        public bool IncludeInFooterColumn1 { get; set; }

        /// <summary>
        /// Gets or sets the value indicating whether this topic should be included in footer (column 1)
        /// </summary>
        public bool IncludeInFooterColumn2 { get; set; }

        /// <summary>
        /// Gets or sets the value indicating whether this topic should be included in footer (column 1)
        /// </summary>
        public bool IncludeInFooterColumn3 { get; set; }

        /// <summary>
        /// Gets or sets the display order
        /// </summary>
        public int DisplayOrder { get; set; }

        /// <summary>
        /// Gets or sets the value indicating whether this topic is accessible when a store is closed
        /// </summary>
        public bool AccessibleWhenStoreClosed { get; set; }

        /// <summary>
        /// Gets or sets the value indicating whether this topic is password protected
        /// </summary>
        public bool IsPasswordProtected { get; set; }

        /// <summary>
        /// Gets or sets the password
        /// </summary>
        public string Password { get; set; }

        /// <summary>
        /// Gets or sets the title
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// Gets or sets the subtitle
        /// </summary>
        public string SubTitle { get; set; }

        /// <summary>
        /// 封面图
        /// </summary>
        public string ImageUrl { get; set; }

        /// <summary>
        /// 视频地址
        /// </summary>
        public string VideoUrl { get; set; }

        /// <summary>
        /// Gets or sets the short text
        /// </summary>
        public string Short { get; set; }

        /// <summary>
        /// Gets or sets the body
        /// </summary>
        public string Body { get; set; }

        /// <summary>
        /// 信息来源
        /// </summary>
        public string Source { get; set; }

        /// <summary>
        /// 作者
        /// </summary>
        public string Author { get; set; }

        /// <summary>
        /// 文章内容图片Lazy加载
        /// </summary>
        public bool LazyLoadImages { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether the entity is published
        /// </summary>
        public bool Published { get; set; }

        /// <summary>
        /// Gets or sets a value of used topic template identifier
        /// </summary>
        public int TopicTemplateId { get; set; }

        /// <summary>
        /// 浏览次数
        /// </summary>
        public int ViewCount { get; set; }

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
        /// 可设置分享小图，SEO 图片 或微信分享小图
        /// </summary>
        public string MetaImageUrl { get; set; }

        /// <summary>
        /// Gets or sets the meta Link
        /// </summary>
        public string MetaLinkUrl { get; set; }

        /// <summary>
        /// 分享大图
        /// </summary>
        public string ShareImageUrl { get; set; }

        /// <summary>
        /// 二维码参考坐标类型：1左上，2中上，3右上……
        /// </summary>
        public int QrcodePositionType { get; set; }

        /// <summary>
        /// 备用，分享二维码x坐标偏移
        /// </summary>
        public int QrcodeXPosition { get; set; }

        /// <summary>
        /// 备用，分享二维码y坐标偏移
        /// </summary>
        public int QrcodeYPosition { get; set; }

        /// <summary>
        /// 备用，分享二维码尺寸
        /// </summary>
        public int QrcodeSize { get; set; }

        /// <summary>
        /// 仅能在微信浏览器中浏览
        /// </summary>
        public bool OnlyWechatBrowser { get; set; }

        /// <summary>
        /// 开启二维码分享
        /// </summary>
        public bool ShareQrcodeEnable { get; set; }

        /// <summary>
        /// 生成关注公众号类型的二维码，否则使用MetaLinkUrl值+个人区分码，或使用当前页面链接+个人区分码
        /// </summary>
        public bool CreatSubscribeQrcode { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether the entity is subject to ACL
        /// </summary>
        public bool SubjectToAcl { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether the entity is limited/restricted to certain stores
        /// </summary>
        public bool LimitedToStores { get; set; }

        /// <summary>
        /// 开始时间
        /// </summary>
        public DateTime? StartDateTimeUtc { get; set; }

        /// <summary>
        /// 结束时间
        /// </summary>
        public DateTime? EndDateTimeUtc { get; set; }

        /// <summary>
        /// 更新时间，可用于自定义展示时间
        /// </summary>
        public DateTime? UpdateDateTimeUtc { get; set; }

        /// <summary>
        /// Gets or sets the date and time of entity creation
        /// </summary>
        public DateTime CreatedOnUtc { get; set; }
    }
}
