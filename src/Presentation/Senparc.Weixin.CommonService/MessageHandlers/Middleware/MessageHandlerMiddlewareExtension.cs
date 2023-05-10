#region Apache License Version 2.0
/*----------------------------------------------------------------

Copyright 2023 Jeffrey Su & Suzhou Senparc Network Technology Co.,Ltd.

Licensed under the Apache License, Version 2.0 (the "License"); you may not use this file
except in compliance with the License. You may obtain a copy of the License at

http://www.apache.org/licenses/LICENSE-2.0

Unless required by applicable law or agreed to in writing, software distributed under the
License is distributed on an "AS IS" BASIS, WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND,
either express or implied. See the License for the specific language governing permissions
and limitations under the License.

Detail: https://github.com/JeffreySu/WeiXinMPSDK/blob/master/license.md

----------------------------------------------------------------*/
#endregion Apache License Version 2.0

/*----------------------------------------------------------------
    Copyright (C) 2023 Senparc
    
    文件名：WxOpenMessageHandlerMiddleware.cs
    文件功能描述：公众号 MessageHandler 中间件
    
    
    创建标识：Senparc - 20191004
    
----------------------------------------------------------------*/

#if NETSTANDARD2_0_OR_GREATER || NETCOREAPP2_1_OR_GREATER || NET6_0_OR_GREATER
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Senparc.CO2NET.Extensions;
using Senparc.CO2NET.HttpUtility;
using Senparc.CO2NET.Trace;
using Senparc.NeuChar;
using Senparc.NeuChar.App.AppStore;
using Senparc.NeuChar.Context;
using Senparc.NeuChar.Entities;
using Senparc.NeuChar.Exceptions;
using Senparc.NeuChar.MessageHandlers;
using Senparc.NeuChar.Middlewares;
using Senparc.Weixin.Entities;
using Senparc.Weixin.MP.Entities;
using Senparc.Weixin.MP.MessageContexts;
using Senparc.Weixin.Work.Entities;
using Senparc.Weixin.Work.MessageContexts;
using Senparc.Weixin.WxOpen.Entities.Request;
using Senparc.Weixin.WxOpen.MessageContexts;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Senparc.Weixin.CommonService.MessageHandlers.Middleware
{
    /// <summary>
    /// 公众号 MessageHandlerMiddleware 扩展类，用于提供简洁的注册过程
    /// </summary>
    public static class MessageHandlerMiddlewareExtension
    {
        /* 用法：
           startup.cs 中 Configure() 方法中加入，即可启用自定义的 CustomMessageHandler，无需任何 Controller 和多余代码：

           app.UseMpMessageHandler("/WeixinAsync", CustomMessageHandler.GenerateMessageHandler, o => o.AccountSettingFunc = c => senparcWeixinSetting.Value);
            );
         */

        /// <summary>
        /// 使用 MessageHandler 配置。注意：会默认使用异步方法 messageHandler.ExecuteAsync()。
        /// </summary>
        /// <param name="builder"></param>
        /// <param name="pathMatch">路径规则（路径开头，可带参数），此路径用于提供微信后台 Url 校验及消息推送</param>
        /// <param name="messageHandler"></param>
        /// <param name="options"></param>
        /// <returns></returns>
        public static IApplicationBuilder UseMessageHandlerForMp<TMC>(this IApplicationBuilder builder, PathString pathMatch,
            Func<Stream, Senparc.Weixin.MP.Entities.Request.PostModel, int, IServiceProvider, MessageHandler<TMC, IRequestMessageBase, IResponseMessageBase>> messageHandler,
            Action<MessageHandlerMiddlewareOptions<ISenparcWeixinSettingForMP>> options)
                where TMC : DefaultMpMessageContext, IMessageContext<IRequestMessageBase, IResponseMessageBase>, new()
        {
            return builder.UseMessageHandler<MpMessageHandlerMiddleware<TMC>, TMC, Senparc.Weixin.MP.Entities.Request.PostModel, ISenparcWeixinSettingForMP>(pathMatch, messageHandler, options);
        }


        /* 用法：
           startup.cs 中 Configure() 方法中加入，即可启用自定义的 CustomMessageHandler，无需任何 Controller 和多余代码：

           app.UseMpMessageHandler("/WeixinAsync", CustomMessageHandler.GenerateMessageHandler, o => o.AccountSettingFunc = c => senparcWeixinSetting.Value);
            );
         */

        /// <summary>
        /// 使用 MessageHandler 配置。注意：会默认使用异步方法 messageHandler.ExecuteAsync()。
        /// </summary>
        /// <param name="builder"></param>
        /// <param name="pathMatch">路径规则（路径开头，可带参数），此路径用于提供微信后台 Url 校验及消息推送</param>
        /// <param name="messageHandler"></param>
        /// <param name="options"></param>
        /// <returns></returns>
        public static IApplicationBuilder UseMessageHandlerForWxOpen<TMC>(this IApplicationBuilder builder, PathString pathMatch,
            Func<Stream, Senparc.Weixin.WxOpen.Entities.Request.PostModel, int, IServiceProvider, MessageHandler<TMC, IRequestMessageBase, IResponseMessageBase>> messageHandler,
            Action<MessageHandlerMiddlewareOptions<ISenparcWeixinSettingForWxOpen>> options)
                where TMC : DefaultWxOpenMessageContext, IMessageContext<IRequestMessageBase, IResponseMessageBase>, new()
        {
            return builder.UseMessageHandler<WxOpenMessageHandlerMiddleware<TMC>, TMC, Senparc.Weixin.WxOpen.Entities.Request.PostModel, ISenparcWeixinSettingForWxOpen>(pathMatch, messageHandler, options);
        }

        /* 用法：
           startup.cs 中 Configure() 方法中加入，即可启用自定义的 CustomMessageHandler，无需任何 Controller 和多余代码：

           app.UseMpMessageHandler("/WeixinAsync", CustomMessageHandler.GenerateMessageHandler, o => o.AccountSettingFunc = c => senparcWeixinSetting.Value);
            );
         */

        /// <summary>
        /// 使用 MessageHandler 配置。注意：会默认使用异步方法 messageHandler.ExecuteAsync()。
        /// </summary>
        /// <param name="builder"></param>
        /// <param name="pathMatch">路径规则（路径开头，可带参数），此路径用于提供微信后台 Url 校验及消息推送</param>
        /// <param name="messageHandler"></param>
        /// <param name="options"></param>
        /// <returns></returns>
        public static IApplicationBuilder UseMessageHandlerForWork<TMC>(this IApplicationBuilder builder, PathString pathMatch,
            Func<Stream, Senparc.Weixin.Work.Entities.PostModel, int, IServiceProvider, MessageHandler<TMC, IWorkRequestMessageBase, IWorkResponseMessageBase>> messageHandler,
            Action<MessageHandlerMiddlewareOptions<ISenparcWeixinSettingForWork>> options)
                where TMC : DefaultWorkMessageContext, IMessageContext<IWorkRequestMessageBase, IWorkResponseMessageBase>, new()
        {
            return builder.UseMessageHandler<WorkMessageHandlerMiddleware<TMC>, IWorkRequestMessageBase, IWorkResponseMessageBase, TMC, Senparc.Weixin.Work.Entities.PostModel, ISenparcWeixinSettingForWork>(pathMatch, messageHandler, options);
        }


    }
}
#endif

