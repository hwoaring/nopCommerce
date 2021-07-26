using System;
using Microsoft.AspNetCore.Mvc.Diagnostics;
using Nop.Core.Caching;
using Nop.Core.Domain.Weixin;

namespace Nop.Services.Weixin
{
    /// <summary>
    /// 获取二维码场景值生成格式
    /// </summary>
    public partial class QrCodeSceneString
    {
        /// <summary>
        /// 关注类型二维码图片字符串ID为：adver + OpenIdHash +  QrCodeImageId + CreatTime
        /// 永久二维码<=1000000（百万）,临时二维码>1000000(百万)
        /// </summary>
        public static string QrcodeTempString => "{0}_{1}_{2}_{3}";

        /// <summary>
        /// 返回临时二维码场景字符串
        /// </summary>
        /// <returns></returns>
        public static string GetTempSceneString(SceneType sceneType, string openId, string value, string value1)
        {
            string result;

            switch (sceneType)
            {
                case SceneType.Adver:
                    {
                        result = SceneType.Adver.ToString() + "_"
                            + openId + "_"
                            + value + "_"  //ProductAdvertImageId，广告传单ID
                            + Nop.Core.Weixin.Helpers.DateTimeHelper.GetUnixDateTime(DateTime.Now).ToString();
                        break;
                    }
                case SceneType.Command:
                    {
                        result = SceneType.Command.ToString() + "_"
                            + openId + "_"
                            + value + "_"  //命令值
                            + Nop.Core.Weixin.Helpers.DateTimeHelper.GetUnixDateTime(DateTime.Now).ToString();
                        break;
                    }
                case SceneType.GiftCard:
                    {
                        result = SceneType.GiftCard.ToString() + "_"
                            + openId + "_"
                            + value + "_"  //自动领取卡券的ID
                            + Nop.Core.Weixin.Helpers.DateTimeHelper.GetUnixDateTime(DateTime.Now).ToString();
                        break;
                    }
                case SceneType.IDCard:
                    {
                        result = SceneType.IDCard.ToString() + "_"
                            + openId + "_"
                            + Nop.Core.Weixin.Helpers.DateTimeHelper.GetUnixDateTime(DateTime.Now).ToString();
                        break;
                    }
                case SceneType.Message:
                    {
                        result = SceneType.Message.ToString() + "_"
                            + openId + "_"
                            + value + "_"  //MessageId
                            + Nop.Core.Weixin.Helpers.DateTimeHelper.GetUnixDateTime(DateTime.Now).ToString();
                        break;
                    }
                case SceneType.Product:
                    {
                        result = SceneType.Product.ToString() + "_"
                            + openId + "_"
                            + value + "_"  //产品ID
                            + Nop.Core.Weixin.Helpers.DateTimeHelper.GetUnixDateTime(DateTime.Now).ToString();
                        break;
                    }
                case SceneType.Supplier:
                    {
                        result = SceneType.Supplier.ToString() + "_"
                            + openId + "_"
                            + value + "_"    //SupplierId
                            + value1 + "_"  //SupplierShopId
                            + Nop.Core.Weixin.Helpers.DateTimeHelper.GetUnixDateTime(DateTime.Now).ToString();
                        break;
                    }
                case SceneType.Verify:
                    {
                        result = SceneType.Verify.ToString() + "_"
                            + openId + "_"
                            + value + "_"  //验证码值
                            + Nop.Core.Weixin.Helpers.DateTimeHelper.GetUnixDateTime(DateTime.Now).ToString();
                        break;
                    }
                case SceneType.Vote:
                    {
                        result = SceneType.Vote.ToString() + "_"
                            + openId + "_"
                            + value + "_"  //投票选项值
                            + Nop.Core.Weixin.Helpers.DateTimeHelper.GetUnixDateTime(DateTime.Now).ToString();
                        break;
                    }
                case SceneType.None:
                    {
                        result = SceneType.None.ToString() + "_"
                            + openId + "_"
                            + Nop.Core.Weixin.Helpers.DateTimeHelper.GetUnixDateTime(DateTime.Now).ToString();
                        break;
                    }
                default:
                    {
                        result = SceneType.None.ToString() + "_"
                            + openId + "_"
                            + Nop.Core.Weixin.Helpers.DateTimeHelper.GetUnixDateTime(DateTime.Now).ToString();
                        break;
                    }
            }
            return result;

        }

