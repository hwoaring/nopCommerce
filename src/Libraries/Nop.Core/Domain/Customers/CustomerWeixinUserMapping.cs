namespace Nop.Core.Domain.Customers
{
    /// <summary>
    /// Represents a customer-微信用户 mapping class
    /// </summary>
    public partial class CustomerWeixinUserMapping : BaseEntity
    {
        /// <summary>
        /// 访客ID
        /// </summary>
        public int CustomerId { get; set; }

        /// <summary>
        /// 微信用户信息ID
        /// </summary>
        public int WeixinUserId { get; set; }
    }
}