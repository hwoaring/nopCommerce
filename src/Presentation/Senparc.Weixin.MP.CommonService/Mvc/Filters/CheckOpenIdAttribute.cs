using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Primitives;
using Nop.Core;
using Nop.Core.Domain.Customers;
using Nop.Core.Domain.Weixin;
using Nop.Data;
using Nop.Services.Weixin;
using Nop.Services.Customers;
using System.Net.Http;
using Nop.Core.Http.Extensions;

namespace Senparc.Weixin.MP.CommonService.Mvc.Filters
{
    /// <summary>
    /// Represents filter attribute that checks and updates OpenId of customer
    /// </summary>
    public sealed class CheckOpenIdAttribute : TypeFilterAttribute
    {
        #region Ctor

        /// <summary>
        /// Create instance of the filter attribute
        /// </summary>
        public CheckOpenIdAttribute() : base(typeof(CheckOpenIdFilter))
        {
        }

        #endregion

        #region Nested filter

        /// <summary>
        /// Represents a filter that checks and updates OpenId of customer
        /// </summary>
        private class CheckOpenIdFilter : IAsyncActionFilter
        {

            #region Fields

            private readonly ICustomerService _customerService;
            private readonly IWorkContext _workContext;
            private readonly IWxUserService _wUserService;
            private readonly IHttpContextAccessor _httpContextAccessor;
            private readonly CustomerSettings _customerSettings;

            #endregion

            #region Ctor

            public CheckOpenIdFilter(ICustomerService customerService,
                IWxUserService wUserService,
                IHttpContextAccessor httpContextAccessor,
                IWorkContext workContext,
                CustomerSettings customerSettings)
            {
                _customerService = customerService;
                _workContext = workContext;
                _httpContextAccessor = httpContextAccessor;
                _wUserService = wUserService;
                _customerSettings = customerSettings;
            }

            #endregion

            #region Utilities

            #endregion

            #region Methods

            /// <summary>
            /// Called before the action executes, after model binding is complete
            /// </summary>
            /// <param name="context">A context for action filters</param>
            private async Task CheckOpenIdAsync(ActionExecutingContext context)
            {
                if (context == null)
                    throw new ArgumentNullException(nameof(context));

                //check request query parameters
                if (!context.HttpContext.Request?.Query?.Any() ?? true)
                    return;

                if (!await DataSettingsManager.IsDatabaseInstalledAsync())
                    return;

                var customer = await _workContext.GetCurrentCustomerAsync();

                //ignore search engines and back ground task
                if (customer.IsSearchEngineAccount() || customer.IsBackgroundTaskAccount())
                    return;

                //推荐人参数
                var queryKey = _customerSettings.UseGidForReferrerParam ? NopCustomerServicesDefaults.CustomerQueryParamGuid : NopCustomerServicesDefaults.CustomerQueryParamOpenid;
                if (!context.HttpContext.Request.Query.TryGetValue(queryKey, out var referrerCodes) || StringValues.IsNullOrEmpty(referrerCodes))
                    return;

                //绑定推荐人Id
                await _workContext.SetCustomerReferrerIdAsync(referrerCodes.FirstOrDefault(), customer, refreshCache: true);
            }

            /// <summary>
            /// Called asynchronously before the action, after model binding is complete.
            /// </summary>
            /// <param name="context">A context for action filters</param>
            /// <param name="next">A delegate invoked to execute the next action filter or the action itself</param>
            /// <returns>A task that on completion indicates the filter has executed</returns>
            public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
            {
                await CheckOpenIdAsync(context);
                if (context.Result == null)
                    await next();
            }

            #endregion
        }

        #endregion
    }
}