        public static QrCodeSceneParam GetTempSceneParams(string sceneStr)
        {
            if (string.IsNullOrEmpty(sceneStr))
                return null;

            var sceneStrParam = sceneStr.Split("_");

            var sceneParam = new QrCodeSceneParam()
            {
                SceneType = (SceneType)Enum.Parse(typeof(SceneType), sceneStrParam[0], true),
                OpenIdReferee = sceneStrParam[1],
                IsQrCodeLimit = false,
            };

            switch (sceneParam.SceneType)
            {
                case SceneType.Adver:
                    {
                        sceneParam.Value = sceneStrParam[2];
                        sceneParam.CreatTime = Convert.ToInt32(sceneStrParam[3]);
                        break;
                    }
                case SceneType.Command:
                    {
                        sceneParam.Value = sceneStrParam[2];
                        sceneParam.CreatTime = Convert.ToInt32(sceneStrParam[3]);
                        break;
                    }
                case SceneType.GiftCard:
                    {
                        sceneParam.Value = sceneStrParam[2];
                        sceneParam.CreatTime = Convert.ToInt32(sceneStrParam[3]);
                        break;
                    }
                case SceneType.IDCard:
                    {
                        sceneParam.CreatTime = Convert.ToInt32(sceneStrParam[2]);
                        break;
                    }
                case SceneType.Message:
                    {
                        sceneParam.Value = sceneStrParam[2];
                        sceneParam.CreatTime = Convert.ToInt32(sceneStrParam[3]);
                        break;
                    }
                case SceneType.Product:
                    {
                        sceneParam.Value = sceneStrParam[2];
                        sceneParam.CreatTime = Convert.ToInt32(sceneStrParam[3]);
                        break;
                    }
                case SceneType.Supplier:
                    {
                        sceneParam.Value = sceneStrParam[2];
                        sceneParam.Value1 = sceneStrParam[3];
                        sceneParam.CreatTime = Convert.ToInt32(sceneStrParam[4]);
                        break;
                    }
                case SceneType.Verify:
                    {
                        sceneParam.Value = sceneStrParam[2];
                        sceneParam.CreatTime = Convert.ToInt32(sceneStrParam[3]);
                        break;
                    }
                case SceneType.Vote:
                    {
                        sceneParam.Value = sceneStrParam[2];
                        sceneParam.CreatTime = Convert.ToInt32(sceneStrParam[3]);
                        break;
                    }
                case SceneType.None:
                    {
                        sceneParam.CreatTime = Convert.ToInt32(sceneStrParam[2]);
                        break;
                    }
                default:
                    {
                        sceneParam.CreatTime = Convert.ToInt32(sceneStrParam[2]);
                        break;
                    }
            }
            return sceneParam;
        }

        public class QrCodeSceneParam
        {
            /// <summary>
            /// 场景类型
            /// </summary>
            public SceneType SceneType { get; set; }
            /// <summary>
            /// 指定回复消息类型
            /// </summary>
            public MessageType MessageType { get; set; }
            /// <summary>
            /// 推荐人ID/二维码生成人ID
            /// </summary>
            public string OpenIdReferee { get; set; }
            /// <summary>
            /// 传递的值
            /// </summary>
            public string Value { get; set; }
            /// <summary>
            /// 传递的值1
            /// </summary>
            public string Value1 { get; set; }
            /// <summary>
            /// 是否永久二维码
            /// </summary>
            public bool IsQrCodeLimit { get; set; }
            /// <summary>
            /// 创建时间
            /// </summary>
            public int CreatTime { get; set; }
        }


    }
}