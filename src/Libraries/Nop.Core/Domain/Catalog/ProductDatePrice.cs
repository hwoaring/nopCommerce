using Nop.Core.Domain.Localization;

namespace Nop.Core.Domain.Catalog
{
    /// <summary>
    /// 按日期定价
    /// </summary>
    public partial class ProductDatePrice : BaseEntity
    {

        /// <summary>
        /// Gets or sets the store identifier (0 - all stores)
        /// </summary>
        public int StoreId { get; set; }

        /// <summary>
        /// 产品ID
        /// </summary>
        public int ProductId { get; set; }

        /// <summary>
        /// 产品属性ID
        /// </summary>
        public int ProductAttributeId { get; set; }

        /// <summary>
        /// Gets or sets the customer role identifier
        /// </summary>
        public int? CustomerRoleId { get; set; }

        /// <summary>
        /// 预定时间
        /// </summary>
        public DateTime PreOrderDateOnUtc { get; set; }

        /// <summary>
        /// 库存数
        /// </summary>
        public int StockQuantity { get; set; }

        /// <summary>
        /// 划线价格
        /// </summary>
        public decimal OldPrice { get; set; }

        /// <summary>
        /// 销售价格
        /// </summary>
        public decimal Price { get; set; }

        /// <summary>
        /// 底价
        /// </summary>
        public decimal BasePrice { get; set; }

        /// <summary>
        /// 使用日期区间价格（开始时间，结束时间）
        /// </summary>
        public bool UseRangePrice { get; set; }

        /// <summary>
        /// 日期价格表
        /// </summary>
        public string DatePricesXml { get; set; }

        /// <summary>
        /// 开始时间
        /// </summary>
        public DateTime? StartDateTimeUtc { get; set; }

        /// <summary>
        /// 结束时间
        /// </summary>
        public DateTime? EndDateTimeUtc { get; set; }

        /// <summary>
        /// 暂停销售
        /// </summary>
        public bool Suspend { get; set; }
    }
}
