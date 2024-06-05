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
using Nop.Core.Domain.Media;
using Nop.Core.Domain.Messages;
using Nop.Core.Domain.News;
using Nop.Core.Domain.Orders;
using Nop.Core.Domain.Polls;
using Nop.Core.Domain.ScheduleTasks;
using Nop.Core.Domain.Security;
using Nop.Core.Domain.Seo;
using Nop.Core.Domain.Shipping;
using Nop.Core.Domain.Stores;
using Nop.Core.Domain.Tax;
using Nop.Core.Domain.Topics;
using Nop.Core.Domain.Vendors;
using Nop.Data.Extensions;

using Nop.Core.Domain.Brands;
using Nop.Core.Domain.Weixins;
using Nop.Core.Domain.FriendCircles;
using Nop.Core.Domain.Shares;
using Nop.Core.Domain.Publics;
using Nop.Core.Domain.AntiFake;
using Nop.Core.Domain.Assets;
using Nop.Core.Domain.Forms;
using Nop.Core.Domain.RelationShips;
using Nop.Core.Domain.SMS;


namespace Nop.Data.Migrations.Installation
{
    [NopSchemaMigration("2020/01/31 11:24:16:2551771", "Nop.Data base schema", MigrationProcessType.Installation)]
    public class SchemaMigration : ForwardOnlyMigration
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
            Create.TableFor<Language>();
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
            Create.TableFor<ProductAttributeCombinationPicture>();
            Create.TableFor<ProductAttributeMapping>();
            Create.TableFor<ProductAttributeValue>();
            Create.TableFor<ProductAttributeValuePicture>();
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
            Create.TableFor<Video>();
            Create.TableFor<ProductVideo>();
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

            //扩展区划表相关 Directory
            Create.TableFor<Bank>();
            Create.TableFor<ChinaRegionCode>(); //中国区划表

            //扩展用户相关 Customer
            Create.TableFor<CustomerReferrer>();
            Create.TableFor<CustomerReferrerSetting>();
            Create.TableFor<CustomerLevel>();
            Create.TableFor<CustomerLevelSetting>();

            //扩展品牌相关 Brand
            Create.TableFor<Brand>();  //产品商标
            Create.TableFor<BrandAuthorize>();
            Create.TableFor<BrandPicture>();
            Create.TableFor<BrandVideo>();
            Create.TableFor<BrandTemplate>();
            Create.TableFor<BrandTag>();
            Create.TableFor<BrandBrandTagMapping>();
            Create.TableFor<BrandFavoriteMapping>();


            //扩展订单相关 Orders
            Create.TableFor<OrderInvoice>(); //订单发票
            Create.TableFor<OrderScene>(); //订单下单场景信息
            Create.TableFor<OrderPromotion>(); //订单下单优惠功能
            Create.TableFor<OrderIDBlackList>();  //实名黑名单
            Create.TableFor<OrderPhoneBlackList>();  //电话黑名单


            //扩展媒体相关 Media
            Create.TableFor<MediaServer>(); //媒体服务器


            //扩展微信相关 Weixins
            Create.TableFor<WeixinUser>();  //微信用户信息
            Create.TableFor<WeixinAccount>();  //公众号账号配置信息
            Create.TableFor<QrCodeLimit>();
            Create.TableFor<QrCodeLimitCustomerMapping>();
            Create.TableFor<QrCodeTemporary>();
            Create.TableFor<WeixinMessageResponse>();
            Create.TableFor<WeixinMessageTemplate>();
            Create.TableFor<WeixinOAuth>();
            Create.TableFor<WeixinTag>();


            //扩展产品及分类 Catalog
            Create.TableFor<Product3rdSalePlatform>();
            Create.TableFor<Product3rdSalePlatformMapping>();
            Create.TableFor<ProductComment>();
            Create.TableFor<ProductCouponsAttribute>();
            Create.TableFor<ProductCustomerAdvertRules>();
            Create.TableFor<ProductCustomerPointRules>();
            Create.TableFor<ProductCustomerCommissionRules>();
            Create.TableFor<ProductCustomerPriceRules>();
            Create.TableFor<ProductDateAndPrice>();
            Create.TableFor<ProductFavoriteMapping>();  //产品收藏、点赞
            Create.TableFor<ProductOrderNotice>();
            Create.TableFor<ProductProductOrderNoticeMapping>();
            Create.TableFor<ProductCustomerViews>();
            Create.TableFor<ProductServiceTag>();
            Create.TableFor<ProductProductServiceTagMapping>();
            Create.TableFor<ProductBlackList>();   //产品展示黑名单


            //扩展新闻相关 News
            Create.TableFor<NewsPicture>();  //新闻图片
            Create.TableFor<NewsVideo>();   //新闻视频
            Create.TableFor<NewsItemFavoriteMapping>(); //新闻收藏
            Create.TableFor<NewsCommentFavoriteMapping>();  //评论点赞
            Create.TableFor<NewsTag>();  //新闻标签
            Create.TableFor<NewsItemNewsTagMapping>();  //新闻标签映射
            Create.TableFor<NewsItemProductMapping>();  //新闻产品映射
            Create.TableFor<NewsCreator>(); //新闻创作者
            Create.TableFor<NewsTemplate>(); //新闻页面模板（如：微信模板，视频模板，新闻模板……）
            Create.TableFor<NewsBlackList>();  //新闻展示黑名单


