namespace Nop.Core.Domain.Orders;

/// <summary>
/// 联系电话黑名单（黑名单用户不能下单）
/// </summary>
public partial class OrderPhoneBlackList : BaseEntity
{
    /// <summary>
    /// 电话号码
    /// </summary>
    public string PhoneNumber { get; set; }

    /// <summary>
    /// 产品ID=0时，禁止所有需要留联系电话的产品下单
    /// </summary>
    public int ProductId { get; set; }

    /// <summary>
    /// 备注
    /// </summary>
    public string Notes { get; set; }

}
