namespace Nop.Core.Domain.Weixins
{
    /// <summary>
    /// Represents the 官方二维码类型 type formatting enumeration
    /// </summary>
    public enum QrcodeActionNameType
    {
        /// <summary>
        /// 为临时的整型参数值
        /// </summary>
        QR_SCENE = 1,

        /// <summary>
        /// 为临时的字符串参数值
        /// </summary>
        QR_STR_SCENE = 2,

        /// <summary>
        /// 为永久的整型参数值
        /// </summary>
        QR_LIMIT_SCENE = 3,

        /// <summary>
        /// 为永久的字符串参数值
        /// </summary>
        QR_LIMIT_STR_SCENE = 4
    }
}
