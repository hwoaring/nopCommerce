using Nop.Core.Domain.Common;

namespace Nop.Core.Domain.Forms
{
    /// <summary>
    /// 表单扩展记录列
    /// </summary>
    public partial class FormExtendValues : BaseEntity
    {
        /// <summary>
        /// 表单ID
        /// </summary>
        public int FormId { get; set; }

        /// <summary>
        /// 扩展值名称
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 扩展值类型
        /// </summary>
        public int FormControlTypeId { get; set; }

        /// <summary>
        /// 默认值
        /// </summary>
        public string DefaultValue { get; set; }

        /// <summary>
        /// 扩展值类型（单选或多选，键值对格式（数值=文本，多项以分号隔开）如：0=未知;1=男;2=女）
        /// </summary>
        public string Value { get; set; }

        /// <summary>
        /// 最大长度
        /// </summary>
        public int MaxLength { get; set; }

        /// <summary>
        /// 正则表达式
        /// </summary>
        public string RegularExpression { get; set; }

        /// <summary>
        /// 排序
        /// </summary>
        public int DisplayOrder { get; set; }

        /// <summary>
        /// 是否已使用（确认表单确认使用后不能够删除，确认前可以删除）
        /// </summary>
        public bool Enabled { get; set; }

        /// <summary>
        /// 启用（隐藏和展示，确认表单后不能够删除，确认前可以删除）
        /// </summary>
        public bool AllowDisplaied { get; set; }


    }
}
