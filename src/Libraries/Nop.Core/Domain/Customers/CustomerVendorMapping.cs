namespace Nop.Core.Domain.Customers
{
    /// <summary>
    /// 用户对供应商的收藏
    /// </summary>
    public partial class CustomerVendorMapping : BaseEntity
    {
        /// <summary>
        /// 用户ID
        /// </summary>
        public int CustomerId { get; set; }

        /// <summary>
        /// 供应商ID
        /// </summary>
        public int VendorId { get; set; }

        /// <summary>
        /// 自定义收藏等级
        /// </summary>
        public int StarLevel { get; set; }

        /// <summary>
        /// 排序
        /// </summary>
        public int DisplayOrder { get; set; }

        /// <summary>
        /// 备注
        /// </summary>
        public string Remark { get; set; }

        /// <summary>
        /// 添加时间
        /// </summary>
        public DateTime CreatedDate { get; set; }
    }
}