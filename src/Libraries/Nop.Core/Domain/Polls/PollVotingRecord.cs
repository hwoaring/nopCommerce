namespace Nop.Core.Domain.Polls;

/// <summary>
/// Represents a poll voting record
/// </summary>
public partial class PollVotingRecord : BaseEntity
{
    /// <summary>
    /// Gets or sets the poll answer identifier
    /// </summary>
    public int PollAnswerId { get; set; }

    /// <summary>
    /// Gets or sets the customer identifier
    /// </summary>
    public int CustomerId { get; set; }

        /// <summary>
        /// Gets or sets the date and time of instance creation
        /// </summary>
        public DateTime CreatedOnUtc { get; set; }

        #region

        /// <summary>
        /// 计数统计（同一用户同一答案的计数，少占用内存空间）
        /// </summary>
        public int NumberOfVotes { get; set; }

        #endregion
    }
}