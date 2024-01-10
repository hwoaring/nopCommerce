namespace Nop.Core.Domain.FriendCircles
{
    /// <summary>
    /// 朋友圈评论点赞（放在一起避免标记与取消多次统计）
    /// </summary>
    public partial class FriendCircleFavoriteMapping : BaseEntity
    {
        /// <summary>
        /// 朋友圈ID
        /// </summary>
        public int FriendCircleId { get; set; }

        /// <summary>
        /// 客户ID
        /// </summary>
        public int CustomerId { get; set; }

        /// <summary>
        /// 不喜欢
        /// </summary>
        public bool Dislike { get; set; }

        /// <summary>
        /// 订阅
        /// </summary>
        public bool Subscribe { get; set; }

        /// <summary>
        /// 收藏
        /// </summary>
        public bool Favorited { get; set; }

        /// <summary>
        /// 推荐
        /// </summary>
        public bool Recommended { get; set; }

        /// <summary>
        /// 点赞
        /// </summary>
        public bool Thumbed { get; set; }
    }
}