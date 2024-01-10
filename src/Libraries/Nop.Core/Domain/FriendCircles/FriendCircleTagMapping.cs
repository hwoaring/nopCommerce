namespace Nop.Core.Domain.FriendCircles
{
    /// <summary>
    /// 朋友圈标签，话题映射
    /// </summary>
    public partial class FriendCircleTagMapping : BaseEntity
    {
        /// <summary>
        /// 朋友圈ID
        /// </summary>
        public int FriendCircleId { get; set; }

        /// <summary>
        /// 标签/话题 ID
        /// </summary>
        public int FriendCircleTagId { get; set; }
    }
}