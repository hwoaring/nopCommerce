﻿namespace Nop.Core.Domain.Messages
{
    /// <summary>
    /// Represents an attribute control type
    /// </summary>
    public enum MessageServiceType
    {
        /// <summary>
        /// 阿里云
        /// </summary>
        Aliyun = 1,

        /// <summary>
        /// 腾讯云
        /// </summary>
        Tencent = 2,

        /// <summary>
        /// Checkboxes
        /// </summary>
        Checkboxes = 3,

        /// <summary>
        /// TextBox
        /// </summary>
        TextBox = 4,

        /// <summary>
        /// Multiline textbox
        /// </summary>
        MultilineTextbox = 10,

        /// <summary>
        /// Datepicker
        /// </summary>
        Datepicker = 20,

        /// <summary>
        /// File upload control
        /// </summary>
        FileUpload = 30,

        /// <summary>
        /// Color squares
        /// </summary>
        ColorSquares = 40,

        /// <summary>
        /// Image squares
        /// </summary>
        ImageSquares = 45,

        /// <summary>
        /// Read-only checkboxes
        /// </summary>
        ReadonlyCheckboxes = 50
    }
}