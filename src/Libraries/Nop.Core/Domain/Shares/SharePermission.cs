

namespace Nop.Core.Domain.Shares;

/// <summary>
/// 设置产品的分销权限信息
/// </summary>
public partial class SharePermission : BaseEntity
{
    /// <summary>
    /// 产品ID
    /// </summary>
    public int ProductId { get; set; }

    /// <summary>
    /// 产品的允许的最大分销人数
    /// 参看：VendorSaleProduct
    /// </summary>
    public int MaxCustomerCounts { get; set; }

    /// <summary>
    /// 产品的总分销权限
    /// 总供应商购买了总分销功能，所有Vendor都可以分销该产品，，都会显示各人的联系方式，不需要Vendor自己充值购买权限。
    /// 参看：VendorSaleProduct表中的相关字段
    /// </summary>
    public bool Enabled { get; set; }

    /// <summary>
    /// 产品的总分销权限（过期时间）
    /// </summary>
    public DateTime? ExpireDateUtc { get; set; }
}
