namespace Nop.Core.Domain.Catalog
{
    /// <summary>
    /// Represents a tier price
    /// </summary>
    public partial class TierPrice : BaseEntity
    {
        /// <summary>
        /// 阶梯价/满减名称
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 短名称，前台展示
        /// </summary>
        public string ShortName { get; set; }

        /// <summary>
        /// 启用：金额满减
        /// </summary>
        public bool EnableAmountDeductPrice { get; set; }

        /// <summary>
        /// 启用：每满减
        /// </summary>
        public bool EnableDeductPriceRepeat { get; set; }

        /// <summary>
        /// 金额满价格
        /// </summary>
        public decimal OverPrice { get; set; }

        /// <summary>
        /// 金额减少价格
        /// </summary>
        public decimal DeductPrice { get; set; }

        /// <summary>
        /// 是否累积优惠，与其他优惠同时使用
        /// </summary>
        public bool IsCumulative { get; set; }

        /// <summary>
        /// 折扣信息标题是否在产品列表页面或详情页面展示
        /// </summary>
        public bool FrontDisplay { get; set; }

        /// <summary>
        /// 仅新用户使用
        /// </summary>
        public bool NewUserOnly { get; set; }

        /// <summary>
        /// Gets or sets the product identifier
        /// </summary>
        public int ProductId { get; set; }

        /// <summary>
        /// Gets or sets the store identifier (0 - all stores)
        /// </summary>
        public int StoreId { get; set; }

        /// <summary>
        /// Gets or sets the customer role identifier
        /// </summary>
        public int? CustomerRoleId { get; set; }

        /// <summary>
        /// Gets or sets the quantity
        /// </summary>
        public int Quantity { get; set; }

        /// <summary>
        /// Gets or sets the price
        /// </summary>
        public decimal Price { get; set; }

        /// <summary>
        /// Gets or sets the start date and time in UTC
        /// </summary>
        public DateTime? StartDateTimeUtc { get; set; }

        /// <summary>
        /// Gets or sets the end date and time in UTC
        /// </summary>
        public DateTime? EndDateTimeUtc { get; set; }
    }
}
