using System;

namespace Nop.Core.Domain.Vendors
{
    /// <summary>
    /// Represents Vendor 短信服务条数
    /// </summary>
    public partial class VendorSms : BaseEntity
    {
        /// <summary>
        /// Gets or sets the vendor identifier
        /// </summary>
        public int VendorId { get; set; }

        /// <summary>
        /// 短信剩余条数
        /// </summary>
        public int Count { get; set; }

        /// <summary>
        /// 展示
        /// </summary>
        public bool Published { get; set; }

        /// <summary>
        /// 是否有效
        /// </summary>
        public bool Active { get; set; }

        /// <summary>
        /// 结束时间
        /// </summary>
        public DateTime? AvailableDateUtc { get; set; }

        /// <summary>
        /// Gets or sets the date and time of vendor note creation
        /// </summary>
        public DateTime CreatedOnUtc { get; set; }
    }
}
