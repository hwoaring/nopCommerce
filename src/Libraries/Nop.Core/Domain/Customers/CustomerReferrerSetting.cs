using Nop.Core.Domain.Common;
using Nop.Core.Domain.Tax;

namespace Nop.Core.Domain.Customers;

/// <summary>
/// 不同Store店铺推荐设置
/// </summary>
public partial class CustomerReferrerSetting : BaseEntity
{
    /// <summary>
    /// 店铺StoreId
    /// </summary>
    public int StoreId { get; set; }

    /// <summary>
    /// 当前用户ID
    /// </summary>
    public int CustomerId { get; set; }

    /// <summary>
    /// 是否允许成为推荐人，默认true，不允许时，该用户发布推荐链接时，不会让其他用户成为他的客户
    /// </summary>
    public bool AsReferrerEnable { get; set; }

    /// <summary>
    /// 是否允许被推荐人，不允许时，该用户不会成为其他用户的推荐客户或临时推荐客户
    /// </summary>
    public bool AsRecommendedEnable { get; set; }

    /// <summary>
    /// 允许成为临时推荐人（False=不允许覆盖临时推荐信ID）
    /// </summary>
    public bool AsTempReferrerEnable { get; set; }
}