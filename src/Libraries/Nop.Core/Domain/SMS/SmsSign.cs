using Nop.Core.Domain.Common;

namespace Nop.Core.Domain.SMS
{
    /// <summary>
    /// 短信签名
    /// </summary>
    public partial class SmsSign : BaseEntity, ISoftDeletedEntity
    {
        /// <summary>
        /// 账号ID
        /// </summary>
        public int SmsAccountId { get; set; }

        /// <summary>
        /// sms平台的签名id
        /// </summary>
        public string SignId { get; set; }

        /// <summary>
        /// 签名内容
        /// </summary>
        public string SignName { get; set; }

        /// <summary>
        /// 签名字数
        /// </summary>
        public int SignWordsNumber { get; set; }

        /// <summary>
        /// 状态
        /// </summary>
        public int Status { get; set; }

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
