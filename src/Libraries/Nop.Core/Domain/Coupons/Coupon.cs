using Nop.Core.Domain.Common;

namespace Nop.Core.Domain.Coupons
{
    /// <summary>
    /// 优惠券
    /// </summary>
    public partial class Coupon : BaseEntity, ISoftDeletedEntity
    {

        /// <summary>
        /// 名称
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 描述
        /// </summary>
        public string AdminComment { get; set; }

        /// <summary>
        /// 折扣指定类型ID
        /// </summary>
        public int DiscountTypeId { get; set; }

        /// <summary>
        /// 是否使用百分比折扣
        /// </summary>
        public bool UsePercentage { get; set; }

        /// <summary>
        /// 折扣百分比
        /// </summary>
        public decimal DiscountPercentage { get; set; }

        /// <summary>
        /// 折扣金额
        /// </summary>
        public decimal DiscountAmount { get; set; }

        /// <summary>
        /// 最大折扣金额 (使用百分比折扣率时)
        /// </summary>
        public decimal? MaximumDiscountAmount { get; set; }

        /// <summary>
        /// 开始领取时间
        /// </summary>
        public DateTime? StartDateUtc { get; set; }

        /// <summary>
        /// 结束领取时间
        /// </summary>
        public DateTime? EndDateUtc { get; set; }

        /// <summary>
        /// 是否需要优惠码
        /// </summary>
        public bool RequiresCouponCode { get; set; }

        /// <summary>
        /// 优惠码
        /// </summary>
        public string CouponCode { get; set; }

        /// <summary>
        /// 是否累计计算折扣
        /// </summary>
        public bool IsCumulative { get; set; }

        /// <summary>
        /// 折扣限制方式ID
        /// </summary>
        public int DiscountLimitationId { get; set; }

        /// <summary>
        /// 折扣限制次数 (used when Limitation is set to "N Times Only" or "N Times Per Customer")
        /// </summary>
        public int LimitationTimes { get; set; }

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
        /// Gets or sets a value indicating whether the discount is active
        /// </summary>
        public bool IsActive { get; set; }

        public bool Deleted { get; set; }
    }
}
