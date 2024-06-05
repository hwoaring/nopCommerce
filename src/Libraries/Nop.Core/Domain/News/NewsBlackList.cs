
namespace Nop.Core.Domain.News;

/// <summary>
/// 新闻黑名单（不对黑名单人展示：显示提醒 网络错误，请重试）
/// </summary>
public partial class NewsBlackList : BaseEntity
{
    /// <summary>
    /// 用户ID
    /// </summary>
    public int CustomerId { get; set; }

    /// <summary>
    /// 禁止所有新闻展示(不在这里设置)
    /// </summary>
    public int NewsItemId { get; set; }

    /// <summary>
    /// 备注
    /// </summary>
    public string Notes { get; set; }


}
