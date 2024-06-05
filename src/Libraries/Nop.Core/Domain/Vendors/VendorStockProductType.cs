namespace Nop.Core.Domain.Vendors;

/// <summary>
/// 产品类型（成品，半成品，非卖品）
/// </summary>
public enum VendorStockProductType
{
    /// <summary>
    /// 成品
    /// </summary>
    Finished = 1,

    /// <summary>
    /// 半成品
    /// </summary>
    SemiFinished = 2,

    /// <summary>
    /// 非卖品
    /// </summary>
    NonSaleable = 3,
}
