
namespace Nop.Core.Domain.SMS;

/// <summary>
/// 供分销人员选择的公共组合
/// </summary>
public partial class SmsSendBlackList : BaseEntity
{
    /// <summary>
    /// 代理商id
    /// </summary>
    public int VendorId { get; set; }

    /// <summary>
    /// 黑名单（电话号码）
    /// </summary>
    public string PhoneNumber { get; set; }

    /// <summary>
    /// 是否系统黑名单（否则未Vendor定义的黑名单）
    /// </summary>
    public bool IsSystem { get; set; }

    /// <summary>
    /// 是否退订客户
    /// </summary>
    public bool UnSubscribed { get; set; }

    /// <summary>
    /// 创建时间
    /// </summary>
    public DateTime CreatedOnUtc { get; set; }
}
