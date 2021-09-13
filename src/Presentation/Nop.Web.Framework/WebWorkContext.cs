using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Localization;
using Nop.Core;
using Nop.Core.Domain.Customers;
using Nop.Core.Domain.Directory;
using Nop.Core.Domain.Localization;
using Nop.Core.Domain.Tax;
using Nop.Core.Domain.Vendors;
using Nop.Core.Domain.Weixin;
using Nop.Core.Http;
using Nop.Core.Http.Extensions;
using Nop.Core.Security;
using Nop.Services.Authentication;
using Nop.Services.Common;
using Nop.Services.Customers;
using Nop.Services.Directory;
using Nop.Services.Helpers;
using Nop.Services.Localization;
using Nop.Services.ScheduleTasks;
using Nop.Services.Stores;
using Nop.Services.Vendors;
using Nop.Services.Weixin;

namespace Nop.Web.Framework
{
    /// <summary>
    /// Represents work context for web application
    /// </summary>
    public partial class WebWorkContext : IWorkContext
    {
        #region Fields

        private readonly CookieSettings _cookieSettings;
        private readonly CurrencySettings _currencySettings;
        private readonly IAuthenticationService _authenticationService;
        private readonly ICurrencyService _currencyService;
        private readonly ICustomerService _customerService;
        private readonly IGenericAttributeService _genericAttributeService;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly ILanguageService _languageService;
        private readonly IStoreContext _storeContext;
        private readonly IStoreMappingService _storeMappingService;
        private readonly IUserAgentHelper _userAgentHelper;
        private readonly IVendorService _vendorService;
        private readonly IWebHelper _webHelper;
        private readonly LocalizationSettings _localizationSettings;
        private readonly TaxSettings _taxSettings;
        private readonly CustomerSettings _customerSettings;
        private readonly VendorSettings _vendorSettings;

        private Customer _cachedCustomer;
        private Customer _cachedReferrerForCustomer;
        private Customer _originalCustomerIfImpersonated;
        private Vendor _cachedVendor;
        private Vendor _cachedVendorForCustomer;
        private Language _cachedLanguage;
        private Currency _cachedCurrency;
        private TaxDisplayType? _cachedTaxDisplayType;

        #endregion

        #region Ctor

        public WebWorkContext(CookieSettings cookieSettings,
            CurrencySettings currencySettings,
            IAuthenticationService authenticationService,
            ICurrencyService currencyService,
            ICustomerService customerService,
            IGenericAttributeService genericAttributeService,
            IHttpContextAccessor httpContextAccessor,
            ILanguageService languageService,
            IStoreContext storeContext,
            IStoreMappingService storeMappingService,
            IUserAgentHelper userAgentHelper,
            IVendorService vendorService,
            IWebHelper webHelper,
            LocalizationSettings localizationSettings,
            TaxSettings taxSettings,
            CustomerSettings customerSettings,
            VendorSettings vendorSettings)
        {
            _cookieSettings = cookieSettings;
            _currencySettings = currencySettings;
            _authenticationService = authenticationService;
            _currencyService = currencyService;
            _customerService = customerService;
            _genericAttributeService = genericAttributeService;
            _httpContextAccessor = httpContextAccessor;
            _languageService = languageService;
            _storeContext = storeContext;
            _storeMappingService = storeMappingService;
            _userAgentHelper = userAgentHelper;
            _vendorService = vendorService;
            _webHelper = webHelper;
            _localizationSettings = localizationSettings;
            _taxSettings = taxSettings;
            _customerSettings = customerSettings;
            _vendorSettings = vendorSettings;
        }

        #endregion

        #region Utilities

        /// <summary>
        /// Get nop customer cookie
        /// </summary>
        /// <returns>String value of cookie</returns>
        protected virtual string GetCustomerCookie()
        {
            var cookieName = $"{NopCookieDefaults.Prefix}{NopCookieDefaults.CustomerCookie}";
            return _httpContextAccessor.HttpContext?.Request?.Cookies[cookieName];
        }

