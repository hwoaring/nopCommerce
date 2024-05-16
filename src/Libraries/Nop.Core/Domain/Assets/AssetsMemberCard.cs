
using Nop.Core.Domain.Common;

namespace Nop.Core.Domain.Assets;

/// <summary>
/// 会员卡，会员等级（不同店铺的用户）
/// </summary>
public partial class AssetsMemberCard : BaseEntity, ISoftDeletedEntity
{
    /// <summary>
    /// 对应StoreID
    /// </summary>
    public int StoreId { get; set; }

    /// <summary>
    /// VendorStore ID
    /// </summary>
    public int VendorStoreId { get; set; }

    /// <summary>
    /// 用户ID
    /// </summary>
    public int CustomerId { get; set; }

    /// <summary>
    /// 会员卡开卡推荐人
    /// </summary>
    public int ReferrerCustomerId { get; set; }

    /// <summary>
    /// 会员卡号（16位=店铺8位+个人随机8位）
    /// </summary>
    public long CardNumber { get; set; }

    /// <summary>
    /// 是否副卡（主卡的分支，副卡时，设置主卡ID）
    /// </summary>
    public bool SecondaryCard { get; set; }

    /// <summary>
    /// 主卡ID
    /// </summary>
    public int MasterMemberCardId { get; set; }

    /// 副卡与主卡关系
    /// </summary>
    public string Relationship { get; set; }

    /// <summary>
    /// hash值，校验码，验证码本条数据的：收入+消费+余额+生成日期的hash值，避免人为修改数据
    /// 收入+消费+余额+生成日期等生产的hash值（校验规则暂未定）
    /// </summary>
    public string HashCode { get; set; }

    /// <summary>
    /// 用户当前等级
    /// </summary>
    public int CurrentLevel { get; set; }

    /// <summary>
    /// 用户最高等级（记录用户最高达到的等级）
    /// </summary>
    public int MaxLevel { get; set; }

    /// <summary>
    /// 基础VIP过期时间（过期后需重新购买会员卡或充值）
    /// </summary>
    public DateTime? ExpireTimeOnUtc { get; set; }

    /// <summary>
    /// 最后升级时间
    /// </summary>
    public DateTime? UpgradeTimeOnUtc { get; set; }

    /// <summary>
    /// 添加时间(开卡时间)
    /// </summary>
    public DateTime CreatOnUtc { get; set; }

    /// <summary>
    /// 锁定备注（锁定原因）
    /// </summary>
    public string LockRemark { get; set; }

    /// <summary>
    /// 是否锁定
    /// </summary>
    public bool Locked { get; set; }

    /// <summary>
    /// 是否用户有升级申请
    /// </summary>
    public bool UpgradeApplication { get; set; }

    /// <summary>
    /// 激活/是否已开卡
    /// </summary>
    public bool Actived { get; set; }

    /// <summary>
    /// 删除
    /// </summary>
    public bool Deleted { get; set; }

}