using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Routing;
using Nop.Web.Framework;
using Nop.Web.Framework.Mvc.Routing;

namespace Nop.Plugin.Payments.WeChatPay.Infrastructure
{
    /// <summary>
    /// Represents plugin route provider
    /// </summary>
    public class RouteProvider : IRouteProvider
    {
        /// <summary>
        /// Register routes
        /// </summary>
        /// <param name="endpointRouteBuilder">Route builder</param>
        public void RegisterRoutes(IEndpointRouteBuilder endpointRouteBuilder)
        {
            endpointRouteBuilder.MapControllerRoute(Defaults.ConfigurationRouteName,
                "Plugins/WeChatPay/Configure",
                new { controller = "WeChatPayPayment", action = "Configure", area = AreaNames.Admin });

            endpointRouteBuilder.MapControllerRoute(Defaults.SecurePayWebhookRouteName,
                "Plugins/WeChatPay/SecurePayWebhook",
                new { controller = "WeChatPayWebhook", action = "SecurePayWebhook" });
        }

        /// <summary>
        /// Gets a priority of route provider
        /// </summary>
        public int Priority => 0;
    }
}