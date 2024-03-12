using Nop.Core.Domain.Common;
using Nop.Core.Domain.Tax;

namespace Nop.Core.Domain.Customers;

/// <summary>
/// 不同Store店铺用户推荐表
/// </summary>
public partial class CustomerReferrer : BaseEntity
{
    /// <summary>
    /// 推荐来源店铺StoreId
    /// </summary>
    public int ReferreredInStoreId { get; set; }

    /// <summary>
    /// 当前用户ID（被推荐人ID）
    /// </summary>
    public int CustomerId { get; set; }

    /// <summary>
    /// 永久推荐人ID（推荐人ID）
    /// </summary>
    public int ReferrerCustomerId { get; set; }

    /// <summary>
    /// 临时推荐人ID（推荐人ID）
    /// </summary>
    public int TempReferrerCustomerId { get; set; }

    /// <summary>
    /// 临时推荐人过期时间（更新时间+系统设置的过期市场=过期时间，超出时间属于默认推荐人）
    /// </summary>
    public DateTime? TempReferrerExpireDateUtc { get; set; }

    /// <summary>
    /// 推荐场景值
    /// </summary>
    public string ReferrerSceneStr { get; set; }

    /// <summary>
    /// 推荐场景数字ID
    /// </summary>
    public int ReferrerSceneId { get; set; }

    /// <summary>
    /// 被推荐用户的首次访问页面，即推荐页面（只有用户是被推荐的才记录首次访问页面）
    /// </summary>
    public string FirstReferrerPageUrl { get; set; }

    /// <summary>
    /// 被推荐用户的首次访问页面ID（只有用户是被推荐，由产品页面进入时候才记录）
    /// </summary>
    public int FirstReferrerPageId { get; set; }

    /// <summary>
    /// 页面类型（如：产品页面，新闻页面，专题页面等）
    /// </summary>
    public int FirstReferrerPageType { get; set; }

    /// <summary>
    /// 备注名称（备用：不同StoreId下的备注）
    /// </summary>
    public string Remark { get; set; }
}