        /// <summary>
        /// Set nop customer cookie
        /// </summary>
        /// <param name="customerGuid">Guid of the customer</param>
        protected virtual void SetCustomerCookie(Guid customerGuid)
        {
            if (_httpContextAccessor.HttpContext?.Response?.HasStarted ?? true)
                return;

            //delete current cookie value
            var cookieName = $"{NopCookieDefaults.Prefix}{NopCookieDefaults.CustomerCookie}";
            _httpContextAccessor.HttpContext.Response.Cookies.Delete(cookieName);

            //get date of cookie expiration
            var cookieExpires = _cookieSettings.CustomerCookieExpires;
            var cookieExpiresDate = DateTime.Now.AddHours(cookieExpires);

            //if passed guid is empty set cookie as expired
            if (customerGuid == Guid.Empty)
                cookieExpiresDate = DateTime.Now.AddMonths(-1);

            //set new cookie value
            var options = new CookieOptions
            {
                HttpOnly = true,
                Expires = cookieExpiresDate,
                Secure = _webHelper.IsCurrentConnectionSecured()
            };
            _httpContextAccessor.HttpContext.Response.Cookies.Append(cookieName, customerGuid.ToString(), options);
        }

        /// <summary>
        /// Get language from the requested page URL
        /// </summary>
        /// <returns>
        /// A task that represents the asynchronous operation
        /// The task result contains the found language
        /// </returns>
        protected virtual async Task<Language> GetLanguageFromUrlAsync()
        {
            if (_httpContextAccessor.HttpContext?.Request == null)
                return null;

            //whether the requsted URL is localized
            var path = _httpContextAccessor.HttpContext.Request.Path.Value;

            var (isLocalized, language) = await path.IsLocalizedUrlAsync(_httpContextAccessor.HttpContext.Request.PathBase, false);
            if (!isLocalized)
                return null;

            //check language availability
            if (!await _storeMappingService.AuthorizeAsync(language))
                return null;

            return language;
        }

        /// <summary>
        /// Get language from the request
        /// </summary>
        /// <returns>
        /// A task that represents the asynchronous operation
        /// The task result contains the found language
        /// </returns>
        protected virtual async Task<Language> GetLanguageFromRequestAsync()
        {
            if (_httpContextAccessor.HttpContext?.Request == null)
                return null;

            //get request culture
            var requestCulture = _httpContextAccessor.HttpContext.Features.Get<IRequestCultureFeature>()?.RequestCulture;
            if (requestCulture == null)
                return null;

            //try to get language by culture name
            var requestLanguage = (await _languageService.GetAllLanguagesAsync()).FirstOrDefault(language =>
                language.LanguageCulture.Equals(requestCulture.Culture.Name, StringComparison.InvariantCultureIgnoreCase));

            //check language availability
            if (requestLanguage == null || !requestLanguage.Published || !await _storeMappingService.AuthorizeAsync(requestLanguage))
                return null;

            return requestLanguage;
        }

        #endregion

        #region Properties

        /// <summary>
        /// Gets the current customer
        /// </summary>
        /// <returns>A task that represents the asynchronous operation</returns>
        public virtual async Task<Customer> GetCurrentCustomerAsync()
        {
            //whether there is a cached value
            if (_cachedCustomer != null)
                return _cachedCustomer;

            await SetCurrentCustomerAsync();

            return _cachedCustomer;
        }

