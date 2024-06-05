using Nop.Core.Domain.Common;

namespace Nop.Core.Domain.SMS
{
    /// <summary>
    /// 短信发送记录
    /// </summary>
    public partial class SmsSendRecords : BaseEntity, ISoftDeletedEntity
    {
        /// <summary>
        /// 发送后平台方返回的序列号
        /// </summary>
        public string SerialNumber { get; set; }

        /// <summary>
        /// 发送的代理商id
        /// </summary>
        public int VendorId { get; set; }

        /// <summary>
        /// 账号ID
        /// </summary>
        public int SmsAccountId { get; set; }

        /// <summary>
        /// sms签名id
        /// </summary>
        public string SmsSignId { get; set; }

        /// <summary>
        /// sms模板id
        /// </summary>
        public int SmsTemplateId { get; set; }

        /// <summary>
        /// 电话号码组合，以逗号，空格或分号隔开。
        /// </summary>
        public string Phones { get; set; }

        /// <summary>
        /// 有效电话数量
        /// </summary>
        public int ValidPhoneCount { get; set; }

        /// <summary>
        /// 使用条数（不论是否成功）
        /// </summary>
        public int UsageCount { get; set; }

        /// <summary>
        /// 参数内容（Json格式）
        /// </summary>
        public string Parameters { get; set; }

        /// <summary>
        /// 状态
        /// </summary>
        public int Status { get; set; }

        /// <summary>
        /// 是否群发记录
        /// </summary>
        public bool GroupSend { get; set; }

        /// <summary>
        /// 是否退订客户
        /// </summary>
        public bool UnSubscribed { get; set; }

        /// <summary>
        /// 删除
        /// </summary>
        public bool Deleted { get; set; }

        /// <summary>
        /// 创建时间、发送时间
        /// </summary>
        public DateTime CreatedOnUtc { get; set; }
    }
}
