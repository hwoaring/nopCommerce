using Nop.Core.Domain.Stores;

namespace Nop.Core.Domain.Polls
{
    /// <summary>
    /// Represents a poll
    /// </summary>
    public partial class Poll : BaseEntity, IStoreMappingSupported
    {
        /// <summary>
        /// Gets or sets the language identifier
        /// </summary>
        public int LanguageId { get; set; }

        /// <summary>
        /// Gets or sets the name
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the system keyword
        /// </summary>
        public string SystemKeyword { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether the entity is published
        /// </summary>
        public bool Published { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether the entity should be shown on home page
        /// </summary>
        public bool ShowOnHomepage { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether the anonymous votes are allowed
        /// </summary>
        public bool AllowGuestsToVote { get; set; }

        /// <summary>
        /// Gets or sets the display order
        /// </summary>
        public int DisplayOrder { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether the entity is limited/restricted to certain stores
        /// </summary>
        public bool LimitedToStores { get; set; }

        /// <summary>
        /// Gets or sets the poll start date and time
        /// </summary>
        public DateTime? StartDateUtc { get; set; }

        /// <summary>
        /// Gets or sets the poll end date and time
        /// </summary>
        public DateTime? EndDateUtc { get; set; }



        #region

        /// <summary>
        /// 备用：组织人/主办方
        /// </summary>
        public string Organizer { get; set; }

        /// <summary>
        /// 主题
        /// </summary>
        public string Subject { get; set; }

        /// <summary>
        /// 备用：投票描述
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// 备用：内容
        /// </summary>
        public string Content { get; set; }

        /// <summary>
        /// 投票提醒文字
        /// </summary>
        public string Notice { get; set; }

        /// <summary>
        /// 图片ID
        /// </summary>
        public int PictureId { get; set; }

        /// <summary>
        /// 一个计数周期内最大投票数
        /// </summary>
        public int VoteCycleMaxCount { get; set; }

        /// <summary>
        /// 计数周期天数
        /// </summary>
        public int VoteCycleDays { get; set; }

        /// <summary>
        /// 上次投票计数结束时间
        /// </summary>
        public DateTime? LastCycleEndDateUtc { get; set; }

        /// <summary>
        /// 本轮次投票计数结束时间
        /// </summary>
        public DateTime? CurrentCycleEndDateUtc { get; set; }

        #endregion
    }
}