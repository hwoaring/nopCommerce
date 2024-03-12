using Nop.Core.Domain.Common;

namespace Nop.Core.Domain.AntiFake;

/// <summary>
/// 防伪瓶身码，可以用于增加防伪功能
/// </summary>
public partial class AntiFakeBottleCode : BaseEntity, ISoftDeletedEntity
{

    /// <summary>
    /// 绑定产品，（AntiFakeProductId和ItemCode必须有一个有值）
    /// ItemCode有值，表示绑定到具体瓶子上，或进一步防伪，可以通过物流外箱控制那几件或有红包，生产线绑定时比较麻烦
    /// AntiFakeProductId，仅为了展示产品，印刷了内码红包的都可以使用。
    /// </summary>
    public int AntiFakeProductId { get; set; }

    /// <summary>
    /// 绑定防伪二维码小标：AntiFakeCode的外键
    /// 可空值（AntiFakeProductId和ItemCode必须有一个有值）
    /// 仅针对不同瓶子不同瓶身编码情况
    /// </summary>
    public long ItemCode { get; set; }

    /// <summary>
    /// 5：数字码，瓶子编码/标签编码（用激光雕刻在玻璃瓶上或印刷在标签上，或用特殊光线照射印刷，以5+6位随机码+1位校验码，共8位）
    /// </summary>
    public int BottleCode { get; set; }

    /// <summary>
    /// 【由生产公司控制】:产品信息绑定日期，不可更改，绑定后作为过期时间计算的参考值
    /// 生产公司也可作为生产日期使用
    /// </summary>
    public DateTime? BindDateUtc { get; set; }

    /// <summary>
    /// 删除
    /// </summary>
    public bool Deleted { get; set; }
}
