using System;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc.Routing;
using Microsoft.Extensions.Primitives;
using Nop.Core;
using Nop.Core.Domain.Customers;
using Nop.Core.Domain.Weixin;
using Nop.Core.Http.Extensions;
using Nop.Data;
using Nop.Services.Customers;
using Nop.Services.Security;
using Nop.Services.Weixin;

using Senparc.CO2NET.Extensions;
using Senparc.Weixin.Entities;
using Senparc.Weixin.MP.AdvancedAPIs;

namespace Senparc.Weixin.MP.CommonService.Mvc.Filters
{
    /// <summary>
    /// Represents a filter attribute that confirms access oauth2
    /// </summary>
    public sealed class CheckWeixinOAuthAttribute : TypeFilterAttribute
    {
        #region Ctor

        /// <summary>
        /// Create instance of the filter attribute
        /// </summary>
        /// <param name="ignore">Whether to ignore the execution of filter actions</param>
        public CheckWeixinOAuthAttribute(bool ignore = false, string oauthRouteName = "", OAuthScope oauthScope = OAuthScope.snsapi_userinfo) : base(typeof(CheckWeixinOAuthFilter))
        {
            IgnoreFilter = ignore;
            Arguments = new object[] { ignore, oauthRouteName, oauthScope };
        }

        #endregion

        #region Properties

        /// <summary>
        /// Gets a value indicating whether to ignore the execution of filter actions
        /// </summary>
        public bool IgnoreFilter { get; }

        #endregion

        #region Nested filter

        /// <summary>
        /// Represents a filter that confirms access to public store
        /// </summary>
        private class CheckWeixinOAuthFilter : IAsyncAuthorizationFilter
        {
            #region Fields

            private readonly bool _ignoreFilter;
            private readonly string _oauthRouteName;
            private readonly OAuthScope _oauthScope;
            private readonly WeixinSettings _weixinSettings;
            private readonly IUrlHelperFactory _urlHelperFactory;
            private readonly IWebHelper _webHelper;
            private readonly IStoreContext _storeContext;
            private readonly CustomerSettings _customerSettings;
            private readonly SenparcWeixinSetting _senparcWeixinSetting;
            #endregion

            #region Ctor

            public CheckWeixinOAuthFilter(bool ignoreFilter,
                string oauthRouteName,
                OAuthScope oauthScope,
                //ignore, oauthRouteName, oauthScope 
                WeixinSettings weixinSettings,
                IUrlHelperFactory urlHelperFactory,
                IWebHelper webHelper,
                IStoreContext storeContext,
                CustomerSettings customerSettings,
                SenparcWeixinSetting senparcWeixinSetting
                )
            {
                _ignoreFilter = ignoreFilter;
                _oauthRouteName = oauthRouteName;
                _oauthScope = oauthScope;
                _weixinSettings = weixinSettings;
                _urlHelperFactory = urlHelperFactory;
                _webHelper = webHelper;
                _storeContext = storeContext;
                _customerSettings = customerSettings;
                _senparcWeixinSetting = senparcWeixinSetting;
            }

            #endregion

            #region Utilities

