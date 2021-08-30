using FluentMigrator;
using Nop.Core.Domain.Affiliates;
using Nop.Core.Domain.Blogs;
using Nop.Core.Domain.Catalog;
using Nop.Core.Domain.Common;
using Nop.Core.Domain.Configuration;
using Nop.Core.Domain.Customers;
using Nop.Core.Domain.Directory;
using Nop.Core.Domain.Discounts;
using Nop.Core.Domain.Forums;
using Nop.Core.Domain.Gdpr;
using Nop.Core.Domain.Localization;
using Nop.Core.Domain.Logging;
using Nop.Core.Domain.Marketing;
using Nop.Core.Domain.Media;
using Nop.Core.Domain.Messages;
using Nop.Core.Domain.News;
using Nop.Core.Domain.Orders;
using Nop.Core.Domain.Polls;
using Nop.Core.Domain.Security;
using Nop.Core.Domain.Seo;
using Nop.Core.Domain.Shipping;
using Nop.Core.Domain.Suppliers;
using Nop.Core.Domain.Stores;
using Nop.Core.Domain.Tasks;
using Nop.Core.Domain.Tax;
using Nop.Core.Domain.Topics;
using Nop.Core.Domain.Vendors;
using Nop.Core.Domain.Weixin;
using Nop.Data.Extensions;

