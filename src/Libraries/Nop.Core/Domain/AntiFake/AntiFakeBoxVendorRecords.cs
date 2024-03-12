using Nop.Core.Domain.Common;

namespace Nop.Core.Domain.AntiFake;

/// <summary>
/// 产品销售员绑定信息更新记录（产品跟踪）
/// </summary>
public partial class AntiFakeBoxVendorRecords : BaseEntity
{
    /// <summary>
    /// 1、大码/箱码/物流码（外包装）（以1开头+6位生产公司条码编号+8位随机码+1位校验码）
    /// 二维码链接加上特殊标识参数，系统识别后马上跳转或更改url去掉特殊标识，防止别人通过链接生成二维码
    /// </summary>
    public long BoxCode { get; set; }

    /// <summary>
    /// 成功转移次数记录（防止恶意刷数据）
    /// Content中可以只记录最近10条，20条等信息
    /// </summary>
    public int TransferCount { get; set; }

    /// <summary>
    /// 当前用有人VendorId
    /// </summary>
    public int CurrentVendorId { get; set; }

    /// <summary>
    /// 申请转移的VendorId（更新记录后，申请人ID设置为0，更新当前用有人Id为申请人ID，更新跟踪记录）
    /// </summary>
    public int ApplyVendorId { get; set; }

    /// <summary>
    /// 跟踪记录（字符串格式为：原拥有人ID-现拥有人ID-年月日，以逗号分割开每个记录值）
    /// 如：2-14-20240201,14-35-20240218
    /// </summary>
    public string Content { get; set; }

    /// <summary>
    /// 最新申请时间
    /// </summary>
    public DateTime UpdateOnUtc { get; set; }
}
