using Nop.Core.Domain.Common;

namespace Nop.Core.Domain.AntiFake;

/// <summary>
/// 生产公司可访问人绑定信息
/// </summary>
public partial class AntiFakeCompanyMapping : BaseEntity
{
    /// <summary>
    /// 能够访问人id
    /// </summary>
    public int CustomerId { get; set; }

    /// <summary>
    /// 生产公司ID
    /// </summary>
    public int AntiFakeCompanyId { get; set; }

    /// <summary>
    /// 允许浏览
    /// </summary>
    public bool EnableView { get; set; }

    /// <summary>
    /// 允许添加
    /// </summary>
    public bool EnableAdd { get; set; }

    /// <summary>
    /// 允许修改
    /// </summary>
    public bool EnableModify { get; set; }

    /// <summary>
    /// 允许统计分析
    /// </summary>
    public bool EnableAnalysis { get; set; }

    /// <summary>
    /// 允许删除
    /// </summary>
    public bool EnableDelete { get; set; }
}
