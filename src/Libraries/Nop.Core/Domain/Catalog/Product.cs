using Nop.Core.Domain.Common;
using Nop.Core.Domain.Discounts;
using Nop.Core.Domain.Localization;
using Nop.Core.Domain.Security;
using Nop.Core.Domain.Seo;
using Nop.Core.Domain.Stores;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Nop.Core.Domain.Catalog;

/// <summary>
/// Represents a product
/// </summary>
public partial class Product : BaseEntity, ILocalizedEntity, ISlugSupported, IAclSupported, IStoreMappingSupported, IDiscountSupported<DiscountProductMapping>, ISoftDeletedEntity
{
    /// <summary>
    /// Gets or sets the product type identifier
    /// </summary>
    public int ProductTypeId { get; set; }

    /// <summary>
    /// Gets or sets the parent product identifier. It's used to identify associated products (only with "grouped" products)
    /// </summary>
    public int ParentGroupedProductId { get; set; }

    /// <summary>
    /// Gets or sets the values indicating whether this product is visible in catalog or search results.
    /// It's used when this product is associated to some "grouped" one
    /// This way associated products could be accessed/added/etc only from a grouped product details page
    /// </summary>
    public bool VisibleIndividually { get; set; }

    /// <summary>
    /// Gets or sets the name
    /// </summary>
    public string Name { get; set; }

    /// <summary>
    /// Gets or sets the short description
    /// </summary>
    public string ShortDescription { get; set; }

    /// <summary>
    /// Gets or sets the full description
    /// </summary>
    public string FullDescription { get; set; }

    /// <summary>
    /// Gets or sets the admin comment
    /// </summary>
    public string AdminComment { get; set; }

    /// <summary>
    /// Gets or sets a value of used product template identifier
    /// </summary>
    public int ProductTemplateId { get; set; }

    /// <summary>
    /// Gets or sets a vendor identifier
    /// </summary>
    public int VendorId { get; set; }

    /// <summary>
    /// Gets or sets a value indicating whether to show the product on home page
    /// </summary>
    public bool ShowOnHomepage { get; set; }

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
    /// Gets or sets a value indicating whether the product allows customer reviews
    /// </summary>
    public bool AllowCustomerReviews { get; set; }

    /// <summary>
    /// Gets or sets the rating sum (approved reviews)
    /// </summary>
    public int ApprovedRatingSum { get; set; }

    /// <summary>
    /// Gets or sets the rating sum (not approved reviews)
    /// </summary>
    public int NotApprovedRatingSum { get; set; }

    /// <summary>
    /// Gets or sets the total rating votes (approved reviews)
    /// </summary>
    public int ApprovedTotalReviews { get; set; }

    /// <summary>
    /// Gets or sets the total rating votes (not approved reviews)
    /// </summary>
    public int NotApprovedTotalReviews { get; set; }

    /// <summary>
    /// Gets or sets a value indicating whether the entity is subject to ACL
    /// </summary>
    public bool SubjectToAcl { get; set; }

    /// <summary>
    /// Gets or sets a value indicating whether the entity is limited/restricted to certain stores
    /// </summary>
    public bool LimitedToStores { get; set; }

    /// <summary>
    /// Gets or sets the SKU
    /// </summary>
    public string Sku { get; set; }

    /// <summary>
    /// Gets or sets the manufacturer part number
    /// </summary>
    public string ManufacturerPartNumber { get; set; }

    /// <summary>
    /// Gets or sets the Global Trade Item Number (GTIN). These identifiers include UPC (in North America), EAN (in Europe), JAN (in Japan), and ISBN (for books).
    /// </summary>
    public string Gtin { get; set; }

    /// <summary>
    /// Gets or sets a value indicating whether the product is gift card
    /// </summary>
    public bool IsGiftCard { get; set; }

    /// <summary>
    /// Gets or sets the gift card type identifier
    /// </summary>
    public int GiftCardTypeId { get; set; }

    /// <summary>
    /// Gets or sets gift card amount that can be used after purchase. If not specified, then product price will be used.
    /// </summary>
    public decimal? OverriddenGiftCardAmount { get; set; }

    /// <summary>
    /// Gets or sets a value indicating whether the product requires that other products are added to the cart (Product X requires Product Y)
    /// </summary>
    public bool RequireOtherProducts { get; set; }