            //扩展朋友圈 FriendCircles
            Create.TableFor<FriendCircle>();
            Create.TableFor<FriendCircleComment>();
            Create.TableFor<FriendCircleFavoriteMapping>();
            Create.TableFor<FriendCirclePicture>();
            Create.TableFor<FriendCircleVideo>();
            Create.TableFor<FriendRelatedProduct>();
            Create.TableFor<FriendCircleTag>();
            Create.TableFor<FriendCircleTagMapping>();


            //扩展供应商相关 Vendors
            Create.TableFor<VendorStore>();
            Create.TableFor<VendorStoreCategory>();
            Create.TableFor<VendorSaleProduct>();
            Create.TableFor<VendorCheckoutPrice>();
            Create.TableFor<VendorProductGroup>();
            Create.TableFor<VendorProductGroupSellProduct>();
            Create.TableFor<RelateVendorStoreMapping>();
            Create.TableFor<Vendor3rdSaleOrder>();
            Create.TableFor<Vendor3rdSaleUrl>();
            Create.TableFor<VendorFavoriteMapping>();
            Create.TableFor<VendorSms>();
            Create.TableFor<VendorStoreBlackList>();
            Create.TableFor<VendorStoreBookingProduct>();
            Create.TableFor<VendorStoreBookingSeat>();
            Create.TableFor<VendorStoreCustomerAuthority>();
            Create.TableFor<VendorStoreFavoriteMapping>();
            Create.TableFor<VendorStorePicture>();
            Create.TableFor<VendorStoreRegionalAgent>();
            Create.TableFor<VendorStoreSaleProduct>();
            Create.TableFor<VendorStoreSeat>();
            Create.TableFor<VendorStoreSeatOrder>();
            Create.TableFor<VendorStoreSeatPicture>();
            Create.TableFor<VendorStoreTemplate>();
            Create.TableFor<VendorTag>();
            Create.TableFor<VendorStoreMember>();
            Create.TableFor<VendorStoreMemberLevelSetting>();
            Create.TableFor<VendorStoreMemberCard>();
            Create.TableFor<VendorStoreMemberFollow>();
            Create.TableFor<VendorStockProduct>();   //库房库存产品品类
            Create.TableFor<VendorStockInbound>();   //库房入库
            Create.TableFor<VendorStockOutbound>();  //库房出库


            //通用扩展Common相关
            Create.TableFor<SearchTermHistory>();

            //扩展Stores相关


            //扩展投票相关 Polls
            Create.TableFor<PollVotingLimit>();

            //扩展分享相关 Shares
            Create.TableFor<SharePage>();
            Create.TableFor<SharePageAdvert>();
            Create.TableFor<SharePicture>();
            Create.TableFor<SharePageRecords>();
            Create.TableFor<SharePageViews>();
            Create.TableFor<SharePageSharePictureMapping>();
            Create.TableFor<SharePermission>();
            Create.TableFor<ShareProductApply>();
            Create.TableFor<ShareScene>();


            //公共相关 Publics
            Create.TableFor<PublicTag>();
            Create.TableFor<PublicTagMapping>();

            //专题扩展 Topics
            Create.TableFor<TopicFavoriteMapping>();

            //防伪扩展 AntiFake
            Create.TableFor<AntiFakeCompany>();
            Create.TableFor<AntiFakeVendorCompany>();
            Create.TableFor<AntiFakeVendorCompanyAuthority>();
            Create.TableFor<AntiFakeCompanyAuthority>();
            Create.TableFor<AntiFakeProduct>();
            Create.TableFor<AntiFakeProductTemplate>();
            Create.TableFor<AntiFakeCodeBox>();
            Create.TableFor<AntiFakeBoxVendorRecords>();
            Create.TableFor<AntiFakeCodeItem>();
            Create.TableFor<AntiFakeCodeBottle>();
            Create.TableFor<AntiFakeCodeCover>();
            Create.TableFor<AntiFakeCodeRelateMapping>();
            Create.TableFor<AntiFakeRewardsConfig>();
            Create.TableFor<AntiFakeRewardsCode>();
            Create.TableFor<AntiFakeRewardsPaid>();
            Create.TableFor<AntiFakeRewardsBlackList>();
            Create.TableFor<AntiFakeCodeScanRecords>();
            Create.TableFor<AntiFakeProductRelatedNews>();
            Create.TableFor<AntiFakeExchangeConfig>();
            Create.TableFor<AntiFakeExchangeCode>();

            //资产扩展 Assets
            Create.TableFor<AssetsBankAccount>();
            Create.TableFor<AssetsCashs>();
            Create.TableFor<AssetsCashsHistory>();
            Create.TableFor<AssetsCouponsHistory>();
            Create.TableFor<AssetsPointsHistory>();

            //表单扩展 Forms
            Create.TableFor<Form>();
            Create.TableFor<FormCustomerMapping>();
            Create.TableFor<FormExtendValues>();
            Create.TableFor<FormFixedValues>();
            Create.TableFor<FormRecord>();

            //个人关系扩展 RelationShips
            Create.TableFor<PersonalRelationShip>();
            Create.TableFor<PersonalRelationTag>();
            Create.TableFor<PersonalRelationCooperater>();
            Create.TableFor<PersonalRelationFollowup>();
            Create.TableFor<PersonalRelationTagMapping>();

            //短信扩展 SMS
            Create.TableFor<SmsAccount>();
            Create.TableFor<SmsSign>();
            Create.TableFor<SmsPlatform>();
            Create.TableFor<SmsTemplate>();
            Create.TableFor<SmsPublicCombination>();
            Create.TableFor<SmsSendRecords>();
            Create.TableFor<SmsSendBlackList>();

            //扩展物流运输发货 Shipping
            Create.TableFor<ShippingCompany>();
        }
    }
}
