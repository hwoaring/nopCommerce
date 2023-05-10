using Nop.Core.Domain.Common;
using Nop.Core.Domain.Localization;
using Nop.Core.Domain.Seo;

namespace Nop.Core.Domain.Vendors
{
    /// <summary>
    /// Represents a vendor
    /// </summary>
    public partial class Vendor : BaseEntity, ILocalizedEntity, ISlugSupported, ISoftDeletedEntity
    {
        /// <summary>
        /// 16位安全URL参数Id
        /// </summary>
        public string VendorSecretId { get; set; }

        /// <summary>
        /// Vendor类型：代理，门市，个人渠道
        /// </summary>
        public int VendorTypeId { get; set; }

        /// <summary>
        /// Gets or sets the name
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the email
        /// </summary>
        public string Email { get; set; }

        /// <summary>
        /// 联系电话
        /// </summary>
        public string PhoneNumber { get; set; }

        /// <summary>
        /// Gets or sets the description
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// Gets or sets the picture identifier
        /// </summary>
        public int PictureId { get; set; }

        /// <summary>
        /// Gets or sets the address identifier
        /// </summary>
        public int AddressId { get; set; }

        /// <summary>
        /// Gets or sets the admin comment
        /// </summary>
        public string AdminComment { get; set; }

        /// <summary>
        /// 是否有线下门店
        /// </summary>
        public bool HasVendorStore { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether the entity is active
        /// </summary>
        public bool Active { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether the entity has been deleted
        /// </summary>
        public bool Deleted { get; set; }

        /// <summary>
        /// Gets or sets the display order
        /// </summary>
        public int DisplayOrder { get; set; }

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
        /// 浏览次数
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
        /// 锁定
        /// </summary>
        public bool Locked { get; set; }

        /// <summary>
        /// 审核通过
        /// </summary>
        public bool Approved { get; set; }

        /// <summary>
        /// Gets or sets the page size
        /// </summary>
        public int PageSize { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether customers can select the page size
        /// </summary>
        public bool AllowCustomersToSelectPageSize { get; set; }

        /// <summary>
        /// Gets or sets the available customer selectable page size options
        /// </summary>
        public string PageSizeOptions { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether the price range filtering is enabled
        /// </summary>
        public bool PriceRangeFiltering { get; set; }

        /// <summary>
        /// Gets or sets the "from" price
        /// </summary>
        public decimal PriceFrom { get; set; }

        /// <summary>
        /// Gets or sets the "to" price
        /// </summary>
        public decimal PriceTo { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether the price range should be entered manually
        /// </summary>
        public bool ManuallyPriceRange { get; set; }
    }
}
