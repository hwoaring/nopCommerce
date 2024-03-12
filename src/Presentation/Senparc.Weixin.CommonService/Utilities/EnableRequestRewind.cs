using Microsoft.AspNetCore.Http;
using Nop.Core;
using Nop.Data;
using Nop.Services.Installation;

namespace Senparc.Weixin.CommonService.Utilities.Http;

/// <summary>
/// <para>EnableRequestRewind中间件，开启.net core 2 中的RequestRewind模式，Request.Body可以二次读取，</para>
/// <para>以解决某些特殊情况下netcore默认机制导致的Request.Body为空而引发的WeixinSDK错误的问题。</para>
/// <para>https://github.com/JeffreySu/WeiXinMPSDK/issues/1090</para>
/// </summary>
public class EnableRequestRewindMiddleware
{
    #region Fields

    protected readonly RequestDelegate _next;

    #endregion

    #region Ctor

    public EnableRequestRewindMiddleware(RequestDelegate next)
    {
        _next = next;
    }

    #endregion

    public async Task InvokeAsync(HttpContext context, IWebHelper webHelper)
    {
        //.NET Core 3.0 不再使用 EnableRewind()，改为 EnableBuffering()：https://github.com/aspnet/AspNetCore/issues/12505
        context.Request.EnableBuffering();
        await _next(context).ConfigureAwait(false);

    }

}