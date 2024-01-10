using Nop.Core.Domain.Common;

namespace Nop.Core.Domain.SMS
{
    /// <summary>
    /// 供分销人员选择的公共组合
    /// </summary>
    public partial class SmsPublicCombination : BaseEntity, ISoftDeletedEntity
    {
        /// <summary>
        /// 使用的账号ID
        /// </summary>
        public int SmsAccountId { get; set; }
        /// <summary>
        /// sms签名id
        /// </summary>
        public int SmsSignId { get; set; }

        /// <summary>
        /// sms模板id
        /// </summary>
        public int SmsTemplateId { get; set; }

        /// <summary>
        /// 需要验证
        /// </summary>
        public bool NeedVerify { get; set; }

        /// <summary>
        /// 是否可用
        /// </summary>
        public bool Enabled { get; set; }

        /// <summary>
        /// 是否系统默认，只有系统可调用
        /// </summary>
        public bool SystemDefault { get; set; }

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
