using Nop.Core.Domain.Common;
using Nop.Core.Domain.Localization;
using Nop.Core.Domain.Seo;

namespace Nop.Core.Domain.Vendors
{
    /// <summary>
    /// 销售选中产品分组展示映射（便于和朋友圈分组隐私对应）
    /// </summary>
    public partial class VendorProductGroupSellProduct : BaseEntity
    {
        /// <summary>
        /// 分组ID
        /// </summary>
        public int VendorProductGroupId { get; set; }

        /// <summary>
        /// 销售代理的产品ID
        /// </summary>
        public int VendorSaleProductId { get; set; }

        /// <summary>
        /// 排序
        /// </summary>
        public int DisplayOrder { get; set; }
    }
}
