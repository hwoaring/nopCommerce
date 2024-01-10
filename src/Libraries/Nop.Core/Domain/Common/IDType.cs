namespace Nop.Core.Domain.Common
{
    /// <summary>
    /// 证件类型
    /// </summary>
    public enum IDType
    {
        /// <summary>
        /// 未知
        /// </summary>
        System = 0,

        /// <summary>
        /// 身份证
        /// </summary>
        IDcard = 1,

        /// <summary>
        /// 护照
        /// </summary>
        Passport = 2,

        /// <summary>
        /// 港澳通行证
        /// </summary>
        HKPassport = 3,
    }
}