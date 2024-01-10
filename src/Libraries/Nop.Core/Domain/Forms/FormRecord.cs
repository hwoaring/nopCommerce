using Nop.Core.Domain.Common;

namespace Nop.Core.Domain.Forms
{
    /// <summary>
    /// 表单记录
    /// </summary>
    public partial class FormRecord : BaseEntity, ISoftDeletedEntity
    {
        /// <summary>
        /// 表单ID
        /// </summary>
        public int FormId { get; set; }

        /// <summary>
        /// 表单登记人ID
        /// </summary>
        public int CustomerId { get; set; }

        /// <summary>
        /// 推荐人ID（如果是Vendor，可以查看自己的推荐表单）
        /// </summary>
        public int ReferrerCustomerId { get; set; }

        /// <summary>
        /// 姓名
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 电话
        /// </summary>
        public string Phone { get; set; }

        /// <summary>
        /// 年龄
        /// </summary>
        public int Age { get; set; }

        /// <summary>
        /// 性别（0=未知，1=男，2=女）
        /// </summary>
        public int Sex { get; set; }

        /// <summary>
        /// 人数（或者用于其他计数统计）
        /// </summary>
        public int Count { get; set; }

        /// <summary>
        /// 地址
        /// </summary>
        public string Address { get; set; }

        /// <summary>
        /// 备注（客人备注）
        /// </summary>
        public string Remark { get; set; }

        /// <summary>
        /// 系统后台备注
        /// </summary>
        public string SystemRemark { get; set; }

        /// <summary>
        /// 日期选择
        /// </summary>
        public DateTime? CustomerDateTime { get; set; }

        /// <summary>
        /// 其他值（其他表单值）
        /// </summary>
        public string ExtendValues { get; set; }

        /// <summary>
        /// 创建日期
        /// </summary>
        public DateTime CreatOnUtc { get; set; }

        /// <summary>
        /// 删除
        /// </summary>
        public bool Deleted { get; set; }
    }
}
