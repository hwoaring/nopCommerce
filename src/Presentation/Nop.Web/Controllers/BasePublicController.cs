using Microsoft.AspNetCore.Mvc;
using Nop.Web.Framework.Controllers;
using Nop.Web.Framework.Mvc.Filters;
using Senparc.Weixin.MP.CommonService.Mvc.Filters;

namespace Nop.Web.Controllers
{
    [WwwRequirement]
    [CheckLanguageSeoCode]
    [CheckWeixinOAuth]
    [CheckAccessPublicStore]
    [CheckAccessClosedStore]
    [CheckDiscountCoupon]
    [CheckAffiliate]
    [CheckOpenId]
    public abstract partial class BasePublicController : BaseController
    {
        protected virtual IActionResult InvokeHttp404()
        {
            Response.StatusCode = 404;
            return new EmptyResult();
        }
    }
}
