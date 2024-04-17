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
    /// 个人控制：设置8位其他人的推荐码（永久推荐人为自己，设置他人推荐码后，临时推荐人为设置的推荐码对应推荐人）
    /// 相当于可以帮助他人发分享链接
    /// 如果为空或找不到推荐人，则默认为自己的推荐码
    /// </summary>
    public long OthersReferrerCode { get; set; }

    /// <summary>
    /// 系统控制：是否允许该用户设置和使用他人的推荐码
    /// </summary>
    public bool OthersReferrerCodeEnable { get; set; }

    /// <summary>
    /// 是否允许成为推荐人，（不允许时，该用户发布推荐链接时，不会让其他用户成为他的永久客户或临时客户
    /// </summary>
    public bool AsReferrerEnable { get; set; }

    /// <summary>
    /// 是否允许成为临时推荐人，（不允许时，该用户发布的推荐链接，不会覆盖被推荐人的临时推荐ID）
    /// </summary>
    public bool AsTempReferrerEnable { get; set; }

    /// <summary>
    /// 是否允许被推荐，不允许时，该用户不会成为其他用户的推荐客户或临时推荐客户
    /// </summary>
    public bool AsRecommendedEnable { get; set; }

    /// <summary>
    /// 是否使用临时推荐ID（不使用时，推荐人不能覆盖临时推荐ID，且临时推荐ID无效，永远使用永久推荐ID）
    /// 针对个人设置是否启用临时推荐ID
    /// </summary>
    public bool EnableTempReferrerId { get; set; }


    /// <summary>
    /// 自己控制（备用）：打开关闭推荐功能，如果关闭，在分享他人链接时源链接分享，不会更改为个人分享链接。
    /// </summary>
    public bool CloseReferrer { get; set; }
}