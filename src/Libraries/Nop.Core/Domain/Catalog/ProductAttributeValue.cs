using Nop.Core.Domain.Localization;

namespace Nop.Core.Domain.Catalog
{
    /// <summary>
    /// Represents a product attribute value
    /// </summary>
    public partial class ProductAttributeValue : BaseEntity, ILocalizedEntity
    {
        /// <summary>
        /// Gets or sets the product attribute name
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        ///短名称
        /// </summary>
        public string ShortName { get; set; }

        /// <summary>
        /// Gets or sets the color RGB value (used with "Color squares" attribute type)
        /// </summary>
        public string ColorSquaresRgb { get; set; }

        /// <summary>
        /// 描述
        /// </summary>
        public string Discription { get; set; }

        /// <summary>
        /// 内容
        /// </summary>
        public string Content { get; set; }

        /// <summary>
        /// Gets or sets the picture (identifier) associated with this value. This picture should replace a product main picture once clicked (selected).
        /// </summary>
        public int PictureId { get; set; }

        /// <summary>
        /// Gets or sets the product attribute mapping identifier
        /// </summary>
        public int ProductAttributeMappingId { get; set; }

        /// <summary>
        /// Gets or sets the attribute value type identifier
        /// </summary>
        public int AttributeValueTypeId { get; set; }

        /// <summary>
        /// Gets or sets the associated product identifier (used only with AttributeValueType.AssociatedToProduct)
        /// </summary>
        public int AssociatedProductId { get; set; }

        /// <summary>
        /// Gets or sets the picture ID for image square (used with "Image squares" attribute type)
        /// </summary>
        public int ImageSquaresPictureId { get; set; }

        /// <summary>
        /// Gets or sets the quantity of associated product (used only with AttributeValueType.AssociatedToProduct)
        /// </summary>
        public int Quantity { get; set; }

        /// <summary>
        /// Gets or sets the display order
        /// </summary>
        public int DisplayOrder { get; set; }

        /// <summary>
        /// Gets or sets the price adjustment (used only with AttributeValueType.Simple)
        /// </summary>
        public decimal PriceAdjustment { get; set; }

        /// <summary>
        /// 原价，划线价
        /// </summary>
        public decimal OldPrice { get; set; }

        /// <summary>
        /// 最小购买数量
        /// </summary>
        public int OrderMinimumQuantity { get; set; }

        /// <summary>
        /// 最大购买数量
        /// </summary>
        public int OrderMaximumQuantity { get; set; }

        /// <summary>
        /// 【价格保护】使用免费的折扣券最大折扣比例（超出比例不显示可用折扣卡或取最小折扣比例）
        /// </summary>
        public decimal? MaxDiscountPercentage { get; set; }

        /// <summary>
        /// 【价格保护】使用免费的现金抵用券最大金额（超出金额的券不显示或取最小限定值）
        /// </summary>
        public decimal? MaxDiscountAmount { get; set; }

        /// <summary>
        /// Gets or sets the weight adjustment (used only with AttributeValueType.Simple)
        /// </summary>
        public decimal WeightAdjustment { get; set; }

        /// <summary>
        /// Gets or sets the attribute value cost (used only with AttributeValueType.Simple)
        /// </summary>
        public decimal Cost { get; set; }

        /// <summary>
        /// 是否推荐
        /// </summary>
        public bool IsRecommend { get; set; }

        /// <summary>
        /// 是否热门
        /// </summary>
        public bool IsHot { get; set; }

        /// <summary>
        /// 是否特价商品
        /// </summary>
        public bool SpecialPrice { get; set; }
        /// <summary>
        /// 是否折扣商品
        /// </summary>
        public bool DiscountPrice { get; set; }

        /// <summary>
        /// 仅新用户可购买
        /// </summary>
        public bool OnlyForNewUser { get; set; }

        /// <summary>
        /// 使用数量倍数（基数价格的x倍，Quantity值为倍数值）
        /// </summary>
        public bool UseQtyMultiple { get; set; }

        /// <summary>
        /// 是否使用固定价格值
        /// </summary>
        public bool PriceAdjustmentUseFixedValue { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether "price adjustment" is specified as percentage (used only with AttributeValueType.Simple)
        /// </summary>
        public bool PriceAdjustmentUsePercentage { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether the customer can enter the quantity of associated product (used only with AttributeValueType.AssociatedToProduct)
        /// </summary>
        public bool CustomerEntersQty { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether the value is pre-selected
        /// </summary>
        public bool IsPreSelected { get; set; }

        /// <summary>
        /// Gets or sets the attribute value type
        /// </summary>
        public AttributeValueType AttributeValueType
        {
            get => (AttributeValueType)AttributeValueTypeId;
            set => AttributeValueTypeId = (int)value;
        }
    }
}
