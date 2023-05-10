using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Nop.Core;
using Nop.Core.Domain.Customers;
using Nop.Data;
using Nop.Services.Customers;

namespace Nop.Web.Framework.Mvc.Filters
{
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
        /// 检查和更新推荐用户ID
        /// </summary>
        private class CheckReferrerCustomerFilter : IAsyncActionFilter
        {
            #region Constants

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
            private readonly CustomerSettings _customerSettings;

            #endregion

            #region Ctor

            public CheckReferrerCustomerFilter(ICustomerService customerService,
                CustomerSettings customerSettings,
                IWorkContext workContext)
            {
                _customerService = customerService;
                _customerSettings = customerSettings;
                _workContext = workContext;
            }

            #endregion

            #region Utilities

            /// <summary>
            /// Set the affiliate identifier of current customer
            /// </summary>
            /// <param name="affiliate">Affiliate</param>
            /// <param name="customer">Customer</param>
            /// <returns>A task that represents the asynchronous operation</returns>
            private async Task SetReferrerCustomerIdAsync(Customer referrerCustomer, Customer currentCustomer)
            {
                if (currentCustomer == null || 
                    referrerCustomer == null || 
                    referrerCustomer.Deleted || 
                    !referrerCustomer.Active || 
                    !referrerCustomer.ReferrerEnable)
                    return;

                //忽略自己推荐自己
                if (referrerCustomer.Id == currentCustomer.Id)
                    return;

                //更新推荐信息
                if (currentCustomer.ReferrerCustomerId == 0)
                {
                    currentCustomer.ReferrerCustomerId = referrerCustomer.Id;
                    currentCustomer.TempReferrerCustomerId = referrerCustomer.Id;
                    currentCustomer.TempReferrerExpireDateUtc = DateTime.UtcNow.AddMinutes(_customerSettings.RefereeIdAvailableMinutes);
                }

                if (referrerCustomer.AsTempReferrerEnable && _customerSettings.RefereeIdAvailableMinutes > 0)
                {
                    if (_customerSettings.LockTempTime)
                    {
                        if (currentCustomer.TempReferrerExpireDateUtc < DateTime.UtcNow)
                        {
                            currentCustomer.TempReferrerCustomerId = referrerCustomer.Id;
                            currentCustomer.TempReferrerExpireDateUtc = DateTime.UtcNow.AddMinutes(_customerSettings.RefereeIdAvailableMinutes);
                        }
                    }
                    else
                    {
                        currentCustomer.TempReferrerCustomerId = referrerCustomer.Id;
                        currentCustomer.TempReferrerExpireDateUtc = DateTime.UtcNow.AddMinutes(_customerSettings.RefereeIdAvailableMinutes);
                    }
                }
                    

                //保存更新
                await _customerService.UpdateCustomerAsync(currentCustomer);

                //更新缓存
                await _workContext.SetCurrentCustomerAsync(currentCustomer);
            }

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
                if (request?.Query == null || !request.Query.Any())
                    return;

                if (!DataSettingsManager.IsDatabaseInstalled())
                    return;

                var customer = await _workContext.GetCurrentCustomerAsync();

                //忽略搜索引擎
                if (customer.IsSearchEngineAccount() || customer.IsBackgroundTaskAccount())
                    return;

                ////通过Customer Id查找
                //var referrerIds = request.Query[REFERRER_CUSTOMER_ID];
                //if (int.TryParse(referrerIds.FirstOrDefault(), out var referrerId)
                //    && referrerId > 0
                //    && referrerId != customer.Id
                //    )
                //{
                //    var referrerCustomer = await _customerService.GetCustomerByIdAsync(referrerId);
                //    await SetReferrerCustomerIdAsync(referrerCustomer, customer);
                //    return;
                //}

                //通过Customer OpenId查找
                var referrerOpenIds = request.Query[REFERRER_CUSTOMER_OPENID];
                var referrerOpenId = referrerOpenIds.FirstOrDefault();
                if (!string.IsNullOrWhiteSpace(referrerOpenId) && referrerOpenId.Length > 25 && referrerOpenId.Length <= 32)
                {
                    if (referrerOpenId != customer.CustomerOpenId)
                    {
                        var referrerCustomer = await _customerService.GetCustomerByOpenIdAsync(referrerOpenId);
                        await SetReferrerCustomerIdAsync(referrerCustomer, customer);
                    }
                }

                //通过Customer Guid查找
                var referrerGuids = request.Query[REFERRER_CUSTOMER_GUID];
                var referrerGuid = referrerGuids.FirstOrDefault();
                if (!string.IsNullOrWhiteSpace(referrerGuid) && referrerGuid.Length == 32)
                {
                    if (Guid.TryParse(referrerGuid, out var refGuid) && refGuid != customer.CustomerGuid)
                    {
                        var referrerCustomer = await _customerService.GetCustomerByGuidAsync(refGuid);
                        await SetReferrerCustomerIdAsync(referrerCustomer, customer);
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
}