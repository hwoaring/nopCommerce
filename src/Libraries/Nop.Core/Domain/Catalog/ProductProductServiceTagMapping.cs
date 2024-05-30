

namespace Nop.Core.Domain.Catalog;

/// <summary>
/// 产品服务标签，特色服务标签绑定到产品
/// </summary>
public partial class ProductProductServiceTagMapping : BaseEntity
{
    /// <summary>
    /// 产品ID
    /// </summary>
    public int ProductId { get; set; }

    /// <summary>
    /// 产品服务标签ID
    /// </summary>
    public int ProductServiceTagId { get; set; }

}