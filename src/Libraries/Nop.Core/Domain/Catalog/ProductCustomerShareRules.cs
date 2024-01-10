using Nop.Core.Domain.Localization;

namespace Nop.Core.Domain.Catalog
{
    /// <summary>
    /// 不同等级客户的广告费最大使用数；等级0不能使用广告费
    /// </summary>
    public partial class ProductCustomerShareRules : BaseEntity
    {
        /// <summary>
        /// 产品ID
        /// </summary>
        public int ProductId { get; set; }

        /// <summary>
        /// 等级0最大可用广告金额（等级0为普通用户）
        /// </summary>
        public decimal LevelZeroAmount { get; set; }

        /// <summary>
        /// 等级1最大可用广告金额
        /// </summary>
        public decimal LevelOneAmount { get; set; }

        /// <summary>
        /// 等级2最大可用广告金额
        /// </summary>
        public decimal LevelTwoAmount { get; set; }

        /// <summary>
        /// 等级3最大可用广告金额
        /// </summary>
        public decimal LevelThreeAmount { get; set; }

        /// <summary>
        /// 等级4最大可用广告金额
        /// </summary>
        public decimal LevelFourAmount { get; set; }

        /// <summary>
        /// 等级5最大可用广告金额
        /// </summary>
        public decimal LevelFiveAmount { get; set; }

        /// <summary>
        /// 等级6最大可用广告金额
        /// </summary>
        public decimal LevelSixAmount { get; set; }

        /// <summary>
        /// 等级7最大可用广告金额
        /// </summary>
        public decimal LevelSevenAmount { get; set; }

        /// <summary>
        /// 等级8最大可用广告金额
        /// </summary>
        public decimal LevelEightAmount { get; set; }

        /// <summary>
        /// 等级9最大可用广告金额
        /// </summary>
        public decimal LevelNineAmount { get; set; }

        /// <summary>
        /// 等级10最大可用广告金额
        /// </summary>
        public decimal LevelTenAmount { get; set; }
    }
}
