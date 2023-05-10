namespace Nop.Core.Domain.Vendors
{
    /// <summary>
    /// 代理商（供应商）对产品的代理选择（表示选择到自己的代理库中，并不表示该产品供应商属于该Vendor）
    /// </summary>
    public partial class VendorProductMapping : BaseEntity
    {
        /// <summary>
        /// 供应商ID
        /// </summary>
        public int VendorId { get; set; }

        /// <summary>
        /// 选择要代理的产品ID
        /// </summary>
        public int ProductId { get; set; }

        /// <summary>
        /// 代理商自定义商品分类
        /// </summary>
        public int VendorCategoryId { get; set; }

        /// <summary>
        /// 自定义销售价格
        /// </summary>
        public decimal Price { get; set; }

        /// <summary>
        /// 库存数量
        /// </summary>
        public int StockNumber { get; set; }

        /// <summary>
        /// 自定义标星等级
        /// </summary>
        public int StarLevel { get; set; }

        /// <summary>
        /// 自定义展示排序
        /// </summary>
        public int DisplayOrder { get; set; }

        /// <summary>
        /// 锁定
        /// </summary>
        public bool Locked { get; set; }
    }
}