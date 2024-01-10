using Nop.Core.Domain.Common;

namespace Nop.Core.Domain.Forms
{
    /// <summary>
    /// Vendor愿意加入推广的表单
    /// </summary>
    public partial class FormCustomerMapping : BaseEntity
    {
        /// <summary>
        /// 表单ID
        /// </summary>
        public int FormId { get; set; }

        /// <summary>
        /// Vendor选择了Form（只有注册了Vendor才能参与）
        /// </summary>
        public int CustomerId { get; set; }

        /// <summary>
        /// 排序
        /// </summary>
        public int DisplayOrder { get; set; }

        /// <summary>
        /// 创建日期
        /// </summary>
        public DateTime CreatOnUtc { get; set; }

    }
}
