using Nop.Core.Domain.Common;

namespace Nop.Core.Domain.Shares;

/// <summary>
/// 分销产品上线申请（当用户想上架新分销产品，提交的申请）
/// 品牌商产品上架申请
/// </summary>
public partial class ShareProductApply : BaseEntity
{
    /// <summary>
    /// 申请人
    /// </summary>
    public int CustomerId { get; set; }

    /// <summary>
    /// 角色：
    /// 0：普通用户
    /// 1：生产厂家
    /// 2：品牌运营商
    /// 3：区域运营商
    /// 4：分销商/门店
    /// </summary>
    public int RoleTypeId { get; set; }

    /// <summary>
    /// 您的称呼
    /// </summary>
    public string Name { get; set; }

    /// <summary>
    /// 对接电话号码
    /// </summary>
    public string PhoneNumber { get; set; }

    /// <summary>
    /// 产品或品牌名称
    /// </summary>
    public string ProductName { get; set; }

    /// <summary>
    /// 产品数量（有几款产品）
    /// </summary>
    public int ProductCount { get; set; }

    /// <summary>
    /// 申请产品简介
    /// </summary>
    public string ProductDescription { get; set; }

    /// <summary>
    /// 回复内容
    /// </summary>
    public string ReplyContent { get; set; }

    /// <summary>
    /// 回复时间
    /// </summary>
    public DateTime? ReplyOnUtc { get; set; }

    /// <summary>
    /// 创建时间
    /// </summary>
    public DateTime CreatOnUtc { get; set; }

}
