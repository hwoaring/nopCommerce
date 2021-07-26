using Nop.Core.Domain.Common;
using Nop.Core.Domain.Localization;
using Nop.Core.Domain.Seo;

namespace Nop.Core.Domain.Vendors
{
    /// <summary>
    /// Vendor 推广的页面统计（浏览量）
    /// </summary>
    public partial class VendorPageAnalyse : BaseEntity
    {
        /// <summary>
        /// Vendor Id
        /// </summary>
        public int VendorId { get; set; }

        /// <summary>
        /// 页面类型（Topic=1,Category=2,Product=3,vendor=4）
        /// </summary>
        public int PageType { get; set; }

        /// <summary>
        /// 页面ID
        /// </summary>
        public int PageId { get; set; }

        /// <summary>
        /// 页面浏览量
        /// </summary>
        public int PageViews { get; set; }
    }
}
