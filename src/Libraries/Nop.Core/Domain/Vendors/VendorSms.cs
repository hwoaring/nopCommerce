namespace Nop.Core.Domain.Vendors
{
    /// <summary>
    /// 代理商申请发送短信记录
    /// </summary>
    public partial class VendorSms : BaseEntity
    {
        /// <summary>
        /// Gets or sets the vendor identifier
        /// </summary>
        public int VendorId { get; set; }

        /// <summary>
        /// 公共可用模板组合
        /// </summary>
        public int SmsPublicCombinationId { get; set; }

        /// <summary>
        /// 电话号码
        /// </summary>
        public string Phones { get; set; }

        /// <summary>
        /// 状态
        /// </summary>
        public int Status  { get; set; }

        /// <summary>
        /// 是否已发送
        /// </summary>
        public int HasSend { get; set; }

        /// <summary>
        /// 是否通过验证
        /// </summary>
        public bool Verified { get; set; }
    }
}
