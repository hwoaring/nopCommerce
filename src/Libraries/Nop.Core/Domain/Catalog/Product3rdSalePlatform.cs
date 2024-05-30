using Nop.Core.Domain.Common;

namespace Nop.Core.Domain.Catalog;

/// <summary>
/// 产品三方平台有那些类型：如 京东，天猫，淘宝，拼多多，抖音等
/// </summary>
public partial class Product3rdSalePlatform : BaseEntity, ISoftDeletedEntity
{
    /// <summary>
    /// 平台名称
    /// </summary>
    public string Name { get; set; }

    /// <summary>
    /// 描述
    /// </summary>
    public string Description { get; set; }

    /// <summary>
    /// 内容，分享链接使用说明等
    /// </summary>
    public string Content { get; set; }

    /// <summary>
    /// 分销链接的正则表达式验证
    /// </summary>
    public string RegularExpression { get; set; }

    /// <summary>
    /// 排序
    /// </summary>
    public int DisplayOrder { get; set; }

    /// <summary>
    /// 平台控制是否启用
    /// </summary>
    public bool Enabled { get; set; }

    /// <summary>
    /// 删除
    /// </summary>
    public bool Deleted { get; set; }
}