    /// <summary>
    /// Gets or sets a required product identifiers (comma separated)
    /// </summary>
    public string RequiredProductIds { get; set; }

    /// <summary>
    /// Gets or sets a value indicating whether required products are automatically added to the cart
    /// </summary>
    public bool AutomaticallyAddRequiredProducts { get; set; }

    /// <summary>
    /// Gets or sets a value indicating whether the product is download
    /// </summary>
    public bool IsDownload { get; set; }

    /// <summary>
    /// Gets or sets the download identifier
    /// </summary>
    public int DownloadId { get; set; }

    /// <summary>
    /// Gets or sets a value indicating whether this downloadable product can be downloaded unlimited number of times
    /// </summary>
    public bool UnlimitedDownloads { get; set; }

    /// <summary>
    /// Gets or sets the maximum number of downloads
    /// </summary>
    public int MaxNumberOfDownloads { get; set; }

    /// <summary>
    /// Gets or sets the number of days during customers keeps access to the file.
    /// </summary>
    public int? DownloadExpirationDays { get; set; }

    /// <summary>
    /// Gets or sets the download activation type
    /// </summary>
    public int DownloadActivationTypeId { get; set; }

    /// <summary>
    /// Gets or sets a value indicating whether the product has a sample download file
    /// </summary>
    public bool HasSampleDownload { get; set; }

    /// <summary>
    /// Gets or sets the sample download identifier
    /// </summary>
    public int SampleDownloadId { get; set; }

    /// <summary>
    /// Gets or sets a value indicating whether the product has user agreement
    /// </summary>
    public bool HasUserAgreement { get; set; }

    /// <summary>
    /// Gets or sets the text of license agreement
    /// </summary>
    public string UserAgreementText { get; set; }

    /// <summary>
    /// Gets or sets a value indicating whether the product is recurring
    /// </summary>
    public bool IsRecurring { get; set; }

    /// <summary>
    /// Gets or sets the cycle length
    /// </summary>
    public int RecurringCycleLength { get; set; }

    /// <summary>
    /// Gets or sets the cycle period
    /// </summary>
    public int RecurringCyclePeriodId { get; set; }

    /// <summary>
    /// Gets or sets the total cycles
    /// </summary>
    public int RecurringTotalCycles { get; set; }

    /// <summary>
    /// Gets or sets a value indicating whether the product is rental
    /// </summary>
    public bool IsRental { get; set; }

    /// <summary>
    /// Gets or sets the rental length for some period (price for this period)
    /// </summary>
    public int RentalPriceLength { get; set; }

    /// <summary>
    /// Gets or sets the rental period (price for this period)
    /// </summary>
    public int RentalPricePeriodId { get; set; }

    /// <summary>
    /// Gets or sets a value indicating whether the entity is ship enabled
    /// </summary>
    public bool IsShipEnabled { get; set; }

    /// <summary>
    /// Gets or sets a value indicating whether the entity is free shipping
    /// </summary>
    public bool IsFreeShipping { get; set; }

    /// <summary>
    /// Gets or sets a value this product should be shipped separately (each item)
    /// </summary>
    public bool ShipSeparately { get; set; }

    /// <summary>
    /// Gets or sets the additional shipping charge
    /// </summary>
    public decimal AdditionalShippingCharge { get; set; }

    /// <summary>
    /// Gets or sets a delivery date identifier
    /// </summary>
    public int DeliveryDateId { get; set; }

    /// <summary>
    /// Gets or sets a value indicating whether the product is marked as tax exempt
    /// </summary>
    public bool IsTaxExempt { get; set; }

    /// <summary>
    /// Gets or sets the tax category identifier
    /// </summary>
    public int TaxCategoryId { get; set; }

    /// <summary>
    /// Gets or sets a value indicating how to manage inventory
    /// </summary>
    public int ManageInventoryMethodId { get; set; }

    /// <summary>
    /// Gets or sets a product availability range identifier
    /// </summary>
    public int ProductAvailabilityRangeId { get; set; }

    /// <summary>
    /// Gets or sets a value indicating whether multiple warehouses are used for this product
    /// </summary>
    public bool UseMultipleWarehouses { get; set; }

