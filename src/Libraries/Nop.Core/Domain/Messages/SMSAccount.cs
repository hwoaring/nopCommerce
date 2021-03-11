namespace Nop.Core.Domain.Messages
{
    /// <summary>
    /// Represents an SMS account
    /// </summary>
    public partial class SMSAccount : BaseEntity
    {
        /// <summary>
        /// 启用短信服务
        /// </summary>
        public bool UseSMSService { get; set; }

        /// <summary>
        /// 服务类型：腾讯，阿里
        /// </summary>
        public int MessageServiceTypeId { get; set; }

        /// <summary>
        /// 服务类型：腾讯，阿里
        /// </summary>
        public MessageServiceType MessageServiceType
        {
            get => (MessageServiceType)MessageServiceTypeId;
            set => MessageServiceTypeId = (int)value;
        }

        /// <summary>
        /// 服务地址
        /// </summary>
        public string SMSServiceUrl { get; set; }

        /// <summary>
        /// 服务ID
        /// </summary>
        public string AccessKeyId { get; set; }

        /// <summary>
        /// 服务密码
        /// </summary>
        public string AccessKeySecret { get; set; }

    }
}
