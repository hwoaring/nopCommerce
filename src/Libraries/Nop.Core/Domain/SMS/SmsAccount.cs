using Nop.Core.Domain.Common;
using Nop.Core.Domain.Localization;
using Nop.Core.Domain.Seo;

namespace Nop.Core.Domain.SMS
{
    /// <summary>
    /// 短信账号
    /// </summary>
    public partial class SmsAccount : BaseEntity, ISoftDeletedEntity
    {
        /// <summary>
        /// StoreId
        /// </summary>
        public int StoreId { get; set; }

        /// <summary>
        /// 代理商店铺名称（只有有店铺的供应商才能注册账号）
        /// 个人代理只能使用供应商提供的短信接口
        /// </summary>
        public int VendorStoreId { get; set; }

        /// <summary>
        /// 对外展示统一加密id（URL参数）
        /// </summary>
        public long UnifiedId { get; set; }

        /// <summary>
        /// 提供接口的应用平台ID
        /// </summary>
        public int SmsPlatformId { get; set; }

        /// <summary>
        /// 可用短信数量，可用条数
        /// </summary>
        public int AvailableQuantity { get; set; }

        /// <summary>
        /// 国内每条短信字数上限(用于计算实际扣除条数)
        /// </summary>
        public int MaxWordsPerSMS { get; set; }

        /// <summary>
        /// 国内短信每天发送数量超出提醒数
        /// </summary>
        public int NoticeSendCountPerDay { get; set; }

        /// <summary>
        /// 国内短信每天发送数量最大数限制，超出后暂停
        /// </summary>
        public int MaxSendCountPerDay { get; set; }

        /// <summary>
        /// 每秒限制发送频率
        /// </summary>
        public int LimitFrequence { get; set; }

        /// <summary>
        /// 国际短信每天发送数量超出提醒数
        /// </summary>
        public int NoticeSendCountPerDay_International{ get; set; }

        /// <summary>
        /// 国际短信每天发送数量最大数限制，超出后暂停
        /// </summary>
        public int MaxSendCountPerDay_International { get; set; }

        /// <summary>
        /// 应用名称
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 描述
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// appid
        /// </summary>
        public string AppId { get; set; }

        /// <summary>
        /// appKey
        /// </summary>
        public string AppKey { get; set; }

        /// <summary>
        /// 标签名称
        /// </summary>
        public string TagName { get; set; }

        /// <summary>
        /// 标签值
        /// </summary>
        public string TagValues { get; set; }

        /// <summary>
        /// 状态
        /// </summary>
        public int Status { get; set; }

        /// <summary>
        /// 同一手机号，启用30秒限制
        /// </summary>
        public bool EnableLimit30Sec { get; set; }

        /// <summary>
        /// 同一手机号，30秒限制数量
        /// </summary>
        public int Limit30SecCount { get; set; }

        /// <summary>
        /// 同一手机号，启用1小时限制
        /// </summary>
        public bool EnableLimit1Hour { get; set; }

        /// <summary>
        /// 同一手机号，1小时限制数量
        /// </summary>
        public int Limit1HourCount { get; set; }

        /// <summary>
        /// 同一手机号，启用24小时限制
        /// </summary>
        public bool EnableLimit24Hour { get; set; }

        /// <summary>
        /// 同一手机号，24小时限制数量
        /// </summary>
        public int Limit24HourCount { get; set; }

        /// <summary>
        /// 同一手机号，启用相同内容限制
        /// </summary>
        public bool EnableLimitSameContent { get; set; }

        /// <summary>
        /// 同一手机号，相同内容限制时间（秒）
        /// </summary>
        public int LimitSameContentSeconds { get; set; }

        /// <summary>
        /// 同一手机号，相同内容限制数量
        /// </summary>
        public int LimitSameContentCount { get; set; }

        /// <summary>
        /// 使用系统默认账号
        /// </summary>
        public bool UseDefaultAccount { get; set; }

        /// <summary>
        /// 是否允许发送国际短信
        /// </summary>
        public bool AllowSendInternationalSMS { get; set; }

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
