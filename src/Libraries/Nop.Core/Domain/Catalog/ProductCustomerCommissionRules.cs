using Nop.Core.Domain.Customers;

namespace Nop.Core.Domain.Catalog;

/// <summary>
/// 零售商/分销商不同等级佣金；
/// </summary>
public partial class ProductCustomerCommissionRules : BaseEntity
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
    /// 使用百分比计算佣金
    /// </summary>
    public bool CommissionUsePercentage { get; set; }

    /// <summary>
    /// 等级0佣金(等级0为普通用户)
    /// </summary>
    public decimal LevelZeroAmount { get; set; }

    /// <summary>
    /// 等级1佣金
    /// </summary>
    public decimal LevelOneAmount { get; set; }

    /// <summary>
    /// 等级2佣金
    /// </summary>
    public decimal LevelTwoAmount { get; set; }

    /// <summary>
    /// 等级3佣金
    /// </summary>
    public decimal LevelThreeAmount { get; set; }

    /// <summary>
    /// 等级4佣金
    /// </summary>
    public decimal LevelFourAmount { get; set; }

    /// <summary>
    /// 等级5佣金
    /// </summary>
    public decimal LevelFiveAmount { get; set; }

    /// <summary>
    /// 等级6佣金
    /// </summary>
    public decimal LevelSixAmount { get; set; }

    /// <summary>
    /// 等级7佣金
    /// </summary>
    public decimal LevelSevenAmount { get; set; }

    /// <summary>
    /// 等级8佣金
    /// </summary>
    public decimal LevelEightAmount { get; set; }

    /// <summary>
    /// 等级9佣金
    /// </summary>
    public decimal LevelNineAmount { get; set; }

    /// <summary>
    /// 等级10佣金
    /// </summary>
    public decimal LevelTenAmount { get; set; }

    /// <summary>
    /// 会员等级范围类型
    /// </summary>
    public CustomerLevelScopeType CustomerLevelScopeType
    {
        get => (CustomerLevelScopeType)CustomerLevelScopeTypeId;
        set => CustomerLevelScopeTypeId = (int)value;
    }
}
