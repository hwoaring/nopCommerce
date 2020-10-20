namespace Nop.Core.Configuration
{
    /// <summary>
    /// Represents SenparcWeixin configuration parameters
    /// </summary>
    public partial class SenparcWeixinSettingTemp : IConfig
    {
        //以下为 Senparc.Weixin 的 SenparcWeixinSetting 微信配置
        //注意：所有的字符串值都可能被用于字典索引，因此请勿留空字符串（但可以根据需要，删除对应的整条设置）！

        //微信全局
        public bool IsDebug { get; set; } = true;

        //以下不使用的参数可以删除，key 修改后将会失效
        //公众号
        public string Token { get; set; } = "#{DefaultToken}#"; ////说明：字符串内两侧#和{}符号为 Azure DevOps 默认的占位符格式，如果您有明文信息，请删除同占位符，修改整体字符串，不保留#和{}，如：{"Token": "MyFullToken"}
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

        //微信支付V3（新版）
        public string TenPayV3_AppId { get; set; } = "#{TenPayV3_AppId}#";
        public string TenPayV3_AppSecret { get; set; } = "#{TenPayV3_AppSecret}#";
        public string TenPayV3_SubAppId { get; set; } = "#{TenPayV3_SubAppId}#";
        public string TenPayV3_SubAppSecret { get; set; } = "#{TenPayV3_SubAppSecret}#";
        public string TenPayV3_MchId { get; set; } = "#{TenPayV3_MchId}#";
        /// <summary>
        /// 子商户，没有可留空
        /// </summary>
        public string TenPayV3_SubMchId { get; set; } = "#{TenPayV3_SubMchId}#";
        public string TenPayV3_Key { get; set; } = "#{TenPayV3_Key}#";
        /// <summary>
        /// （新）支付证书物理路径，如：D:\\cert\\apiclient_cert.p12
        /// </summary>
        public string TenPayV3_CertPath { get; set; } = "#{TenPayV3_CertPath}#";
        /// <summary>
        /// （新）支付证书密码（原始密码和 MchId 相同）
        /// </summary>
        public string TenPayV3_CertSecret { get; set; } = "#{TenPayV3_CertSecret}#";
        /// <summary>
        /// http://YourDomainName/TenpayV3/PayNotifyUrl
        /// </summary>
        public string TenPayV3_TenpayNotify { get; set; } = "#{TenPayV3_TenpayNotify}#";
        /// <summary>
        /// 如果不设置TenPayV3_WxOpenTenpayNotify，默认在 TenPayV3_TenpayNotify 的值最后加上 "WxOpen"
        /// //http://YourDomainName/TenpayV3/PayNotifyUrlWxOpen
        /// </summary>
        public string TenPayV3_WxOpenTenpayNotify { get; set; } = "#{TenPayV3_WxOpenTenpayNotify}#";

        //开放平台
        public string Component_Appid { get; set; } = "#{Component_Appid}#";
        public string Component_Secret { get; set; } = "#{Component_Secret}#";
        public string Component_Token { get; set; } = "#{Component_Token}#";
        public string Component_EncodingAESKey { get; set; } = "#{Component_EncodingAESKey}#";

        //扩展及代理参数
        public string AgentUrl { get; set; } = "#{AgentUrl}#";
        public string AgentToken { get; set; } = "#{AgentToken}#";
        public string SenparcWechatAgentKey { get; set; } = "#{SenparcWechatAgentKey}#";
    }
}