        /// <summary>
        /// Sets the current customer
        /// </summary>
        /// <param name="customer">Current customer</param>
        /// <returns>A task that represents the asynchronous operation</returns>
        public virtual async Task SetCurrentCustomerAsync(Customer customer = null)
        {
            if (customer == null)
            {
                //check whether request is made by a background (schedule) task
                if (_httpContextAccessor.HttpContext?.Request
                    ?.Path.Equals(new PathString($"/{NopTaskDefaults.ScheduleTaskPath}"), StringComparison.InvariantCultureIgnoreCase)
                    ?? true)
                {
                    //in this case return built-in customer record for background task
                    customer = await _customerService.GetOrCreateBackgroundTaskUserAsync();
                }

                if (customer == null || customer.Deleted || !customer.Active || customer.RequireReLogin)
                {
                    //check whether request is made by a search engine, in this case return built-in customer record for search engines
                    if (_userAgentHelper.IsSearchEngine())
                        customer = await _customerService.GetOrCreateSearchEngineUserAsync();
                }

                if (customer == null || customer.Deleted || !customer.Active || customer.RequireReLogin)
                {
                    //try to get registered user
                    customer = await _authenticationService.GetAuthenticatedCustomerAsync();
                }

                if (customer != null && !customer.Deleted && customer.Active && !customer.RequireReLogin)
                {
                    //get impersonate user if required
                    var impersonatedCustomerId = await _genericAttributeService
                        .GetAttributeAsync<int?>(customer, NopCustomerDefaults.ImpersonatedCustomerIdAttribute);
                    if (impersonatedCustomerId.HasValue && impersonatedCustomerId.Value > 0)
                    {
                        var impersonatedCustomer = await _customerService.GetCustomerByIdAsync(impersonatedCustomerId.Value);
                        if (impersonatedCustomer != null && !impersonatedCustomer.Deleted &&
                            impersonatedCustomer.Active &&
                            !impersonatedCustomer.RequireReLogin)
                        {
                            //set impersonated customer
                            _originalCustomerIfImpersonated = customer;
                            customer = impersonatedCustomer;
                        }
                    }
                }

                if (customer == null || customer.Deleted || !customer.Active || customer.RequireReLogin)
                {
                    //try to get weixin oauth2 session user
                    var customerSession = _httpContextAccessor.HttpContext.Session.Get<OauthSession>(NopWeixinDefaults.WeixinOauthSession);
                    if (customerSession != null && !string.IsNullOrEmpty(customerSession.OpenId))
                    {
                        var customerBySession = await _customerService.GetCustomerByOpenIdAsync(customerSession.OpenId);
                        if (customerBySession != null)
                            customer = customerBySession;
                    }
                }

                if (customer == null || customer.Deleted || !customer.Active || customer.RequireReLogin)
                {
                    //get guest customer
                    var customerCookie = GetCustomerCookie();
                    if (Guid.TryParse(customerCookie, out var customerGuid))
                    {
                        //get customer from cookie (should not be registered)
                        var customerByCookie = await _customerService.GetCustomerByGuidAsync(customerGuid);
                        if (customerByCookie != null && !await _customerService.IsRegisteredAsync(customerByCookie))
                            customer = customerByCookie;
                    }
                }

                if (customer == null || customer.Deleted || !customer.Active || customer.RequireReLogin)
                {
                    //create guest if not exists
                    customer = await _customerService.InsertGuestCustomerAsync();
                }
            }

            //Customer与OpenId绑定
            if (string.IsNullOrEmpty(customer.OpenId))
            {
                await SetCustomerOpenIdAsync(string.Empty, customer); 
            }

            if (!customer.Deleted && customer.Active && !customer.RequireReLogin)
            {
                //set customer cookie
                SetCustomerCookie(customer.CustomerGuid);

                //cache the found customer
                _cachedCustomer = customer;
            }
        }

        /// <summary>
        /// 设置Customer绑定的OpenId
        /// </summary>
        /// <param name="openId">当前用户OpenId</param>
        /// <param name="customer">当前用户</param>
        /// <returns></returns>
        public virtual async Task SetCustomerOpenIdAsync(string openId, Customer customer = null)
        {
            if (string.IsNullOrEmpty(openId) && customer != null)
            {
                //Weixin oauth2 session user
                var oauthSession = _httpContextAccessor.HttpContext.Session.Get<OauthSession>(NopWeixinDefaults.WeixinOauthSession);
                if (oauthSession != null && !string.IsNullOrEmpty(oauthSession.OpenId))
                    openId = oauthSession.OpenId;
            }

            if (string.IsNullOrEmpty(openId))
                return;

            //Customer为空，是从API接入
            if (customer == null)
            {
                customer = await _customerService.GetCustomerByOpenIdAsync(openId);
                if (customer == null)
                    customer = await _customerService.InsertGuestCustomerAsync();
            }

            if (string.IsNullOrEmpty(customer.OpenId))
            {
                customer.OpenId = openId;
                customer.AdminComment = "Weixin Guest.";
                //customer.RegisteredInStoreId = (await _storeContext.GetCurrentStoreAsync()).Id;

                //update customer
                await _customerService.UpdateCustomerAsync(customer);
            }
        }

