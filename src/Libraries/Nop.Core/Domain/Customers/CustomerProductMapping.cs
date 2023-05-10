namespace Nop.Core.Domain.Customers
{
    /// <summary>
    /// 产品收藏（普通用户对产品的收藏）
    /// </summary>
    public partial class CustomerProductMapping : BaseEntity
    {
        /// <summary>
        /// 用户ID
        /// </summary>
        public int CustomerId { get; set; }

        /// <summary>
        /// 收藏的产品ID
        /// </summary>
        public int ProductId { get; set; }   
    }
}