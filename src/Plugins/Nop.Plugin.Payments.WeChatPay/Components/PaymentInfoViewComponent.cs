using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Nop.Plugin.Payments.WeChatPay.Models;
using Nop.Plugin.Payments.WeChatPay.Services;
using Nop.Services.Localization;
using Nop.Web.Framework.Components;

namespace Nop.Plugin.Payments.WeChatPay.Components
{
    /// <summary>
    /// Represents a view component to display payment info in public store
    /// </summary>
    [ViewComponent(Name = Defaults.PAYMENT_INFO_VIEW_COMPONENT_NAME)]
    public class PaymentInfoViewComponent : NopViewComponent
    {
        #region Fields

        private readonly ILocalizationService _localizationService;
        private readonly WeChatPayService _weChatPayService;

        #endregion

        #region Ctor

        public PaymentInfoViewComponent(ILocalizationService localizationService,
            WeChatPayService weChatPayService)
        {
            _localizationService = localizationService;
            _weChatPayService = weChatPayService;
        }

        #endregion

        #region Methods

        /// <summary>
        /// Invoke view component
        /// </summary>
        /// <returns>A task that represents the asynchronous operation whose result contains the view component result</returns>
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var model = new PaymentInfoModel();

            if (!await _weChatPayService.IsConfiguredAsync())
                ModelState.AddModelError(string.Empty, await _localizationService.GetResourceAsync("Plugins.Payments.WeChatPay.IsNotConfigured"));
            else
            {
                model.AvailablePaymentChannels = Defaults.AvailablePaymentChannels
                    .Where(item => _weChatPayService.IsAvailablePaymentChannel(item.Value))
                    .ToList();
            }

            return View("~/Plugins/Payments.WeChatPay/Views/PaymentInfo.cshtml", model);
        }

        #endregion
    }
}