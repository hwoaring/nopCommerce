namespace Nop.Core.Domain.Discounts
{
    /// <summary>
    /// Represents a discount type
    /// </summary>
    public enum DiscountType
    {
        /// <summary>
        /// Assigned to order total 订单总计
        /// </summary>
        AssignedToOrderTotal = 1,

        /// <summary>
        /// Assigned to products (SKUs) 产品
        /// </summary>
        AssignedToSkus = 2,

        /// <summary>
        /// Assigned to categories (all products in a category) 分配给类别
        /// </summary>
        AssignedToCategories = 5,

        /// <summary>
        /// Assigned to manufacturers (all products of a manufacturer) 分配给制造商
        /// </summary>
        AssignedToManufacturers = 6,

        /// <summary>
        /// Assigned to shipping 分配给运输
        /// </summary>
        AssignedToShipping = 10,

        /// <summary>
        /// Assigned to order subtotal 分配给订单小计
        /// </summary>
        AssignedToOrderSubTotal = 20
    }
}
