using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Nop.Core;
using Nop.Plugin.Payments.Offline.Models;
using Nop.Services.Configuration;
using Nop.Services.Localization;
using Nop.Services.Messages;
using Nop.Services.Security;
using Nop.Web.Framework;
using Nop.Web.Framework.Controllers;
using Nop.Web.Framework.Mvc.Filters;

namespace Nop.Plugin.Payments.Offline.Controllers
{
    [AuthorizeAdmin]
    [Area(AreaNames.Admin)]
    [AutoValidateAntiforgeryToken]
    public class PaymentOfflineController : BasePaymentController
    {
        #region Fields

        private readonly ILanguageService _languageService;
        private readonly ILocalizationService _localizationService;
        private readonly INotificationService _notificationService;
        private readonly IPermissionService _permissionService;
        private readonly ISettingService _settingService;
        private readonly IStoreContext _storeContext;

        #endregion

        #region Ctor

        public PaymentOfflineController(ILanguageService languageService,
            ILocalizationService localizationService,
            INotificationService notificationService,
            IPermissionService permissionService,
            ISettingService settingService,
            IStoreContext storeContext)
        {
            _languageService = languageService;
            _localizationService = localizationService;
            _notificationService = notificationService;
            _permissionService = permissionService;
            _settingService = settingService;
            _storeContext = storeContext;
        }

        #endregion

        #region Methods

        public async Task<IActionResult> Configure()
        {
            if (!await _permissionService.AuthorizeAsync(StandardPermissionProvider.ManagePaymentMethods))
                return AccessDeniedView();

            //load settings for a chosen store scope
            var storeScope = await _storeContext.GetActiveStoreScopeConfigurationAsync();
            var offlinePaymentSettings = await _settingService.LoadSettingAsync<OfflinePaymentSettings>(storeScope);

            var model = new ConfigurationModel
            {
                DescriptionText = offlinePaymentSettings.DescriptionText,
                WechatPaymentInfo = offlinePaymentSettings.WechatPaymentInfo,
                AlipayPaymentInfo = offlinePaymentSettings.AlipayPaymentInfo,
                BankCardPaymentInfo = offlinePaymentSettings.BankCardPaymentInfo
            };


            model.AdditionalFee = offlinePaymentSettings.AdditionalFee;
            model.AdditionalFeePercentage = offlinePaymentSettings.AdditionalFeePercentage;
            model.ShippableProductRequired = offlinePaymentSettings.ShippableProductRequired;

            model.ActiveStoreScopeConfiguration = storeScope;
            if (storeScope > 0)
            {
                model.DescriptionText_OverrideForStore = await _settingService.SettingExistsAsync(offlinePaymentSettings, x => x.DescriptionText, storeScope);
                model.WechatPaymentInfo_OverrideForStore = await _settingService.SettingExistsAsync(offlinePaymentSettings, x => x.WechatPaymentInfo, storeScope);
                model.AlipayPaymentInfo_OverrideForStore = await _settingService.SettingExistsAsync(offlinePaymentSettings, x => x.AlipayPaymentInfo, storeScope);
                model.BankCardPaymentInfo_OverrideForStore = await _settingService.SettingExistsAsync(offlinePaymentSettings, x => x.BankCardPaymentInfo, storeScope);
                model.AdditionalFee_OverrideForStore = await _settingService.SettingExistsAsync(offlinePaymentSettings, x => x.AdditionalFee, storeScope);
                model.AdditionalFeePercentage_OverrideForStore = await _settingService.SettingExistsAsync(offlinePaymentSettings, x => x.AdditionalFeePercentage, storeScope);
                model.ShippableProductRequired_OverrideForStore = await _settingService.SettingExistsAsync(offlinePaymentSettings, x => x.ShippableProductRequired, storeScope);
            }

            return View("~/Plugins/Payments.Offline/Views/Configure.cshtml", model);
        }

        [HttpPost]
        public async Task<IActionResult> Configure(ConfigurationModel model)
        {
            if (!await _permissionService.AuthorizeAsync(StandardPermissionProvider.ManagePaymentMethods))
                return AccessDeniedView();

            if (!ModelState.IsValid)
                return await Configure();

            //load settings for a chosen store scope
            var storeScope = await _storeContext.GetActiveStoreScopeConfigurationAsync();
            var offlinePaymentSettings = await _settingService.LoadSettingAsync<OfflinePaymentSettings>(storeScope);

            //save settings
            offlinePaymentSettings.DescriptionText = model.DescriptionText;
            offlinePaymentSettings.WechatPaymentInfo = model.WechatPaymentInfo;
            offlinePaymentSettings.AlipayPaymentInfo = model.AlipayPaymentInfo;
            offlinePaymentSettings.BankCardPaymentInfo = model.BankCardPaymentInfo;
            offlinePaymentSettings.AdditionalFee = model.AdditionalFee;
            offlinePaymentSettings.AdditionalFeePercentage = model.AdditionalFeePercentage;
            offlinePaymentSettings.ShippableProductRequired = model.ShippableProductRequired;

            /* We do not clear cache after each setting update.
             * This behavior can increase performance because cached settings will not be cleared 
             * and loaded from database after each update */
            await _settingService.SaveSettingOverridablePerStoreAsync(offlinePaymentSettings, x => x.DescriptionText, model.DescriptionText_OverrideForStore, storeScope, false);
            await _settingService.SaveSettingOverridablePerStoreAsync(offlinePaymentSettings, x => x.WechatPaymentInfo, model.WechatPaymentInfo_OverrideForStore, storeScope, false);
            await _settingService.SaveSettingOverridablePerStoreAsync(offlinePaymentSettings, x => x.AlipayPaymentInfo, model.AlipayPaymentInfo_OverrideForStore, storeScope, false);
            await _settingService.SaveSettingOverridablePerStoreAsync(offlinePaymentSettings, x => x.BankCardPaymentInfo, model.BankCardPaymentInfo_OverrideForStore, storeScope, false);
            await _settingService.SaveSettingOverridablePerStoreAsync(offlinePaymentSettings, x => x.AdditionalFee, model.AdditionalFee_OverrideForStore, storeScope, false);
            await _settingService.SaveSettingOverridablePerStoreAsync(offlinePaymentSettings, x => x.AdditionalFeePercentage, model.AdditionalFeePercentage_OverrideForStore, storeScope, false);
            await _settingService.SaveSettingOverridablePerStoreAsync(offlinePaymentSettings, x => x.ShippableProductRequired, model.ShippableProductRequired_OverrideForStore, storeScope, false);

            //now clear settings cache
            await _settingService.ClearCacheAsync();

            _notificationService.SuccessNotification(await _localizationService.GetResourceAsync("Admin.Plugins.Saved"));

            return await Configure();
        }

        #endregion
    }
}