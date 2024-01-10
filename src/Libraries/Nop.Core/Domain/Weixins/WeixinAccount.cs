using Nop.Core.Domain.Common;
using Nop.Core.Domain.Localization;
using Nop.Core.Domain.Seo;

namespace Nop.Core.Domain.Weixins
{
    /// <summary>
    /// 微信账号配置
    /// </summary>
    public partial class WeixinAccount : BaseEntity, ISoftDeletedEntity
    {
        /// <summary>
        /// StoreId
        /// </summary>
        public int StoreId { get; set; }

        /// <summary>
        /// 公司名称
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// api接口id（系统生成）
        /// </summary>
        public string ApiCode { get; set; }

        //以下不使用的参数可以删除，key 修改后将会失效
        //公众号
        public string Token { get; set; } = "#{Token}#"; //说明：字符串内两侧#和{}符号为 Azure DevOps 默认的占位符格式，如果您有明文信息，请删除同占位符，修改整体字符串，不保留#和{}，如：{"Token": "MyFullToken"}
        public string EncodingAESKey { get; set; } = "#{EncodingAESKey}#";
        public string WeixinAppId { get; set; } = "#{WeixinAppId}#";
        public string WeixinAppSecret { get; set; } = "#{WeixinAppSecret}#";

        //小程序
        public string WxOpenAppId { get; set; } = "#{WxOpenAppId}#";
        public string WxOpenAppSecret { get; set; } = "#{WxOpenAppSecret}#";
        public string WxOpenToken { get; set; } = "#{WxOpenToken}#";
        public string WxOpenEncodingAESKey { get; set; } = "#{WxOpenEncodingAESKey}#";

        //企业微信
        public string WeixinCorpId { get; set; } = "#{WeixinCorpId}#";
        public string WeixinCorpAgentId { get; set; } = "#{WeixinCorpAgentId}#";
        public string WeixinCorpSecret { get; set; } = "#{WeixinCorpSecret}#";
        public string WeixinCorpToken { get; set; } = "#{WeixinCorpToken}#";
        public string WeixinCorpEncodingAESKey { get; set; } = "#{WeixinCorpEncodingAESKey}#";

        //微信支付
        //微信支付V2（旧版）
        public string WeixinPay_PartnerId { get; set; } = "#{WeixinPay_PartnerId}#";
        public string WeixinPay_Key { get; set; } = "#{WeixinPay_Key}#";
        public string WeixinPay_AppId { get; set; } = "#{WeixinPay_AppId}#";
        public string WeixinPay_AppKey { get; set; } = "#{WeixinPay_AppKey}#";
        public string WeixinPay_TenpayNotify { get; set; } = "#{WeixinPay_TenpayNotify}#";

        //微信支付V3
        public string TenPayV3_AppId { get; set; } = "#{TenPayV3_AppId}#";
        public string TenPayV3_AppSecret { get; set; } = "#{TenPayV3_AppSecret}#";
        public string TenPayV3_SubAppId { get; set; } = "#{TenPayV3_SubAppId}#";
        public string TenPayV3_SubAppSecret { get; set; } = "#{TenPayV3_SubAppSecret}#";
        public string TenPayV3_MchId { get; set; } = "#{TenPayV3_MchId}#";
        public string TenPayV3_SubMchId { get; set; } = "#{TenPayV3_SubMchId}#"; //子商户，没有可留空
        public string TenPayV3_Key { get; set; } = "#{TenPayV3_Key}#";

        /* 证书路径（APIv3 可不使用）
         * 1、物理路径如：D:\\cert\\apiclient_cert.p12
         * 2、相对路径，如：~/App_Data/cert/apiclient_cert.p12，注意：必须放在 App_Data 等受保护的目录下，避免泄露
         * 备注：证书下载地址：https://pay.weixin.qq.com/index.php/account/api_cert
         */
        public string TenPayV3_CertPath { get; set; } = "#{TenPayV3_CertPath}#"; //（V3 API 可不使用）证书路径
        public string TenPayV3_CertSecret { get; set; } = "#{TenPayV3_CertSecret}#"; //（V3 API 可不使用）支付证书密码（原始密码和 MchId 相同）
        public string TenPayV3_TenpayNotify { get; set; } = "#{TenPayV3_TenpayNotify}#"; // http://YourDomainName/TenpayApiV3/PayNotifyUrl

        /* 支付证书私钥
        * 1、支持明文私钥（无换行字符）
        * 2、私钥文件路径（如：~/App_Data/cert/apiclient_key.pem），注意：必须放在 App_Data 等受保护的目录下，避免泄露
        */
        public string TenPayV3_PrivateKey { get; set; } = "#{TenPayV3_PrivateKey}#"; //（新）证书私钥
        public string TenPayV3_SerialNumber { get; set; } = "#{TenPayV3_SerialNumber}#"; //（新）证书序列号
        public string TenPayV3_ApiV3Key { get; set; } = "#{TenPayV3_APIv3Key}#"; //（新）APIv3 密钥
        //如果不设置TenPayV3_WxOpenTenpayNotify，默认在 TenPayV3_TenpayNotify 的值最后加上 "WxOpen"
        public string TenPayV3_WxOpenTenpayNotify { get; set; } = "#{TenPayV3_WxOpenTenpayNotify}#"; //http://YourDomainName/TenpayV3/PayNotifyUrlWxOpen

        //开放平台
        public string Component_Appid { get; set; } = "#{Component_Appid}#";
        public string Component_Secret { get; set; } = "#{Component_Secret}#";
        public string Component_Token { get; set; } = "#{Component_Token}#";
        public string Component_EncodingAESKey { get; set; } = "#{Component_EncodingAESKey}#";

        /// <summary>
        /// 是否作为系统默认值
        /// </summary>
        public bool SystemAccount { get; set; }

        /// <summary>
        /// 锁定
        /// </summary>
        public bool Locked { get; set; }

        /// <summary>
        /// 删除
        /// </summary>
        public bool Deleted { get; set; }

        /// <summary>
        /// 服务过期时间
        /// </summary>
        public DateTime? ExpiredDateOnUtc { get; set; }

        /// <summary>
        /// 更新时间
        /// </summary>
        public DateTime? UpdatedOnUtc { get; set; }

        /// <summary>
        /// 创建时间
        /// </summary>
        public DateTime CreatedOnUtc { get; set; }
    }
}