    /// <summary>
    /// Gets or sets a warehouse identifier
    /// </summary>
    public int WarehouseId { get; set; }

    /// <summary>
    /// Gets or sets the stock quantity
    /// </summary>
    public int StockQuantity { get; set; }

    /// <summary>
    /// Gets or sets a value indicating whether to display stock availability
    /// </summary>
    public bool DisplayStockAvailability { get; set; }

    /// <summary>
    /// Gets or sets a value indicating whether to display stock quantity
    /// </summary>
    public bool DisplayStockQuantity { get; set; }

    /// <summary>
    /// Gets or sets the minimum stock quantity
    /// </summary>
    public int MinStockQuantity { get; set; }

    /// <summary>
    /// Gets or sets the low stock activity identifier
    /// </summary>
    public int LowStockActivityId { get; set; }

    /// <summary>
    /// Gets or sets the quantity when admin should be notified
    /// </summary>
    public int NotifyAdminForQuantityBelow { get; set; }

    /// <summary>
    /// Gets or sets a value backorder mode identifier
    /// </summary>
    public int BackorderModeId { get; set; }

    /// <summary>
    /// Gets or sets a value indicating whether to back in stock subscriptions are allowed
    /// </summary>
    public bool AllowBackInStockSubscriptions { get; set; }

    /// <summary>
    /// Gets or sets the order minimum quantity
    /// </summary>
    public int OrderMinimumQuantity { get; set; }

    /// <summary>
    /// Gets or sets the order maximum quantity
    /// </summary>
    public int OrderMaximumQuantity { get; set; }

    /// <summary>
    /// Gets or sets the comma separated list of allowed quantities. null or empty if any quantity is allowed
    /// </summary>
    public string AllowedQuantities { get; set; }

    /// <summary>
    /// Gets or sets a value indicating whether we allow adding to the cart/wishlist only attribute combinations that exist and have stock greater than zero.
    /// This option is used only when we have "manage inventory" set to "track inventory by product attributes"
    /// </summary>
    public bool AllowAddingOnlyExistingAttributeCombinations { get; set; }

    /// <summary>
    /// Gets or sets a value indicating whether to display attribute combination images only
    /// </summary>
    public bool DisplayAttributeCombinationImagesOnly { get; set; }

    /// <summary>
    /// Gets or sets a value indicating whether this product is returnable (a customer is allowed to submit return request with this product)
    /// </summary>
    public bool NotReturnable { get; set; }

    /// <summary>
    /// Gets or sets a value indicating whether to disable buy (Add to cart) button
    /// </summary>
    public bool DisableBuyButton { get; set; }

    /// <summary>
    /// Gets or sets a value indicating whether to disable "Add to wishlist" button
    /// </summary>
    public bool DisableWishlistButton { get; set; }

    /// <summary>
    /// Gets or sets a value indicating whether this item is available for Pre-Order
    /// </summary>
    public bool AvailableForPreOrder { get; set; }

    /// <summary>
    /// Gets or sets the start date and time of the product availability (for pre-order products)
    /// </summary>
    public DateTime? PreOrderAvailabilityStartDateTimeUtc { get; set; }

    /// <summary>
    /// Gets or sets a value indicating whether to show "Call for Pricing" or "Call for quote" instead of price
    /// </summary>
    public bool CallForPrice { get; set; }

    /// <summary>
    /// Gets or sets the price
    /// </summary>
    public decimal Price { get; set; }

    /// <summary>
    /// Gets or sets the old price
    /// </summary>
    public decimal OldPrice { get; set; }

    /// <summary>
    /// Gets or sets the product cost（进货底价、成本价）
    /// </summary>
    public decimal ProductCost { get; set; }

    /// <summary>
    /// Gets or sets a value indicating whether a customer enters price
    /// </summary>
    public bool CustomerEntersPrice { get; set; }

    /// <summary>
    /// Gets or sets the minimum price entered by a customer
    /// </summary>
    public decimal MinimumCustomerEnteredPrice { get; set; }

    /// <summary>
    /// Gets or sets the maximum price entered by a customer
    /// </summary>
    public decimal MaximumCustomerEnteredPrice { get; set; }

    /// <summary>
    /// Gets or sets a value indicating whether base price (PAngV) is enabled. Used by German users.
    /// </summary>
    public bool BasepriceEnabled { get; set; }