        /// <summary>
        /// 设置Customer绑定的推荐人
        /// </summary>
        /// <param name="referrerParam">推荐人参数：OpenId或Gid</param>
        /// <param name="customer">当前用户</param>
        /// <param name="openIdParamFixed">referrerParam固定为OpenId（不检查传入参数名称）</param>
        /// <param name="forceUpdateReferrerCustomerId">是否强制更新永久推荐人Id</param>
        /// <param name="refreshCache">刷新Customer缓存</param>
        /// <returns></returns>
        public virtual async Task SetCustomerReferrerIdAsync(string referrerParam, Customer currentCustomer, bool openIdParamFixed = false, bool forceUpdateReferrerCustomerId = false, bool refreshCache = false)
        {
            if (string.IsNullOrEmpty(referrerParam))
                return;

            if (currentCustomer == null)
                return;

            //获取推荐人
            var referrerCustomer = openIdParamFixed ?
                await _customerService.GetCustomerByOpenIdAsync(referrerParam) :
                (_customerSettings.UseGidForReferrerParam ?
                (Guid.TryParse(referrerParam, out var customerGuid) ? await _customerService.GetCustomerByGuidAsync(customerGuid) : null) :
                await _customerService.GetCustomerByOpenIdAsync(referrerParam));

            if (referrerCustomer == null
                || referrerCustomer.Deleted
                || !referrerCustomer.Active
                || !referrerCustomer.ReferrerEnable)
                return;

            //自己不能推荐自己
            if (referrerCustomer.Id == currentCustomer.Id)
                return;

            if (currentCustomer.ReferrerCustomerId == 0 || forceUpdateReferrerCustomerId)
            {
                //没有第一推荐人或强制更新
                currentCustomer.ReferrerCustomerId = referrerCustomer.Id;
                if (referrerCustomer.AsTempReferrerEnable)
                {
                    currentCustomer.TempReferrerCustomerId = referrerCustomer.Id;
                    currentCustomer.TempReferrerDateUtc = DateTime.UtcNow;
                }

                //update Customer
                await _customerService.UpdateCustomerAsync(currentCustomer);

                if (refreshCache)
                    await SetCurrentCustomerAsync(currentCustomer);
            }
            else if (_customerSettings.RefereeIdAvailableMinutes > 0 && referrerCustomer.AsTempReferrerEnable)
            {
                //启用临时推荐人过时
                currentCustomer.TempReferrerCustomerId = referrerCustomer.Id;
                currentCustomer.TempReferrerDateUtc = DateTime.UtcNow;

                //update Customer
                await _customerService.UpdateCustomerAsync(currentCustomer);

                if (refreshCache)
                    await SetCurrentCustomerAsync(currentCustomer);
            }
        }

        /// <summary>
        /// 设置Customer绑定的推荐人
        /// </summary>
        /// <param name="referrerCustomerId">Customer Id</param>
        /// <param name="customer">当前用户</param>
        /// <param name="forceUpdateReferrerCustomerId">是否强制更新永久推荐人Id</param>
        /// <param name="refreshCache">刷新Customer缓存</param>
        /// <returns></returns>
        public virtual async Task SetCustomerReferrerIdAsync(int referrerCustomerId, Customer currentCustomer, bool forceUpdateReferrerCustomerId = false, bool refreshCache = false)
        {
            if (referrerCustomerId <= 0)
                return;

            if (currentCustomer == null)
                return;

            //获取推荐人
            var referrerCustomer = await _customerService.GetCustomerByIdAsync(referrerCustomerId);

            if (referrerCustomer == null
                || referrerCustomer.Deleted
                || !referrerCustomer.Active
                || !referrerCustomer.ReferrerEnable)
                return;

            //自己不能推荐自己
            if (referrerCustomer.Id == currentCustomer.Id)
                return;

            if (currentCustomer.ReferrerCustomerId == 0 || forceUpdateReferrerCustomerId)
            {
                //没有第一推荐人或强制更新
                currentCustomer.ReferrerCustomerId = referrerCustomer.Id;
                if (referrerCustomer.AsTempReferrerEnable)
                {
                    currentCustomer.TempReferrerCustomerId = referrerCustomer.Id;
                    currentCustomer.TempReferrerDateUtc = DateTime.UtcNow;
                }

                //update Customer
                await _customerService.UpdateCustomerAsync(currentCustomer);

                if (refreshCache)
                    await SetCurrentCustomerAsync(currentCustomer);
            }
            else if (_customerSettings.RefereeIdAvailableMinutes > 0 && referrerCustomer.AsTempReferrerEnable)
            {
                //启用临时推荐人过时
                currentCustomer.TempReferrerCustomerId = referrerCustomer.Id;
                currentCustomer.TempReferrerDateUtc = DateTime.UtcNow;

                //update Customer
                await _customerService.UpdateCustomerAsync(currentCustomer);

                if (refreshCache)
                    await SetCurrentCustomerAsync(currentCustomer);
            }
        }

