using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;
using Nop.Core.Domain.Localization;

namespace Nop.Core.Domain.Catalog;

/// <summary>
/// Represents a product attribute value
/// </summary>
public partial class ProductAttributeValue : BaseEntity, ILocalizedEntity
{
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
    /// Gets or sets the product attribute name
    /// </summary>
    public string Name { get; set; }

    /// <summary>
    /// Gets or sets the color RGB value (used with "Color squares" attribute type)
    /// </summary>
    public string ColorSquaresRgb { get; set; }

    /// <summary>
    /// Gets or sets the picture ID for image square (used with "Image squares" attribute type)
    /// </summary>
    public int ImageSquaresPictureId { get; set; }

    /// <summary>
    /// Gets or sets the price adjustment (used only with AttributeValueType.Simple)
    /// </summary>
    public decimal PriceAdjustment { get; set; }

    /// <summary>
    /// Gets or sets a value indicating whether "price adjustment" is specified as percentage (used only with AttributeValueType.Simple)
    /// </summary>
    public bool PriceAdjustmentUsePercentage { get; set; }

    /// <summary>
    /// Gets or sets the weight adjustment (used only with AttributeValueType.Simple)
    /// </summary>
    public decimal WeightAdjustment { get; set; }

    /// <summary>
    /// Gets or sets the attribute value cost (used only with AttributeValueType.Simple)
    /// </summary>
    public decimal Cost { get; set; }

    /// <summary>
    /// Gets or sets a value indicating whether the customer can enter the quantity of associated product (used only with AttributeValueType.AssociatedToProduct)
    /// </summary>
    public bool CustomerEntersQty { get; set; }

    /// <summary>
    /// Gets or sets the quantity of associated product (used only with AttributeValueType.AssociatedToProduct)
    /// </summary>
    public int Quantity { get; set; }

    /// <summary>
    /// Gets or sets a value indicating whether the value is pre-selected
    /// </summary>
    public bool IsPreSelected { get; set; }

    /// <summary>
    /// Gets or sets the display order
    /// </summary>
    public int DisplayOrder { get; set; }

    /// <summary>
    /// Gets or sets the attribute value type
    /// </summary>
    public AttributeValueType AttributeValueType
    {
        get => (AttributeValueType)AttributeValueTypeId;
        set => AttributeValueTypeId = (int)value;
    }

    /// <summary>
    /// The field is not used since 4.70 and is left only for the update process
    /// use the <see cref="ProductAttributeValuePicture"/> instead
    /// </summary>
    [EditorBrowsable(EditorBrowsableState.Never)]
    [Browsable(false)]
    [Obsolete("The field is not used since 4.70 and is left only for the update process use the ProductAttributeValuePicture instead")]
    public int? PictureId { get; set; }


    #region

    /// <summary>
    /// 每个属性产品的系统SKU
    /// </summary>
    public string Sku { get; set; }

    /// <summary>
    ///短名称
    /// </summary>
    public string ShortName { get; set; }

    /// <summary>
    /// 描述
    /// </summary>
    public string Discription { get; set; }

    /// <summary>
    /// 内容
    /// </summary>
    public string Content { get; set; }

    /// <summary>
    /// 使用规则（使用限制文本信息）
    /// </summary>
    public string UsageRulesContent { get; set; }

    /// <summary>
    /// 原价/划线价（备用）
    /// </summary>
    public decimal OldPriceAdjustment { get; set; }

    /// <summary>
    /// 库存数量（备用），可能原有的Quantity是表示库存
    /// </summary>
    public int StockQuantity { get; set; }

    /// <summary>
    /// 最小购买数量
    /// </summary>
    public int OrderMinimumQuantity { get; set; }

    /// <summary>
    /// 最大购买数量
    /// </summary>
    public int OrderMaximumQuantity { get; set; }

    /// <summary>
    /// 广告分享金抵用：最高使用金额
    /// </summary>
    public decimal MaxAdvertAmounts { get; set; }

    /// <summary>
    /// 必须使用积分抵扣数量
    /// </summary>
    public decimal RequirePoints { get; set; }

    /// <summary>
    /// 使用等级价格规则
    /// </summary>
    public bool UseCustomerPriceRules { get; set; }

    /// <summary>
    /// 使用等级价格规则ID
    /// </summary>
    public int CustomerPriceRulesId { get; set; }

    /// <summary>
    /// 使用等级积分购买规则
    /// </summary>
    public bool UseCustomerPointRules { get; set; }

    /// <summary>
    /// 使用等级积分购买规则ID
    /// </summary>
    public int CustomerPointRulesId { get; set; }

    /// <summary>
    /// 使用等级分享广告规则
    /// </summary>
    public bool UseCustomerAdvertRules { get; set; }

    /// <summary>
    /// 使用等级分享广告规则ID
    /// </summary>
    public int CustomerAdvertRulesId { get; set; }

    /// <summary>
    /// 仅新用户可购买
    /// </summary>
    public bool NewUserOnly { get; set; }

    /// <summary>
    /// 启用状态
    /// </summary>
    public bool Enabled { get; set; }

    #endregion

}
