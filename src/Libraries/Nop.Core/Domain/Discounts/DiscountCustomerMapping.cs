using System;

namespace Nop.Core.Domain.Discounts
{
    /// <summary>
    /// 系统折扣码与用户分享折扣码映射
    /// </summary>
    public partial class DiscountCustomerMapping : BaseEntity
    {

        /// <summary>
        /// Gets or sets the discount identifier
        /// </summary>
        public int DiscountId { get; set; }

        /// <summary>
        /// 领取人ID
        /// </summary>
        public int CustomerId { get; set; }

        /// <summary>
        /// 推荐人ID
        /// </summary>
        public int RefereeUserId { get; set; }

        /// <summary>
        /// 用户推广用的个人折扣码，查找对应的公用DiscountId
        /// </summary>
        public string CouponCode { get; set; }

        /// <summary>
        /// 该用户对应的折扣码最大使用数量
        /// </summary>
        public int MaxUsageCount { get; set; }

        /// <summary>
        /// 使用场景描述
        /// </summary>
        public string SceneDescription { get; set; }

        /// <summary>
        /// 使用场景内容(可用于针对指定场景主题或活动内容进行说明)
        /// </summary>
        public string SceneContent { get; set; }

        /// <summary>
        /// 可指定本场景折扣的有效期
        /// </summary>
        public DateTime? StartDateUtc { get; set; }

        /// <summary>
        /// 可指定本场景折扣的有效期
        /// </summary>
        public DateTime? EndDateUtc { get; set; }

        /// <summary>
        /// 创建时间
        /// </summary>
        public DateTime CreatTimeUtc { get; set; }

        /// <summary>
        /// 是否使用
        /// </summary>
        public bool IsUsed { get; set; }

        /// <summary>
        /// 是否启用，针对用户特定的折扣码进行锁定/解锁操作
        /// </summary>
        public bool Published { get; set; }

    }
}
