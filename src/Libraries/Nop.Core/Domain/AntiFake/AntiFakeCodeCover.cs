using Nop.Core.Domain.Common;

namespace Nop.Core.Domain.AntiFake;

/// <summary>
/// 防伪瓶盖码，可以用于开盖红包功能
/// </summary>
public partial class AntiFakeCodeCover : BaseEntity, ISoftDeletedEntity
{
    /// <summary>
    /// 快速筛选：印刷批次号，可以为日期数
    /// </summary>
    public long CoverCodeSerialNumber { get; set; }

    /// <summary>
    /// 3：瓶盖码（外）（用隐形码标记，特殊光线照射后显示出来，以3+14位随机码+1位校验码）
    /// 除了防伪，主要用于通过外码方便扫描，便于识别内码，用于内码开盖红包之内的功能
    /// </summary>
    public long CoverOuterCode { get; set; }

    /// <summary>
    /// 4：瓶盖码（内）（内包装盒编码，用激光打印印刷或用特殊显影工艺印刷，以4+14位随机码+1位校验码，一共16位）
    /// 开盖红包之类的功能
    /// </summary>
    public long CoverInnerCode { get; set; }

    /// <summary>
    /// 【由生产公司控制】：绑定的产品（后期使用的时候绑定，避免乱设置产品信息）
    /// </summary>
    public int AntiFakeProductId { get; set; }

    /// <summary>
    /// 绑定到销售ID扫码的时候可以显示购买电话
    /// </summary>
    public int VendorId { get; set; }

    /// <summary>
    /// 【由生产公司控制】:产品信息绑定日期，不可更改，绑定后作为过期时间计算的参考值
    /// </summary>
    public DateTime? BindDateUtc { get; set; }

    /// <summary>
    /// 【由销售公司控制】是否启用
    /// </summary>
    public bool Enabled { get; set; }

    /// <summary>
    /// 【由系统平台控制】是否可用
    /// </summary>
    public bool Available { get; set; }

    /// <summary>
    /// 删除
    /// </summary>
    public bool Deleted { get; set; }
}
