namespace Nop.Core.Domain.Catalog
{
    /// <summary>
    /// 产品有哪些第三方平台可销售，如：京东，天猫，淘宝等
    /// </summary>
    public partial class Product3rdSalePlatformMapping : BaseEntity
    {
        /// <summary>
        /// 产品ID
        /// </summary>
        public int ProductId { get; set; }

        /// <summary>
        /// 第三方平台类型ID，京东，淘宝，抖音等
        /// </summary>
        public int Product3rdSalePlatformId { get; set; }

        /// <summary>
        /// 产品Url或店铺url，不会在前台展示，仅用于分销商在对应平台找到产品使用
        /// </summary>
        public string Url { get; set; }

        /// <summary>
        /// 产品对应的三方平台是否有分销链接（如果有，Vendor可以在自己后台设置）
        /// </summary>
        public bool HasShareUrl { get; set; }

        /// <summary>
        /// 由产品供应商自己控制是否启用
        /// </summary>
        public bool Enabled { get; set; }

        /// <summary>
        /// 系统审核通过（不能填写非法链接）
        /// </summary>
        public bool Approved { get; set; }

        /// <summary>
        /// 平台控制是否锁定，默认为不锁定（系统控制，不允许分销或销售本产品）
        /// </summary>
        public bool Locked { get; set; }
    }
}