namespace Nop.Core.Domain.Catalog
{
    /// <summary>
    /// Represents the product sorting
    /// </summary>
    public enum ProductSortingEnum
    {
        /// <summary>
        /// 位置 (显示顺序)
        /// </summary>
        Position = 0,

        /// <summary>
        /// 名称: A to Z
        /// </summary>
        NameAsc = 5,

        /// <summary>
        /// 名称: Z to A
        /// </summary>
        NameDesc = 6,

        /// <summary>
        /// 价格：从低到高
        /// </summary>
        PriceAsc = 10,

        /// <summary>
        /// 价格：从高到低
        /// </summary>
        PriceDesc = 11,

        /// <summary>
        /// 日期：创建日期
        /// </summary>
        CreatedOn = 15,
        /// <summary>
        /// 销量：从低到高
        /// </summary>
        SalesAsc = 20,
        /// <summary>
        /// 销量：从高到低
        /// </summary>
        SalesDesc = 21,
        /// <summary>
        /// 关注量：从低到高
        /// </summary>
        FocusAsc = 30,
        /// <summary>
        /// 关注量：从高到低
        /// </summary>
        FocusDesc = 31,
    }
}