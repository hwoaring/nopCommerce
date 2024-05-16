using Nop.Core.Domain.Common;

namespace Nop.Core.Domain.AntiFake;

/// <summary>
/// 产品信息页面相关新闻
/// </summary>
public partial class AntiFakeProductRelatedNews : BaseEntity
{
    /// <summary>
    /// 产品ID
    /// </summary>
    public int AntiFakeProductId { get; set; }

    /// <summary>
    /// 新闻ID
    /// </summary>
    public int NewsItemId { get; set; }

    /// <summary>
    /// 排序
    /// </summary>
    public int DisplayOrder { get; set; }

    /// <summary>
    /// 展示
    /// </summary>
    public bool Displayed { get; set; }
}
