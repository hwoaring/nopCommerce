using System;
using System.IO;
using System.Text;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Options;

using Nop.Core.Infrastructure;

using Senparc.CO2NET;
using Senparc.CO2NET.AspNet;
using Senparc.CO2NET.Cache;
using Senparc.CO2NET.Cache.Memcached;
using Senparc.CO2NET.Helpers;
using Senparc.CO2NET.Utilities;
using Senparc.CO2NET.WebApi;
using Senparc.NeuChar.MessageHandlers;
using Senparc.WebSocket;

using Senparc.Weixin.Entities;
using Senparc.Weixin.MP;
using Senparc.Weixin.RegisterServices;
using Senparc.Weixin.Cache.Memcached;
using Senparc.Weixin.Cache.Redis;
using Senparc.Weixin.CommonService.Infrastructure.Extensions;
using Senparc.Weixin.CommonService.MessageHandlers.WebSocket;
using Senparc.Weixin.CommonService.WorkMessageHandlers;
using Senparc.Weixin.CommonService.WxOpenMessageHandler;

using Senparc.CO2NET.RegisterServices;
using Senparc.Weixin.Helpers;
using Senparc.CO2NET.Extensions;
using Nop.Core.Configuration;
using SenparcWeixinSetting = Senparc.Weixin.Entities.SenparcWeixinSetting;
using SenparcSetting = Senparc.CO2NET.SenparcSetting;
using Nop.Core;
using Microsoft.Extensions.FileProviders;

namespace Senparc.Weixin.CommonService.Infrastructure.Extensions
{
    /// <summary>
    /// Represents extensions of IServiceCollection
    /// </summary>
    public static class ServiceCollectionExtensions
    {
        /// <summary>
        /// Register Nop Senparc Weixin Services
        /// </summary>
        /// <param name="services">Collection of service descriptors</param>
        public static void AddNopSenparcWeixinServices(this IServiceCollection services, IConfiguration configuration)
        {
            //services.AddSingleton<ITempDataProvider, CookieTempDataProvider>();

            //如果部署在linux系统上，需要加上下面的配置：
            //services.Configure<KestrelServerOptions>(options => options.AllowSynchronousIO = true);

            //如果部署在IIS上，需要加上下面的配置：
            //services.Configure<IISServerOptions>(options => options.AllowSynchronousIO = true);

            //services.AddMemoryCache();//使用本地缓存必须添加

            //使用 SignalR
            //services.AddSignalR();

            var webHostEnvironment = Singleton<IWebHostEnvironment>.Instance;

            services.AddSenparcWeixinServices(configuration, webHostEnvironment);//Senparc.Weixin 注册（必须）

            //services.AddSenparcWebSocket<CustomNetCoreWebSocketMessageHandler>(); //Senparc.WebSocket 注册（按需）

            //此处可以添加更多 Cert 证书
            //services.AddCertHttpClient("name", "pwd", "path");
        }

        /// <summary>
        /// 注册 IServiceCollection，并返回 RegisterService，开始注册流程
        /// </summary>
        /// <param name="serviceCollection">IServiceCollection</param>
        /// <param name="configuration">IConfiguration</param>
        /// <param name="env">IHostingEnvironment</param>
        /// <returns></returns>
        public static void AddSenparcWeixinServices(this IServiceCollection services, IConfiguration configuration, IHostEnvironment env)
        {
            //add Senparc configuration parameters
            services.Configure<SenparcWeixinSetting>(configuration.GetSection("SenparcWeixinSetting"));
            var senparcWeixinSetting = configuration.GetSection("SenparcWeixinSetting").Get<SenparcWeixinSetting>();
            services.AddSingleton(senparcWeixinSetting);

            var senparcSetting = configuration.GetSection("SenparcSetting").Get<SenparcSetting>();
            services.AddSingleton(senparcSetting);

            //全局注册 CO2NET
            if (!CO2NET.RegisterServices.RegisterServiceExtension.SenparcGlobalServicesRegistered)
            {
                services.AddSenparcGlobalServices(configuration);//自动注册 SenparcGlobalServices 
            }

            //注册 HttpClient
            var key = senparcWeixinSetting.TenPayV3_MchId + "_" + senparcWeixinSetting.TenPayV3_SubMchId;
            services.AddCertHttpClient(key, senparcWeixinSetting.TenPayV3_CertSecret, senparcWeixinSetting.TenPayV3_CertPath, env);

            // using var scope = serviceCollection.BuildServiceProvider().CreateScope();
            //var tenPayV3Setting = scope.ServiceProvider.GetService<IOptions<SenparcWeixinSetting>>().Value.TenpayV3Setting;
            //var key = TenPayHelper.GetRegisterKey(tenPayV3Setting);
            //serviceCollection.AddCertHttpClient(key, tenPayV3Setting.TenPayV3_CertSecret, tenPayV3Setting.TenPayV3_CertPath, env);

        }


        /// <summary>
        /// 注册HttpClient请求证书（V3 API 可不使用）
        /// </summary>
        /// <param name="services"></param>
        /// <param name="certName">证书名称</param>
        /// <param name="certPassword">证书密码</param>
        /// <param name="certPath">证书路径。
        /// <para>物理路径，如：D:\\cert\\apiclient_cert.p12</para>
        /// <para>相对路径，如：~/App_Data/cert/apiclient_cert.p12，注意：必须放在 App_Data 等受保护的目录下，避免泄露</para></param>
        /// <param name="env">IHostingEnvironment</param>
        /// <returns></returns>
        public static IServiceCollection AddCertHttpClient(this IServiceCollection services, string certName, string certPassword, string certPath, IHostEnvironment env)
        {
            if (certPath.IsNullOrEmpty())
                return services;

            var fileProvider = CommonHelper.DefaultFileProvider;

            //处理相对路径
            if (certPath.StartsWith("~/"))
            {
                //#if NET6_0_OR_GREATER
                //if (env is Microsoft.AspNetCore.Hosting.IWebHostEnvironment webHostEnv)
                //{
                //    Config.RootDirectoryPath = webHostEnv.ContentRootPath;
                //}
                //#endif

                Config.RootDirectoryPath = env.ContentRootPath;

                certPath = Senparc.CO2NET.Utilities.ServerUtility.ContentRootMapPath(certPath);
            }

            return Senparc.Weixin.RegisterServices.RegisterServiceExtension.AddCertHttpClient(services, certName, certPassword, certPath);
        }

    }
}