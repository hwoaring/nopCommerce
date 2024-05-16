using Nop.Core.Domain.Common;

namespace Nop.Core.Domain.AntiFake;

/// <summary>
/// 防伪码（瓶身），可以用于增加防伪功能
/// </summary>
public partial class AntiFakeCodeBottle : BaseEntity, ISoftDeletedEntity
{
    /// <summary>
    /// 5：数字码（5开头），瓶子编码/标签编码（用激光雕刻在玻璃瓶上或印刷在标签上，或用特殊光线照射印刷，以5+6位随机码+1位校验码，共8位）
    /// </summary>
    public int BottleCode { get; set; }

    /// <summary>
    /// 【由生产公司控制】：绑定的产品（后期使用的时候绑定，避免乱设置产品信息）
    /// </summary>
    public int AntiFakeProductId { get; set; }

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
