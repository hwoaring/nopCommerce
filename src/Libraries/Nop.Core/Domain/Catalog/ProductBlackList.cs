namespace Nop.Core.Domain.Catalog;

/// <summary>
/// 产品对应用户黑名单（黑名单用户不展示产品）
/// </summary>
public partial class ProductBlackList : BaseEntity
{
    /// <summary>
    /// 用户ID
    /// </summary>
    public int CustomerId { get; set; }

    /// <summary>
    /// 产品ID（如果产品ID=0，则禁止所有产品展示和下单）
    /// </summary>
    public int ProductId { get; set; }

    /// <summary>
    /// 备注
    /// </summary>
    public string Notes { get; set; }
}