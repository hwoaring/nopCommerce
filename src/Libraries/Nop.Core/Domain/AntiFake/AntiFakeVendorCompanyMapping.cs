using Nop.Core.Domain.Common;

namespace Nop.Core.Domain.AntiFake
{
    /// <summary>
    /// 销售公司可访问人ID
    /// </summary>
    public partial class AntiFakeVendorCompanyMapping : BaseEntity
    {
        /// <summary>
        /// 能够访问人id
        /// </summary>
        public int CustomerId { get; set; }

        /// <summary>
        /// 销售公司ID
        /// </summary>
        public int AntiFakeVendorCompanyId { get; set; }

        /// <summary>
        /// 允许浏览
        /// </summary>
        public bool EnableView { get; set; }

        /// <summary>
        /// 允许添加
        /// </summary>
        public bool EnableAdd { get; set; }

        /// <summary>
        /// 允许修改
        /// </summary>
        public bool EnableModify { get; set; }

        /// <summary>
        /// 允许统计分析
        /// </summary>
        public bool EnableAnalysis { get; set; }

        /// <summary>
        /// 允许删除
        /// </summary>
        public bool EnableDelete { get; set; }
    }
}
