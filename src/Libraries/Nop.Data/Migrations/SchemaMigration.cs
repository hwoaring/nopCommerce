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
            _migrationManager.BuildTable<AddressAttribute>(Create);
            _migrationManager.BuildTable<AddressAttributeValue>(Create);
            _migrationManager.BuildTable<GenericAttribute>(Create);
            _migrationManager.BuildTable<SearchTerm>(Create);
            _migrationManager.BuildTable<Country>(Create);
            _migrationManager.BuildTable<Currency>(Create);
            _migrationManager.BuildTable<MeasureDimension>(Create);
            _migrationManager.BuildTable<MeasureWeight>(Create);
            _migrationManager.BuildTable<StateProvince>(Create);
            _migrationManager.BuildTable<CityCounty>(Create);
            _migrationManager.BuildTable<DivisionsCode>(Create);
            _migrationManager.BuildTable<Address>(Create);
            _migrationManager.BuildTable<Affiliate>(Create);

            _migrationManager.BuildTable<CustomerAttribute>(Create);
            _migrationManager.BuildTable<CustomerAttributeValue>(Create);

            _migrationManager.BuildTable<Customer>(Create);
            _migrationManager.BuildTable<CustomerPassword>(Create);
            _migrationManager.BuildTable<CustomerAddressMapping>(Create);

            _migrationManager.BuildTable<CustomerRole>(Create);
            _migrationManager.BuildTable<CustomerCustomerRoleMapping>(Create);

            _migrationManager.BuildTable<ExternalAuthenticationRecord>(Create);

            _migrationManager.BuildTable<CheckoutAttribute>(Create);
            _migrationManager.BuildTable<CheckoutAttributeValue>(Create);

            _migrationManager.BuildTable<ReturnRequestAction>(Create);
            _migrationManager.BuildTable<ReturnRequest>(Create);
            _migrationManager.BuildTable<ReturnRequestReason>(Create);

            _migrationManager.BuildTable<ProductAttribute>(Create);
            _migrationManager.BuildTable<PredefinedProductAttributeValue>(Create);
            _migrationManager.BuildTable<ProductTag>(Create);

            _migrationManager.BuildTable<Product>(Create);
            _migrationManager.BuildTable<ProductTemplate>(Create);
            _migrationManager.BuildTable<ProductComment>(Create);
            _migrationManager.BuildTable<ProductLableGroup>(Create);
            _migrationManager.BuildTable<ProductLable>(Create);
            _migrationManager.BuildTable<BackInStockSubscription>(Create);
            _migrationManager.BuildTable<RelatedProduct>(Create);
            _migrationManager.BuildTable<ReviewType>(Create);
            _migrationManager.BuildTable<SpecificationAttributeGroup>(Create);
            _migrationManager.BuildTable<SpecificationAttribute>(Create);
            _migrationManager.BuildTable<ProductAttributeCombination>(Create);
            _migrationManager.BuildTable<ProductAttributeMapping>(Create);
            _migrationManager.BuildTable<ProductAttributeValue>(Create);
            _migrationManager.BuildTable<ProductProductLableMapping>(Create);

            _migrationManager.BuildTable<Order>(Create);
            _migrationManager.BuildTable<OrderItem>(Create);
            _migrationManager.BuildTable<RewardPointsHistory>(Create);

            _migrationManager.BuildTable<GiftCard>(Create);
            _migrationManager.BuildTable<GiftCardUsageHistory>(Create);

            _migrationManager.BuildTable<OrderNote>(Create);

            _migrationManager.BuildTable<RecurringPayment>(Create);
            _migrationManager.BuildTable<RecurringPaymentHistory>(Create);

            _migrationManager.BuildTable<ShoppingCartItem>(Create);

            _migrationManager.BuildTable<Store>(Create);
            _migrationManager.BuildTable<StoreMapping>(Create);
            _migrationManager.BuildTable<StoreRegionalContact>(Create);

            _migrationManager.BuildTable<Language>(Create);
            _migrationManager.BuildTable<LocaleStringResource>(Create);
            _migrationManager.BuildTable<LocalizedProperty>(Create);

            _migrationManager.BuildTable<BlogPost>(Create);
            _migrationManager.BuildTable<BlogComment>(Create);

            _migrationManager.BuildTable<Category>(Create);
            _migrationManager.BuildTable<CategoryTemplate>(Create);

            _migrationManager.BuildTable<ProductCategory>(Create);

            _migrationManager.BuildTable<CrossSellProduct>(Create);
            _migrationManager.BuildTable<Manufacturer>(Create);
            _migrationManager.BuildTable<ManufacturerTemplate>(Create);

            _migrationManager.BuildTable<ProductManufacturer>(Create);
            _migrationManager.BuildTable<ProductProductTagMapping>(Create);
            _migrationManager.BuildTable<ProductReview>(Create);

            _migrationManager.BuildTable<ProductReviewHelpfulness>(Create);
            _migrationManager.BuildTable<ProductReviewReviewTypeMapping>(Create);

            _migrationManager.BuildTable<SpecificationAttributeOption>(Create);
            _migrationManager.BuildTable<ProductSpecificationAttribute>(Create);

            _migrationManager.BuildTable<TierPrice>(Create);
            _migrationManager.BuildTable<TierDeductPrice>(Create);

            _migrationManager.BuildTable<Warehouse>(Create);
            _migrationManager.BuildTable<DeliveryDate>(Create);
            _migrationManager.BuildTable<ProductAvailabilityRange>(Create);
            _migrationManager.BuildTable<Shipment>(Create);
            _migrationManager.BuildTable<ShipmentItem>(Create);
            _migrationManager.BuildTable<ShippingMethod>(Create);
            _migrationManager.BuildTable<ShippingMethodCountryMapping>(Create);
            _migrationManager.BuildTable<ExpressCompany>(Create);

            _migrationManager.BuildTable<ProductWarehouseInventory>(Create);
            _migrationManager.BuildTable<StockQuantityHistory>(Create);

            _migrationManager.BuildTable<Download>(Create);
            _migrationManager.BuildTable<Picture>(Create);
            _migrationManager.BuildTable<PictureBinary>(Create);

            _migrationManager.BuildTable<ProductPicture>(Create);
            _migrationManager.BuildTable<ProductCommentPicture>(Create);

            _migrationManager.BuildTable<Setting>(Create);

            _migrationManager.BuildTable<Discount>(Create);

            _migrationManager.BuildTable<DiscountCustomerMapping>(Create);
            _migrationManager.BuildTable<DiscountCategoryMapping>(Create);
            _migrationManager.BuildTable<DiscountProductMapping>(Create);
            _migrationManager.BuildTable<DiscountRequirement>(Create);
            _migrationManager.BuildTable<DiscountUsageHistory>(Create);
            _migrationManager.BuildTable<DiscountManufacturerMapping>(Create);

            _migrationManager.BuildTable<PrivateMessage>(Create);
            _migrationManager.BuildTable<ForumGroup>(Create);
            _migrationManager.BuildTable<Forum>(Create);
            _migrationManager.BuildTable<ForumTopic>(Create);
            _migrationManager.BuildTable<ForumPost>(Create);
            _migrationManager.BuildTable<ForumPostVote>(Create);
            _migrationManager.BuildTable<ForumSubscription>(Create);

            _migrationManager.BuildTable<GdprConsent>(Create);
            _migrationManager.BuildTable<GdprLog>(Create);

            _migrationManager.BuildTable<ActivityLogType>(Create);
            _migrationManager.BuildTable<ActivityLog>(Create);
            _migrationManager.BuildTable<Log>(Create);

            _migrationManager.BuildTable<Campaign>(Create);
            _migrationManager.BuildTable<EmailAccount>(Create);
            _migrationManager.BuildTable<MessageTemplate>(Create);
            _migrationManager.BuildTable<NewsLetterSubscription>(Create);
            _migrationManager.BuildTable<QueuedEmail>(Create);

            _migrationManager.BuildTable<NewsCategory>(Create);
            _migrationManager.BuildTable<NewsItem>(Create);
            _migrationManager.BuildTable<NewsComment>(Create);
            _migrationManager.BuildTable<NewsAlbums>(Create);
            _migrationManager.BuildTable<NewsTags>(Create);
            _migrationManager.BuildTable<NewsNewsTagMapping>(Create);

            _migrationManager.BuildTable<Poll>(Create);
            _migrationManager.BuildTable<PollAnswer>(Create);
            _migrationManager.BuildTable<PollVotingRecord>(Create);

            _migrationManager.BuildTable<AclRecord>(Create);
            _migrationManager.BuildTable<PermissionRecord>(Create);
            _migrationManager.BuildTable<PermissionRecordCustomerRoleMapping>(Create);

            _migrationManager.BuildTable<UrlRecord>(Create);

            _migrationManager.BuildTable<ScheduleTask>(Create);

            _migrationManager.BuildTable<TaxCategory>(Create);

            _migrationManager.BuildTable<TopicTemplate>(Create);
            _migrationManager.BuildTable<Topic>(Create);

            _migrationManager.BuildTable<Vendor>(Create);
            _migrationManager.BuildTable<VendorAttribute>(Create);
            _migrationManager.BuildTable<VendorAttributeValue>(Create);
            _migrationManager.BuildTable<VendorNote>(Create);
            _migrationManager.BuildTable<VendorPageAnalyse>(Create);
            _migrationManager.BuildTable<VendorCustomerForm>(Create);
            _migrationManager.BuildTable<VendorSms>(Create);
            _migrationManager.BuildTable<VendorSmsHistory>(Create);
            _migrationManager.BuildTable<VendorSelfPrice>(Create);
            _migrationManager.BuildTable<VendorRegion>(Create);

            _migrationManager.BuildTable<ProductVendorMapping>(Create);
            _migrationManager.BuildTable<CategoryVendorMapping>(Create);

            //Weixin
            _migrationManager.BuildTable<WxConfig>(Create);

            _migrationManager.BuildTable<WxUser>(Create);
            _migrationManager.BuildTable<WxAddress>(Create);
            _migrationManager.BuildTable<WxUserTag>(Create);
            _migrationManager.BuildTable<WxUserSysTag>(Create);
            _migrationManager.BuildTable<WxUserUserSysTagMapping>(Create);
            _migrationManager.BuildTable<WxBrowserCheck>(Create);

            _migrationManager.BuildTable<WxLocation>(Create);
            _migrationManager.BuildTable<WxMenu>(Create);
            _migrationManager.BuildTable<WxMenuButton>(Create);
            _migrationManager.BuildTable<WxMessage>(Create);
            _migrationManager.BuildTable<WxOauth>(Create);
            _migrationManager.BuildTable<WxMessageBindMapping>(Create);

            _migrationManager.BuildTable<WxAutoreplyNewsInfo>(Create);

            _migrationManager.BuildTable<WxMessageAutoReply>(Create);
            _migrationManager.BuildTable<WxKeywordAutoreplyKeyword>(Create);
            _migrationManager.BuildTable<WxKeywordAutoreplyReply>(Create);
            

            _migrationManager.BuildTable<WxShareLink>(Create);
            _migrationManager.BuildTable<WxJSDKShare>(Create);
            _migrationManager.BuildTable<WxShareCount>(Create);
            
            _migrationManager.BuildTable<QrCodeCategory>(Create);
            _migrationManager.BuildTable<QrCodeChannel>(Create);
            _migrationManager.BuildTable<QrCodeLimit>(Create);
            
            _migrationManager.BuildTable<QrCodeLimitUserMapping>(Create);
            _migrationManager.BuildTable<QrCodeLimitBindingSource>(Create);

            _migrationManager.BuildTable<QrCodeTemp>(Create);

            //Supplier
            _migrationManager.BuildTable<Supplier>(Create);
            _migrationManager.BuildTable<SupplierShop>(Create);
            _migrationManager.BuildTable<SupplierShopTag>(Create);
            _migrationManager.BuildTable<SupplierSelfGroup>(Create);
            _migrationManager.BuildTable<SupplierImage>(Create);
            _migrationManager.BuildTable<SupplierProductMapping>(Create);
            _migrationManager.BuildTable<SupplierUserAuthorityMapping>(Create);
            _migrationManager.BuildTable<SupplierShopTagMapping>(Create);
            _migrationManager.BuildTable<SupplierShopUserFollowMapping>(Create);

            _migrationManager.BuildTable<SupplierVoucherCoupon>(Create);
            _migrationManager.BuildTable<SupplierVoucherCouponAppliedValue>(Create);
            _migrationManager.BuildTable<ProductSupplierVoucherCouponMapping>(Create);
            _migrationManager.BuildTable<QrCodeSupplierVoucherCouponMapping>(Create);
            _migrationManager.BuildTable<UserSupplierVoucherCoupon>(Create);

            _migrationManager.BuildTable<ProductAdvertImage>(Create);
            _migrationManager.BuildTable<MarketingAdvertWay>(Create);
            _migrationManager.BuildTable<MarketingAdvertAddress>(Create);
            _migrationManager.BuildTable<UserAdvertChannelAnalysis>(Create);


            
            _migrationManager.BuildTable<ProductExtendLabel>(Create);
            _migrationManager.BuildTable<ProductMarketLabel>(Create);
            _migrationManager.BuildTable<PromotionCommission>(Create);
            _migrationManager.BuildTable<ActivitiesTheme>(Create);
            _migrationManager.BuildTable<CustomTeam>(Create);
            _migrationManager.BuildTable<CustomTeamOrder>(Create);
            _migrationManager.BuildTable<OfficialCustomer>(Create);
            _migrationManager.BuildTable<PartnerApplicationForm>(Create);
            _migrationManager.BuildTable<PartnerServiceInfo>(Create);
            _migrationManager.BuildTable<ProductActivitiesThemeMapping>(Create);
            _migrationManager.BuildTable<ProductGiftProductMapping>(Create);
            _migrationManager.BuildTable<ProductProductExtendLabelMapping>(Create);
            _migrationManager.BuildTable<ProductProductMarketLabelMapping>(Create);
            _migrationManager.BuildTable<ProductUserFollowMapping>(Create);
            _migrationManager.BuildTable<ProductVisitorMapping>(Create);
            
            _migrationManager.BuildTable<UserAsset>(Create);
            _migrationManager.BuildTable<UserAssetIncomeHistory>(Create);
            _migrationManager.BuildTable<UserAssetConsumeHistory>(Create);

        }
    }
}