        /// <summary>
        /// 获取当前用户的Vendor（自己或父级）
        /// </summary>
        /// <returns></returns>
        public virtual async Task<Vendor> GetVendorForCurrentCustomerAsync()
        {
            //whether there is a cached value
            if (_cachedVendorForCustomer != null)
                return _cachedVendorForCustomer;

            var customer = await GetCurrentCustomerAsync();
            if (customer == null)
                return null;

            //自己是Vendor，不再往上找
            var vendor = await GetCurrentVendorAsync();

            //向上查找父级Vendor
            if (vendor == null)
            {
                //至少查一级
                var vendorParentLevel = _vendorSettings.VendorParentLevel > 0 ?
                    _vendorSettings.VendorParentLevel : 1;

                for (var i = 0; i < vendorParentLevel; i++)
                {
                    customer = await _customerService.GetReferrerCustomerAsync(customer, true);
                    if (customer != null && customer.Active && !customer.Deleted)
                    {
                        vendor = await _vendorService.GetVendorByIdAsync(customer.VendorId);
                        if (vendor != null && vendor.Active && !vendor.Deleted)
                            break;
                    }
                }
            }

            //cache the found Vendor
            _cachedVendorForCustomer = vendor;

            return _cachedVendorForCustomer;
        }

        /// <summary>
        /// 获取当前用户的Referrer(临时或永久)
        /// </summary>
        /// <returns></returns>
        public virtual async Task<Customer> GetReferrerForCurrentCustomerAsync()
        {
            //whether there is a cached value
            if (_cachedReferrerForCustomer != null)
                return _cachedReferrerForCustomer;

            var customer = await GetCurrentCustomerAsync();
            if (customer == null)
                return null;

            var referrerCustomer = await _customerService.GetReferrerCustomerAsync(customer);

            //cache the found Referrer
            _cachedReferrerForCustomer = referrerCustomer;

            return _cachedReferrerForCustomer;
        }

        /// <summary>
        /// Gets the original customer (in case the current one is impersonated)
        /// </summary>
        public virtual Customer OriginalCustomerIfImpersonated => _originalCustomerIfImpersonated;

        /// <summary>
        /// Gets the current vendor (logged-in manager)
        /// </summary>
        /// <returns>A task that represents the asynchronous operation</returns>
        public virtual async Task<Vendor> GetCurrentVendorAsync()
        {
            //whether there is a cached value
            if (_cachedVendor != null)
                return _cachedVendor;

            var customer = await GetCurrentCustomerAsync();
            if (customer == null)
                return null;

            //check vendor availability
            var vendor = await _vendorService.GetVendorByIdAsync(customer.VendorId);
            if (vendor == null || vendor.Deleted || !vendor.Active)
                return null;

            //cache the found vendor
            _cachedVendor = vendor;

            return _cachedVendor;
        }

        /// <summary>
        /// Sets current user working language
        /// </summary>
        /// <param name="language">Language</param>
        /// <returns>A task that represents the asynchronous operation</returns>
        public virtual async Task SetWorkingLanguageAsync(Language language)
        {
            //save passed language identifier
            var customer = await GetCurrentCustomerAsync();
            var store = await _storeContext.GetCurrentStoreAsync();
            await _genericAttributeService.SaveAttributeAsync(customer, NopCustomerDefaults.LanguageIdAttribute, language?.Id ?? 0, store.Id);

            //then reset the cached value
            _cachedLanguage = null;
        }

