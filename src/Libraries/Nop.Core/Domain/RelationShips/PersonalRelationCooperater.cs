namespace Nop.Core.Domain.RelationShips;

/// <summary>
/// 个人对客户关系的跟进记录向指定人公开共享
/// </summary>
public partial class PersonalRelationCooperater : BaseEntity
{
    /// <summary>
    /// 客户关系ID
    /// </summary>
    public int PersonalRelationShipId { get; set; }

    /// <summary>
    /// 合作人ID
    /// </summary>
    public int CooperaterCustomerId { get; set; }

    /// <summary>
    /// 共享和操作跟进记录
    /// </summary>
    public bool EnableCooperateFollowup { get; set; }

    /// <summary>
    /// 共享姓名
    /// </summary>
    public bool EnableCooperateName { get; set; }

    /// <summary>
    /// 共享备注
    /// </summary>
    public bool EnableCooperateNotes { get; set; }

    /// <summary>
    /// 共享尊称（礼貌名称，发祝福时候使用尊称）
    /// </summary>
    public bool EnableCooperateCourtesyName { get; set; }

    /// <summary>
    /// 共享联系电话
    /// </summary>
    public bool EnableCooperatePhoneNumber { get; set; }

    /// <summary>
    /// 共享地址
    /// </summary>
    public bool EnableCooperateAddress { get; set; }

    /// <summary>
    /// 共享备注，描述
    /// </summary>
    public bool EnableCooperateDescription { get; set; }

    /// <summary>
    /// 共享公司名称
    /// </summary>
    public bool EnableCooperateCompany { get; set; }

    /// <summary>
    /// 共享职务名称
    /// </summary>
    public bool EnableCooperatePostName { get; set; }

    /// <summary>
    /// 共享会员生日（国历）
    /// </summary>
    public bool EnableCooperateBirthOfDateUtc { get; set; }

}
