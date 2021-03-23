using System;

namespace Nop.Core.Domain.Weixin
{
    /// <summary>
    /// Represents an 微信小程序记录表
    /// </summary>
    public partial class WApp : BaseEntity
    {
        /// <summary>
        /// 小程序AppID
        /// </summary>
        public string AppId { get; set; }
        /// <summary>
        /// 小程序AppSecret
        /// </summary>
        public string AppSecret { get; set; }
        /// <summary>
        /// 微信商户号ID
        /// </summary>
        public string MchId { get; set; }

        /// <summary>
        /// 微信支付密钥
        /// </summary>
        public string ApiKey { get; set; }
        /// <summary>
        /// 证书文件cert
        /// </summary>
        public string CertPem { get; set; }
        /// <summary>
        /// 商城ID（外键）
        /// </summary>
        public int StoreId { get; set; }
        /// <summary>
        /// 是否删除
        /// </summary>
        public bool Deleted { get; set; }

        /// <summary>
        /// 更新时间
        /// </summary>
        public DateTime? UpdateTimeUtc { get; set; }
        /// <summary>
        /// 创建时间
        /// </summary>
        public DateTime CreatTimeUtc { get; set; }
    }
}
