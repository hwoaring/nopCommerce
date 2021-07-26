using Microsoft.Extensions.DependencyInjection;
using Nop.Core.Configuration;
using Nop.Core.Infrastructure;
using Nop.Core.Infrastructure.DependencyManagement;
using Nop.Services.Weixin;
using Nop.Services.Suppliers;
using Nop.Services.Marketing;

namespace Senparc.Weixin.MP.CommonService.Infrastructure
{
    /// <summary>
    /// Represents a plugin dependency registrar
    /// </summary>
    public class DependencyRegistrar : IDependencyRegistrar
    {
        /// <summary>
        /// Register services and interfaces
        /// </summary>
        /// <param name="builder">Container builder</param>
        /// <param name="typeFinder">Type finder</param>
        /// <param name="config">Config</param>
        public virtual void Register(IServiceCollection services, ITypeFinder typeFinder, AppSettings appSettings)
        {
            services.AddScoped<IWxConfigService, WxConfigService>();
            services.AddScoped<IWxLocationService, WxLocationService>();
            services.AddScoped<IWxMessageBindService, WxMessageBindService>();
            services.AddScoped<IWxMessageService, WxMessageService>();
            services.AddScoped<IQrCodeCategoryService, QrCodeCategoryService>();
            services.AddScoped<IQrCodeChannelService, QrCodeChannelService>();
            services.AddScoped<IQrCodeLimitService, QrCodeLimitService>();
            services.AddScoped<IQrCodeLimitUserService, QrCodeLimitUserService>();
            services.AddScoped<IWxUserService, WxUserService>();
            services.AddScoped<IWxUserTagService, WxUserTagService>();
            services.AddScoped<IQrCodeLimitBindingSourceService, QrCodeLimitBindingSourceService>();

            services.AddScoped<IWxMenuService, WxMenuService>();
            services.AddScoped<IWxMenuButtonService, WxMenuButtonService>();
            //builder.RegisterType<WAutoreplyNewsInfoService>().As<IWAutoreplyNewsInfoService>().InstancePerLifetimeScope();
            //builder.RegisterType<WMessageAutoReplyService>().As<IWMessageAutoReplyService>().InstancePerLifetimeScope();
            //builder.RegisterType<WKeywordAutoreplyService>().As<IWKeywordAutoreplyService>().InstancePerLifetimeScope();
            //builder.RegisterType<WKeywordAutoreplyKeywordService>().As<IWKeywordAutoreplyKeywordService>().InstancePerLifetimeScope();
            //builder.RegisterType<WKeywordAutoreplyReplyService>().As<IWKeywordAutoreplyReplyService>().InstancePerLifetimeScope();

            //Marketing
            //builder.RegisterType<ActivitiesThemeService>().As<IActivitiesThemeService>().InstancePerLifetimeScope();
            //builder.RegisterType<CustomTeamOrderService>().As<ICustomTeamOrderService>().InstancePerLifetimeScope();
            //builder.RegisterType<CustomTeamService>().As<ICustomTeamService>().InstancePerLifetimeScope();
            //builder.RegisterType<DivisionsCodeChinaService>().As<IDivisionsCodeChinaService>().InstancePerLifetimeScope();
            //builder.RegisterType<MarketingAdvertAddressService>().As<IMarketingAdvertAddressService>().InstancePerLifetimeScope();
            //builder.RegisterType<MarketingAdvertWayService>().As<IMarketingAdvertWayService>().InstancePerLifetimeScope();
            //builder.RegisterType<OfficialCustomerService>().As<IOfficialCustomerService>().InstancePerLifetimeScope();
            //builder.RegisterType<PartnerApplicationFormService>().As<IPartnerApplicationFormService>().InstancePerLifetimeScope();
            //builder.RegisterType<PartnerServiceInfoService>().As<IPartnerServiceInfoService>().InstancePerLifetimeScope();
            //builder.RegisterType<ProductActivitiesThemeMappingService>().As<IProductActivitiesThemeMappingService>().InstancePerLifetimeScope();
            services.AddScoped<IProductAdvertImageService, ProductAdvertImageService>();
            //builder.RegisterType<ProductExtendLabelService>().As<IProductExtendLabelService>().InstancePerLifetimeScope();
            //builder.RegisterType<ProductGiftProductMappingService>().As<IProductGiftProductMappingService>().InstancePerLifetimeScope();
            //builder.RegisterType<ProductMarketLabelService>().As<IProductMarketLabelService>().InstancePerLifetimeScope();
            //builder.RegisterType<ProductProductExtendLabelMappingService>().As<IProductProductExtendLabelMappingService>().InstancePerLifetimeScope();
            //builder.RegisterType<ProductProductMarketLabelMappingService>().As<IProductProductMarketLabelMappingService>().InstancePerLifetimeScope();
            //builder.RegisterType<ProductUserFollowMappingService>().As<IProductUserFollowMappingService>().InstancePerLifetimeScope();
            //builder.RegisterType<ProductVisitorMappingService>().As<IProductVisitorMappingService>().InstancePerLifetimeScope();
            //builder.RegisterType<PromotionCommissionService>().As<IPromotionCommissionService>().InstancePerLifetimeScope();
            //builder.RegisterType<UserAdvertChannelAnalysisService>().As<IUserAdvertChannelAnalysisService>().InstancePerLifetimeScope();
            services.AddScoped<IUserAssetConsumeHistoryService, UserAssetConsumeHistoryService>();
            services.AddScoped<IUserAssetIncomeHistoryService, UserAssetIncomeHistoryService>();
            services.AddScoped<IUserAssetService, UserAssetService>();

            //Supplier
            //builder.RegisterType<ProductSupplierVoucherCouponMappingService>().As<IProductSupplierVoucherCouponMappingService>().InstancePerLifetimeScope();
            services.AddScoped<IQrCodeSupplierVoucherCouponMappingService, QrCodeSupplierVoucherCouponMappingService>();
            //builder.RegisterType<SupplierImageService>().As<ISupplierImageService>().InstancePerLifetimeScope();
            //builder.RegisterType<SupplierProductMappingService>().As<ISupplierProductMappingService>().InstancePerLifetimeScope();
            //builder.RegisterType<SupplierSelfGroupService>().As<ISupplierSelfGroupService>().InstancePerLifetimeScope();
            //builder.RegisterType<SupplierService>().As<ISupplierService>().InstancePerLifetimeScope();
            services.AddScoped<ISupplierShopService, SupplierShopService>();
            //builder.RegisterType<SupplierShopTagMappingService>().As<ISupplierShopTagMappingService>().InstancePerLifetimeScope();
            //builder.RegisterType<SupplierShopTagService>().As<ISupplierShopTagService>().InstancePerLifetimeScope();
            //builder.RegisterType<SupplierShopUserFollowMappingService>().As<ISupplierShopUserFollowMappingService>().InstancePerLifetimeScope();
            services.AddScoped<ISupplierUserAuthorityMappingService, SupplierUserAuthorityMappingService>();
            //builder.RegisterType<SupplierVoucherCouponAppliedValueService>().As<ISupplierVoucherCouponAppliedValueService>().InstancePerLifetimeScope();
            services.AddScoped<ISupplierVoucherCouponService, SupplierVoucherCouponService>();
            //builder.RegisterType<UserSupplierVoucherCouponService>().As<IUserSupplierVoucherCouponService>().InstancePerLifetimeScope();
        }

        /// <summary>
        /// Order of this dependency registrar implementation
        /// </summary>
        public int Order => 1;
    }
}