using Nop.Core.Configuration;

namespace Nop.Core.Domain.AntiFake;

/// <summary>
/// 防伪设置
/// </summary>
public partial class AntiFakeSettings : ISettings
{
    /// <summary>
    /// 防伪查询域名：如anti.xxxx.cn/
    /// </summary>
    public string AntiFakeDomain { get; set; }

    /// <summary>
    /// 防伪产品页域名
    /// </summary>
    public string AntiFakeProductDomain { get; set; }

    /// <summary>
    /// 防伪代理查询域名
    /// </summary>
    public string AntiFakeVendorDomain { get; set; }

    /// <summary>
    /// 扫码是否记录经纬度
    /// </summary>
    public bool RecordLongitude { get; set; }
}