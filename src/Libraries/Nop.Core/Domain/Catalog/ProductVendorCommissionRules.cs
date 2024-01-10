using Nop.Core.Domain.Localization;

namespace Nop.Core.Domain.Catalog
{
    /// <summary>
    /// 零售商/分销商不同等级佣金；
    /// </summary>
    public partial class ProductVendorCommissionRules : BaseEntity
    {
        /// <summary>
        /// 产品ID
        /// </summary>
        public int ProductId { get; set; }

        /// <summary>
        /// 等级0佣金使用百分比(等级0为普通用户)
        /// </summary>
        public bool PercentageRulesLevelZero { get; set; }

        /// <summary>
        /// 等级0佣金(等级0为普通用户)
        /// </summary>
        public decimal LevelZreoAmount { get; set; }

        /// <summary>
        /// Vendor等级1佣金使用百分比
        /// </summary>
        public bool PercentageRulesLevelOne { get; set; }

        /// <summary>
        /// Vendor等级1佣金
        /// </summary>
        public decimal LevelOneAmount { get; set; }

        /// <summary>
        /// Vendor等级2佣金使用百分比
        /// </summary>
        public bool PercentageRulesLevelTwo { get; set; }

        /// <summary>
        /// Vendor等级2佣金
        /// </summary>
        public decimal LevelTwoAmount { get; set; }

        /// <summary>
        /// Vendor等级3佣金使用百分比
        /// </summary>
        public bool PercentageRulesLevelThree { get; set; }

        /// <summary>
        /// Vendor等级3佣金
        /// </summary>
        public decimal LevelThreeAmount { get; set; }

        /// <summary>
        /// Vendor等级4佣金使用百分比
        /// </summary>
        public bool PercentageRulesLevelFour { get; set; }

        /// <summary>
        /// Vendor等级4佣金
        /// </summary>
        public decimal LevelFourAmount { get; set; }

        /// <summary>
        /// Vendor等级5佣金使用百分比
        /// </summary>
        public bool PercentageRulesLevelFive { get; set; }

        /// <summary>
        /// Vendor等级5佣金
        /// </summary>
        public decimal LevelFiveAmount { get; set; }

        /// <summary>
        /// Vendor等级6佣金使用百分比
        /// </summary>
        public bool PercentageRulesLevelSix { get; set; }

        /// <summary>
        /// Vendor等级6佣金
        /// </summary>
        public decimal LevelSixAmount { get; set; }

        /// <summary>
        /// Vendor等级7佣金使用百分比
        /// </summary>
        public bool PercentageRulesLevelSeven { get; set; }

        /// <summary>
        /// Vendor等级7佣金
        /// </summary>
        public decimal LevelSevenAmount { get; set; }

        /// <summary>
        /// Vendor等级8佣金使用百分比
        /// </summary>
        public bool PercentageRulesLevelEight { get; set; }

        /// <summary>
        /// Vendor等级8佣金
        /// </summary>
        public decimal LevelEightAmount { get; set; }

        /// <summary>
        /// Vendor等级9佣金使用百分比
        /// </summary>
        public bool PercentageRulesLevelNine { get; set; }

        /// <summary>
        /// Vendor等级9佣金
        /// </summary>
        public decimal LevelNineAmount { get; set; }

        /// <summary>
        /// Vendor等级10佣金使用百分比
        /// </summary>
        public bool PercentageRulesLevelTen { get; set; }

        /// <summary>
        /// Vendor等级10佣金
        /// </summary>
        public decimal LevelTenAmount { get; set; }
    }
}
