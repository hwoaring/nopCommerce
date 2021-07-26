using System;

namespace Nop.Core.Domain.Vendors
{
    /// <summary>
    /// Represents Vendor 短信服务使用情况
    /// </summary>
    public partial class VendorSmsHistory : BaseEntity
    {
        /// <summary>
        /// Gets or sets the vendor identifier
        /// </summary>
        public int VendorId { get; set; }

        /// <summary>
        /// 使用条数
        /// </summary>
        public int Count { get; set; }

        /// <summary>
        /// 接收号码
        /// </summary>
        public string SendNumber { get; set; }

        /// <summary>
        /// 发送内容
        /// </summary>
        public string SendContent { get; set; }

        /// <summary>
        /// 是否有效
        /// </summary>
        public bool Active { get; set; }

        /// <summary>
        /// Gets or sets the date and time of vendor note creation
        /// </summary>
        public DateTime CreatedOnUtc { get; set; }
    }
}
