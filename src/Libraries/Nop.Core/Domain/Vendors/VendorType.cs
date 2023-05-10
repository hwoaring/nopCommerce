namespace Nop.Core.Domain.Vendors
{
    /// <summary>
    /// 供应商类型
    /// </summary>
    public enum VendorType
    {
        /// <summary>
        /// 代理商（区域代理）
        /// </summary>
        Agent = 1,

        /// <summary>
        /// 门市销售（有实体店面）
        /// </summary>
        Store = 2,

        /// <summary>
        /// 无门市的个人渠道销售（无实体店面）
        /// </summary>
        Personal = 3
    }
}
