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

        public IActionResult Configure()
        {
            if (!_permissionService.Authorize(StandardPermissionProvider.ManagePaymentMethods))
                return AccessDeniedView();

            //load settings for a chosen store scope
            var storeScope = _storeContext.ActiveStoreScopeConfiguration;
            var offlinePaymentSettings = _settingService.LoadSetting<OfflinePaymentSettings>(storeScope);

            var model = new ConfigurationModel
            {
                DescriptionText = offlinePaymentSettings.DescriptionText,
                WechatPaymentInfo = offlinePaymentSettings.WechatPaymentInfo,
                AlipayPaymentInfo = offlinePaymentSettings.AlipayPaymentInfo,
                BankCardPaymentInfo = offlinePaymentSettings.BankCardPaymentInfo
            };

            //locales
            AddLocales(_languageService, model.Locales, (locale, languageId) =>
            {
                locale.DescriptionText = _localizationService
                    .GetLocalizedSetting(offlinePaymentSettings, x => x.DescriptionText, languageId, 0, false, false);
                locale.WechatPaymentInfo = _localizationService
                    .GetLocalizedSetting(offlinePaymentSettings, x => x.WechatPaymentInfo, languageId, 0, false, false);
                locale.AlipayPaymentInfo = _localizationService
                    .GetLocalizedSetting(offlinePaymentSettings, x => x.AlipayPaymentInfo, languageId, 0, false, false);
                locale.BankCardPaymentInfo = _localizationService
                    .GetLocalizedSetting(offlinePaymentSettings, x => x.BankCardPaymentInfo, languageId, 0, false, false);
            });
            model.AdditionalFee = offlinePaymentSettings.AdditionalFee;
            model.AdditionalFeePercentage = offlinePaymentSettings.AdditionalFeePercentage;
            model.ShippableProductRequired = offlinePaymentSettings.ShippableProductRequired;

            model.ActiveStoreScopeConfiguration = storeScope;
            if (storeScope > 0)
            {
                model.DescriptionText_OverrideForStore = _settingService.SettingExists(offlinePaymentSettings, x => x.DescriptionText, storeScope);
                model.WechatPaymentInfo_OverrideForStore = _settingService.SettingExists(offlinePaymentSettings, x => x.WechatPaymentInfo, storeScope);
                model.AlipayPaymentInfo_OverrideForStore = _settingService.SettingExists(offlinePaymentSettings, x => x.AlipayPaymentInfo, storeScope);
                model.BankCardPaymentInfo_OverrideForStore = _settingService.SettingExists(offlinePaymentSettings, x => x.BankCardPaymentInfo, storeScope);
                model.AdditionalFee_OverrideForStore = _settingService.SettingExists(offlinePaymentSettings, x => x.AdditionalFee, storeScope);
                model.AdditionalFeePercentage_OverrideForStore = _settingService.SettingExists(offlinePaymentSettings, x => x.AdditionalFeePercentage, storeScope);
                model.ShippableProductRequired_OverrideForStore = _settingService.SettingExists(offlinePaymentSettings, x => x.ShippableProductRequired, storeScope);
            }

            return View("~/Plugins/Payments.Offline/Views/Configure.cshtml", model);
        }

        [HttpPost]
        public IActionResult Configure(ConfigurationModel model)
        {
            if (!_permissionService.Authorize(StandardPermissionProvider.ManagePaymentMethods))
                return AccessDeniedView();

            if (!ModelState.IsValid)
                return Configure();

            //load settings for a chosen store scope
            var storeScope = _storeContext.ActiveStoreScopeConfiguration;
            var offlinePaymentSettings = _settingService.LoadSetting<OfflinePaymentSettings>(storeScope);

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
            _settingService.SaveSettingOverridablePerStore(offlinePaymentSettings, x => x.DescriptionText, model.DescriptionText_OverrideForStore, storeScope, false);
            _settingService.SaveSettingOverridablePerStore(offlinePaymentSettings, x => x.WechatPaymentInfo, model.WechatPaymentInfo_OverrideForStore, storeScope, false);
            _settingService.SaveSettingOverridablePerStore(offlinePaymentSettings, x => x.AlipayPaymentInfo, model.AlipayPaymentInfo_OverrideForStore, storeScope, false);
            _settingService.SaveSettingOverridablePerStore(offlinePaymentSettings, x => x.BankCardPaymentInfo, model.BankCardPaymentInfo_OverrideForStore, storeScope, false);
            _settingService.SaveSettingOverridablePerStore(offlinePaymentSettings, x => x.AdditionalFee, model.AdditionalFee_OverrideForStore, storeScope, false);
            _settingService.SaveSettingOverridablePerStore(offlinePaymentSettings, x => x.AdditionalFeePercentage, model.AdditionalFeePercentage_OverrideForStore, storeScope, false);
            _settingService.SaveSettingOverridablePerStore(offlinePaymentSettings, x => x.ShippableProductRequired, model.ShippableProductRequired_OverrideForStore, storeScope, false);

            //now clear settings cache
            _settingService.ClearCache();

            //localization. no multi-store support for localization yet.
            foreach (var localized in model.Locales)
            {
                _localizationService.SaveLocalizedSetting(offlinePaymentSettings,
                    x => x.DescriptionText, localized.LanguageId, localized.DescriptionText);
                _localizationService.SaveLocalizedSetting(offlinePaymentSettings,
                    x => x.WechatPaymentInfo, localized.LanguageId, localized.WechatPaymentInfo);
                _localizationService.SaveLocalizedSetting(offlinePaymentSettings,
                    x => x.AlipayPaymentInfo, localized.LanguageId, localized.AlipayPaymentInfo);
                _localizationService.SaveLocalizedSetting(offlinePaymentSettings,
                    x => x.BankCardPaymentInfo, localized.LanguageId, localized.BankCardPaymentInfo);
            }

            _notificationService.SuccessNotification(_localizationService.GetResource("Admin.Plugins.Saved"));

            return Configure();
        }

        #endregion
    }
}