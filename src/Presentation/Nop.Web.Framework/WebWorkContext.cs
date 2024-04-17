using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Localization;
using Nop.Core;
using Nop.Core.Domain.Customers;
using Nop.Core.Domain.Directory;
using Nop.Core.Domain.Localization;
using Nop.Core.Domain.Tax;
using Nop.Core.Domain.Vendors;
using Nop.Core.Http;
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
using Nop.Web.Framework.Globalization;

//=======
using Nop.Services.Weixins;
using Nop.Core.Http.Extensions;

namespace Nop.Web.Framework;

/// <summary>
/// Represents work context for web application
/// </summary>
public partial class WebWorkContext : IWorkContext
{
    #region Fields

    protected readonly CookieSettings _cookieSettings;
    protected readonly CurrencySettings _currencySettings;
    protected readonly IAuthenticationService _authenticationService;
    protected readonly ICurrencyService _currencyService;
    protected readonly ICustomerService _customerService;
    protected readonly IGenericAttributeService _genericAttributeService;
    protected readonly IHttpContextAccessor _httpContextAccessor;
    protected readonly ILanguageService _languageService;
    protected readonly IStoreContext _storeContext;
    protected readonly IStoreMappingService _storeMappingService;
    protected readonly IUserAgentHelper _userAgentHelper;
    protected readonly IVendorService _vendorService;
    protected readonly IWebHelper _webHelper;
    protected readonly LocalizationSettings _localizationSettings;
    protected readonly TaxSettings _taxSettings;

