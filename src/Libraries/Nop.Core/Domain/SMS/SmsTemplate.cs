using Nop.Core.Domain.Common;

namespace Nop.Core.Domain.SMS
{
    /// <summary>
    /// 短信模板
    /// </summary>
    public partial class SmsTemplate : BaseEntity, ISoftDeletedEntity
    {
        /// <summary>
        /// 账号ID
        /// </summary>
        public int SmsAccountId { get; set; }

        /// <summary>
        /// sms平台的模板id
        /// </summary>
        public string TemplateId { get; set; }

        /// <summary>
        /// 模板名称
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 模板内容
        /// </summary>
        public string Content { get; set; }

        /// <summary>
        /// 模板总字数（不含签名）
        /// </summary>
        public int ContentWordsNumber { get; set; }

        /// <summary>
        /// 变量个数
        /// </summary>
        public int VariableNumber { get; set; }

        /// <summary>
        /// 变量使用说明
        /// </summary>
        public int VariableNotice { get; set; }

        /// <summary>
        /// 允许发送开始时间
        /// </summary>
        public int StartHour { get; set; }

        /// <summary>
        /// 允许发送结束时间
        /// </summary>
        public int EndHour { get; set; }

        /// <summary>
        /// 状态
        /// </summary>
        public int Status { get; set; }

        /// <summary>
        /// 是否营销短信
        /// </summary>
        public bool MarketingSMS { get; set; }

        /// <summary>
        /// 锁定
        /// </summary>
        public bool Locked { get; set; }

        /// <summary>
        /// 删除
        /// </summary>
        public bool Deleted { get; set; }

        /// <summary>
        /// 创建时间、申请时间
        /// </summary>
        public DateTime CreatedOnUtc { get; set; }
    }
}
