namespace Nop.Core.Domain.Shipping
{
    /// <summary>
    /// Represents a ExpressCompany
    /// </summary>
    public partial class ExpressCompany : BaseEntity
    {
        /// <summary>
        /// 公司名称
        /// </summary>
        public string Name   { get; set; }
        /// <summary>
        /// 代码
        /// </summary>
        public string NameCode { get; set; }
        /// <summary>
        /// 描述
        /// </summary>
        public string Description { get; set; }
        /// <summary>
        /// 查询链接
        /// </summary>
        public string Url { get; set; }
    }
}