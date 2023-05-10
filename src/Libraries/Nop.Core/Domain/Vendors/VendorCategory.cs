namespace Nop.Core.Domain.Vendors
{
    /// <summary>
    /// 供应商自定义商品分类
    /// </summary>
    public partial class VendorCategory : BaseEntity
    {
        /// <summary>
        /// 供应商ID
        /// </summary>
        public int VendorId { get; set; }

        /// <summary>
        /// 类别名称
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 排序
        /// </summary>
        public int DisplayOrder { get; set; }
    }
}
