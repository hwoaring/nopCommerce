namespace Nop.Core.Domain.News
{
    /// <summary>
    /// Represents a news comment
    /// </summary>
    public partial class NewsComment : BaseEntity
    {
        /// <summary>
        /// Gets or sets the comment title
        /// </summary>
        public string CommentTitle { get; set; }

        /// <summary>
        /// Gets or sets the comment text
        /// </summary>
        public string CommentText { get; set; }

        /// <summary>
        /// Gets or sets the news item identifier
        /// </summary>
        public int NewsItemId { get; set; }

        /// <summary>
        /// 评论ID，针对评论下继续评论或留言
        /// </summary>
        public int NewsCommentId { get; set; }

        /// <summary>
        /// Gets or sets the customer identifier
        /// </summary>
        public int CustomerId { get; set; }

        /// <summary>
        /// 评论人IP位置
        /// </summary>
        public string PublishArea { get; set; }

        /// <summary>
        /// 评论人IP
        /// </summary>
        public string PublisherIp { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether the comment is approved
        /// </summary>
        public bool IsApproved { get; set; }

        /// <summary>
        /// Gets or sets the store identifier
        /// </summary>
        public int StoreId { get; set; }

        /// <summary>
        /// Gets or sets the date and time of instance creation
        /// </summary>
        public DateTime CreatedOnUtc { get; set; }
    }
}