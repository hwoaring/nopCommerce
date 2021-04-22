using System;
using System.Collections.Generic;
using System.Globalization;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.AspNetCore.Mvc.Routing;
using Microsoft.Extensions.Primitives;
using Newtonsoft.Json;
using Nop.Core;
using Nop.Core.Domain.Directory;
using Nop.Core.Domain.Orders;
using Nop.Core.Domain.Payments;
using Nop.Plugin.Payments.WeChatPay.Extensions;
using Nop.Plugin.Payments.WeChatPay.Models;
using Nop.Plugin.Payments.WeChatPay.Services;
using Nop.Services.Catalog;
using Nop.Services.Configuration;
using Nop.Services.Directory;
using Nop.Services.Localization;
using Nop.Services.Messages;
using Nop.Services.Orders;
using Nop.Services.Payments;
using Nop.Services.Plugins;

namespace Nop.Plugin.Payments.WeChatPay
{
    /// <summary>
    /// Represents the WeChatPay payment processor
    /// </summary>
    public class WeChatPayPaymentProcessor : BasePlugin, IPaymentMethod
    {
        #region Fields

        private readonly CurrencySettings _currencySettings;
        private readonly IActionContextAccessor _actionContextAccessor;
        private readonly ICurrencyService _currencyService;
        private readonly ILocalizationService _localizationService;
        private readonly INotificationService _notificationService;
        private readonly IOrderService _orderService;
        private readonly IPaymentService _paymentService;
        private readonly IProductAttributeFormatter _productAttributeFormatter;
        private readonly IProductService _productService;
        private readonly ISettingService _settingService;
        private readonly IUrlHelperFactory _urlHelperFactory;
        private readonly IWebHelper _webHelper;
        private readonly IWorkContext _workContext;
        private readonly WeChatPayApi _weChatPayApi;
        private readonly WeChatPayService _weChatPayService;
        private readonly WeChatPayPaymentSettings _weChatPayPaymentSettings;

        #endregion

        #region Ctor

        public WeChatPayPaymentProcessor(CurrencySettings currencySettings,
            IActionContextAccessor actionContextAccessor,
            ICurrencyService currencyService,
            ILocalizationService localizationService,
            INotificationService notificationService,
            IOrderService orderService,
            IPaymentService paymentService,
            IProductAttributeFormatter productAttributeFormatter,
            IProductService productService,
            ISettingService settingService,
            IUrlHelperFactory urlHelperFactory,
            IWebHelper webHelper,
            IWorkContext workContext,
            WeChatPayApi weChatPayApi,
            WeChatPayService weChatPayService,
            WeChatPayPaymentSettings weChatPayPaymentSettings
        )
        {
            _currencySettings = currencySettings;
            _actionContextAccessor = actionContextAccessor;
            _currencyService = currencyService;
            _localizationService = localizationService;
            _notificationService = notificationService;
            _orderService = orderService;
            _paymentService = paymentService;
            _productAttributeFormatter = productAttributeFormatter;
            _productService = productService;
            _settingService = settingService;
            _urlHelperFactory = urlHelperFactory;
            _webHelper = webHelper;
            _workContext = workContext;
            _weChatPayApi = weChatPayApi;
            _weChatPayService = weChatPayService;
            _weChatPayPaymentSettings = weChatPayPaymentSettings;
        }

        #endregion

        #region Methods

        /// <summary>
        /// Process a payment
        /// </summary>
        /// <param name="processPaymentRequest">Payment info required for an order processing</param>
        /// <returns>
        /// A task that represents the asynchronous operation
        /// The task result contains the process payment result
        /// </returns>
        public Task<ProcessPaymentResult> ProcessPaymentAsync(ProcessPaymentRequest processPaymentRequest)
        {
            return Task.FromResult(new ProcessPaymentResult());
        }

