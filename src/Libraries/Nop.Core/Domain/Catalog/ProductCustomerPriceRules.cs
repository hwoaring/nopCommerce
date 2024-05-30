using Nop.Core.Domain.Customers;

namespace Nop.Core.Domain.Catalog;

/// <summary>
/// 不同等级客户的【购买价格】；等级0不能购买任何产品
/// </summary>
public partial class ProductCustomerPriceRules : BaseEntity
{
    /// <summary>
    /// 产品ID（备用）
    /// </summary>
    public int ProductId { get; set; }

    /// <summary>
    /// 产品属性价格ID（备用）
    /// </summary>
    public int ProductAttributeValueId { get; set; }

    /// <summary>
    /// 会员等级范围类型
    /// </summary>
    public int CustomerLevelScopeTypeId { get; set; }

    /// <summary>
    /// 价格调整使用百分比
    /// </summary>
    public bool PriceAdjustmentUsePercentage { get; set; }

    /// <summary>
    /// 等级0价格（等级0为普通用户）
    /// </summary>
    public decimal LevelZeroPriceAdjustment { get; set; }

    /// <summary>
    /// 等级1价格
    /// </summary>
    public decimal LevelOnePriceAdjustment { get; set; }

    /// <summary>
    /// 等级2价格
    /// </summary>
    public decimal LevelTwoPriceAdjustment { get; set; }

    /// <summary>
    /// 等级3价格
    /// </summary>
    public decimal LevelThreePriceAdjustment { get; set; }

    /// <summary>
    /// 等级4价格
    /// </summary>
    public decimal LevelFourPriceAdjustment { get; set; }


    /// <summary>
    /// 等级5价格
    /// </summary>
    public decimal LevelFivePriceAdjustment { get; set; }

    /// <summary>
    /// 等级6价格
    /// </summary>
    public decimal LevelSixPriceAdjustment { get; set; }

    /// <summary>
    /// 等级7价格
    /// </summary>
    public decimal LevelSevenPriceAdjustment { get; set; }

    /// <summary>
    /// 等级8价格
    /// </summary>
    public decimal LevelEightPriceAdjustment { get; set; }

    /// <summary>
    /// 等级9价格
    /// </summary>
    public decimal LevelNinePriceAdjustment { get; set; }

    /// <summary>
    /// 等级10价格
    /// </summary>
    public decimal LevelTenPriceAdjustment { get; set; }

    /// <summary>
    /// 会员等级范围类型
    /// </summary>
    public CustomerLevelScopeType CustomerLevelScopeType
    {
        get => (CustomerLevelScopeType)CustomerLevelScopeTypeId;
        set => CustomerLevelScopeTypeId = (int)value;
    }
}
