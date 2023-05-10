namespace Nop.Core.Domain.SecureCode
{
    /// <summary>
    /// 区域代理商类型
    /// </summary>
    public enum SecureCodeRegionType
    {
        /// <summary>
        /// 代理
        /// </summary>
        Agent = 1,

        /// <summary>
        /// 门市
        /// </summary>
        Store = 2,

        /// <summary>
        /// 无门市的个人渠道
        /// </summary>
        Personal = 3
    }
}
