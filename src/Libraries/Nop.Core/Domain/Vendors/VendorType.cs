namespace Nop.Core.Domain.Vendors
{
    /// <summary>
    /// 供应商类型
    /// </summary>
    public enum VendorType
    {
        /// <summary>
        /// 无门市的个人渠道销售
        /// </summary>
        Personal = 10,


        /// <summary>
        /// 普通终端门店：如餐饮，酒店
        /// </summary>
        Terminal = 20,

        /// <summary>
        /// 普通门市销售，烟酒店（有实体店面）
        /// </summary>
        Store = 30,

        /// <summary>
        /// 代理商（区域代理）
        /// </summary>
        Agent = 40,
    }
}
