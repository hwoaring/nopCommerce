using Nop.Core.Domain.Common;
using Nop.Core.Domain.Localization;
using Nop.Core.Domain.Seo;

namespace Nop.Core.Domain.Vendors
{
    /// <summary>
    /// 销售员自定义场景（用于统计二维码宣传场景，区分渠道）
    /// </summary>
    public partial class VendorScene : BaseEntity
    {
        /// <summary>
        /// 销售员ID
        /// </summary>
        public int VendorId { get; set; }

        /// <summary>
        /// 场景名称
        /// </summary>
        public string Name { get; set; }
    }
}