    /// <summary>
    /// Gets or sets an amount in product for PAngV
    /// </summary>
    public decimal BasepriceAmount { get; set; }

    /// <summary>
    /// Gets or sets a unit of product for PAngV (MeasureWeight entity)
    /// </summary>
    public int BasepriceUnitId { get; set; }

    /// <summary>
    /// Gets or sets a reference amount for PAngV
    /// </summary>
    public decimal BasepriceBaseAmount { get; set; }

    /// <summary>
    /// Gets or sets a reference unit for PAngV (MeasureWeight entity)
    /// </summary>
    public int BasepriceBaseUnitId { get; set; }

    /// <summary>
    /// Gets or sets a value indicating whether this product is marked as new
    /// </summary>
    public bool MarkAsNew { get; set; }

    /// <summary>
    /// Gets or sets the start date and time of the new product (set product as "New" from date). Leave empty to ignore this property
    /// </summary>
    public DateTime? MarkAsNewStartDateTimeUtc { get; set; }

    /// <summary>
    /// Gets or sets the end date and time of the new product (set product as "New" to date). Leave empty to ignore this property
    /// </summary>
    public DateTime? MarkAsNewEndDateTimeUtc { get; set; }

    /// <summary>
    /// Gets or sets the weight
    /// </summary>
    public decimal Weight { get; set; }

    /// <summary>
    /// Gets or sets the length
    /// </summary>
    public decimal Length { get; set; }

    /// <summary>
    /// Gets or sets the width
    /// </summary>
    public decimal Width { get; set; }

    /// <summary>
    /// Gets or sets the height
    /// </summary>
    public decimal Height { get; set; }

    /// <summary>
    /// Gets or sets the available start date and time
    /// </summary>
    public DateTime? AvailableStartDateTimeUtc { get; set; }

    /// <summary>
    /// Gets or sets the available end date and time
    /// </summary>
    public DateTime? AvailableEndDateTimeUtc { get; set; }

    /// <summary>
    /// Gets or sets a display order.
    /// This value is used when sorting associated products (used with "grouped" products)
    /// This value is used when sorting home page products
    /// </summary>
    public int DisplayOrder { get; set; }

    /// <summary>
    /// Gets or sets a value indicating whether the entity is published
    /// </summary>
    public bool Published { get; set; }

    /// <summary>
    /// Gets or sets a value indicating whether the entity has been deleted
    /// </summary>
    public bool Deleted { get; set; }

    /// <summary>
    /// Gets or sets the date and time of product creation
    /// </summary>
    public DateTime CreatedOnUtc { get; set; }

    /// <summary>
    /// Gets or sets the date and time of product update
    /// </summary>
    public DateTime UpdatedOnUtc { get; set; }


    #region === 扩展属性 ===

    /// <summary>
    /// 对外展示统一加密id（URL参数）
    /// </summary>
    public long UnifiedId { get; set; }

    /// <summary>
    /// 产品标语
    /// </summary>
    public string Slogan { get; set; }

    /// <summary>
    /// 产品标语链接地址
    /// </summary>
    public string SloganUrl { get; set; }

    /// <summary>
    /// 产品标语链接文字
    /// </summary>
    public string SloganUrlText { get; set; }

    /// <summary>
    /// 使用规则（使用限制信息）
    /// </summary>
    public string UsageRulesContent { get; set; }

    /// <summary>
    /// 售后服务内容
    /// </summary>
    public string AfterSaleService { get; set; }

    /// <summary>
    /// 跳转链接，在列表页点击详情链接跳转（可用于三方购买链接使用）
    /// </summary>
    public string Url { get; set; }

    /// <summary>
    /// 支付页标题（可以使用通配符替换）
    /// </summary>
    public string PaymentPageTitle { get; set; }

    /// <summary>
    /// 支付页描述（可以使用通配符替换）
    /// </summary>
    public string PaymentPageDescription { get; set; }

    /// <summary>
    /// 延时支付分钟数（默认=0未单独设置，默认为3天，如果产品单独设置后，采用产品设置）
    /// 订单支付过期秒数（过期前支付，产品单独设置主要用于抢购商品）
    /// 支付时效
    /// </summary>
    public int PaymentDelayMinutes { get; set; }

