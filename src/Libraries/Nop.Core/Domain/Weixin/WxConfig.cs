using System;
using Nop.Core.Domain.Common;

namespace Nop.Core.Domain.Weixin
{
    /// <summary>
    /// Represents an 微信接入配置
    /// </summary>
    public partial class WxConfig : BaseEntity, ISoftDeletedEntity
    {
        /// <summary>
        /// 站点ID
        /// </summary>
        public int StoreId { get; set; }

        /// <summary>
        /// 微信公众号原始字符串，用于区分不同平台用户
        /// </summary>
        public string OriginalId { get; set; }
        
        /// <summary>
        /// 系统名称
        /// </summary>
        /// <returns></returns>
        public string SystemName { get; set; }

        /// <summary>
        /// 对公众号备注，便于后台管理
        /// </summary>
        /// <returns></returns>
        public string Remark { get; set; }

        /// <summary>
        /// 微信公众号appid
        /// </summary>
        /// <returns></returns>
        public string WeixinAppId { get; set; }
        /// <summary>
        /// 微信公众号appsecret
        /// </summary>
        /// <returns></returns>
        public string WeixinAppSecret { get; set; }
        /// <summary>
        /// 微信公众号token
        /// </summary>
        /// <returns></returns>
        public string Token { get; set; }
        /// <summary>
        /// 微信公众号EncodingAESKey
        /// </summary>
        /// <returns></returns>
        public string EncodingAESKey { get; set; }

        /// <summary>
        /// 微信小程序appid
        /// </summary>
        /// <returns></returns>
        public string WxOpenAppId { get; set; }

        /// <summary>
        /// 微信小程序appsecret
        /// </summary>
        /// <returns></returns>
        public string WxOpenAppSecret { get; set; }
        /// <summary>
        /// 微信小程序token
        /// </summary>
        /// <returns></returns>
        public string WxOpenToken { get; set; }
        /// <summary>
        /// 微信小程序EncodingAESKey
        /// </summary>
        /// <returns></returns>
        public string WxOpenEncodingAESKey { get; set; }

        /// <summary>
        /// 企业微信
        /// </summary>
        public string WeixinCorpId { get; set; }
        /// <summary>
        /// 企业微信
        /// </summary>
        public string WeixinCorpAgentId { get; set; }
        /// <summary>
        /// 企业微信
        /// </summary>
        public string WeixinCorpSecret { get; set; }
        /// <summary>
        /// 企业微信
        /// </summary>
        public string WeixinCorpToken { get; set; }
        /// <summary>
        /// 企业微信
        /// </summary>
        public string WeixinCorpEncodingAESKey { get; set; }

        /// <summary>
        /// 微信支付V3
        /// </summary>
        public string TenPayV3AppId { get; set; }
        /// <summary>
        /// 微信支付V3
        /// </summary>
        public string TenPayV3AppSecret { get; set; }
        /// <summary>
        /// 微信支付V3
        /// </summary>
        public string TenPayV3SubAppId { get; set; }
        /// <summary>
        /// 微信支付V3
        /// </summary>
        public string TenPayV3SubAppSecret { get; set; }
        /// <summary>
        /// 微信支付V3
        /// </summary>
        public string TenPayV3MchId { get; set; }
        /// <summary>
        /// 微信支付V3
        /// </summary>
        public string TenPayV3SubMchId { get; set; }
        /// <summary>
        /// 微信支付V3
        /// </summary>
        public string TenPayV3Key { get; set; }
        /// <summary>
        /// 微信支付V3
        /// </summary>
        public string TenPayV3CertPath { get; set; }
        /// <summary>
        /// 微信支付V3
        /// </summary>
        public string TenPayV3CertSecret { get; set; }
        /// <summary>
        /// 微信支付V3
        /// </summary>
        public string TenPayV3TenpayNotify { get; set; }
        /// <summary>
        /// 微信支付V3
        /// </summary>
        public string TenPayV3WxOpenTenpayNotify { get; set; }

        /// <summary>
        /// 更新时间
        /// </summary>
        public DateTime? UpdateTimeUtc { get; set; }

        /// <summary>
        /// 创建时间
        /// </summary>
        public DateTime CreatTimeUtc { get; set; }

        /// <summary>
        /// 状态，预留
        /// </summary>
        public byte Status { get; set; }

        /// <summary>
        /// 发布中
        /// </summary>
        public bool Published { get; set; }

        /// <summary>
        /// 删除
        /// </summary>
        public bool Deleted { get; set; }

    }
}
