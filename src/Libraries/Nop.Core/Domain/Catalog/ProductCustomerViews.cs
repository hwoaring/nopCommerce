namespace Nop.Core.Domain.Catalog;

/// <summary>
/// 浏览产品记录
/// </summary>
public partial class ProductCustomerViews : BaseEntity
{
    /// <summary>
    /// 用户ID
    /// </summary>
    public int CustomerId { get; set; }

    /// <summary>
    /// 浏览产品ID
    /// </summary>
    public int ProductId { get; set; }

    /// <summary>
    /// 创建时间
    /// </summary>
    public int CreatOnUtc { get; set; }
}