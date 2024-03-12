namespace Nop.Core.Domain.Assets;

/// <summary>
/// 资产状态
/// </summary>
public enum AssetsStatus
{
    /// <summary>
    /// 待审核
    /// </summary>
    Pending = 0,

    /// <summary>
    /// 有效
    /// </summary>
    Valid = 10,

    /// <summary>
    /// 无效
    /// </summary>
    Invalid = 20,


}
