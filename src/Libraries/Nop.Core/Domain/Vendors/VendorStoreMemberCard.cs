
using Nop.Core.Domain.Common;

namespace Nop.Core.Domain.Vendors;

/// <summary>
/// 会员卡（不同店铺的用户）
/// </summary>
public partial class VendorStoreMemberCard : BaseEntity, ISoftDeletedEntity
{
    /// <summary>
    /// 会员信息ID（外键）
    /// </summary>
    public int VendorStoreMemberId { get; set; }

    /// <summary>
    /// 会员卡号，虚拟卡ID（16位=店铺8位+个人随机8位）
    /// </summary>
    public long CardNumber { get; set; }

    /// <summary>
    /// 绑定的实物卡卡号，实体卡卡号
    /// </summary>
    public string PhysicalCardNumber { get; set; }

    /// <summary>
    /// 是否主卡，否则为副卡
    /// </summary>
    public bool IsMasterCard { get; set; }

    /// <summary>
    /// 备注
    /// </summary>
    public string Notes { get; set; }

    /// <summary>
    /// hash值，校验码，验证码本条数据的：收入+消费+余额+生成日期的hash值，避免人为修改数据
    /// 收入+消费+余额+生成日期等生产的hash值（校验规则暂未定）
    /// </summary>
    public string HashCode { get; set; }

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
    /// 激活/是否已开卡
    /// </summary>
    public bool Actived { get; set; }

    /// <summary>
    /// 删除
    /// </summary>
    public bool Deleted { get; set; }

}