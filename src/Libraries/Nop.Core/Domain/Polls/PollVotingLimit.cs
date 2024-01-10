using Nop.Core.Domain.Stores;

namespace Nop.Core.Domain.Polls
{
    /// <summary>
    /// 投票限制
    /// </summary>
    public partial class PollVotingLimit : BaseEntity
    {

        /// <summary>
        /// 投票项目ID
        /// </summary>
        public int PollId { get; set; }

        /// <summary>
        /// 投票用户ID
        /// </summary>
        public int CustomerId { get; set; }

        /// <summary>
        /// 本轮次已投票次数
        /// </summary>
        public int NumberOfVotes { get; set; }

        /// <summary>
        /// 本轮次投票时间（小于本轮次开始时间时，计数器清零值为1）
        /// </summary>
        public DateTime CurrentCycleVoteDateUtc { get; set; } 
    }
}