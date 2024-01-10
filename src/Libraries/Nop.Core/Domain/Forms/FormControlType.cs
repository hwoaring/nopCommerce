namespace Nop.Core.Domain.Forms
{
    /// <summary>
    /// 表单控件类型
    /// </summary>
    public enum FormControlType
    {
        /// <summary>
        /// 下拉
        /// </summary>
        DropdownList = 1,

        /// <summary>
        /// 多项单选框
        /// </summary>
        RadioList = 2,

        /// <summary>
        /// 多项复选框
        /// </summary>
        Checkboxes = 3,

        /// <summary>
        /// 单行文本
        /// </summary>
        TextBox = 4,

        /// <summary>
        /// 密码文本
        /// </summary>
        Password = 5,

        /// <summary>
        /// 多行文本
        /// </summary>
        MultilineTextbox = 10,

        /// <summary>
        /// 文本区域框
        /// </summary>
        Textarea = 11,

        /// <summary>
        /// 日期
        /// </summary>
        Datepicker = 20,

        /// <summary>
        /// 文件上传
        /// </summary>
        FileUpload = 30,

        /// <summary>
        /// 区域选择（省市区）
        /// </summary>
        Regionpicker = 40,

        /// <summary>
        /// 只读复选框
        /// </summary>
        ReadonlyCheckboxes = 50
    }
}