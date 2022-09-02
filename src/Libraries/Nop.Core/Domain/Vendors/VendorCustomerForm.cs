using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nop.Core.Domain.Vendors
{
    /// <summary>
    /// Represents Vendor 客户联系信息表单（含订单信息）
    /// </summary>
    public partial class VendorCustomerForm : BaseEntity
    {
        /// <summary>
        /// Gets or sets the vendor identifier
        /// </summary>
        public int VendorId { get; set; }

        /// <summary>
        /// 客户Id
        /// </summary>
        public int CustomerId { get; set; }

        /// <summary>
        /// 表单类型（备用）
        /// </summary>
        public int FormType { get; set; }

        /// <summary>
        /// 客户姓名
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 客户电话
        /// </summary>
        public string Phone { get; set; }

        /// <summary>
        /// 扩展消息
        /// </summary>
        public string ExtendMessage { get; set; }

        /// <summary>
        /// 客户留言
        /// </summary>
        public string CustomerMessage { get; set; }

        /// <summary>
        /// 地址信息
        /// </summary>
        public string AddressInfo { get; set; }

        /// <summary>
        /// 订单信息
        /// </summary>
        public string OrderXml { get; set; }

        /// <summary>
        /// Vendor对表单的备注或回复内容
        /// </summary>
        public string ReplyMessage { get; set; }

        /// <summary>
        /// 是否已回复
        /// </summary>
        public bool Replied { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public bool Published { get; set; }

        /// <summary>
        /// 是否有效
        /// </summary>
        public bool Active { get; set; }

        /// <summary>
        /// 回复时间
        /// </summary>
        public DateTime? ReplyDateUtc { get; set; }

        /// <summary>
        /// Gets or sets the date and time of vendor note creation
        /// </summary>
        public DateTime CreatedOnUtc { get; set; }
    }
}
