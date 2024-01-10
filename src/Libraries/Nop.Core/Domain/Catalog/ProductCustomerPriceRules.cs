using Nop.Core.Domain.Localization;

namespace Nop.Core.Domain.Catalog
{
    /// <summary>
    /// 不同等级客户的【购买价格】；等级0不能购买任何产品
    /// </summary>
    public partial class ProductCustomerPriceRules : BaseEntity
    {
        /// <summary>
        /// 产品ID
        /// </summary>
        public int ProductId { get; set; }

        /// <summary>
        /// 等级0价格使用百分比（等级0为普通用户）
        /// </summary>
        public bool PercentageRulesLevelZero { get; set; }

        /// <summary>
        /// 等级0价格（等级0为普通用户）
        /// </summary>
        public decimal LevelZeroAmount { get; set; }

        /// <summary>
        /// 等级1价格使用百分比
        /// </summary>
        public bool PercentageRulesLevelOne { get; set; }

        /// <summary>
        /// 等级1价格
        /// </summary>
        public decimal LevelOneAmount { get; set; }

        /// <summary>
        /// 等级2价格使用百分比
        /// </summary>
        public bool PercentageRulesLevelTwo { get; set; }

        /// <summary>
        /// 等级2价格
        /// </summary>
        public decimal LevelTwoAmount { get; set; }

        /// <summary>
        /// 等级3价格使用百分比
        /// </summary>
        public bool PercentageRulesLevelThree { get; set; }

        /// <summary>
        /// 等级3价格
        /// </summary>
        public decimal LevelThreeAmount { get; set; }

        /// <summary>
        /// 等级4价格使用百分比
        /// </summary>
        public bool PercentageRulesLevelFour { get; set; }

        /// <summary>
        /// 等级4价格
        /// </summary>
        public decimal LevelFourAmount { get; set; }

        /// <summary>
        /// 等级5价格使用百分比
        /// </summary>
        public bool PercentageRulesLevelFive { get; set; }

        /// <summary>
        /// 等级5价格
        /// </summary>
        public decimal LevelFiveAmount { get; set; }

        /// <summary>
        /// 等级6价格使用百分比
        /// </summary>
        public bool PercentageRulesLevelSix { get; set; }

        /// <summary>
        /// 等级6价格
        /// </summary>
        public decimal LevelSixAmount { get; set; }

        /// <summary>
        /// 等级7价格使用百分比
        /// </summary>
        public bool PercentageRulesLevelSeven { get; set; }

        /// <summary>
        /// 等级7价格
        /// </summary>
        public decimal LevelSevenAmount { get; set; }

        /// <summary>
        /// 等级8价格使用百分比
        /// </summary>
        public bool PercentageRulesLevelEight { get; set; }

        /// <summary>
        /// 等级8价格
        /// </summary>
        public decimal LevelEightAmount { get; set; }

        /// <summary>
        /// 等级9价格使用百分比
        /// </summary>
        public bool PercentageRulesLevelNine { get; set; }

        /// <summary>
        /// 等级9价格
        /// </summary>
        public decimal LevelNineAmount { get; set; }

        /// <summary>
        /// 等级10价格使用百分比
        /// </summary>
        public bool PercentageRulesLevelTen { get; set; }

        /// <summary>
        /// 等级10价格
        /// </summary>
        public decimal LevelTenAmount { get; set; }
    }
}
