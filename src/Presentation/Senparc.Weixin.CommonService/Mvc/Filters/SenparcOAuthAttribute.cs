using System;
using System.Diagnostics.CodeAnalysis;
using Senparc.Weixin.MP.AdvancedAPIs;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;


namespace Senparc.Weixin.MP.MvcExtension
{
    /// <summary>
    /// SenparcOAuthAttribute
    /// </summary>
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method, Inherited = true, AllowMultiple = true)]
    public abstract class SenparcOAuthAttribute : ActionFilterAttribute,/* AuthorizeAttribute,*/ IAuthorizationFilter
    {
        protected string AppId { get; set; }
        protected string OauthCallbackUrl { get; set; }
        protected OAuthScope OauthScope { get; set; }

        /// <summary>
        /// AppId
        /// </summary>
        /// <param name="appId"></param>
        /// <param name="oauthCallbackUrl">网站内路径（如：/TenpayV3/OAuthCallback），以/开头！当前页面地址会加在Url中的returlUrl=xx参数中</param>
        /// <param name="oauthScope">默认为 OAuthScope.snsapi_userinfo</param>
        public SenparcOAuthAttribute(string appId, string oauthCallbackUrl, OAuthScope oauthScope = OAuthScope.snsapi_userinfo)
        {
            AppId = appId;
            OauthCallbackUrl = oauthCallbackUrl;
            OauthScope = oauthScope;
        }


        /// <summary>
        /// 判断用户是否已经登录
        /// </summary>
        /// <param name="httpContext"></param>
        /// <returns></returns>
        public abstract bool IsLogined(HttpContext httpContext);

        protected virtual bool AuthorizeCore(HttpContext httpContext)
        {
            //return true;
            if (httpContext == null)
            {
                throw new ArgumentNullException(nameof(httpContext));
            }

            if (!IsLogined(httpContext))
            {
                return false;//未登录
            }

            return true;
        }

        public virtual void OnAuthorization(AuthorizationFilterContext filterContext)
        {
            if (filterContext == null)
            {
                throw new ArgumentNullException(nameof(filterContext));
            }

            if (AuthorizeCore(filterContext.HttpContext))
            {
                // ** IMPORTANT **
                // Since we're performing authorization at the action level, the authorization code runs
                // after the output caching module. In the worst case this could allow an authorized user
                // to cause the page to be cached, then an unauthorized user would later be served the
                // cached page. We work around this by telling proxies not to cache the sensitive page,
                // then we hook our custom authorization code into the caching mechanism so that we have
                // the final say on whether a page should be served from the cache.

            }
            else
            {
                if (IsLogined(filterContext.HttpContext))
                {
                    //已经登录
                }
                else
                {
                    var callbackUrl = Senparc.Weixin.AspNetHttpUtility.UrlUtility.GenerateOAuthCallbackUrl(filterContext.HttpContext, OauthCallbackUrl);
                    var state = string.Format("{0}|{1}", "FromSenparc", SystemTime.Now.Ticks);

                    var url = OAuthApi.GetAuthorizeUrl(AppId, callbackUrl, state, OauthScope);
                    filterContext.Result = new RedirectResult(url/*, true*/);
                }
            }
        }
    }
}
