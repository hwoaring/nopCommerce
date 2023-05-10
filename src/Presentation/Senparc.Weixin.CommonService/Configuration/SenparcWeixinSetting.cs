using Senparc.Weixin.Entities;

namespace Nop.Core.Configuration
{
    /// <summary>
    /// Represents SenparcWeixinSetting parameters
    /// </summary>
    public partial class SenparcWeixinSetting : IConfig
    {
        //微信全局
        public bool IsDebug { get; protected set; } = true;

        //以下不使用的参数可以删除，key 修改后将会失效
        //公众号
        public string Token { get; protected set; } = "#{Token}#"; //说明：字符串内两侧#和{}符号为 Azure DevOps 默认的占位符格式，如果您有明文信息，请删除同占位符，修改整体字符串，不保留#和{}，如：{"Token": "MyFullToken"}
        public string EncodingAESKey { get; protected set; } = "#{EncodingAESKey}#";
        public string WeixinAppId { get; protected set; } = "#{WeixinAppId}#";
        public string WeixinAppSecret { get; protected set; } = "#{WeixinAppSecret}#";

        //小程序
        public string WxOpenAppId { get; protected set; } = "#{WxOpenAppId}#";
        public string WxOpenAppSecret { get; protected set; } = "#{WxOpenAppSecret}#";
        public string WxOpenToken { get; protected set; } = "#{WxOpenToken}#";
        public string WxOpenEncodingAESKey { get; protected set; } = "#{WxOpenEncodingAESKey}#";

        //企业微信
        public string WeixinCorpId { get; protected set; } = "#{WeixinCorpId}#";
        public string WeixinCorpAgentId { get; protected set; } = "#{WeixinCorpAgentId}#";
        public string WeixinCorpSecret { get; protected set; } = "#{WeixinCorpSecret}#";
        public string WeixinCorpToken { get; protected set; } = "#{WeixinCorpToken}#";
        public string WeixinCorpEncodingAESKey { get; protected set; } = "#{WeixinCorpEncodingAESKey}#";

        //微信支付
        //微信支付V2（旧版）
        public string WeixinPay_PartnerId { get; protected set; } = "#{WeixinPay_PartnerId}#";
        public string WeixinPay_Key { get; protected set; } = "#{WeixinPay_Key}#";
        public string WeixinPay_AppId { get; protected set; } = "#{WeixinPay_AppId}#";
        public string WeixinPay_AppKey { get; protected set; } = "#{WeixinPay_AppKey}#";
        public string WeixinPay_TenpayNotify { get; protected set; } = "#{WeixinPay_TenpayNotify}#";

        //微信支付V3
        public string TenPayV3_AppId { get; protected set; } = "#{TenPayV3_AppId}#";
        public string TenPayV3_AppSecret { get; protected set; } = "#{TenPayV3_AppSecret}#";
        public string TenPayV3_SubAppId { get; protected set; } = "#{TenPayV3_SubAppId}#";
        public string TenPayV3_SubAppSecret { get; protected set; } = "#{TenPayV3_SubAppSecret}#";
        public string TenPayV3_MchId { get; protected set; } = "#{TenPayV3_MchId}#";
        public string TenPayV3_SubMchId { get; protected set; } = "#{TenPayV3_SubMchId}#"; //子商户，没有可留空
        public string TenPayV3_Key { get; protected set; } = "#{TenPayV3_Key}#";

        /* 证书路径（APIv3 可不使用）
         * 1、物理路径如：D:\\cert\\apiclient_cert.p12
         * 2、相对路径，如：~/App_Data/cert/apiclient_cert.p12，注意：必须放在 App_Data 等受保护的目录下，避免泄露
         * 备注：证书下载地址：https://pay.weixin.qq.com/index.php/account/api_cert
         */
        public string TenPayV3_CertPath { get; protected set; } = "#{TenPayV3_CertPath}#"; //（V3 API 可不使用）证书路径
        public string TenPayV3_CertSecret { get; protected set; } = "#{TenPayV3_CertSecret}#"; //（V3 API 可不使用）支付证书密码（原始密码和 MchId 相同）
        public string TenPayV3_TenpayNotify { get; protected set; } = "#{TenPayV3_TenpayNotify}#"; // http://YourDomainName/TenpayApiV3/PayNotifyUrl

        /* 支付证书私钥
        * 1、支持明文私钥（无换行字符）
        * 2、私钥文件路径（如：~/App_Data/cert/apiclient_key.pem），注意：必须放在 App_Data 等受保护的目录下，避免泄露
        */
        public string TenPayV3_PrivateKey { get; protected set; } = "#{TenPayV3_PrivateKey}#"; //（新）证书私钥
        public string TenPayV3_SerialNumber { get; protected set; } = "#{TenPayV3_SerialNumber}#"; //（新）证书序列号
        public string TenPayV3_ApiV3Key { get; protected set; } = "#{TenPayV3_APIv3Key}#"; //（新）APIv3 密钥
        //如果不设置TenPayV3_WxOpenTenpayNotify，默认在 TenPayV3_TenpayNotify 的值最后加上 "WxOpen"
        public string TenPayV3_WxOpenTenpayNotify { get; protected set; } = "#{TenPayV3_WxOpenTenpayNotify}#"; //http://YourDomainName/TenpayV3/PayNotifyUrlWxOpen

        //开放平台
        public string Component_Appid { get; protected set; } = "#{Component_Appid}#";
        public string Component_Secret { get; protected set; } = "#{Component_Secret}#";
        public string Component_Token { get; protected set; } = "#{Component_Token}#";
        public string Component_EncodingAESKey { get; protected set; } = "#{Component_EncodingAESKey}#";

        //扩展及代理参数
        public string AgentUrl { get; protected set; } = "#{AgentUrl}#";
        public string AgentToken { get; protected set; } = "#{AgentToken}#";
        public string SenparcWechatAgentKey { get; protected set; } = "#{SenparcWechatAgentKey}#";
    }
}