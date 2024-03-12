namespace Nop.Core.Domain.Assets;

/// <summary>
/// 会员卡计算周期（单位）
/// </summary>
public enum AssetsCalculationPeriodType
{
    /// <summary>
    /// 不限
    /// </summary>
    None = 0,

    /// <summary>
    /// 周
    /// </summary>
    Weeks = 1,

    /// <summary>
    /// 月
    /// </summary>
    Months = 2,

    /// <summary>
    /// 年
    /// </summary>
    Yeers = 3,
}
