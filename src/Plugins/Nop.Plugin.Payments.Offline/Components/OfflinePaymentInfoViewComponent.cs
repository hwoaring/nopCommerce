using Microsoft.AspNetCore.Mvc;
using Nop.Core;
using Nop.Plugin.Payments.Offline.Models;
using Nop.Services.Localization;
using Nop.Web.Framework.Components;

namespace Nop.Plugin.Payments.Offline.Components
{
    [ViewComponent(Name = "PaymentOffline")]
    public class OfflineViewComponent : NopViewComponent
    {
        private readonly OfflinePaymentSettings _offlinePaymentSettings;
        private readonly ILocalizationService _localizationService;
        private readonly IStoreContext _storeContext;
        private readonly IWorkContext _workContext;

        public OfflineViewComponent(OfflinePaymentSettings offlinePaymentSettings,
            ILocalizationService localizationService,
            IStoreContext storeContext,
            IWorkContext workContext)
        {
            _offlinePaymentSettings = offlinePaymentSettings;
            _localizationService = localizationService;
            _storeContext = storeContext;
            _workContext = workContext;
        }

        public IViewComponentResult Invoke()
        {
            var model = new PaymentInfoModel() { 

            };
            return View("~/Plugins/Payments.Offline/Views/PaymentInfo.cshtml", model);
        }
    }
}