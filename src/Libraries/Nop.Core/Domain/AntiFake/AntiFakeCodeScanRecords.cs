using Nop.Core.Domain.Common;

namespace Nop.Core.Domain.AntiFake;

/// <summary>
/// 防伪内码（小码）扫描记录
/// </summary>
public partial class AntiFakeCodeScanRecords : BaseEntity
{
    /// <summary>
    /// 8：密码内包装密码二维码或掩盖的16位数字（8+14位随机码+1位校验码，一共16位密码，）
    /// 二维码链接加上特殊标识参数，系统识别后马上跳转或更改url去掉特殊标识，防止别人通过链接生成二维码
    /// </summary>
    public long Password { get; set; }

    /// <summary>
    /// 累计扫描次数
    /// </summary>
    public int Count { get; set; }

    /// <summary>
    /// 扫描人ID（首次扫码）
    /// </summary>
    public int CustomerId { get; set; }

    /// <summary>
    /// 地址的区划代码ID（首次扫码）
    /// </summary>
    public int RegionCodeId { get; set; }

    /// <summary>
    /// 经度值（首次扫码）
    /// </summary>
    public decimal? Longitude { get; set; }

    /// <summary>
    /// 纬度值（首次扫码）
    /// </summary>
    public decimal? Latitude { get; set; }

    /// <summary>
    /// 本次扫码时间
    /// </summary>
    public DateTime UpdateDateOnUtc { get; set; }

    /// <summary>
    /// 上一次时间（最新扫码时间）
    /// </summary>
    public DateTime LastDateOnUtc { get; set; }

    /// <summary>
    /// 创建时间（首次扫码）
    /// </summary>
    public DateTime CreatOnUtc { get; set; }
}
