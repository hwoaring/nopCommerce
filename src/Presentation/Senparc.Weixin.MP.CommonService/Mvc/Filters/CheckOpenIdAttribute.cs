using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
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
    /// Represents filter attribute that checks and updates WUser OpenId of customer
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
        /// Represents a filter that checks and updates WUser OpenId of customer
        /// </summary>
        private class CheckOpenIdFilter : IAsyncActionFilter
        {
            #region Constants

            //这两个都是保存推荐人或分享人的信息，当前用户的openid 在Oauth2中获取
            private const string WUSER_OPENID_QUERY_PARAMETER_NAME = "openid";
            private const string WUSER_OPENID_HASH_QUERY_PARAMETER_NAME = "openidhash";

            #endregion

            #region Fields

            private readonly ICustomerService _customerService;
            private readonly IWorkContext _workContext;
            private readonly IWUserService _wUserService;
            private readonly IHttpContextAccessor _httpContextAccessor;

            #endregion

            #region Ctor

            public CheckOpenIdFilter(ICustomerService customerService,
                IWUserService wUserService,
                IHttpContextAccessor httpContextAccessor,
                IWorkContext workContext)
            {
                _customerService = customerService;
                _workContext = workContext;
                _httpContextAccessor = httpContextAccessor;
                _wUserService = wUserService;
            }

            #endregion

            #region Utilities

            /// <summary>
            /// Set the wuser referee openid of current customer
            /// </summary>
            /// <param name="affiliate">Affiliate</param>
            private async Task SetCustomerOpenIdAsync(Customer customer, string refereeOpenId, long refereeOpenIdHash)
            {
                var update = false;

                //不能自己推荐自己
                if (!string.IsNullOrEmpty(refereeOpenId) && refereeOpenId.Length < 32 && refereeOpenId != customer.OpenId)
                {
                    var refereeUser = await _wUserService.GetWUserByOpenIdAsync(refereeOpenId);
                    if (refereeUser != null)
                    {
                        customer.RefereeId = refereeUser.Id;
                        customer.RefereeIdUpdateTime = Convert.ToInt32(Nop.Core.Weixin.Helpers.DateTimeHelper.GetUnixDateTime(DateTime.Now));
                        update = true;
                    }
                }
                else if (refereeOpenIdHash > 0)
                {
                    var refereeUser = await _wUserService.GetWUserByOpenIdHashAsync(refereeOpenIdHash);
                    if (refereeUser != null && refereeUser.OpenId != customer.OpenId)
                    {
                        customer.RefereeId = refereeUser.Id;
                        customer.RefereeIdUpdateTime = Convert.ToInt32(Nop.Core.Weixin.Helpers.DateTimeHelper.GetUnixDateTime(DateTime.Now));
                        update = true;
                    }
                }

                //update openId Info
                if (update)
                    await _customerService.UpdateCustomerAsync(customer);
            }

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

                if (!await DataSettingsManager.IsDatabaseInstalledAsync())
                    return;

                var customer = await _workContext.GetCurrentCustomerAsync();

                //ignore search engines and back ground task
                if (customer.IsSearchEngineAccount() || customer.IsBackgroundTaskAccount())
                    return;

                //Customer与OpenId绑定
                var oauthSession = _httpContextAccessor.HttpContext.Session.Get<OauthSession>(NopWeixinDefaults.WeixinOauthSession);
                if (oauthSession != null && !string.IsNullOrEmpty(oauthSession.OpenId) && string.IsNullOrEmpty(customer.OpenId))
                {
                    customer.OpenId = oauthSession.OpenId;
                    await _customerService.UpdateCustomerAsync(customer);
                }

                //check request query parameters
                var request = context.HttpContext.Request;
                if (request?.Query == null || !request.Query.Any())
                    return;

                var openIds = request.Query[WUSER_OPENID_QUERY_PARAMETER_NAME];  //这里是推荐人OpenId
                var openIdsHash = request.Query[WUSER_OPENID_HASH_QUERY_PARAMETER_NAME]; //这里是推荐人OpenIdHash

                var openId = openIds.Any() ? openIds.FirstOrDefault() : string.Empty;
                var openIdHash = openIdsHash.Any() ? (long.TryParse(openIdsHash.FirstOrDefault(), out var hashResult) ? hashResult : 0) : 0;

                await SetCustomerOpenIdAsync(customer, openId, openIdHash);
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