        /// <summary>
        /// Gets current user working language
        /// </summary>
        /// <returns>A task that represents the asynchronous operation</returns>
        public virtual async Task<Language> GetWorkingLanguageAsync()
        {
            //whether there is a cached value
            if (_cachedLanguage != null)
                return _cachedLanguage;

            var customer = await GetCurrentCustomerAsync();
            var store = await _storeContext.GetCurrentStoreAsync();

            Language detectedLanguage = null;

            //localized URLs are enabled, so try to get language from the requested page URL
            if (_localizationSettings.SeoFriendlyUrlsForLanguagesEnabled)
                detectedLanguage = await GetLanguageFromUrlAsync();

            //whether we should detect the language from the request
            if (detectedLanguage == null && _localizationSettings.AutomaticallyDetectLanguage)
            {
                //whether language already detected by this way
                var alreadyDetected = await _genericAttributeService
                    .GetAttributeAsync<bool>(customer, NopCustomerDefaults.LanguageAutomaticallyDetectedAttribute, store.Id);

                //if not, try to get language from the request
                if (!alreadyDetected)
                {
                    detectedLanguage = await GetLanguageFromRequestAsync();
                    if (detectedLanguage != null)
                    {
                        //language already detected
                        await _genericAttributeService
                            .SaveAttributeAsync(customer, NopCustomerDefaults.LanguageAutomaticallyDetectedAttribute, true, store.Id);
                    }
                }
            }

            //if the language is detected we need to save it
            if (detectedLanguage != null)
            {
                //get current saved language identifier
                var currentLanguageId = await _genericAttributeService
                    .GetAttributeAsync<int>(customer, NopCustomerDefaults.LanguageIdAttribute, store.Id);

                //save the detected language identifier if it differs from the current one
                if (detectedLanguage.Id != currentLanguageId)
                {
                    await _genericAttributeService
                        .SaveAttributeAsync(customer, NopCustomerDefaults.LanguageIdAttribute, detectedLanguage.Id, store.Id);
                }
            }

            //get current customer language identifier
            var customerLanguageId = await _genericAttributeService
                .GetAttributeAsync<int>(customer, NopCustomerDefaults.LanguageIdAttribute, store.Id);

            var allStoreLanguages = await _languageService.GetAllLanguagesAsync(storeId: store.Id);

            //check customer language availability
            var customerLanguage = allStoreLanguages.FirstOrDefault(language => language.Id == customerLanguageId);
            if (customerLanguage == null)
            {
                //it not found, then try to get the default language for the current store (if specified)
                customerLanguage = allStoreLanguages.FirstOrDefault(language => language.Id == store.DefaultLanguageId);
            }

            //if the default language for the current store not found, then try to get the first one
            if (customerLanguage == null)
                customerLanguage = allStoreLanguages.FirstOrDefault();

            //if there are no languages for the current store try to get the first one regardless of the store
            if (customerLanguage == null)
                customerLanguage = (await _languageService.GetAllLanguagesAsync()).FirstOrDefault();

            //cache the found language
            _cachedLanguage = customerLanguage;

            return _cachedLanguage;
        }

        /// <summary>
        /// Gets current user working currency
        /// </summary>
        /// <returns>A task that represents the asynchronous operation</returns>
        public virtual async Task<Currency> GetWorkingCurrencyAsync()
        {
            //whether there is a cached value
            if (_cachedCurrency != null)
                return _cachedCurrency;

            var adminAreaUrl = $"{_webHelper.GetStoreLocation()}admin";

            //return primary store currency when we're in admin area/mode
            if (_webHelper.GetThisPageUrl(false).StartsWith(adminAreaUrl, StringComparison.InvariantCultureIgnoreCase))
            {
                var primaryStoreCurrency = await _currencyService.GetCurrencyByIdAsync(_currencySettings.PrimaryStoreCurrencyId);
                if (primaryStoreCurrency != null)
                {
                    _cachedCurrency = primaryStoreCurrency;
                    return primaryStoreCurrency;
                }
            }

            var customer = await GetCurrentCustomerAsync();
            var store = await _storeContext.GetCurrentStoreAsync();

            //find a currency previously selected by a customer
            var customerCurrencyId = await _genericAttributeService
                .GetAttributeAsync<int>(customer, NopCustomerDefaults.CurrencyIdAttribute, store.Id);

            var allStoreCurrencies = await _currencyService.GetAllCurrenciesAsync(storeId: store.Id);

            //check customer currency availability
            var customerCurrency = allStoreCurrencies.FirstOrDefault(currency => currency.Id == customerCurrencyId);
            if (customerCurrency == null)
            {
                //it not found, then try to get the default currency for the current language (if specified)
                var language = await GetWorkingLanguageAsync();
                customerCurrency = allStoreCurrencies
                    .FirstOrDefault(currency => currency.Id == language.DefaultCurrencyId);
            }

            //if the default currency for the current store not found, then try to get the first one
            if (customerCurrency == null)
                customerCurrency = allStoreCurrencies.FirstOrDefault();

            //if there are no currencies for the current store try to get the first one regardless of the store
            if (customerCurrency == null)
                customerCurrency = (await _currencyService.GetAllCurrenciesAsync()).FirstOrDefault();

            //cache the found currency
            _cachedCurrency = customerCurrency;

            return _cachedCurrency;
        }

