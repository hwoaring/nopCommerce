using Nop.Core.Configuration;

namespace Nop.Core.Domain.Common;

/// <summary>
/// Common settings
/// </summary>
public partial class SearchTermSettings : ISettings
{
    /// <summary>
    /// 单人最大记录数量
    /// </summary>
    public int MaxRecordCount { get; set; }

    /// <summary>
    /// 记录保存天数
    /// </summary>
    public int SaveDays { get; set; }
}