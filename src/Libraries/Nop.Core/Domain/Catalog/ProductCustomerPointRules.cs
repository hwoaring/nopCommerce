using Nop.Core.Domain.Customers;

namespace Nop.Core.Domain.Catalog;

/// <summary>
/// 不同等级客户的【积分购买规则】
/// </summary>
public partial class ProductCustomerPointRules : BaseEntity
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
    /// 必须使用积分抵扣数量
    /// </summary>
    public decimal LevelZeroRequirePoints { get; set; }

    /// <summary>
    /// 必须使用积分抵扣数量
    /// </summary>
    public decimal LevelOneRequirePoints { get; set; }

    /// <summary>
    /// 必须使用积分抵扣数量
    /// </summary>
    public decimal LevelTwoRequirePoints { get; set; }

    /// <summary>
    /// 必须使用积分抵扣数量
    /// </summary>
    public decimal LevelThreeRequirePoints { get; set; }

    /// <summary>
    /// 必须使用积分抵扣数量
    /// </summary>
    public decimal LevelFourRequirePoints { get; set; }

    /// <summary>
    /// 必须使用积分抵扣数量
    /// </summary>
    public decimal LevelFiveRequirePoints { get; set; }

    /// <summary>
    /// 必须使用积分抵扣数量
    /// </summary>
    public decimal LevelSixRequirePoints { get; set; }

    /// <summary>
    /// 必须使用积分抵扣数量
    /// </summary>
    public decimal LevelSevenRequirePoints { get; set; }

    /// <summary>
    /// 必须使用积分抵扣数量
    /// </summary>
    public decimal LevelEightRequirePoints { get; set; }

    /// <summary>
    /// 必须使用积分抵扣数量
    /// </summary>
    public decimal LevelNineRequirePoints { get; set; }

    /// <summary>
    /// 必须使用积分抵扣数量
    /// </summary>
    public decimal LevelTenRequirePoints { get; set; }

    /// <summary>
    /// 会员等级范围类型
    /// </summary>
    public CustomerLevelScopeType CustomerLevelScopeType
    {
        get => (CustomerLevelScopeType)CustomerLevelScopeTypeId;
        set => CustomerLevelScopeTypeId = (int)value;
    }
}
