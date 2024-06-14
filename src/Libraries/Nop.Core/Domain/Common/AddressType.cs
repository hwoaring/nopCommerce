namespace Nop.Core.Domain.Common;

/// <summary>
/// 地址类型：普通客户信息，提货地址，邮寄地址，代理商地址，代理商店铺地址，库房地址，会员地址
/// </summary>
public enum AddressType
{
    /// <summary>
    /// 普通客户信息
    /// </summary>
    Customer = 0,

    /// <summary>
    /// 邮寄地址
    /// </summary>
    Shipping = 1,

    /// <summary>
    /// 提货地址
    /// </summary>
    Pickup = 2,

    /// <summary>
    /// 库房地址
    /// </summary>
    Warehouse = 3,


    /// <summary>
    /// 代理商地址
    /// </summary>
    Vendor = 4,


    /// <summary>
    /// 代理商店铺地址
    /// </summary>
    VendorStore = 5,

    /// <summary>
    /// 会员地址
    /// </summary>
    Member = 6,


}
