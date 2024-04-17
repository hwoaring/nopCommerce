using System.Reflection.Emit;

namespace Nop.Core.Domain.Orders;

/// <summary>
/// 订单下单场景信息
/// </summary>
public partial class OrderScene : BaseEntity
{
    /// <summary>
    /// 订单ID
    /// </summary>
    public int OrderId { get; set; }

    /// <summary>
    /// 是。用户的客户端IP，支持IPv4和IPv6两种格式的IP地址
    /// </summary>
    public string PayerClientIp { get; set; }

    /// <summary>
    /// 否。商户端设备号（门店号或收银设备ID）
    /// </summary>
    public string DeviceId { get; set; }

    /// <summary>
    /// 是。商户侧门店编号（和本系统的storeId 不同）
    /// </summary>
    public string StoreId { get; set; }

    /// <summary>
    /// 否。商户侧门店名称
    /// </summary>
    public string StoreName { get; set; }

    /// <summary>
    /// 否.地区编码，详细请见省市区编号对照表
    /// </summary>
    public string AreaCode { get; set; }

    /// <summary>
    /// 否。详细的商户门店地址
    /// </summary>
    public string Address { get; set; }

    /// <summary>
    /// 是.场景类型
    /// </summary>
    public string SceneType { get; set; }

    /// <summary>
    /// 否。应用名称
    /// </summary>
    public string AppName { get; set; }

    /// <summary>
    /// 否 .网站URL
    /// </summary>
    public string AppUrl { get; set; }

    /// <summary>
    /// 否。iOS平台BundleID
    /// </summary>
    public string BundleId { get; set; }

    /// <summary>
    /// 否。Android平台PackageName
    /// </summary>
    public string PackageName { get; set; }

}
