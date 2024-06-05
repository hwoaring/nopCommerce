using Nop.Core.Domain.Common;

namespace Nop.Core.Domain.Orders;

/// <summary>
/// 实名信息黑名单（黑名单用户不能下单）
/// </summary>
public partial class OrderIDBlackList : BaseEntity
{
    /// <summary>
    /// 证件类型（Common中的IDType）
    /// </summary>
    public int IDTypeId { get; set; }

    /// <summary>
    /// 证件号（以查询的证件号为准）
    /// </summary>
    public string IDNumber { get; set; }

    /// <summary>
    /// 产品ID=0时，禁止所有需要实名认证的产品下单
    /// </summary>
    public int ProductId { get; set; }

    /// <summary>
    /// 证件姓名（备用）
    /// </summary>
    public string IDName { get; set; }

    /// <summary>
    /// 备注
    /// </summary>
    public string Notes { get; set; }


}
