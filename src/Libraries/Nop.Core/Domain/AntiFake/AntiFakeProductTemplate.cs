namespace Nop.Core.Domain.AntiFake;

/// <summary>
/// 产品页面模板
/// </summary>
public partial class AntiFakeProductTemplate : BaseEntity
{
    /// <summary>
    /// 名称
    /// </summary>
    public string Name { get; set; }

    /// <summary>
    /// 路径
    /// </summary>
    public string ViewPath { get; set; }

    /// <summary>
    /// 排序
    /// </summary>
    public int DisplayOrder { get; set; }
}
