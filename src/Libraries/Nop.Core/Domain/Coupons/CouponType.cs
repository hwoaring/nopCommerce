namespace Nop.Core.Domain.Coupons
{
    /// <summary>
    /// 优惠券类型
    /// </summary>
    public enum CouponType
    {
        /// <summary>
        /// 订单总计
        /// </summary>
        AssignedToOrderTotal = 1,

        /// <summary>
        /// 产品
        /// </summary>
        AssignedToSkus = 2,

        /// <summary>
        /// 分配给类别
        /// </summary>
        AssignedToCategories = 5,

        /// <summary>
        /// 分配给制造商
        /// </summary>
        AssignedToManufacturers = 6,

        /// <summary>
        /// 分配给运输
        /// </summary>
        AssignedToShipping = 10,

        /// <summary>
        /// 分配给订单小计
        /// </summary>
        AssignedToOrderSubTotal = 20,

        /// <summary>
        /// 分配给供应商
        /// </summary>
        AssignedToVendor = 30,
    }
}
