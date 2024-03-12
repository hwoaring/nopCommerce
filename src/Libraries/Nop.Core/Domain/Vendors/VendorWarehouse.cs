using Nop.Core.Domain.Common;
using Nop.Core.Domain.Localization;
using Nop.Core.Domain.Seo;

namespace Nop.Core.Domain.Vendors;

/// <summary>
/// 代理商仓库
/// </summary>
public partial class VendorWarehouse : BaseEntity
{
    /// <summary>
    /// 代理ID
    /// </summary>
    public int VendorId { get; set; }

    /// <summary>
    /// 地址的区划代码
    /// </summary>
    public int ChinaRegionCode { get; set; }

    /// <summary>
    /// 自提电话联系
    /// </summary>
    public string SelfPickupPhone { get; set; }

    /// <summary>
    /// 经度值
    /// </summary>
    public decimal? Longitude { get; set; }

    /// <summary>
    /// 纬度值
    /// </summary>
    public decimal? Latitude { get; set; }

    /// <summary>
    /// 线下门店提货地址（否则为个人没有门店的提货地址）
    /// </summary>
    public bool VendorStoreAddress { get; set; }

    /// <summary>
    /// 是否支持自提
    /// </summary>
    public bool SupportSelfPickup { get; set; }

    /// <summary>
    /// 是否地图展示出来（客户搜索时候可以展示位置坐标点）
    /// </summary>
    public bool DisplayMap { get; set; }

    /// <summary>
    /// 是否展示电话
    /// </summary>
    public bool DisplayPhone { get; set; }
}
