using Nop.Core.Domain.Localization;

namespace Nop.Core.Domain.Catalog
{
    /// <summary>
    /// Represents a predefined (default) product attribute value
    /// </summary>
    public partial class PredefinedProductAttributeValue : BaseEntity, ILocalizedEntity
    {
        /// <summary>
        /// Gets or sets the product attribute identifier
        /// </summary>
        public int ProductAttributeId { get; set; }

        /// <summary>
        /// Gets or sets the product attribute name
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the price adjustment
        /// </summary>
        public decimal PriceAdjustment { get; set; }

        /// <summary>
        /// 分销价
        /// </summary>
        public decimal DistributorPriceAdjustment { get; set; }

        /// <summary>
        /// 代理价
        /// </summary>
        public decimal AgentPriceAdjustment { get; set; }

        /// <summary>
        /// 会员价
        /// </summary>
        public decimal MemberPriceAdjustment { get; set; }

        /// <summary>
        /// 划线价
        /// </summary>
        public decimal OldPriceAdjustment { get; set; }

        /// <summary>
        /// 多数量
        /// </summary>
        public bool UseQtyMultiple { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether "price adjustment" is specified as percentage
        /// </summary>
        public bool PriceAdjustmentUsePercentage { get; set; }

        /// <summary>
        /// Gets or sets the weight adjustment
        /// </summary>
        public decimal WeightAdjustment { get; set; }

        /// <summary>
        /// Gets or sets the attribute value cost
        /// </summary>
        public decimal Cost { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether the value is pre-selected
        /// </summary>
        public bool IsPreSelected { get; set; }

        /// <summary>
        /// Gets or sets the display order
        /// </summary>
        public int DisplayOrder { get; set; }
    }
}
