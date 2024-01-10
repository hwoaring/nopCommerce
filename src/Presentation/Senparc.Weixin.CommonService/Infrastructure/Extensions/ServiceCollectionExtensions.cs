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
using Senparc.CO2NET.HttpUtility;
using System.Net.Security;
using System.Security.Cryptography.X509Certificates;
using Nop.Data;

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

            //services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            //services.AddMemoryCache();//使用本地缓存必须添加

            //services.AddSignalR();//使用 SignalR WebSocket

            /*
             * CO2NET 是从 Senparc.Weixin 分离的底层公共基础模块，经过了长达 6 年的迭代优化，稳定可靠。
             * 关于 CO2NET 在所有项目中的通用设置可参考 CO2NET 的 Sample：
             * https://github.com/Senparc/Senparc.CO2NET/blob/master/Sample/Senparc.CO2NET.Sample.netcore/Startup.cs
             */


            var webHostEnvironment = Singleton<IWebHostEnvironment>.Instance;

            //Senparc.Weixin 注册（必须）
            services.AddSenparcWeixinServices(configuration, webHostEnvironment);

            //Senparc.WebSocket 注册（按需）
            //services.AddSenparcWebSocket<CustomNetCoreWebSocketMessageHandler>();

            //启用 WebApi（可选）
            //services.AddAndInitDynamicApi(builder, options => options.DocXmlPath = ServerUtility.ContentRootMapPath("~/App_Data"));

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
        public static void AddSenparcWeixinServices(this IServiceCollection services, IConfiguration configuration, IHostEnvironment env, Action addCertHttpClient = null)
        {
            //系统还未安装
            if (!DataSettingsManager.IsDatabaseInstalled())
                return;

            //add SenparcWeixinSetting parameters
            services.Configure<SenparcWeixinSetting>(configuration.GetSection("SenparcWeixinSetting"));
            var senparcWeixinSetting = configuration.GetSection("SenparcWeixinSetting").Get<SenparcWeixinSetting>();
            services.AddSingleton(senparcWeixinSetting);

            //add SenparcSetting parameters
            services.Configure<SenparcSetting>(configuration.GetSection("SenparcSetting"));
            var senparcSetting = configuration.GetSection("SenparcSetting").Get<SenparcSetting>();
            services.AddSingleton(senparcSetting);

            //全局注册 CO2NET
            if (!CO2NET.RegisterServices.RegisterServiceExtension.SenparcGlobalServicesRegistered)
            {
                services.AddSenparcGlobalServices(configuration);//自动注册 SenparcGlobalServices 
            }

            //注册 HttpClient
            var key = senparcWeixinSetting.TenPayV3_MchId + "_" + senparcWeixinSetting.TenPayV3_SubMchId;

            //执行 Http 证书添加，如果为空则执行默认操作
            (addCertHttpClient ?? (() =>
            {
                services.AddCertHttpClient(key, senparcWeixinSetting.TenPayV3_CertSecret, senparcWeixinSetting.TenPayV3_CertPath, env);
            }))();
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
            if(string.IsNullOrWhiteSpace(certPath))
                return services;

            var fileProvider = CommonHelper.DefaultFileProvider;

            //处理相对路径
            if (certPath.StartsWith("~/"))
                certPath = certPath.Replace("~/", Senparc.CO2NET.Config.RootDirectoryPath);

            #region 添加证书

            //添加注册
            if (File.Exists(certPath))
            {
                try
                {
                    var cert = new X509Certificate2(certPath, certPassword, X509KeyStorageFlags.PersistKeySet | X509KeyStorageFlags.MachineKeySet);
                    var checkValidationResult = false;
                    //serviceCollection.AddHttpClient<SenparcHttpClient>(certName)
                    services.AddHttpClient(certName)
                            .ConfigurePrimaryHttpMessageHandler(() =>
                            {
                                var httpClientHandler = HttpClientHelper.GetHttpClientHandler(null, RequestUtility.SenparcHttpClientWebProxy, System.Net.DecompressionMethods.None);
                                httpClientHandler.ClientCertificates.Add(cert);

                                if (checkValidationResult)
                                {
                                    httpClientHandler.ServerCertificateCustomValidationCallback = new Func<System.Net.Http.HttpRequestMessage, X509Certificate2, X509Chain, SslPolicyErrors, bool>(RequestUtility.CheckValidationResult);
                                }

                                return httpClientHandler;
                            });
                    Senparc.CO2NET.Trace.SenparcTrace.SendCustomLog($"成功添加 cert 证书", $"certName:{certName},certPath:{certPath}");
                }
                catch (Exception ex)
                {
                    Senparc.CO2NET.Trace.SenparcTrace.SendCustomLog($"添加微信支付证书发生异常", $"certName:{certName},certPath:{certPath}");
                    Senparc.CO2NET.Trace.SenparcTrace.BaseExceptionLog(ex);
                }
            }
            else
            {
                Senparc.CO2NET.Trace.SenparcTrace.SendCustomLog($"已设置微信支付证书，但无法找到文件", $"certName:{certName},certPath:{certPath}");
            }
            #endregion

            return services;
        }

    }
}