    /// <summary>
    /// 货款结算延迟天数或佣金结算延迟天数
    /// （根据产品类型确定在不同产品结算延迟不同天数）
    /// 总延迟结算天数为：该产品设置的延迟天数+OrderSetting中设置的天数
    /// 必须大于或等于0
    /// </summary>
    public int SettleDelayDays { get; set; }

    /// <summary>
    /// 商标/品牌ID
    /// </summary>
    public int BrandId { get; set; }

    /// <summary>
    /// 封面图(长图或大图)
    /// </summary>
    public int CoverPictureId { get; set; }

    /// <summary>
    /// 缩微图（方图或小图）
    /// </summary>
    public int CoverThumbPictureId { get; set; }

    /// <summary>
    /// 产品透明图片ID
    /// </summary>
    public int TransparentPictureId { get; set; }

    /// <summary>
    /// 产品条码号，即UPC编码
    /// </summary>
    public long ProductBarCode { get; set; }

    /// <summary>
    /// 开启浏览统计
    /// </summary>
    public bool EnableViewsCount { get; set; }

    /// <summary>
    /// 浏览量（实际浏览量）
    /// </summary>
    public int ViewsCount { get; set; }

    /// <summary>
    /// 超库存销售（延期销售库存数）：超出库存量继续销售的最大数量（超出库存的订单作为延期发货订单，如果没有人退单，则退款）
    /// 延期发货订单进入排队队列。
    /// </summary>
    public int MaxBackOrderStockQuantity { get; set; }

    /// <summary>
    /// 超库存销售（延期销售库存数）：延期发货订单提醒客户的信息
    /// </summary>
    public string BackOrderNotice { get; set; }

    /// <summary>
    /// 平台交易费率（成交后扣除费率，商品指定费率优先，其次时候分类指定的费率）
    /// 可以在Category中指定，如果Product再次指定就采用Product费率
    /// </summary>
    public decimal PlatformRate { get; set; }

    /// <summary>
    /// 基础销售量（增加数据销量效果，并非实际销量）
    /// </summary>
    public int BaseSalesCount { get; set; }

    /// <summary>
    /// 分销底价（备用）
    /// </summary>
    public decimal ShareBasePrice { get; set; }

    /// <summary>
    /// 广告分享抵用：最高使用金额
    /// </summary>
    public decimal MaxAdvertAmounts { get; set; }

    /// <summary>
    /// 积分抵用：必须使用积分数量
    /// </summary>
    public decimal RequirePoints { get; set; }

    /// <summary>
    /// 使用会员等级价格规则
    /// </summary>
    public bool UseCustomerPriceRules { get; set; }

    /// <summary>
    /// 使用会员等级价格规则ID
    /// </summary>
    public int CustomerPriceRulesId { get; set; }

    /// <summary>
    /// 使用会员等级积分购买规则
    /// </summary>
    public bool UseCustomerPointRules { get; set; }

    /// <summary>
    /// 使用会员等级积分购买规则ID
    /// </summary>
    public int CustomerPointRulesId { get; set; }

    /// <summary>
    /// 使用会员等级分享广告规则
    /// </summary>
    public bool UseCustomerAdvertRules { get; set; }

    /// <summary>
    /// 使用会员等级分享广告规则ID
    /// </summary>
    public int CustomerAdvertRulesId { get; set; }

    /// <summary>
    /// 仅新用户可购买
    /// </summary>
    public bool NewUserOnly { get; set; }

    /// <summary>
    /// 设置为热卖
    /// </summary>
    public bool MarkAsHot { get; set; }

    /// <summary>
    /// 设置为推荐
    /// </summary>
    public bool MarkAsRecommend { get; set; }

    /// <summary>
    /// 平台自营产品（拥有自主定价权和促销活动策划权）
    /// </summary>
    public bool SelfOperated { get; set; }

    /// <summary>
    /// 是否定制产品
    /// </summary>
    public bool CustomizedProducts { get; set; }

    /// <summary>
    /// 是否允许评论
    /// </summary>
    public bool AllowComments { get; set; }

    /// <summary>
    /// 产品购买后是否获得积分
    /// </summary>
    public bool EnablePoints { get; set; }

    /// <summary>
    /// 产品需要后台验证审核后才能付款
    /// </summary>
    public bool OrderRequireVerify { get; set; }

