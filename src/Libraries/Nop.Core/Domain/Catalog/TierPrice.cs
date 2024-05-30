namespace Nop.Core.Domain.Catalog;

/// <summary>
/// Represents a tier price
/// </summary>
public partial class TierPrice : BaseEntity
{
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


    #region === 扩展属性 ===

    /// <summary>
    /// 名称
    /// </summary>
    public string Name { get; set; }

    /// <summary>
    /// 短名称（前台展示）
    /// </summary>
    public string ShortName { get; set; }

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
    /// 购买需大于等于会员等级（0-不限会员等级）
    /// </summary>
    public int OrderLimitCustomerLevel { get; set; }

    /// <summary>
    /// 划线价
    /// </summary>
    public decimal OldPrice { get; set; }

    /// <summary>
    /// 广告分享金抵用：最高使用金额
    /// </summary>
    public decimal MaxAdvertAmounts { get; set; }

    /// <summary>
    /// 必须使用积分抵扣数量
    /// </summary>
    public decimal RequirePoints { get; set; }

    #endregion

}