        /// <summary>
        /// Post process payment (used by payment gateways that require redirecting to a third-party URL)
        /// </summary>
        /// <param name="postProcessPaymentRequest">Payment info required for an order processing</param>
        /// <returns>A task that represents the asynchronous operation</returns>
        public async Task PostProcessPaymentAsync(PostProcessPaymentRequest postProcessPaymentRequest)
        {
            if (postProcessPaymentRequest is null)
                throw new ArgumentNullException(nameof(postProcessPaymentRequest));

            var storeCurrency = await _currencyService.GetCurrencyByIdAsync(_currencySettings.PrimaryStoreCurrencyId)
                ?? throw new NopException("Primary store currency is not set");

            var order = postProcessPaymentRequest.Order;
            var orderCustomValues = _paymentService.DeserializeCustomValues(order);

            var paymentChannelKey = await _localizationService.GetResourceAsync("Plugins.Payments.WeChatPay.PaymentChannel.Key");
            if (!orderCustomValues.TryGetValue(paymentChannelKey, out var vendor))
                throw new NopException("The payment channel is not set");

            var customer = await _workContext.GetCurrentCustomerAsync();
            var goods = new List<object>();
            var orderItems = await _orderService.GetOrderItemsAsync(order.Id);
            foreach (var item in orderItems)
            {
                var product = await _productService.GetProductByIdAsync(item.ProductId)
                    ?? throw new InvalidOperationException("Cannot get the product.");

                var productName = string.Empty;
                if (string.IsNullOrEmpty(item.AttributesXml))
                    productName = product.Name;
                else
                {
                    var attributeInfo = await _productAttributeFormatter.FormatAttributesAsync(product, item.AttributesXml, customer, ", ");
                    productName = $"{product.Name} ({attributeInfo})";
                }

                goods.Add(new { goods_name = productName, quantity = item.Quantity.ToString() });
            }

            var currentRequestProtocol = _webHelper.GetCurrentRequestProtocol();
            var urlHelper = _urlHelperFactory.GetUrlHelper(_actionContextAccessor.ActionContext);
            var failUrl = urlHelper.RouteUrl(Defaults.OrderDetailsRouteName, new { orderId = order.Id }, currentRequestProtocol);
            var callbackUrl = urlHelper.RouteUrl(Defaults.CheckoutCompletedRouteName, new { orderId = order.Id }, currentRequestProtocol);
            var ipnUrl = urlHelper.RouteUrl(Defaults.SecurePayWebhookRouteName, null, currentRequestProtocol);

            var request = new SecurePayRequest
            {
                MerchantId = _weChatPayPaymentSettings.MerchantId,
                StoreId = _weChatPayPaymentSettings.StoreId,
                Vendor = vendor.ToString(),
                Terminal = "ONLINE",
                Amount = order.OrderTotal.ToString(CultureInfo.InvariantCulture),
                Currency = storeCurrency.CurrencyCode,
                SettleCurrency = storeCurrency.CurrencyCode,
                CallbackUrl = callbackUrl,
                IpnUrl = ipnUrl,
                GoodsInfo = JsonConvert.SerializeObject(goods),
                Reference = order.OrderGuid.ToString()
            };

            var signingParams = new[]
            {
                ("amount", request.Amount),
                ("callbackUrl", request.CallbackUrl),
                ("currency", request.Currency),
                ("goodsInfo", request.GoodsInfo),
                ("ipnUrl", request.IpnUrl),
                ("merchantNo", request.MerchantId),
                ("reference", request.Reference),
                ("storeNo", request.StoreId),
                ("terminal", request.Terminal),
                ("vendor", request.Vendor),
                ("settleCurrency", request.SettleCurrency),
            };
            request.VerifySign = CommonHelpers.GenerateSign(_weChatPayPaymentSettings.ApiToken, signingParams);

            var response = await _weChatPayApi.SecurePayAsync(request);
            if (!string.IsNullOrEmpty(response?.Payload?.CashierUrl))
                _actionContextAccessor.ActionContext.HttpContext.Response.Redirect(response.Payload.CashierUrl);
            else
            {
                _notificationService
                    .ErrorNotification($"Error when calling WeChatPay secure pay endpoint. Code: {response?.Code}, Message: {response?.Message}.");

                _actionContextAccessor.ActionContext.HttpContext.Response.Redirect(failUrl);
            }
        }

        /// <summary>
        /// Returns a value indicating whether payment method should be hidden during checkout
        /// </summary>
        /// <param name="cart">Shopping cart</param>
        /// <returns>
        /// A task that represents the asynchronous operation
        /// The task result contains the rue - hide; false - display.
        /// </returns>
        public Task<bool> HidePaymentMethodAsync(IList<ShoppingCartItem> cart)
        {
            return Task.FromResult(false);
        }

        /// <summary>
        /// Gets additional handling fee
        /// </summary>
        /// <param name="cart">Shopping cart</param>
        /// <returns>
        /// A task that represents the asynchronous operation
        /// The task result contains the additional handling fee
        /// </returns>
        public async Task<decimal> GetAdditionalHandlingFeeAsync(IList<ShoppingCartItem> cart)
        {
            return await _paymentService.CalculateAdditionalFeeAsync(cart,
                _weChatPayPaymentSettings.AdditionalFee, _weChatPayPaymentSettings.AdditionalFeePercentage);
        }

