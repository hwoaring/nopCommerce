using Nop.Core.Domain.Common;

namespace Nop.Core.Domain.Assets;

/// <summary>
/// 银行
/// </summary>
public partial class AssetsBank : BaseEntity, ISoftDeletedEntity
{
    /// <summary>
    /// 银行名称
    /// </summary>
    public string Name { get; set; }

    /// <summary>
    /// 代码（简码）
    /// </summary>
    public string SimpleCode { get; set; }

    /// <summary>
    /// 数字编码
    /// </summary>
    public int Code { get; set; }

    /// <summary>
    /// 排序
    /// </summary>
    public int DisplayOrder { get; set; }

    /// <summary>
    /// 可用
    /// </summary>
    public bool Available { get; set; }

    /// <summary>
    /// 删除
    /// </summary>
    public bool Deleted { get; set; }
}
