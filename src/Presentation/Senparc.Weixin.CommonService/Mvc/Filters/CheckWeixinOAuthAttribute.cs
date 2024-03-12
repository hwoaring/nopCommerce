using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc.Routing;
using Nop.Core.Domain.Customers;
using Nop.Core.Domain.Weixins;
using Nop.Core;
using Nop.Data;
using Nop.Services.Security;
using Nop.Services.Weixins;
using Senparc.CO2NET.Extensions;
using Senparc.Weixin.MP;
using Senparc.Weixin.Entities;
using Senparc.Weixin.MP.AdvancedAPIs;
using Nop.Core.Http.Extensions;


namespace Senparc.Weixin.CommonService.Mvc.Filters;

/// <summary>
/// 检查微信登录授权信息
/// </summary>
public sealed class CheckWeixinOAuthAttribute : TypeFilterAttribute
{
    #region Ctor

    /// <summary>
    /// Create instance of the filter attribute
    /// </summary>
    /// <param name="ignore">Whether to ignore the execution of filter actions</param>
    public CheckWeixinOAuthAttribute(bool ignore = false, bool publicPage = false) : base(typeof(CheckWeixinOAuthFilter))
    {
        IgnoreFilter = ignore;
        PublicPageFilter = publicPage;
        Arguments = new object[] { ignore, publicPage };
    }

    #endregion

    #region Properties

    /// <summary>
    /// Gets a value indicating whether to ignore the execution of filter actions
    /// </summary>
    public bool IgnoreFilter { get; }

    public bool PublicPageFilter { get; }

    #endregion

    #region Nested filter

    /// <summary>
    /// Represents a filter that confirms access to the admin panel
    /// </summary>
    private class CheckWeixinOAuthFilter : IAsyncAuthorizationFilter
    {
        #region Fields

        protected readonly bool _ignoreFilter;
        protected readonly bool _publicPageFilter;
        private readonly WeixinSettings _weixinSettings;
        private readonly IUrlHelperFactory _urlHelperFactory;
        private readonly IWebHelper _webHelper;
        protected readonly IWorkContext _workContext;
        private readonly SenparcWeixinSetting _senparcWeixinSetting;

        #endregion

        #region Ctor

        public CheckWeixinOAuthFilter(bool ignoreFilter,
            bool publicPageFilter,
            WeixinSettings weixinSettings,
            IUrlHelperFactory urlHelperFactory,
            IWebHelper webHelper,
            IWorkContext workContext,
            SenparcWeixinSetting senparcWeixinSetting)
        {
            _ignoreFilter = ignoreFilter;
            _publicPageFilter = publicPageFilter;
            _weixinSettings = weixinSettings;
            _urlHelperFactory = urlHelperFactory;
            _webHelper = webHelper;
            _workContext = workContext;
            _senparcWeixinSetting = senparcWeixinSetting;
        }

        #endregion

        #region Utilities