        /// <summary>
        /// Captures payment
        /// </summary>
        /// <param name="capturePaymentRequest">Capture payment request</param>
        /// <returns>
        /// A task that represents the asynchronous operation
        /// The task result contains the capture payment result
        /// </returns>
        public Task<CapturePaymentResult> CaptureAsync(CapturePaymentRequest capturePaymentRequest)
        {
            return Task.FromResult(new CapturePaymentResult { Errors = new[] { "Capture method not supported" } });
        }

        /// <summary>
        /// Refunds a payment
        /// </summary>
        /// <param name="refundPaymentRequest">Request</param>
        /// <returns>
        /// A task that represents the asynchronous operation
        /// The task result contains the result
        /// </returns>
        public async Task<RefundPaymentResult> RefundAsync(RefundPaymentRequest refundPaymentRequest)
        {
            if (refundPaymentRequest is null)
                throw new ArgumentNullException(nameof(refundPaymentRequest));

            if (!await _weChatPayService.IsConfiguredAsync())
                return new RefundPaymentResult { Errors = new[] { await _localizationService.GetResourceAsync("Plugins.Payments.WeChatPay.IsNotConfigured") } };

            var storeCurrency = await _currencyService.GetCurrencyByIdAsync(_currencySettings.PrimaryStoreCurrencyId);
            if (storeCurrency == null)
                return new RefundPaymentResult { Errors = new[] { "Primary store currency is not set" } };

            var request = new CreateRefundRequest
            {
                MerchantId = _weChatPayPaymentSettings.MerchantId,
                StoreId = _weChatPayPaymentSettings.StoreId,
                RefundAmount = refundPaymentRequest.AmountToRefund.ToString(CultureInfo.InvariantCulture),
                Currency = storeCurrency.CurrencyCode,
                SettleCurrency = storeCurrency.CurrencyCode,
                TransactionId = refundPaymentRequest.Order.CaptureTransactionId
            };

            var signingParams = new[]
            {
                ("refundAmount", request.RefundAmount),
                ("currency", request.Currency),
                ("merchantNo", request.MerchantId),
                ("storeNo", request.StoreId),
                ("settleCurrency", request.SettleCurrency),
                ("transactionNo", request.TransactionId),
            };
            request.VerifySign = CommonHelpers.GenerateSign(_weChatPayPaymentSettings.ApiToken, signingParams);

            var response = await _weChatPayApi.CreateRefundAsync(request);
            if (response?.Payload == null)
                return new RefundPaymentResult { Errors = new[] { $"Error when calling WeChatPay refund endpoint. Code: {response?.Code}, Message: {response?.Message}." } };

            if (response.Payload.Status != "success")
                return new RefundPaymentResult { Errors = new[] { "Order refund is invalid" } };

            return new RefundPaymentResult
            {
                NewPaymentStatus = refundPaymentRequest.IsPartialRefund
                    ? PaymentStatus.PartiallyRefunded
                    : PaymentStatus.Refunded
            };
        }

        /// <summary>
        /// Voids a payment
        /// </summary>
        /// <param name="voidPaymentRequest">Request</param>
        /// <returns>
        /// A task that represents the asynchronous operation
        /// The task result contains the result
        /// </returns>
        public Task<VoidPaymentResult> VoidAsync(VoidPaymentRequest voidPaymentRequest)
        {
            return Task.FromResult(new VoidPaymentResult { Errors = new[] { "Void method not supported" } });
        }

        /// <summary>
        /// Process recurring payment
        /// </summary>
        /// <param name="processPaymentRequest">Payment info required for an order processing</param>
        /// <returns>
        /// A task that represents the asynchronous operation
        /// The task result contains the process payment result
        /// </returns>
        public Task<ProcessPaymentResult> ProcessRecurringPaymentAsync(ProcessPaymentRequest processPaymentRequest)
        {
            return Task.FromResult(new ProcessPaymentResult { Errors = new[] { "Recurring payment not supported" } });
        }

        /// <summary>
        /// Cancels a recurring payment
        /// </summary>
        /// <param name="cancelPaymentRequest">Request</param>
        /// <returns>
        /// A task that represents the asynchronous operation
        /// The task result contains the result
        /// </returns>
        public Task<CancelRecurringPaymentResult> CancelRecurringPaymentAsync(CancelRecurringPaymentRequest cancelPaymentRequest)
        {
            return Task.FromResult(new CancelRecurringPaymentResult { Errors = new[] { "Recurring payment not supported" } });
        }

