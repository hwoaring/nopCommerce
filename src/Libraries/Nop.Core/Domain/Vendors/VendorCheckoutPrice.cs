namespace Nop.Core.Domain.Vendors;

/// <summary>
/// 上级代理给其下级代理结算价的备注
/// </summary>
public partial class VendorCheckoutPrice : BaseEntity
{
    /// <summary>
    /// 当前代理商ID
    /// </summary>
    public int VendorId { get; set; }

    /// <summary>
    /// 下级VendorId
    /// </summary>
    public int ChildVendorId { get; set; }

    /// <summary>
    /// 代理产品ID
    /// </summary>
    public int ProductId { get; set; }

    /// <summary>
    /// 结算价
    /// </summary>
    public decimal Price { get; set; }

    /// <summary>
    /// 备注信息
    /// </summary>
    public string Remark { get; set; }
}
