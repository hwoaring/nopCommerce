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
        /// Gets or sets the name
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the email
        /// </summary>
        public string Email { get; set; }

        /// <summary>
        /// Gets or sets the description
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// 店铺名称（线下店铺名称）
        /// </summary>
        public string StoreName { get; set; }

        /// <summary>
        /// 个人促销信息
        /// </summary>
        public string PromotionInfo { get; set; }

        /// <summary>
        /// 联系电话
        /// </summary>
        public string ContactNumber { get; set; }

        /// <summary>
        /// 联系地址
        /// </summary>
        public string ContactAddress { get; set; }

        /// <summary>
        /// 商城购买链接（或第三方商城）
        /// </summary>
        public string ShoppingMallLink{ get; set; }

        /// <summary>
        /// 营业时间
        /// </summary>
        public string OpenHours { get; set; }

        /// <summary>
        /// Gets or sets the picture identifier
        /// </summary>
        public int PictureId { get; set; }

        /// <summary>
        /// 二维码图片ID
        /// </summary>
        public int QrCodeId { get; set; }

        /// <summary>
        /// 提货点环境（门头）照片ID
        /// </summary>
        public int StorePictureId { get; set; }

        /// <summary>
        /// 地理位置纬度
        /// </summary>
        public decimal Latitude { get; set; }

        /// <summary>
        /// 地理位置经度
        /// </summary>
        public decimal Longitude { get; set; }

        /// <summary>
        /// 地理位置精度
        /// </summary>
        public decimal Precision { get; set; }

        /// <summary>
        /// Gets or sets the address identifier
        /// </summary>
        public int AddressId { get; set; }

        /// <summary>
        /// Gets or sets the admin comment
        /// </summary>
        public string AdminComment { get; set; }

        /// <summary>
        /// 是否显示商城购买链接
        /// </summary>
        public bool ShowShoppingMallLink { get; set; }

        /// <summary>
        /// 是否允许在线购买（指在本地平台显示购买按钮）
        /// </summary>
        public bool AllowBuyOnline { get; set; }

        /// <summary>
        /// 显示信息收集表单
        /// </summary>
        public bool DisplayForm { get; set; }

        /// <summary>
        /// 显示默认信息
        /// </summary>
        public bool DisplayDefaultInfo { get; set; }

        /// <summary>
        /// 使用AddressId地址信息
        /// </summary>
        public bool UseAddressId { get; set; }

        /// <summary>
        /// 是否拥有实体店铺（针对有共享实体店铺的人）
        /// </summary>
        public bool HasStores { get; set; }

        /// <summary>
        /// 无现货（缺货）
        /// </summary>
        public bool OutOfStock { get; set; }

        /// <summary>
        /// 是否暂停营业（休假中）
        /// </summary>
        public bool Suspended { get; set; }

        /// <summary>
        /// 仅显示扫码价格（部分商家要加价卖，不显示零售价）
        /// </summary>
        public bool ScanCodePrice { get; set; }

        /// <summary>
        /// 是否临时供应商
        /// </summary>
        public bool IsTemporary { get; set; }

        /// <summary>
        /// 能对外招商
        /// </summary>
        public bool IsMerchants { get; set; }

        /// <summary>
        /// 是否前台展示
        /// </summary>
        public bool Displayed { get; set; }

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
        /// Gets or sets the meta image，SEO image or weixin share image
        /// </summary>
        public string MetaImageUrl { get; set; }

        /// <summary>
        /// Gets or sets the meta Link
        /// </summary>
        public string MetaLinkUrl { get; set; }

        /// <summary>
        /// Gets or sets the share big size image
        /// </summary>
        public string ShareImageUrl { get; set; }

        /// <summary>
        /// 指定个人分享链接页面，用于自己用该链接生成二维码，与MetaLinkUrl（当前页分享链接）不同
        /// </summary>
        public string ShareLinkUrl { get; set; }

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