        /// <summary>
        /// Gets a value indicating whether customers can complete a payment after order is placed but not completed (for redirection payment methods)
        /// </summary>
        /// <param name="order">Order</param>
        /// <returns>
        /// A task that represents the asynchronous operation
        /// The task result contains the result
        /// </returns>
        public Task<bool> CanRePostProcessPaymentAsync(Order order)
        {
            if (order == null)
                throw new ArgumentNullException(nameof(order));

            return Task.FromResult(true);
        }

        /// <summary>
        /// Validate payment form
        /// </summary>
        /// <param name="form">The parsed form values</param>
        /// <returns>
        /// A task that represents the asynchronous operation
        /// The task result contains the list of validating errors
        /// </returns>
        public async Task<IList<string>> ValidatePaymentFormAsync(IFormCollection form)
        {
            var errors = new List<string>();

            if (!await _weChatPayService.IsConfiguredAsync())
                errors.Add(await _localizationService.GetResourceAsync("Plugins.Payments.WeChatPay.IsNotConfigured"));

            if (!form.TryGetValue(nameof(PaymentInfoModel.PaymentChannel), out var paymentChannel) ||
                StringValues.IsNullOrEmpty(paymentChannel) ||
                !_weChatPayService.IsAvailablePaymentChannel(paymentChannel))
            {
                errors.Add(await _localizationService.GetResourceAsync("Plugins.Payments.WeChatPay.PaymentChannel.IsNotAvailable"));
            }

            return errors;
        }

        /// <summary>
        /// Get payment information
        /// </summary>
        /// <param name="form">The parsed form values</param>
        /// <returns>
        /// A task that represents the asynchronous operation
        /// The task result contains the payment info holder
        /// </returns>
        public async Task<ProcessPaymentRequest> GetPaymentInfoAsync(IFormCollection form)
        {
            var paymentRequest = new ProcessPaymentRequest();

            var paymentChannel = form.TryGetValue(nameof(PaymentInfoModel.PaymentChannel), out var value) ? value.ToString() : string.Empty;
            var paymentChannelKey = await _localizationService.GetResourceAsync("Plugins.Payments.WeChatPay.PaymentChannel.Key");
            paymentRequest.CustomValues.Add(paymentChannelKey, paymentChannel);

            return paymentRequest;
        }

        /// <summary>
        /// Gets a configuration page URL
        /// </summary>
        public override string GetConfigurationPageUrl()
        {
            return _urlHelperFactory.GetUrlHelper(_actionContextAccessor.ActionContext).RouteUrl(Defaults.ConfigurationRouteName);
        }

        /// <summary>
        /// Gets a name of a view component for displaying plugin in public store ("payment info" checkout step)
        /// </summary>
        /// <returns>View component name</returns>
        public string GetPublicViewComponentName()
        {
            return Defaults.PAYMENT_INFO_VIEW_COMPONENT_NAME;
        }

