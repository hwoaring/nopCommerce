using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.FileProviders;
using Nop.Core.Domain.Weixins;
using Nop.Core.Infrastructure;
using Nop.Data;
using Nop.Web.Framework.Mvc.Filters;
using Senparc.CO2NET;
using Senparc.CO2NET.AspNet.HttpUtility;
using Senparc.NeuChar.MessageHandlers;
using Senparc.Weixin.AspNet.MvcExtension;
using Senparc.Weixin.Entities;
using Senparc.Weixin.MP;
using Senparc.Weixin.MP.Entities.Request;


namespace Senparc.Weixin.CommonService.Controllers
{
    public partial class WeixinController : WeixinBaseController
    {
        #region Fields

        private readonly INopFileProvider _fileProvider;
        protected readonly SenparcSetting _senparcSetting;
        protected readonly SenparcWeixinSetting _senparcWeixinSetting;
        protected readonly WeixinSettings _weixinSettings;

        #endregion

        #region Ctor

        public WeixinController(INopFileProvider fileProvider,
            SenparcSetting senparcSetting,
            SenparcWeixinSetting senparcWeixinSetting,
            WeixinSettings weixinSettings)
        {
            _fileProvider = fileProvider;
            _senparcSetting = senparcSetting;
            _senparcWeixinSetting = senparcWeixinSetting;
            _weixinSettings = weixinSettings;
        }

        #endregion

        #region 方法

        /// <summary>
        /// 微信后台验证地址
        /// </summary>
        [HttpGet]
        public virtual IActionResult Index(PostModel postModel, string echostr)
        {
            if (!DataSettingsManager.IsDatabaseInstalled())
                return Content("System not installed.");

            if (CheckSignature.Check(postModel.Signature, postModel.Timestamp, postModel.Nonce, _senparcWeixinSetting.Token))
            {
                return Content(echostr); //返回随机字符串则表示验证通过
            }
            else
            {
                return Content("Failed.");
                //return Content("failed:" + postModel.Signature + "," + CheckSignature.GetSignature(postModel.Timestamp, postModel.Nonce, _senparcWeixinSetting.Token) + "。");
                //"如果你在浏览器中看到这句话，说明此地址可以被作为微信公众账号后台的Url，请注意保持Token一致。");
            }
        }


        [HttpPost]
        public async Task<ActionResult> Index(PostModel postModel)
        {
            if (!DataSettingsManager.IsDatabaseInstalled())
                return Content("System not installed.");

            if (!CheckSignature.Check(postModel.Signature, postModel.Timestamp, postModel.Nonce, _senparcWeixinSetting.Token))
            {
                return Content("参数错误！");
            }

            #region 打包 PostModel 信息

            postModel.Token = _senparcWeixinSetting.Token;//根据自己后台的设置保持一致
            postModel.EncodingAESKey = _senparcWeixinSetting.EncodingAESKey;//根据自己后台的设置保持一致
            postModel.AppId = _senparcWeixinSetting.WeixinAppId;//根据自己后台的设置保持一致（必须提供）

            #endregion

            //v4.2.2之后的版本，可以设置每个人上下文消息储存的最大数量，防止内存占用过多，如果该参数小于等于0，则不限制（实际最大限制 99999）
            //注意：如果使用分布式缓存，不建议此值设置过大，如果需要储存历史信息，请使用数据库储存
            var maxRecordCount = 10;

            //自定义MessageHandler，对微信请求的详细判断操作都在这里面。
            var messageHandler = new CustomMessageHandler.CustomMessageHandler(await Request.GetRequestMemoryStreamAsync(), postModel, maxRecordCount);

            #region 设置消息去重设置 + 优先调用同步、异步方法设置

            /* 如果需要添加消息去重功能，只需打开OmitRepeatedMessage功能，SDK会自动处理。
             * 收到重复消息通常是因为微信服务器没有及时收到响应，会持续发送2-5条不等的相同内容的 RequestMessage */
            messageHandler.OmitRepeatedMessage = true;//默认已经是开启状态，此处仅作为演示，也可以设置为 false 在本次请求中停用此功能

            //当同步方法被重写，且异步方法未被重写时，尝试调用同步方法
            messageHandler.DefaultMessageHandlerAsyncEvent = DefaultMessageHandlerAsyncEvent.SelfSynicMethod;
            #endregion

            try
            {
                if (_weixinSettings.SaveRequestMessageLog)
                    messageHandler.SaveRequestMessageLog();//记录 Request 日志（可选）

                var ct = new CancellationToken();
                await messageHandler.ExecuteAsync(ct);//执行微信处理过程（关键）

                if (_weixinSettings.SaveResponseMessageLog)
                    messageHandler.SaveResponseMessageLog();//记录 Response 日志（可选）

                //return Content(messageHandler.ResponseDocument.ToString());//v0.7-
                //return new WeixinResult(messageHandler);//v0.8+
                return new FixWeixinBugWeixinResult(messageHandler);//为了解决官方微信5.0软件换行bug暂时添加的方法，平时用下面一个方法即可
            }
            catch (Exception ex)
            {
                #region 异常处理
                WeixinTrace.Log("MessageHandler错误：{0}", ex.Message);

                using (TextWriter tw = new StreamWriter(_fileProvider.MapPath(string.Concat("~/App_Data/Error_", SystemTime.Now.ToString("yyyyMMdd-HHmmss"), Guid.NewGuid().ToString("n").AsSpan(0, 6), ".txt"))))
                {
                    tw.WriteLine("ExecptionMessage:" + ex.Message);
                    tw.WriteLine(ex.Source);
                    tw.WriteLine(ex.StackTrace);
                    //tw.WriteLine("InnerExecptionMessage:" + ex.InnerException.Message);

                    if (messageHandler.ResponseDocument != null)
                    {
                        tw.WriteLine(messageHandler.ResponseDocument.ToString());
                    }

                    if (ex.InnerException != null)
                    {
                        tw.WriteLine("========= InnerException =========");
                        tw.WriteLine(ex.InnerException.Message);
                        tw.WriteLine(ex.InnerException.Source);
                        tw.WriteLine(ex.InnerException.StackTrace);
                    }

                    tw.Flush();
                    tw.Close();
                }
                return Content("");
                #endregion
            }
        }


        #endregion
    }
}