using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc.Rendering;
using Nop.Core;

namespace Nop.Plugin.Payments.WeChatPay
{
    /// <summary>
    /// Represents a plugin defaults
    /// </summary>
    public static class Defaults
    {
        /// <summary>
        /// Gets the plugin system name
        /// </summary>
        public static string SystemName => "Payments.WeChatPay";

        /// <summary>
        /// Gets the plugin configuration route name
        /// </summary>
        public static string ConfigurationRouteName => "Plugin.Payments.WeChatPay.Configure";

        /// <summary>
        /// Gets the checkout completed route name
        /// </summary>
        public static string CheckoutCompletedRouteName => "CheckoutCompleted";

        /// <summary>
        /// Gets the secure pay web hook route name
        /// </summary>
        public static string SecurePayWebhookRouteName => "WeChatPaySecurePayWebHook";

        /// <summary>
        /// Gets the order details route name
        /// </summary>
        public static string OrderDetailsRouteName => "OrderDetails";

        /// <summary>
        /// Gets a name of the view component to display payment info in public store
        /// </summary>
        public const string PAYMENT_INFO_VIEW_COMPONENT_NAME = "WeChatPayPaymentInfo";

        /// <summary>
        /// Gets the name of attribute to store payment channel per customer
        /// </summary>
        public static string PaymentChannelAttribute => "WeChatPayPaymentChannelAttribute";

        /// <summary>
        /// Gets the available payment channels
        /// </summary>
        public static List<SelectListItem> AvailablePaymentChannels => new()
        {
            new SelectListItem("AliPay", "alipay"),
            new SelectListItem("WeChat Pay", "wechatpay"),
        };

        /// <summary>
        /// Represents API defaults
        /// </summary>
        public static class Api
        {
            /// <summary>
            /// Gets the API base URL
            /// </summary>
            public static string SandboxBaseUrl => "https://api.mch.weixin.qq.com/sandboxnew/pay/";

            /// <summary>
            /// Gets the user agent
            /// </summary>
            public static string UserAgent => $"nopCommerce-{NopVersion.CURRENT_VERSION}";

            /// <summary>
            /// Gets the default timeout
            /// </summary>
            public static int DefaultTimeout => 20;

            /// <summary>
            /// Represents endpoints defaults
            /// </summary>
            public static class Endpoints
            {
                /// <summary>
                /// Gets the secure pay endpoint path
                /// </summary>
                public static string SecurePayPath => "/online/v3/secure-pay";

                /// <summary>
                /// Gets the refund endpoint path
                /// </summary>
                public static string RefundPath => "/app-data-search/v3/refund";
            }

            /// <summary>
            /// Gets the URL to request demo
            /// </summary>
            public static string RequestDemoUrl => "https://api.mch.weixin.qq.com/sandboxnew/pay/";
        }
    }
}