        /// <summary>
        /// Install the plugin
        /// </summary>
        /// <returns>A task that represents the asynchronous operation</returns>
        public override async Task InstallAsync()
        {
            //settings
            await _settingService.SaveSettingAsync(new WeChatPayPaymentSettings
            {
                BaseApiUrl = Defaults.Api.SandboxBaseUrl,
                PaymentChannels = new List<string> { "alipay", "wechatpay", "paypal", "venmo", "unionpay" }
            });

            //locales
            await _localizationService.AddLocaleResourceAsync(new Dictionary<string, string>
            {
                ["Plugins.Payments.WeChatPay.Instructions"] = @"
                    <p>
                        1. Apply for a WeChatPay Merchant Account
                        <br />2. Enter the Base API URL, Merchant No, Store No, and API token provided by WeChatPay
                        <br />3. Choose wallets you would like to enable from the Payment Channels drop down menu
                        <br />4. Click Save.
	                    <br />
                    </p>",
                ["Plugins.Payments.WeChatPay.IsNotConfigured"] = "Plugin isn't configured.",
                ["Plugins.Payments.WeChatPay.PaymentChannel.IsNotAvailable"] = "The payment channel isn't available.",
                ["Plugins.Payments.WeChatPay.PaymentChannel.Select"] = "Select the wallet:",
                ["Plugins.Payments.WeChatPay.PaymentChannel.Key"] = "The wallet",
                ["Plugins.Payments.WeChatPay.PaymentMethodDescription"] = "Pay by WeChatPay",
                ["Plugins.Payments.WeChatPay.RoundingWarning"] = "It looks like you have <a href=\"{0}\" target=\"_blank\">RoundPricesDuringCalculation</a> setting disabled. Keep in mind that this can lead to a discrepancy of the order total amount, as some payment services rounds to two decimals only.",
                ["Plugins.Payments.WeChatPay.Fields.ApiToken"] = "API token",
                ["Plugins.Payments.WeChatPay.Fields.ApiToken.Required"] = "The API token is required.",
                ["Plugins.Payments.WeChatPay.Fields.ApiToken.Hint"] = "Enter the token to sign the API requests.",
                ["Plugins.Payments.WeChatPay.Fields.BaseApiUrl"] = "Base API URL",
                ["Plugins.Payments.WeChatPay.Fields.BaseApiUrl.Required"] = "The base API URL is required.",
                ["Plugins.Payments.WeChatPay.Fields.BaseApiUrl.Hint"] = "Enter the base URL of the WeChatPay environment API.",
                ["Plugins.Payments.WeChatPay.Fields.MerchantEmail"] = "Request free WeChatPay product demo",
                ["Plugins.Payments.WeChatPay.Fields.MerchantEmail.Button"] = "Request",
                ["Plugins.Payments.WeChatPay.Fields.MerchantEmail.Hint"] = "Enter your email address.",
                ["Plugins.Payments.WeChatPay.Fields.MerchantEmail.Success"] = "Thank you for contacting. A member of WeChatPay team will respond to you shortly.",
                ["Plugins.Payments.WeChatPay.Fields.MerchantId"] = "Merchant No.",
                ["Plugins.Payments.WeChatPay.Fields.MerchantId.Required"] = "The merchant No. is required.",
                ["Plugins.Payments.WeChatPay.Fields.MerchantId.Hint"] = "Enter the merchant No.",
                ["Plugins.Payments.WeChatPay.Fields.StoreId"] = "Store No.",
                ["Plugins.Payments.WeChatPay.Fields.StoreId.Required"] = "The store No. is required.",
                ["Plugins.Payments.WeChatPay.Fields.StoreId.Hint"] = "Enter the store No.",
                ["Plugins.Payments.WeChatPay.Fields.PaymentChannels"] = "Payment channels",
                ["Plugins.Payments.WeChatPay.Fields.PaymentChannels.Required"] = "The payment channels are required.",
                ["Plugins.Payments.WeChatPay.Fields.PaymentChannels.Hint"] = "Select the payment channels available in checkout.",
                ["Plugins.Payments.WeChatPay.Fields.AdditionalFee"] = "Additional fee",
                ["Plugins.Payments.WeChatPay.Fields.AdditionalFee.Hint"] = "Enter additional fee to charge your customers.",
                ["Plugins.Payments.WeChatPay.Fields.AdditionalFeePercentage"] = "Additional fee. Use percentage",
                ["Plugins.Payments.WeChatPay.Fields.AdditionalFeePercentage.Hint"] = "Determines whether to apply a percentage additional fee to the order total. If not enabled, a fixed value is used.",
            });

            await base.InstallAsync();
        }

        /// <summary>
        /// Uninstall the plugin
        /// </summary>
        /// <returns>A task that represents the asynchronous operation</returns>
        public override async Task UninstallAsync()
        {
            //settings
            await _settingService.DeleteSettingAsync<WeChatPayPaymentSettings>();

            //locales
            await _localizationService.DeleteLocaleResourcesAsync("Plugins.Payments.WeChatPay");

            await base.UninstallAsync();
        }

        /// <summary>
        /// Gets a payment method description that will be displayed on checkout pages in the public store
        /// </summary>
        /// <returns>A task that represents the asynchronous operation</returns>
        public async Task<string> GetPaymentMethodDescriptionAsync()
        {
            return await _localizationService.GetResourceAsync("Plugins.Payments.WeChatPay.PaymentMethodDescription");
        }

        #endregion

        #region Properties

        /// <summary>
        /// Gets a value indicating whether capture is supported
        /// </summary>
        public bool SupportCapture => false;

        /// <summary>
        /// Gets a value indicating whether partial refund is supported
        /// </summary>
        public bool SupportPartiallyRefund => true;

        /// <summary>
        /// Gets a value indicating whether refund is supported
        /// </summary>
        public bool SupportRefund => true;

        /// <summary>
        /// Gets a value indicating whether void is supported
        /// </summary>
        public bool SupportVoid => false;

        /// <summary>
        /// Gets a recurring payment type of payment method
        /// </summary>
        public RecurringPaymentType RecurringPaymentType => RecurringPaymentType.NotSupported;

        /// <summary>
        /// Gets a payment method type
        /// </summary>
        public PaymentMethodType PaymentMethodType => PaymentMethodType.Redirection;

        /// <summary>
        /// Gets a value indicating whether we should display a payment information page for this plugin
        /// </summary>
        public bool SkipPaymentInfo => false;

        #endregion
    }
}