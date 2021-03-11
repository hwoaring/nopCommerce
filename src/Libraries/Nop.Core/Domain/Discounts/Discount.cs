using System;

namespace Nop.Core.Domain.Discounts
{
    /// <summary>
    /// Represents a discount
    /// </summary>
    public partial class Discount : BaseEntity
    {
        /// <summary>
        /// Gets or sets the name
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 短名称（用于前台展示，为空则取Name值）
        /// </summary>
        public string ShortName { get; set; }

        /// <summary>
        /// 折扣描述
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// Gets or sets the admin comment
        /// </summary>
        public string AdminComment { get; set; }

        /// <summary>
        /// Gets or sets the discount type identifier
        /// </summary>
        public int DiscountTypeId { get; set; }

        /// <summary>
        /// 启用推荐人数要求
        /// </summary>
        public bool EnableRefereeRequirement { get; set; }

        /// <summary>
        /// 最低推荐人数（达到推荐人数可以使用，默认为0）
        /// </summary>
        public int MinReferralsNumber { get; set; }

        /// <summary>
        /// 邀请人数统计开始日期
        /// </summary>
        public DateTime? ReferralsNumberStartDateUtc { get; set; }

        /// <summary>
        /// 邀请人数统计结束日期
        /// </summary>
        public DateTime? ReferralsNumberEndDateUtc { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether to use percentage
        /// </summary>
        public bool UsePercentage { get; set; }

        /// <summary>
        /// Gets or sets the discount percentage
        /// </summary>
        public decimal DiscountPercentage { get; set; }

        /// <summary>
        /// Gets or sets the discount amount
        /// </summary>
        public decimal DiscountAmount { get; set; }

        /// <summary>
        /// 订单总额满多少金额可以使用折扣券
        /// </summary>
        public decimal? MinOrderTotalAmount { get; set; }

        /// <summary>
        /// Gets or sets the maximum discount amount (used with "UsePercentage")
        /// </summary>
        public decimal? MaximumDiscountAmount { get; set; }

        /// <summary>
        /// Gets or sets the discount start date and time
        /// </summary>
        public DateTime? StartDateUtc { get; set; }

        /// <summary>
        /// Gets or sets the discount end date and time
        /// </summary>
        public DateTime? EndDateUtc { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether discount requires coupon code
        /// </summary>
        public bool RequiresCouponCode { get; set; }

        /// <summary>
        /// Gets or sets the coupon code
        /// </summary>
        public string CouponCode { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether discount can be used simultaneously with other discounts (with the same discount type)
        /// </summary>
        public bool IsCumulative { get; set; }

        /// <summary>
        /// 折扣信息是否在产品列表页面或详情页面展示
        /// </summary>
        public bool FrontDisplay { get; set; }

        /// <summary>
        /// Gets or sets the discount limitation identifier
        /// </summary>
        public int DiscountLimitationId { get; set; }

        /// <summary>
        /// Gets or sets the discount limitation times (used when Limitation is set to "N Times Only" or "N Times Per Customer")
        /// </summary>
        public int LimitationTimes { get; set; }

        /// <summary>
        /// 最大发行数量（可以配合limit user times使用）
        /// </summary>
        public int MaximumNumbers { get; set; }
        
        /// <summary>
        /// Gets or sets the maximum product quantity which could be discounted
        /// Used with "Assigned to products" or "Assigned to categories" type
        /// </summary>
        public int? MaximumDiscountedQuantity { get; set; }

        /// <summary>
        /// Gets or sets value indicating whether it should be applied to all subcategories or the selected one
        /// Used with "Assigned to categories" type only.
        /// </summary>
        public bool AppliedToSubCategories { get; set; }

        /// <summary>
        /// 仅新用户可用
        /// </summary>
        public bool NewUserOnly { get; set; }

        /// <summary>
        /// 可以使用多少积分兑换，0=不能兑换
        /// </summary>
        public int Points { get; set; }

        /// <summary>
        /// 结束使用时间从领取开始x天内，0=不限制（计算的结束使用时间应小于指定的最晚使用时间）
        /// </summary>
        public int EndUseTimeDay { get; set; }

        /// <summary>
        /// 开始使用时间
        /// </summary>
        public DateTime? StartUseTimeUtc { get; set; }

        /// <summary>
        /// 最晚使用时间
        /// </summary>
        public DateTime? EndUseTimeUtc { get; set; }

        /// <summary>
        /// 更新时间
        /// </summary>
        public DateTime UpdatedOnUtc { get; set; }

        /// <summary>
        /// 创建时间
        /// </summary>
        public DateTime CreatedOnUtc { get; set; }

        /// <summary>
        /// Gets or sets the discount type
        /// </summary>
        public DiscountType DiscountType
        {
            get => (DiscountType)DiscountTypeId;
            set => DiscountTypeId = (int)value;
        }

        /// <summary>
        /// Gets or sets the discount limitation
        /// </summary>
        public DiscountLimitationType DiscountLimitation
        {
            get => (DiscountLimitationType)DiscountLimitationId;
            set => DiscountLimitationId = (int)value;
        }

    }
}
