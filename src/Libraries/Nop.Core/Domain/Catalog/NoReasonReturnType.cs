namespace Nop.Core.Domain.Catalog;

/// <summary>
/// 无理由退货类型
/// </summary>
public enum NoReasonReturnType
{
    /// <summary>
    /// 不支持7天无理由退货
    /// </summary>
    UnSupport7Day = 0,
    /// <summary>
    /// 支持7天无理由退货
    /// </summary>
    Support7Day = 7,
    /// <summary>
    /// 支持7天无理由退货(不能是自定义产品)
    /// </summary>
    Support7DayNoCustomize = 8,
    /// <summary>
    /// 支持7天无理由退货(不能破损一次性包装或包装)
    /// </summary>
    Support7DayNoDamage = 9,
    /// <summary>
    /// 支持15天无理由退货
    /// </summary>
    Support15Day = 15,
    /// <summary>
    /// 支持30天无理由退货
    /// </summary>
    Support30Day = 30,
}