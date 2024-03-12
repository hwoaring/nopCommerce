using Nop.Core.Domain.Common;

namespace Nop.Core.Domain.RelationShips;

/// <summary>
/// 客户个人关系表（联系人信息表）
/// </summary>
public partial class PersonalRelationShip : BaseEntity, ISoftDeletedEntity
{
    /// <summary>
    /// 所属人ID
    /// </summary>
    public int CustomerId { get; set; }

    /// <summary>
    /// 自己的客户在系统内的Customer id
    /// </summary>
    public int RelationCustomerId { get; set; }

    /// <summary>
    /// 姓名
    /// </summary>
    public string Name { get; set; }

    /// <summary>
    /// 备注
    /// </summary>
    public string Notes { get; set; }

    /// <summary>
    /// 0=未知，1=男，2=女
    /// </summary>
    public int Gender { get; set; }

    /// <summary>
    /// 尊称（礼貌名称，发祝福时候使用尊称）
    /// </summary>
    public string CourtesyName { get; set; }

    /// <summary>
    /// 联系电话
    /// </summary>
    public string PhoneNumber { get; set; }

    /// <summary>
    /// 其他联系电话（会员不可见，由商家设置）
    /// </summary>
    public string OtherPhoneNumbers { get; set; }

    /// <summary>
    /// 地址
    /// </summary>
    public int AddressId { get; set; }

    /// <summary>
    /// 头像ID
    /// </summary>
    public int PictureId { get; set; }

    /// <summary>
    /// 备注，描述
    /// </summary>
    public string Description { get; set; }

    /// <summary>
    /// 公司名称
    /// </summary>
    public string Company { get; set; }
    
    /// <summary>
    /// 职务名称
    /// </summary>
    public string PostName { get; set; }

    /// <summary>
    /// 会员生日（国历）（会员不可见）
    /// </summary>
    public DateTime? BirthOfDateUtc { get; set; }

    /// <summary>
    /// 删除
    /// </summary>
    public bool Deleted { get; set; }
}