            /// <summary>
            /// Called early in the filter pipeline to confirm request is authorized
            /// </summary>
            /// <param name="filterContext">Authorization filter context</param>
            public async Task AuthorizeWeixinOauthAsync(AuthorizationFilterContext context)
            {
                if (context == null)
                    throw new ArgumentNullException(nameof(context));

                //only in GET requests
                //if (!context.HttpContext.Request.Method.Equals(WebRequestMethods.Http.Get, StringComparison.InvariantCultureIgnoreCase))
                //return;

                if (!await DataSettingsManager.IsDatabaseInstalledAsync())
                    return;

                //check whether this filter has been overridden for the action
                var actionFilter = context.ActionDescriptor.FilterDescriptors
                    .Where(filterDescriptor => filterDescriptor.Scope == FilterScope.Action)
                    .Select(filterDescriptor => filterDescriptor.Filter)
                    .OfType<CheckWeixinOAuthAttribute>()
                    .FirstOrDefault();

                //ignore filter (the action is available even if navigation is not allowed)
                if (actionFilter?.IgnoreFilter ?? _ignoreFilter)
                    return;

                //whether Oauth is enabled
                if (!_weixinSettings.ForcedAccessWeChatBrowser)
                    return;

                //whether check webbroswer before
                if (_weixinSettings.CheckWebBrowser && !Utilities.WeixinBrowserUtility.SideInWeixinBrowser(context.HttpContext))
                {
                    var wechatBrowserControlerUrl = _urlHelperFactory.GetUrlHelper(context).RouteUrl(NopWeixinDefaults.WechatBrowserControler);
                    context.Result = new RedirectResult(wechatBrowserControlerUrl);
                }

                //Oauth Session 是否过期
                var session = context.HttpContext.Session.Get<OauthSession>(NopWeixinDefaults.WeixinOauthSession);
                if (session != null && session.CreatTime.AddDays(25) > DateTime.Now)  //RefreshToken30天有效期，在25天内刷新有效
                {
                    if (session.CreatTime.AddMinutes(110) < DateTime.Now)  // oauth accesstoken 2小时过期，提前10分钟验证
                    {
                        try
                        {
                            var refreshResult = OAuthApi.RefreshToken(_senparcWeixinSetting.WeixinAppId, session.RefreshToken);
                            if (refreshResult.errcode == ReturnCode.请求成功)
                            {
                                session.AccessToken = refreshResult.access_token;
                                session.CreatTime = DateTime.Now;
                                session.RefreshToken = refreshResult.refresh_token;
                                //Set Session
                                context.HttpContext.Session.Set(NopWeixinDefaults.WeixinOauthSession, session);

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
                        return; //session的access token 没有过期，直接跳过验证
                    }
                }

                //初始化Oauth State（官方邀请state只能是a-zA-Z0-9）测试下面格式是否能通过传递
                //格式为：userinfo{TimeTicket}+【_{CustomerGuid}或{OpenId}】
                var oauthStateString = string.Concat(((_oauthScope == OAuthScope.snsapi_userinfo) ? "userinfo" : "userbase"), SystemTime.Now.Ticks.ToString());

                //check request query parameters
                var request = context.HttpContext.Request;
                if (request?.Query?.Any() ?? false)
                {
                    //推荐人参数
                    var queryKey = _customerSettings.UseGidForReferrerParam ? NopCustomerServicesDefaults.CustomerQueryParamGuid : NopCustomerServicesDefaults.CustomerQueryParamOpenid;
                    if (request.Query.TryGetValue(queryKey, out var referrerCodes) && !StringValues.IsNullOrEmpty(referrerCodes))
                    {
                        oauthStateString += "_" + referrerCodes.FirstOrDefault();
                    }
                }

                //保存state
                context.HttpContext.Session.SetString(NopWeixinDefaults.WeixinOauthStateString, oauthStateString);

                //TODO 仅前端页面才判断是用snapapibase还是userinfo

                //redirect callback url
                var oauthCallbackUrl = _webHelper.GetStoreLocation().TrimEnd('/') + _urlHelperFactory.GetUrlHelper(context).RouteUrl(string.IsNullOrEmpty(_oauthRouteName) ? NopWeixinDefaults.WeixinOauthCallbackControler : _oauthRouteName);

                oauthCallbackUrl += "?returnUrl=" + _webHelper.GetThisPageUrl(true).UrlEncode();

                var url = OAuthApi.GetAuthorizeUrl(_senparcWeixinSetting.WeixinAppId, oauthCallbackUrl, oauthStateString, _oauthScope);

                context.Result = new RedirectResult(url);
            }

            #endregion

            #region Methods

            public async Task OnAuthorizationAsync(AuthorizationFilterContext context)
            {
                await AuthorizeWeixinOauthAsync(context);
            }

            #endregion
        }

        #endregion
    }
}