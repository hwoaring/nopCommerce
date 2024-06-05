using Nop.Core.Domain.Common;

namespace Nop.Core.Domain.Orders;

/// <summary>
/// 订单实名信息表
/// </summary>
public partial class OrderRealNames : BaseEntity, ISoftDeletedEntity
{
    /// <summary>
    /// 订单产品ID
    /// </summary>
    public int OrderItemId { get; set; }

    /// <summary>
    /// 证件类型（Common中的IDType）
    /// </summary>
    public int IDTypeId { get; set; }

    /// <summary>
    /// 证件国籍（身份证默认为中国）
    /// </summary>
    public string IDNationality { get; set; }

    /// <summary>
    /// 证件号
    /// </summary>
    public string IDNumber { get; set; }

    /// <summary>
    /// 证件姓名
    /// </summary>
    public string BindIDName { get; set; }

    /// <summary>
    /// 证件电话
    /// </summary>
    public string BindPhone { get; set; }

    /// <summary>
    /// 备注
    /// </summary>
    public string Remark { get; set; }

    /// <summary>
    /// 是否通过系统真实性认证
    /// </summary>
    public bool Certified { get; set; }

    /// <summary>
    /// 删除
    /// </summary>
    public bool Deleted { get; set; }

}
