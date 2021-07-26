using System;

namespace Nop.Core.Domain.Vendors
{
    /// <summary>
    /// Represents Vendor 自己对产品的展示价格，一般对区域加价卖的客户使用（仅线下成交，只做前端展示）
    /// </summary>
    public partial class VendorSelfPrice : BaseEntity
    {
        /// <summary>
        /// Gets or sets the vendor identifier
        /// </summary>
        public int VendorId { get; set; }

        public int ProductId { get; set; }

        /// <summary>
        /// 自定义价格
        /// </summary>
        public decimal Price { get; set; }

        /// <summary>
        /// 是否有效
        /// </summary>
        public bool Active { get; set; }
    }
}
