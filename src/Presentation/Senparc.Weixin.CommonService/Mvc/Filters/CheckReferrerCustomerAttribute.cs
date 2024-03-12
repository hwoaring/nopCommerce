using DocumentFormat.OpenXml.Office2010.Excel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Nop.Core;
using Nop.Core.Domain.Affiliates;
using Nop.Core.Domain.Customers;
using Nop.Data;
using Nop.Services.Affiliates;
using Nop.Services.Customers;

namespace Nop.Web.Framework.Mvc.Filters;

/// <summary>
/// 通过检查URL参数，更新推荐用户ID
/// </summary>
public sealed class CheckReferrerCustomerAttribute : TypeFilterAttribute
{
    #region Ctor

    /// <summary>
    /// Create instance of the filter attribute
    /// </summary>
    public CheckReferrerCustomerAttribute() : base(typeof(CheckReferrerCustomerFilter))
    {
    }

    #endregion

    #region Nested filter

    /// <summary>
    /// Represents a filter that checks and updates affiliate of customer
    /// </summary>
    private class CheckReferrerCustomerFilter : IAsyncActionFilter
    {
        #region Constants

        /// <summary>
        /// /// <summary>
        /// 通过Customer 推荐码 ReferrerCode查找
        /// </summary>
        /// </summary>
        private const string REFERRER_CUSTOMER_CODE = "refcode";

        /// <summary>
        /// /// <summary>
        /// 通过Customer Id查找
        /// </summary>
        /// </summary>
        private const string REFERRER_CUSTOMER_ID = "refid";

        /// <summary>
        /// /// <summary>
        /// 通过Customer OpenId查找
        /// </summary>
        /// </summary>
        private const string REFERRER_CUSTOMER_OPENID = "refopenid";

        /// <summary>
        /// 通过Customer Guid查找
        /// </summary>
        private const string REFERRER_CUSTOMER_GUID = "refgid";

        #endregion

        #region Fields

        protected readonly ICustomerService _customerService;
        protected readonly IWorkContext _workContext;
        protected readonly IStoreContext _storeContext;
        protected readonly CustomerSettings _customerSettings;

        #endregion

        #region Ctor

        public CheckReferrerCustomerFilter(ICustomerService customerService,
            IWorkContext workContext,
            IStoreContext storeContext,
            CustomerSettings customerSettings)
        {
            _customerService = customerService;
            _workContext = workContext;
            _storeContext = storeContext;
            _customerSettings = customerSettings;
        }

        #endregion

        #region Utilities

        /// <summary>
        /// Called asynchronously before the action, after model binding is complete.
        /// </summary>
        /// <param name="context">A context for action filters</param>
        /// <returns>A task that represents the asynchronous operation</returns>
        private async Task CheckReferrerCustomerAsync(ActionExecutingContext context)
        {
            if (context == null)
                throw new ArgumentNullException(nameof(context));

            //check request query parameters
            var request = context.HttpContext.Request;
            if (request?.Query == null || request.Query.Count == 0)
                return;

            if (!DataSettingsManager.IsDatabaseInstalled())
                return;

            //查找当前用户
            var customer = await _workContext.GetCurrentCustomerAsync();

            //忽略搜索引擎
            if (customer.IsSearchEngineAccount()|| customer.IsBackgroundTaskAccount())
                return;

            //通过ReferrerCode查找
            var referrerCustomerCodes = request.Query[REFERRER_CUSTOMER_CODE];
            if (long.TryParse(referrerCustomerCodes.FirstOrDefault(), out var referrerCustomerCode) && referrerCustomerCode > 0 && referrerCustomerCode != customer.ReferrerCode)
            {
                var referrerCustomer = await _customerService.GetCustomerByReferrerCodeAsync(referrerCustomerCode);
                await _workContext.SetCurrentReferrerCustomerAsync(referrerCustomer);
                return;
            }

            //通过Id查找
            var referrerCustomerIds = request.Query[REFERRER_CUSTOMER_ID];
            if (int.TryParse(referrerCustomerIds.FirstOrDefault(), out var referrerCustomerId) && referrerCustomerId > 0 && referrerCustomerId != customer.Id)
            {
                var referrerCustomer = await _customerService.GetCustomerByIdAsync(referrerCustomerId);
                await _workContext.SetCurrentReferrerCustomerAsync(referrerCustomer);
                return;
            }

            //通过Openid查找
            var referrerCustomerOpenIds = request.Query[REFERRER_CUSTOMER_OPENID];
            var referrerCustomerOpenId = referrerCustomerOpenIds.FirstOrDefault();
            if (!string.IsNullOrEmpty(referrerCustomerOpenId))
            {
                var referrerCustomer = await _customerService.GetCustomerByOpenIdAsync(referrerCustomerOpenId);
                await _workContext.SetCurrentReferrerCustomerAsync(referrerCustomer);
                return;
            }

            //通过Guid查找
            var referrerCustomerGuids = request.Query[REFERRER_CUSTOMER_GUID];
            var referrerCustomerGuid = referrerCustomerGuids.FirstOrDefault();
            if (!string.IsNullOrWhiteSpace(referrerCustomerGuid) && referrerCustomerGuid.Length == 32)
            {
                if (Guid.TryParse(referrerCustomerGuid, out var referrerGuid) && referrerGuid != customer.CustomerGuid)
                {
                    var referrerCustomer = await _customerService.GetCustomerByGuidAsync(referrerGuid);
                    await _workContext.SetCurrentReferrerCustomerAsync(referrerCustomer);
                    return;
                }
            }
        }

        #endregion

        #region Methods

        /// <summary>
        /// Called asynchronously before the action, after model binding is complete.
        /// </summary>
        /// <param name="context">A context for action filters</param>
        /// <param name="next">A delegate invoked to execute the next action filter or the action itself</param>
        /// <returns>A task that represents the asynchronous operation</returns>
        public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            await CheckReferrerCustomerAsync(context);
            if (context.Result == null)
                await next();
        }

        #endregion
    }

    #endregion
}