    /// <summary>
    /// 产品是否需要验证码购买（验证码通过绑定的手机号发送）
    /// </summary>
    public bool OrderRequireVerifyCode { get; set; }

    /// <summary>
    /// 产品是否通过审核（编辑或其他商家上的产品需要先通过审核）
    /// </summary>
    public bool Audited { get; set; }

    /// <summary>
    /// 只展示给对应供应商（不对外公开）
    /// 限制到Vendor（产品绑定了Vendor后，只能对应Vendor可以访问查看。）
    /// </summary>
    public bool OnlyDisplayToVendor { get; set; }

    /// <summary>
    /// 库存减少方式：支付成功减少库存（否则为下单就减库存）
    /// </summary>
    public bool PaymentReduceInventory { get; set; }

    /// <summary>
    /// 是否支持货到付款（cash on delivery）
    /// </summary>
    public bool CODSupport { get; set; }

    /// <summary>
    /// 是否支持电子发票
    /// </summary>
    public bool SupportFapiao { get; set; }

    /// <summary>
    /// 是否特价商品（特价商品不参与某些优惠活动）
    /// </summary>
    public bool SpecialOfferProduct { get; set; }

    /// <summary>
    /// 一个用户24小时最大购买量（用户单次购买数量必须小于最大购买量和24小时最大购买量）
    /// </summary>
    public int OrderMaximumQuantity24Hour { get; set; }

    /// <summary>
    /// 是否允许代理商自定义价格
    /// </summary>
    public bool VendorEntersPrice { get; set; }

    /// <summary>
    /// 代理商自定义价格最低价
    /// </summary>
    public decimal MinVendorEnteredPrice { get; set; }

    /// <summary>
    /// 代理商自定义价格最高价
    /// </summary>
    public decimal MaxVendorEnteredPrice { get; set; }

    /// <summary>
    /// 该产品允许代理商自己出库发货（在代理商满足出库发货条件下）
    /// 允许从代理商仓库出库/发货
    /// </summary>
    public bool AllowVendorShipping { get; set; }

    /// <summary>
    /// 发货地-备用（可以存储AddressId或者区域代码，要固定一种格式）
    /// </summary>
    public int ShippingAddressId { get; set; }

    /// <summary>
    /// 满额免邮金额
    /// </summary>
    public decimal FreeShippingAmount { get; set; }

    /// <summary>
    /// 运费模板ID
    /// </summary>
    public int ShippingTemplateId { get; set; }

    /// <summary>
    /// 预售：预售结束时间
    /// </summary>
    public DateTime? PreOrderAvailabilityEndDateTimeUtc { get; set; }

    /// <summary>
    /// 预售，是否需要客户确定消费日期/使用时间/使用日期
    /// 弹出使用日期选项
    /// </summary>
    public bool UseFixedUsageDate { get; set; }

    /// <summary>
    /// 预售，使用指定的日期，或指定日期价格
    /// 当需要消费者选择使用（消费）日期时，可以指定可以选择的日期
    /// 也可以在指定日期中设置不同的价格或库存。
    /// 相应的设置在ProductDateAndPrice中
    /// </summary>
    public bool UseSchedulDateAndPrice { get; set; }

    /// <summary>
    /// 预售，有具体使用日期或消费日期的：最早可以提前几天下单（不能预定太久的产品）
    /// </summary>
    public int PreOrderEarliestDays { get; set; }

    /// <summary>
    /// 预售，有具体使用日期或消费日期的：最晚必须提前几天下单（后台可能要从官方出票，给客服预留出出票时间）
    /// </summary>
    public int PreOrderLatestDays { get; set; }

    /// <summary>
    /// 预售，有具体使用日期或消费日期的：最晚必须提前几天的具体时间前下单（后台可能要从官方出票）
    /// </summary>
    public int PreOrderLatestTime { get; set; }

    /// <summary>
    /// 卡券类型产品（需要填写卡券相关信息）
    /// </summary>
    public bool IsCouponCard { get; set; }

    /// <summary>
    /// 分销：该产品开启销售佣金功能
    /// </summary>
    public bool EnabledCommission { get; set; }

    /// <summary>
    /// 分销：佣金是否按销售价格百分比（否则按固定金额）
    /// </summary>
    public bool CommissionUsePercentage { get; set; }

