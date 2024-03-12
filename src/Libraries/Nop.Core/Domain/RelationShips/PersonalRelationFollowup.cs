namespace Nop.Core.Domain.RelationShips;

/// <summary>
/// 个人对客户关系的跟进记录
/// </summary>
public partial class PersonalRelationFollowup : BaseEntity
{
    /// <summary>
    /// 客户关系ID
    /// </summary>
    public int PersonalRelationShipId { get; set; }

    /// <summary>
    /// 回访沟通内容和备注
    /// </summary>
    public string Content { get; set; }

    /// <summary>
    /// 跟进记录是私有信息（对外公开是，该条信息不会被公开）
    /// </summary>
    public bool PrivateRemark { get; set; }

    /// <summary>
    /// 沟通效果评价（1-5）
    /// </summary>
    public int EffectLevel { get; set; }

    /// <summary>
    /// 对方是否回复
    /// </summary>
    public bool Replyed { get; set; }

    /// <summary>
    /// 下次回访时间
    /// </summary>
    public DateTime? NextVisitDateUtc { get; set; }

    /// <summary>
    /// 沟通时间
    /// </summary>
    public DateTime? VisitDateUtc { get; set; }

    /// <summary>
    /// 创建时间
    /// </summary>
    public DateTime CreatOnUtc { get; set; }

}
