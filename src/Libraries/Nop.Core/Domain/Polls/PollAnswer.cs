namespace Nop.Core.Domain.Polls;

/// <summary>
/// Represents a poll answer
/// </summary>
public partial class PollAnswer : BaseEntity
{
    /// <summary>
    /// Gets or sets the poll identifier
    /// </summary>
    public int PollId { get; set; }

    /// <summary>
    /// Gets or sets the poll answer name
    /// </summary>
    public string Name { get; set; }

    /// <summary>
    /// Gets or sets the current number of votes
    /// </summary>
    public int NumberOfVotes { get; set; }

        /// <summary>
        /// Gets or sets the display order
        /// </summary>
        public int DisplayOrder { get; set; }


        #region

        /// <summary>
        /// 答案编码
        /// </summary>
        public string Code { get; set; }

        /// <summary>
        /// 图片ID
        /// </summary>
        public int PictureId { get; set; }

        /// <summary>
        /// 备用：答案描述
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// 备用：组织名称（展示字段和筛选使用）
        /// </summary>
        public string GroupName { get; set; }

        /// <summary>
        /// 备用：区域名称（展示字段和筛选使用）
        /// </summary>
        public string AreaName { get; set; }

        #endregion
    }
}