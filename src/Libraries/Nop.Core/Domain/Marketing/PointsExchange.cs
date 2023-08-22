namespace Nop.Core.Domain.Marketing
{
    /// <summary>
    /// 积分兑换
    /// </summary>
    public partial class PointsExchange : BaseEntity
    {
        /// <summary>
        /// 名称
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 活动开始时间
        /// </summary>
        public DateTime StartDateUtc { get; set; }

        /// <summary>
        /// 活动结束时间
        /// </summary>
        public DateTime EndDateUtc { get; set;}

        /// <summary>
        /// 可兑换的会员等级，1=表示等级大于等于1的会员
        /// </summary>
        public int CustomerLevel { get; set; }

        /// <summary>
        /// 积分消耗数量
        /// </summary>
        public int Amounts { get; set; }


    }
}
