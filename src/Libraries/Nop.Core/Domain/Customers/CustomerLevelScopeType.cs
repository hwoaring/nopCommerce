namespace Nop.Core.Domain.Customers;

/// <summary>
/// 用户等级范围类型
/// </summary>
public enum CustomerLevelScopeType
{
    /// <summary>
    /// 全局用户等级
    /// </summary>
    GlobalCustomerLevel = 0,

    /// <summary>
    /// 店铺用户等级
    /// </summary>
    StoreCustomerLevel = 1,

    /// <summary>
    /// 代理商/分销商店铺等级
    /// </summary>
    VendorStoreCustomerLevel = 2
}