        /// <summary>
        /// Called early in the filter pipeline to confirm request is authorized
        /// </summary>
        /// <param name="context">Authorization filter context</param>
        /// <returns>A task that represents the asynchronous operation</returns>
        private async Task CheckWeixinOAuthAsync(AuthorizationFilterContext context)
        {
            if (context == null)
                throw new ArgumentNullException(nameof(context));

            if (!DataSettingsManager.IsDatabaseInstalled())
                return;

            //check whether this filter has been overridden for the action
            var actionFilter = context.ActionDescriptor.FilterDescriptors
                .Where(filterDescriptor => filterDescriptor.Scope == FilterScope.Action)
                .Select(filterDescriptor => filterDescriptor.Filter)
                .OfType<CheckWeixinOAuthAttribute>()
                .FirstOrDefault();

            //ignore filter (the action is available even if a customer hasn't access to the admin area)
            if (actionFilter?.IgnoreFilter ?? _ignoreFilter)
                return;

            //是否启用微信认证
            if (!_weixinSettings.WeChatOAuthEnable)
                return;

            var customer = await _workContext.GetCurrentCustomerAsync();
            //指定用户忽略验证
            if (actionFilter?.PublicPageFilter ?? _publicPageFilter)
            {
                //忽略前台认证
                if (customer.IgnoringWeChatPublicOauth)
                    return;
            }
            else
            {
                //忽略后台认证
                if (customer.IgnoringWeChatAdminOauth)
                    return;
            }

            //预先检查微信浏览器（不确定是否能准确检查到）
            if (_weixinSettings.CheckWeChatBrowser && !BrowserUtility.BrowserUtility.SideInWeixinBrowser(context.HttpContext))
            {
                var wechatBrowserControlerUrl = _urlHelperFactory.GetUrlHelper(context).RouteUrl(NopWeixinDefaults.WechatBrowserControler);
                context.Result = new RedirectToRouteResult(NopWeixinDefaults.WechatBrowserControler);
            }

            //there is AuthorizeFilter, so check access
            if (context.Filters.Any(filter => filter is CheckWeixinOAuthFilter))
            {
                var session = await context.HttpContext.Session.GetAsync<WeixinOAuthSession>(NopWeixinDefaults.WeixinOAuthSession);

                //RefreshToken30天有效期，在25天内刷新有效
                if (session != null && session.CreatTime.AddDays(25) > DateTime.Now)
                {
                    //OAuth accesstoken 2小时过期，提前10分钟验证，过期使用下面的RefreshToken刷新
                    if (session.CreatTime.AddMinutes(110) < DateTime.Now)
                    {
                        try
                        {
                            var refreshResult = OAuthApi.RefreshToken(_senparcWeixinSetting.WeixinAppId, session.RefreshToken);
                            if (refreshResult.errcode == ReturnCode.请求成功)
                            {
                                session.AccessToken = refreshResult.access_token;
                                session.RefreshToken = refreshResult.refresh_token;
                                session.ExpiresIn = refreshResult.expires_in;
                                session.CreatTime = DateTime.Now;
                                //Set Session
                                await context.HttpContext.Session.SetAsync(NopWeixinDefaults.WeixinOAuthSession, session);
                                return;
                            }
                        }
                        catch
                        {
                            //do nothing
                        }
                    }
                    else
                    {
                        return; //不需要刷新 
                    }
                }

                //开始重新获取accesstoken
                var oauthScope = OAuthScope.snsapi_userinfo;

                //判断前端页面使用snsapi_base认证
                if (actionFilter?.PublicPageFilter ?? _publicPageFilter && _weixinSettings.PublicPageUseSnsapiBase)
                    oauthScope = OAuthScope.snsapi_base;

                //初始化Oauth State（官方邀请state只能是a-zA-Z0-9）测试下面格式是否能通过传递
                //格式为：userinfo/userbase{TimeTicket}+【_{CustomerGuid}或{OpenId}】
                var oauthState = string.Concat(((oauthScope == OAuthScope.snsapi_base) ? "userbase" : "userinfo"), SystemTime.Now.Ticks.ToString());
                //保存state
                await context.HttpContext.Session.SetAsync(NopWeixinDefaults.WeixinOAuthState, oauthState);

                //redirect callback url
                var oauthCallbackUrl = _webHelper.GetStoreLocation().TrimEnd('/') + _urlHelperFactory.GetUrlHelper(context).RouteUrl(NopWeixinDefaults.WeixinOauthCallbackControler);
                oauthCallbackUrl += "?returnUrl=" + _webHelper.GetThisPageUrl(true).UrlEncode();
                var url = OAuthApi.GetAuthorizeUrl(_senparcWeixinSetting.WeixinAppId, oauthCallbackUrl, oauthState, oauthScope);
                context.Result = new RedirectResult(url);
            }
        }

        #endregion

        #region Methods

        /// <summary>
        /// Called early in the filter pipeline to confirm request is authorized
        /// </summary>
        /// <param name="context">Authorization filter context</param>
        /// <returns>A task that represents the asynchronous operation</returns>
        public async Task OnAuthorizationAsync(AuthorizationFilterContext context)
        {
            await CheckWeixinOAuthAsync(context);
        }

        #endregion
    }

    #endregion
}