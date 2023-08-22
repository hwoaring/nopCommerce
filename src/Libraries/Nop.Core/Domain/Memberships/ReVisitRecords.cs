using Nop.Core.Domain.Common;

namespace Nop.Core.Domain.Memberships
{
    /// <summary>
    /// 会员回访记录
    /// </summary>
    public partial class ReVisitRecords : BaseEntity
    {
        /// <summary>
        /// 默认会员卡ID
        /// </summary>
        public int MemberShipCardId { get; set; }

        /// <summary>
        /// 回访方式
        /// </summary>
        public int ReVisitTypeId { get; set; }

        /// <summary>
        /// 回访沟通内容
        /// </summary>
        public string Content { get; set; }

        /// <summary>
        /// 沟通效果评价（1-5）
        /// </summary>
        public int EffectLevel { get; set; }

        /// <summary>
        /// 对方是否回复
        /// </summary>
        public bool Replyed { get; set; }

        /// <summary>
        /// 下次回访时间
        /// </summary>
        public DateTime? NextVisitDateUtc { get; set; }

        /// <summary>
        /// 回访时间
        /// </summary>
        public DateTime VisitDateUtc { get; set; }

    }
}