namespace Nop.Data.Migrations
{
    [SkipMigrationOnUpdate]
    [NopMigration("2020/01/31 11:24:16:2551771", "Nop.Data base schema")]
    public class SchemaMigration : AutoReversingMigration
    {
        /// <summary>
        /// Collect the UP migration expressions
        /// <remarks>
        /// We use an explicit table creation order instead of an automatic one
        /// due to problems creating relationships between tables
        /// </remarks>
        /// </summary>
        public override void Up()
        {
            Create.TableFor<AddressAttribute>();
            Create.TableFor<AddressAttributeValue>();
            Create.TableFor<GenericAttribute>();
            Create.TableFor<SearchTerm>();
            Create.TableFor<Country>();
            Create.TableFor<Currency>();
            Create.TableFor<MeasureDimension>();
            Create.TableFor<MeasureWeight>();
            Create.TableFor<StateProvince>();
            Create.TableFor<Address>();
            Create.TableFor<Affiliate>();
            Create.TableFor<CustomerAttribute>();
            Create.TableFor<CustomerAttributeValue>();
            Create.TableFor<Customer>();
            Create.TableFor<CustomerPassword>();
            Create.TableFor<CustomerAddressMapping>();
            Create.TableFor<CustomerRole>();
            Create.TableFor<CustomerCustomerRoleMapping>();
            Create.TableFor<ExternalAuthenticationRecord>();
            Create.TableFor<CheckoutAttribute>();
            Create.TableFor<CheckoutAttributeValue>();
            Create.TableFor<ReturnRequestAction>();
            Create.TableFor<ReturnRequest>();
            Create.TableFor<ReturnRequestReason>();
            Create.TableFor<ProductAttribute>();
            Create.TableFor<PredefinedProductAttributeValue>();
            Create.TableFor<ProductTag>();
            Create.TableFor<Product>();
            Create.TableFor<ProductTemplate>();
            Create.TableFor<BackInStockSubscription>();
            Create.TableFor<RelatedProduct>();
            Create.TableFor<ReviewType>();
            Create.TableFor<SpecificationAttributeGroup>();
            Create.TableFor<SpecificationAttribute>();
            Create.TableFor<ProductAttributeCombination>();
            Create.TableFor<ProductAttributeMapping>();
            Create.TableFor<ProductAttributeValue>();
            Create.TableFor<Order>();
            Create.TableFor<OrderItem>();
            Create.TableFor<RewardPointsHistory>();
            Create.TableFor<GiftCard>();
            Create.TableFor<GiftCardUsageHistory>();
            Create.TableFor<OrderNote>();
            Create.TableFor<RecurringPayment>();
            Create.TableFor<RecurringPaymentHistory>();
            Create.TableFor<ShoppingCartItem>();
            Create.TableFor<Store>();
            Create.TableFor<StoreMapping>();
            Create.TableFor<Language>();
            Create.TableFor<LocaleStringResource>();
            Create.TableFor<LocalizedProperty>();
            Create.TableFor<BlogPost>();
            Create.TableFor<BlogComment>();
            Create.TableFor<Category>();
            Create.TableFor<CategoryTemplate>();
            Create.TableFor<ProductCategory>();
            Create.TableFor<CrossSellProduct>();
            Create.TableFor<Manufacturer>();
            Create.TableFor<ManufacturerTemplate>();
            Create.TableFor<ProductManufacturer>();
            Create.TableFor<ProductProductTagMapping>();
            Create.TableFor<ProductReview>();
            Create.TableFor<ProductReviewHelpfulness>();
            Create.TableFor<ProductReviewReviewTypeMapping>();
            Create.TableFor<SpecificationAttributeOption>();
            Create.TableFor<ProductSpecificationAttribute>();
            Create.TableFor<TierPrice>();
            Create.TableFor<Warehouse>();
            Create.TableFor<DeliveryDate>();
            Create.TableFor<ProductAvailabilityRange>();
            Create.TableFor<Shipment>();
            Create.TableFor<ShipmentItem>();
            Create.TableFor<ShippingMethod>();
            Create.TableFor<ShippingMethodCountryMapping>();
            Create.TableFor<ProductWarehouseInventory>();
            Create.TableFor<StockQuantityHistory>();
            Create.TableFor<Download>();
            Create.TableFor<Picture>();
            Create.TableFor<PictureBinary>();
            Create.TableFor<ProductPicture>();
            Create.TableFor<Setting>();
            Create.TableFor<Discount>();
            Create.TableFor<DiscountCategoryMapping>();
            Create.TableFor<DiscountProductMapping>();
            Create.TableFor<DiscountRequirement>();
            Create.TableFor<DiscountUsageHistory>();
            Create.TableFor<DiscountManufacturerMapping>();
            Create.TableFor<PrivateMessage>();
            Create.TableFor<ForumGroup>();
            Create.TableFor<Forum>();
            Create.TableFor<ForumTopic>();
            Create.TableFor<ForumPost>();
            Create.TableFor<ForumPostVote>();
            Create.TableFor<ForumSubscription>();
            Create.TableFor<GdprConsent>();
            Create.TableFor<GdprLog>();
            Create.TableFor<ActivityLogType>();
            Create.TableFor<ActivityLog>();
            Create.TableFor<Log>();
            Create.TableFor<Campaign>();
            Create.TableFor<EmailAccount>();
            Create.TableFor<MessageTemplate>();
            Create.TableFor<NewsLetterSubscription>();
            Create.TableFor<QueuedEmail>();
            Create.TableFor<NewsItem>();
            Create.TableFor<NewsComment>();
            Create.TableFor<Poll>();
            Create.TableFor<PollAnswer>();
            Create.TableFor<PollVotingRecord>();
            Create.TableFor<AclRecord>();
            Create.TableFor<PermissionRecord>();
            Create.TableFor<PermissionRecordCustomerRoleMapping>();
            Create.TableFor<UrlRecord>();
            Create.TableFor<ScheduleTask>();
            Create.TableFor<TaxCategory>();
            Create.TableFor<TopicTemplate>();
            Create.TableFor<Topic>();
            Create.TableFor<Vendor>();
            Create.TableFor<VendorAttribute>();
            Create.TableFor<VendorAttributeValue>();
            Create.TableFor<VendorNote>();

            //==============
            //New Table
            //==============

            Create.TableFor<CityCounty>();
            Create.TableFor<DivisionsCode>();
            Create.TableFor<ProductComment>();
            Create.TableFor<ProductLableGroup>();
            Create.TableFor<ProductLable>();
            Create.TableFor<ProductProductLableMapping>();
            Create.TableFor<StoreRegionalContact>();
            Create.TableFor<TierDeductPrice>();
            Create.TableFor<ExpressCompany>();
            Create.TableFor<ProductCommentPicture>();
            Create.TableFor<DiscountCustomerMapping>();
            Create.TableFor<NewsCategory>();
            Create.TableFor<NewsAlbums>();
            Create.TableFor<NewsTags>();
            Create.TableFor<NewsNewsTagMapping>();
            Create.TableFor<VendorPageAnalyse>();
            Create.TableFor<VendorCustomerForm>();
            Create.TableFor<VendorSms>();
            Create.TableFor<VendorSmsHistory>();
            Create.TableFor<VendorSelfPrice>();
            Create.TableFor<VendorRegion>();

            Create.TableFor<ProductVendorMapping>();
            Create.TableFor<CategoryVendorMapping>();

            //Weixin
            Create.TableFor<WxConfig>();

            Create.TableFor<WxUser>();
            Create.TableFor<WxAddress>();
            Create.TableFor<WxUserTag>();
            Create.TableFor<WxUserSysTag>();
            Create.TableFor<WxUserUserSysTagMapping>();
            Create.TableFor<WxBrowserCheck>();

            Create.TableFor<WxLocation>();
            Create.TableFor<WxMenu>();
            Create.TableFor<WxMenuButton>();
            Create.TableFor<WxMessage>();
            Create.TableFor<WxOauth>();
            Create.TableFor<WxMessageBindMapping>();

            Create.TableFor<WxAutoreplyNewsInfo>();

            Create.TableFor<WxMessageAutoReply>();
            Create.TableFor<WxKeywordAutoreplyKeyword>();
            Create.TableFor<WxKeywordAutoreplyReply>();
            

            Create.TableFor<WxShareLink>();
            Create.TableFor<WxJSDKShare>();
            Create.TableFor<WxShareCount>();
            
            Create.TableFor<QrCodeCategory>();
            Create.TableFor<QrCodeChannel>();
            Create.TableFor<QrCodeLimit>();
            
            Create.TableFor<QrCodeLimitUserMapping>();
            Create.TableFor<QrCodeLimitBindingSource>();

            Create.TableFor<QrCodeTemp>();

            //Supplier
            Create.TableFor<Supplier>();
            Create.TableFor<SupplierShop>();
            Create.TableFor<SupplierShopTag>();
            Create.TableFor<SupplierSelfGroup>();
            Create.TableFor<SupplierImage>();
            Create.TableFor<SupplierProductMapping>();
            Create.TableFor<SupplierUserAuthorityMapping>();
            Create.TableFor<SupplierShopTagMapping>();
            Create.TableFor<SupplierShopUserFollowMapping>();

            Create.TableFor<SupplierVoucherCoupon>();
            Create.TableFor<SupplierVoucherCouponAppliedValue>();
            Create.TableFor<ProductSupplierVoucherCouponMapping>();
            Create.TableFor<QrCodeSupplierVoucherCouponMapping>();
            Create.TableFor<UserSupplierVoucherCoupon>();

            Create.TableFor<ProductAdvertImage>();
            Create.TableFor<MarketingAdvertWay>();
            Create.TableFor<MarketingAdvertAddress>();
            Create.TableFor<UserAdvertChannelAnalysis>();

            Create.TableFor<ProductExtendLabel>();
            Create.TableFor<ProductMarketLabel>();
            Create.TableFor<PromotionCommission>();
            Create.TableFor<ActivitiesTheme>();
            Create.TableFor<CustomTeam>();
            Create.TableFor<CustomTeamOrder>();
            Create.TableFor<OfficialCustomer>();
            Create.TableFor<PartnerApplicationForm>();
            Create.TableFor<PartnerServiceInfo>();
            Create.TableFor<ProductActivitiesThemeMapping>();
            Create.TableFor<ProductGiftProductMapping>();
            Create.TableFor<ProductProductExtendLabelMapping>();
            Create.TableFor<ProductProductMarketLabelMapping>();
            Create.TableFor<ProductUserFollowMapping>();
            Create.TableFor<ProductVisitorMapping>();
            
            Create.TableFor<UserAsset>();
            Create.TableFor<UserAssetIncomeHistory>();
            Create.TableFor<UserAssetConsumeHistory>();

        }
    }
}