    /// <summary>
    /// 分销：佣金金额/或佣金比例
    /// </summary>
    public decimal CommissionAmount { get; set; }

    /// <summary>
    /// 使用等级佣金规则
    /// </summary>
    public bool UseCustomerCommissionRules { get; set; }

    /// <summary>
    /// 使用等级佣金规则ID
    /// </summary>
    public int CustomerCommissionRulesId { get; set; }

    /// <summary>
    /// 是否折扣商品
    /// </summary>
    public bool DiscountedProduct { get; set; }

    /// <summary>
    /// 公开等级（备用）
    /// 大于等于设定等级的用户可以公开
    /// 或者只能通过分享链接访问，或者只能通过权限访问
    /// </summary>
    public int PublicDisplayCustomerLevel { get; set; }

    /// <summary>
    /// 购买需大于等于会员等级（0-不限会员等级）
    /// </summary>
    public int OrderLimitCustomerLevel { get; set; }

    /// <summary>
    /// 退款：支持无理由退货类型
    /// </summary>
    public int NoReasonReturnTypeId { get; set; }

    /// <summary>
    /// 退款：是否过期可退款（过期后仍然没有消费）
    /// </summary>
    public bool EnableExpiredReturn { get; set; }

    /// <summary>
    /// 退款：退货需要（在使用日期）前几天
    /// </summary>
    public bool ReturnNeedPreDays { get; set; }

    /// <summary>
    /// 退款：退货需要（在使用日期）前几天
    /// </summary>
    public int ReturnPreDays { get; set; }

    /// <summary>
    /// 退款：退货需要（在使用日期）前几天(具体到小时和分钟)
    /// </summary>
    public DateTime? ReturnPreTime { get; set; }

    /// <summary>
    /// 退款：手续费按百分比（否则按固定金额）
    /// </summary>
    public bool ReturnFeeByPercent { get; set; }

    /// <summary>
    /// 退款：免手续费退款，需要提前多少天（设置为0，表示始终有手续费）
    /// </summary>
    public int FreeReturnPredays { get; set; }

    /// <summary>
    /// 退款：手续费
    /// </summary>
    public decimal ReturnFee { get; set; }




    #endregion



    /// <summary>
    /// Gets or sets the product type
    /// </summary>
    public ProductType ProductType
    {
        get => (ProductType)ProductTypeId;
        set => ProductTypeId = (int)value;
    }

    /// <summary>
    /// Gets or sets the backorder mode
    /// </summary>
    public BackorderMode BackorderMode
    {
        get => (BackorderMode)BackorderModeId;
        set => BackorderModeId = (int)value;
    }

    /// <summary>
    /// Gets or sets the download activation type
    /// </summary>
    public DownloadActivationType DownloadActivationType
    {
        get => (DownloadActivationType)DownloadActivationTypeId;
        set => DownloadActivationTypeId = (int)value;
    }

    /// <summary>
    /// Gets or sets the gift card type
    /// </summary>
    public GiftCardType GiftCardType
    {
        get => (GiftCardType)GiftCardTypeId;
        set => GiftCardTypeId = (int)value;
    }

    /// <summary>
    /// Gets or sets the low stock activity
    /// </summary>
    public LowStockActivity LowStockActivity
    {
        get => (LowStockActivity)LowStockActivityId;
        set => LowStockActivityId = (int)value;
    }

    /// <summary>
    /// Gets or sets the value indicating how to manage inventory
    /// </summary>
    public ManageInventoryMethod ManageInventoryMethod
    {
        get => (ManageInventoryMethod)ManageInventoryMethodId;
        set => ManageInventoryMethodId = (int)value;
    }

    /// <summary>
    /// Gets or sets the cycle period for recurring products
    /// </summary>
    public RecurringProductCyclePeriod RecurringCyclePeriod
    {
        get => (RecurringProductCyclePeriod)RecurringCyclePeriodId;
        set => RecurringCyclePeriodId = (int)value;
    }

    /// <summary>
    /// Gets or sets the period for rental products
    /// </summary>
    public RentalPricePeriod RentalPricePeriod
    {
        get => (RentalPricePeriod)RentalPricePeriodId;
        set => RentalPricePeriodId = (int)value;
    }
}