        /// <summary>
        /// Sets current user working currency
        /// </summary>
        /// <param name="currency">Currency</param>
        /// <returns>A task that represents the asynchronous operation</returns>
        public virtual async Task SetWorkingCurrencyAsync(Currency currency)
        {
            //save passed currency identifier
            var customer = await GetCurrentCustomerAsync();
            var store = await _storeContext.GetCurrentStoreAsync();
            await _genericAttributeService.SaveAttributeAsync(customer, NopCustomerDefaults.CurrencyIdAttribute, currency?.Id ?? 0, store.Id);

            //then reset the cached value
            _cachedCurrency = null;
        }

        /// <summary>
        /// Gets or sets current tax display type
        /// </summary>
        /// <returns>A task that represents the asynchronous operation</returns>
        public virtual async Task<TaxDisplayType> GetTaxDisplayTypeAsync()
        {
            //whether there is a cached value
            if (_cachedTaxDisplayType.HasValue)
                return _cachedTaxDisplayType.Value;

            var taxDisplayType = TaxDisplayType.IncludingTax;
            var customer = await GetCurrentCustomerAsync();
            var store = await _storeContext.GetCurrentStoreAsync();

            //whether customers are allowed to select tax display type
            if (_taxSettings.AllowCustomersToSelectTaxDisplayType && customer != null)
            {
                //try to get previously saved tax display type
                var taxDisplayTypeId = await _genericAttributeService
                    .GetAttributeAsync<int?>(customer, NopCustomerDefaults.TaxDisplayTypeIdAttribute, store.Id);
                if (taxDisplayTypeId.HasValue)
                    taxDisplayType = (TaxDisplayType)taxDisplayTypeId.Value;
                else
                {
                    //default tax type by customer roles
                    var defaultRoleTaxDisplayType = await _customerService.GetCustomerDefaultTaxDisplayTypeAsync(customer);
                    if (defaultRoleTaxDisplayType != null)
                        taxDisplayType = defaultRoleTaxDisplayType.Value;
                }
            }
            else
            {
                //default tax type by customer roles
                var defaultRoleTaxDisplayType = await _customerService.GetCustomerDefaultTaxDisplayTypeAsync(customer);
                if (defaultRoleTaxDisplayType != null)
                    taxDisplayType = defaultRoleTaxDisplayType.Value;
                else
                {
                    //or get the default tax display type
                    taxDisplayType = _taxSettings.TaxDisplayType;
                }
            }

            //cache the value
            _cachedTaxDisplayType = taxDisplayType;

            return _cachedTaxDisplayType.Value;
        }

        /// <returns>A task that represents the asynchronous operation</returns>
        public virtual async Task SetTaxDisplayTypeAsync(TaxDisplayType taxDisplayType)
        {
            //whether customers are allowed to select tax display type
            if (!_taxSettings.AllowCustomersToSelectTaxDisplayType)
                return;

            //save passed value
            var customer = await GetCurrentCustomerAsync();
            var store = await _storeContext.GetCurrentStoreAsync();
            await _genericAttributeService
                .SaveAttributeAsync(customer, NopCustomerDefaults.TaxDisplayTypeIdAttribute, (int)taxDisplayType, store.Id);

            //then reset the cached value
            _cachedTaxDisplayType = null;
        }

        /// <summary>
        /// Gets or sets value indicating whether we're in admin area
        /// </summary>
        public virtual bool IsAdmin { get; set; }

        #endregion
    }
}