    protected Customer _cachedCustomer;
    protected Customer _originalCustomerIfImpersonated;
    protected Vendor _cachedVendor;
    protected Language _cachedLanguage;
    protected Currency _cachedCurrency;
    protected TaxDisplayType? _cachedTaxDisplayType;
    protected Customer _cachedReferrerCustomer;  //推荐人信息

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
        TaxSettings taxSettings)
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
    /// Set language culture cookie
    /// </summary>
    /// <param name="language">Language</param>
    protected virtual void SetLanguageCookie(Language language)
    {
        if (_httpContextAccessor.HttpContext?.Response?.HasStarted ?? true)
            return;

        //delete current cookie value
        var cookieName = $"{NopCookieDefaults.Prefix}{NopCookieDefaults.CultureCookie}";
        _httpContextAccessor.HttpContext.Response.Cookies.Delete(cookieName);

        if (string.IsNullOrEmpty(language?.LanguageCulture))
            return;

        //set new cookie value
        var value = CookieRequestCultureProvider.MakeCookieValue(new RequestCulture(language.LanguageCulture));
        var options = new CookieOptions { Expires = DateTimeOffset.UtcNow.AddYears(1) };
        _httpContextAccessor.HttpContext.Response.Cookies.Append(cookieName, value, options);
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
        var requestCultureFeature = _httpContextAccessor.HttpContext?.Features.Get<IRequestCultureFeature>();
        if (requestCultureFeature is null)
            return null;

        //whether we should detect the current language by customer settings
        if (requestCultureFeature.Provider is not NopSeoUrlCultureProvider && !_localizationSettings.AutomaticallyDetectLanguage)
            return null;

        //get request culture
        if (requestCultureFeature.RequestCulture is null)
            return null;

        //try to get language by culture name
        var requestLanguage = (await _languageService.GetAllLanguagesAsync()).FirstOrDefault(language =>
            language.LanguageCulture.Equals(requestCultureFeature.RequestCulture.Culture.Name, StringComparison.InvariantCultureIgnoreCase));

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

            if (customer == null || customer.Deleted || !customer.Active || customer.RequireReLogin)
            {
                //微信认证登录获取用户
                var customerSession = await _httpContextAccessor.HttpContext.Session.GetAsync<WeixinOAuthSession>(NopWeixinDefaults.WeixinOAuthSession);
                if (customerSession != null && !string.IsNullOrEmpty(customerSession.OpenId))
                {
                    var customerBySession = await _customerService.GetCustomerByOpenIdAsync(customerSession.OpenId);
                    if (customerBySession != null)
                        customer = customerBySession;
                }
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

        if (!customer.Deleted && customer.Active && !customer.RequireReLogin)
        {
            //set customer cookie
            SetCustomerCookie(customer.CustomerGuid);

            //cache the found customer
            _cachedCustomer = customer;
        }
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

        if (!customer.IsSystemAccount)
        {
            customer.LanguageId = language?.Id;
            await _customerService.UpdateCustomerAsync(customer);
        }

        //set cookie
        SetLanguageCookie(language);

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

        //whether we should detect the language from the request
        var detectedLanguage = await GetLanguageFromRequestAsync();

        //get current saved language identifier
        var currentLanguageId = customer.LanguageId;

        //if the language is detected we need to save it
        if (detectedLanguage != null)
        {
            //save the detected language identifier if it differs from the current one
            if (detectedLanguage.Id != currentLanguageId)
                await SetWorkingLanguageAsync(detectedLanguage);
        }
        else
        {
            var allStoreLanguages = await _languageService.GetAllLanguagesAsync(storeId: store.Id);

            //check customer language availability
            detectedLanguage = allStoreLanguages.FirstOrDefault(language => language.Id == currentLanguageId);

            //it not found, then try to get the default language for the current store (if specified)
            detectedLanguage ??= allStoreLanguages.FirstOrDefault(language => language.Id == store.DefaultLanguageId);

            //if the default language for the current store not found, then try to get the first one
            detectedLanguage ??= allStoreLanguages.FirstOrDefault();

            //if there are no languages for the current store try to get the first one regardless of the store
            detectedLanguage ??= (await _languageService.GetAllLanguagesAsync()).FirstOrDefault();

            SetLanguageCookie(detectedLanguage);
        }

        //cache the found language
        _cachedLanguage = detectedLanguage;

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

        if (customer.IsSearchEngineAccount())
        {
            _cachedCurrency = await _currencyService.GetCurrencyByIdAsync(_currencySettings.PrimaryStoreCurrencyId)
                              ?? (await _currencyService.GetAllCurrenciesAsync(storeId: store.Id)).FirstOrDefault();

            return _cachedCurrency;
        }

        var allStoreCurrencies = await _currencyService.GetAllCurrenciesAsync(storeId: store.Id);

        //check customer currency availability
        var customerCurrency = allStoreCurrencies.FirstOrDefault(currency => currency.Id == customer.CurrencyId);
        if (customerCurrency == null)
        {
            //it not found, then try to get the default currency for the current language (if specified)
            var language = await GetWorkingLanguageAsync();
            customerCurrency = allStoreCurrencies
                .FirstOrDefault(currency => currency.Id == language.DefaultCurrencyId);
        }

        //if the default currency for the current store not found, then try to get the first one
        customerCurrency ??= allStoreCurrencies.FirstOrDefault();

        //if there are no currencies for the current store try to get the first one regardless of the store
        customerCurrency ??= (await _currencyService.GetAllCurrenciesAsync()).FirstOrDefault();

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
        if (customer.IsSearchEngineAccount())
            return;

        customer.CurrencyId = currency?.Id;
        await _customerService.UpdateCustomerAsync(customer);

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

        var customer = await GetCurrentCustomerAsync();
        var taxDisplayType = await _customerService.GetCustomerTaxDisplayTypeAsync(customer);

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
        customer.TaxDisplayType = taxDisplayType;
        await _customerService.UpdateCustomerAsync(customer);

        //then reset the cached value
        _cachedTaxDisplayType = null;
    }

    /// <summary>
    /// Gets or sets value indicating whether we're in admin area
    /// </summary>
    public virtual bool IsAdmin { get; set; }

    #endregion

    #region === 扩展方法 ===

    /// <summary>
    /// 获取当前用户推荐人信息（已经判断临时推荐人和永久推荐人）
    /// </summary>
    /// <returns></returns>
    public virtual async Task<Customer> GetCurrentReferrerCustomerAsync()
    {
        //whether there is a cached value
        if (_cachedReferrerCustomer != null)
            return _cachedReferrerCustomer;

        await SetCurrentReferrerCustomerAsync();

        return _cachedReferrerCustomer;
    }

    /// <summary>
    /// 获取当前用户的推荐人信息
    /// 如果传入有值，判断是否更推荐人信息
    /// </summary>
    /// <param name="referrerCustomer"></param>
    /// <returns></returns>
    public virtual async Task SetCurrentReferrerCustomerAsync(Customer referrerCustomer = null)
    {
        //需要解决问题：
        //传入参数为空时，直接获取当前已经有的推荐人
        //如果有参数，则判断是否更新推荐人信息，并重新获取推荐人

        var store = await _storeContext.GetCurrentStoreAsync();
        var currentCustomer = GetCurrentCustomerAsync();

        var rootReferrerCustomerId = 0;          //保存源推荐人ID
        var setRootReferrerCustomerId = false;   //判断是否需要设置源推荐人ID（源推荐人设置了新的推荐人code情况）


        #region === 判断referrerCustomer是否设置了他人的推荐码 ===

        //判断源推荐人referrerCustomer是否设置了他人的推荐码(不为空，Id>0防止默认推荐人传入)
        if (referrerCustomer != null && referrerCustomer.Id > 0)
        {
            //判断（推荐人）是否在推荐状态，忽略自己推荐自己
            if (referrerCustomer.Deleted || !referrerCustomer.Active)
                referrerCustomer = null;

            //判断店铺是否关闭推荐功能
            if (!store.ReferrerEnable)
                referrerCustomer = null;

            if(referrerCustomer != null)
            {
                //获取当前（推荐人）的推荐设置
                var referrerCustomerReferrerSetting = await _customerService.GetCustomerReferrerSettingByStoreIdCustomerIdAsync(store.Id, referrerCustomer.Id);
                if (referrerCustomerReferrerSetting != null &&
                    referrerCustomerReferrerSetting.AsReferrerEnable &&
                    referrerCustomerReferrerSetting.AsTempReferrerEnable &&
                    referrerCustomerReferrerSetting.OthersReferrerCode > 0 &&
                    referrerCustomerReferrerSetting.OthersReferrerCodeEnable)
                {
                    rootReferrerCustomerId = referrerCustomer.Id;  //保存源推荐人ID
                    setRootReferrerCustomerId = true;              //允许设置源推荐人ID
                    //获取用户通过推荐码设置的新（推荐人）
                    referrerCustomer = await _customerService.GetCustomerByReferrerCodeAsync(referrerCustomerReferrerSetting.OthersReferrerCode);
                }
            }
        }

        #endregion

        #region === 更新或新建推荐人信息 ===

        //更新（不为空，Id>0防止默认推荐人传入）
        if (referrerCustomer != null && referrerCustomer.Id > 0)
        {
            //判断（推荐人）是否在推荐状态，忽略自己推荐自己
            if (referrerCustomer.Deleted || !referrerCustomer.Active || referrerCustomer.Id == currentCustomer.Id)
                referrerCustomer = null;

            //判断店铺是否关闭推荐功能
            if (!store.ReferrerEnable)
                referrerCustomer = null;

            if (referrerCustomer != null)
            {
                //获取（当前）用户的推荐设置
                var currentCustomerReferrerSetting = await _customerService.GetCustomerReferrerSettingByStoreIdCustomerIdAsync(store.Id, currentCustomer.Id);
                if (currentCustomerReferrerSetting == null)
                {
                    currentCustomerReferrerSetting = new CustomerReferrerSetting
                    {
                        StoreId = store.Id,
                        CustomerId = currentCustomer.Id,
                        OthersReferrerCode = 0L,
                        OthersReferrerCodeEnable = true,
                        AsReferrerEnable = store.DefaultCustomerReferrerEnable,
                        AsRecommendedEnable = store.DefaultCustomerRecommendedEnable,
                        AsTempReferrerEnable = store.DefaultCustomerTempReferrerEnable,
                        EnableTempReferrerId = true,
                        CloseReferrer = false
                    };
                    await _customerService.InsertCustomerReferrerSettingAsync(currentCustomerReferrerSetting);
                }

                //判断（当前）用户是否在被推荐状态
                if (!currentCustomerReferrerSetting.AsRecommendedEnable)
                    referrerCustomer = null;
            }

            if (referrerCustomer != null)
            {
                //获取（推荐人）用户的推荐设置
                var referrerCustomerReferrerSetting = await _customerService.GetCustomerReferrerSettingByStoreIdCustomerIdAsync(store.Id, referrerCustomer.Id);
                if (referrerCustomerReferrerSetting == null)
                {
                    referrerCustomerReferrerSetting = new CustomerReferrerSetting
                    {
                        StoreId = store.Id,
                        CustomerId = referrerCustomer.Id,
                        OthersReferrerCode = 0L,
                        OthersReferrerCodeEnable = true,
                        AsReferrerEnable = store.DefaultCustomerReferrerEnable,
                        AsRecommendedEnable = store.DefaultCustomerRecommendedEnable,
                        AsTempReferrerEnable = store.DefaultCustomerTempReferrerEnable,
                        EnableTempReferrerId = true,
                        CloseReferrer = false
                    };
                    await _customerService.InsertCustomerReferrerSettingAsync(referrerCustomerReferrerSetting);
                }

                //判断（推荐人）是否在推荐状态
                if (!referrerCustomerReferrerSetting.AsReferrerEnable)
                    referrerCustomer = null;
            }

            if (referrerCustomer != null)
            {
                //获取（当前）用户的推荐人参数信息
                var currentCustomerReferrer = await _customerService.GetCustomerReferrerByStoreIdCustomerIdAsync(store.Id, currentCustomer.Id);
                if (currentCustomerReferrer == null)
                {
                    currentCustomerReferrer = new CustomerReferrer
                    {
                        ReferreredInStoreId = store.Id,
                        CustomerId = currentCustomer.Id,
                        ReferrerCustomerId = referrerCustomer.Id,
                        TempReferrerCustomerId = referrerCustomer.Id,
                        TempReferrerExpireDateUtc = DateTime.UtcNow.AddMinutes(store.TempReferrerExpireMinutes),
                        ReferrerSceneStr = string.Empty,  //推荐场景值
                        ReferrerSceneId = 0,   //推荐场景数字ID
                        FirstReferrerPageUrl = string.Empty,  //被推荐用户的首次访问页面
                        FirstReferrerPageId = 0,  //被推荐用户的首次访问页面ID
                        FirstReferrerPageType = 1,  //页面类型
                    };
                    //新建当前用户的推荐人信息，如果推荐用户设置了推荐码，永久推荐人保存为当前推荐人，临时推荐人为设置的推荐人
                    currentCustomerReferrer.ReferrerCustomerId = setRootReferrerCustomerId ? rootReferrerCustomerId : referrerCustomer.Id;
                    currentCustomerReferrer.TempReferrerBySourceCustomerId = setRootReferrerCustomerId ? rootReferrerCustomerId : referrerCustomer.Id;

                    await _customerService.InsertCustomerReferrerAsync(currentCustomerReferrer);
                }

                //获取（推荐人）用户的推荐设置
                var referrerCustomerReferrerSetting = await _customerService.GetCustomerReferrerSettingByStoreIdCustomerIdAsync(store.Id, referrerCustomer.Id);
                
                //更新（当前）用户的临时推荐人ID
                if (referrerCustomerReferrerSetting != null && referrerCustomerReferrerSetting.AsTempReferrerEnable && store.TempReferrerExpireMinutes > 0)
                {
                    //过期前保护
                    if (store.TempReferrerExpireProtect)
                    {
                        if (currentCustomerReferrer.TempReferrerExpireDateUtc < DateTime.UtcNow)
                        {
                            currentCustomerReferrer.TempReferrerCustomerId = referrerCustomer.Id;
                            currentCustomerReferrer.TempReferrerBySourceCustomerId = setRootReferrerCustomerId ? rootReferrerCustomerId : referrerCustomer.Id;
                            currentCustomerReferrer.TempReferrerExpireDateUtc = DateTime.UtcNow.AddMinutes(store.TempReferrerExpireMinutes);
                        }
                    }
                    else
                    {
                        currentCustomerReferrer.TempReferrerCustomerId = referrerCustomer.Id;
                        currentCustomerReferrer.TempReferrerBySourceCustomerId = setRootReferrerCustomerId ? rootReferrerCustomerId : referrerCustomer.Id;
                        currentCustomerReferrer.TempReferrerExpireDateUtc = DateTime.UtcNow.AddMinutes(store.TempReferrerExpireMinutes);
                    }

                    //更新临时推荐人信息
                    await _customerService.UpdateCustomerReferrerAsync(currentCustomerReferrer);
                }
            }
        }

        #endregion

        #region === 重新查找推荐人信息 ===

        //重新查找推荐人信息
        var customerReferrer = await _customerService.GetCustomerReferrerByStoreIdCustomerIdAsync(store.Id, currentCustomer.Id);
        if (customerReferrer != null)
        {
            int referrerId;
            if (customerReferrer.TempReferrerExpireDateUtc != null && customerReferrer.TempReferrerExpireDateUtc > DateTime.UtcNow)
                referrerId = customerReferrer.TempReferrerCustomerId;
            else
                referrerId = customerReferrer.ReferrerCustomerId;

            //重新查找（新推荐人），并判断推荐人状态
            referrerCustomer = await _customerService.GetCustomerByIdAsync(referrerId);
            if (referrerCustomer == null || referrerCustomer.Deleted || !referrerCustomer.Active)
            {
                _cachedReferrerCustomer = new Customer();
                return;
            }

            //获取（新推荐人）的推荐设置，并判断推荐人推荐状态
            var referrerCustomerReferrerSetting = await _customerService.GetCustomerReferrerSettingByStoreIdCustomerIdAsync(store.Id, referrerCustomer.Id);
            if (referrerCustomerReferrerSetting == null || !referrerCustomerReferrerSetting.AsReferrerEnable)
            {
                _cachedReferrerCustomer = new Customer();
                return;
            }

            //缓存新推荐人
            _cachedReferrerCustomer = referrerCustomer;

        }
        else
        {
            _cachedReferrerCustomer = new Customer();
        }

        #endregion
    }

    /// <summary>
    /// 从WeixinSession绑定当前用户的OpenId
    /// </summary>
    /// <param name="customer">当前用户</param>
    /// <param name="openId"></param>
    /// <param name="isSnapshotuser"></param>
    /// <returns></returns>
    public virtual async Task<Customer> SetCurrentCustomerOpenIdAsync(Customer customer, string openId, int? isSnapshotuser)
    {
        //空值不绑定
        if (string.IsNullOrEmpty(openId) || customer == null)
            return customer;

        //虚拟账号不进行绑定
        if (isSnapshotuser.HasValue && isSnapshotuser.Value == 1)
            return customer;

        //已经绑定OpenId
        if (!string.IsNullOrWhiteSpace(customer.OpenId))
            return customer;

        //绑定
        customer.OpenId = openId;
        customer.AdminComment = "Weixin Authorized Guest."; //微信授权进入的普通访客

        //更新数据库
        await _customerService.UpdateCustomerAsync(customer);

        //重置缓存
        await SetCurrentCustomerAsync(customer);

        return customer;
    }

    #endregion
}