namespace Nop.Core.Domain.Orders
{
    /// <summary>
    /// 订单发票
    /// </summary>
    public partial class OrderInvoice : BaseEntity
    {
        /// <summary>
        /// 客户id
        /// </summary>
        public int CustomerId { get; set; }

        /// <summary>
        /// 是否公司发票
        /// </summary>
        public bool CompanyInvoice { get; set; }

        /// <summary>
        /// 是否专票
        /// </summary>
        public bool SpecialInvoice { get; set; }

        /// <summary>
        /// 个人名称/公司名称
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 税号：公司税号或个人身份证号码
        /// </summary>
        public string TaxNumber { get; set; }

        /// <summary>
        /// 银行账号
        /// </summary>
        public string BankAccount { get; set; }

        /// <summary>
        /// 地址
        /// </summary>
        public string Address { get; set; }

        /// <summary>
        /// 联系电话
        /// </summary>
        public string Phone { get; set; }

        /// <summary>
        /// 创建时间
        /// </summary>
        public DateTime CreatedOnUtc { get; set; }
    }
}
