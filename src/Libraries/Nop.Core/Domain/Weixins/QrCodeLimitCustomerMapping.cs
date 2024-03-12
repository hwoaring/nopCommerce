

namespace Nop.Core.Domain.Weixins;

/// <summary>
/// 永久二维码
/// </summary>
public partial class QrCodeLimitCustomerMapping : BaseEntity
{
    /// <summary>
    /// 绑定到用户Id
    /// </summary>
    public int CustomerId { get; set; }

    /// <summary>
    /// 永久二维码在本系统的ID
    /// </summary>
    public int QrCodeLimitId { get; set; }


    /// <summary>
    /// 绑定人个人备注的二维码名称（可为空）
    /// </summary>
    public string Name { get; set; }

    /// <summary>
    /// 绑定人个人备注的二维码描述（可为空）
    /// </summary>
    public string Description { get; set; }

    /// <summary>
    /// 备用：跳转链接Url
    /// </summary>
    public string Url { get; set; }

    /// <summary>
    /// 绑定开始时间
    /// </summary>
    public DateTime? StartDateOnUtc { get; set; }

    /// <summary>
    /// 绑定结束时间
    /// </summary>
    public DateTime? EndDateOnUtc { get; set; }

    /// <summary>
    /// 是否启用
    /// </summary>
    public bool Enabled { get; set; }
}
