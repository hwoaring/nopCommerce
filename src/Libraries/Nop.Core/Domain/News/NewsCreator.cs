using Nop.Core.Domain.Common;

namespace Nop.Core.Domain.News;

/// <summary>
/// 新闻创作者
/// </summary>
public partial class NewsCreator : BaseEntity, ISoftDeletedEntity
{
    /// <summary>
    /// 创作者ID
    /// </summary>
    public int CustomerId { get; set; }

    /// <summary>
    /// 创作者昵称
    /// </summary>
    public string NickName { get; set; }

    /// <summary>
    /// 创作者等级（0-10）等级为0时，不允许发布
    /// </summary>
    public int Level { get; set; }

    /// <summary>
    /// 活跃等级（0-10）
    /// </summary>
    public int ActiveLevel { get; set; }

    /// <summary>
    /// 是否审核通过
    /// </summary>
    public bool IsApproved { get; set; }

    /// <summary>
    /// 删除
    /// </summary>
    public bool Deleted { get; set; }
}