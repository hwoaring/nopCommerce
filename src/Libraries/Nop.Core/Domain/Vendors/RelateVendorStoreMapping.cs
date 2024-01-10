using Nop.Core.Domain.Common;
using Nop.Core.Domain.Localization;
using Nop.Core.Domain.Seo;

namespace Nop.Core.Domain.Vendors
{
    /// <summary>
    /// 相关店铺，适用于连锁店形式
    /// </summary>
    public partial class RelateVendorStoreMapping : BaseEntity
    {
        /// <summary>
        /// 店铺ID
        /// </summary>
        public int VendorStoreId { get; set; }

        /// <summary>
        /// 关联店铺ID
        /// </summary>
        public int RelateVendorStoreId { get; set; }

        /// <summary>
        /// 需要被关联店铺同意（否则添加的关联的店铺无效）
        /// </summary>
        public bool RelateVendorStoreApproved { get; set; }

        /// <summary>
        /// 排序
        /// </summary>
        public int DisplayOrder { get; set; }
    }
}
