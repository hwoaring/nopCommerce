using Nop.Services.Installation;
using Nop.Web.Framework.Mvc.Routing;

namespace Nop.Web.Infrastructure
{
    /// <summary>
    /// Represents provider that provided basic routes
    /// </summary>
    public partial class RouteWeixinProvider : BaseRouteProvider, IRouteProvider
    {
        #region Methods

        /// <summary>
        /// Register routes
        /// </summary>
        /// <param name="endpointRouteBuilder">Route builder</param>
        public void RegisterRoutes(IEndpointRouteBuilder endpointRouteBuilder)
        {
            var lang = GetLanguageRoutePattern();


            endpointRouteBuilder.MapControllerRoute(name: "Weixin",
                pattern: $"Weixin",
                defaults: new { controller = "Weixin", action = "Index" });

            endpointRouteBuilder.MapControllerRoute(name: "OAuth2",
                pattern: $"OAuth2",
                defaults: new { controller = "OAuth2", action = "Index" });

            endpointRouteBuilder.MapControllerRoute(name: "WeixinJSSDK",
                pattern: $"WeixinJSSDK",
                defaults: new { controller = "WeixinJSSDK", action = "Index" });
        }

        #endregion

        #region Properties

        /// <summary>
        /// Gets a priority of route provider
        /// </summary>
        public int Priority => 0;

        #endregion
    }
}