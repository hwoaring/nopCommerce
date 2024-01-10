namespace Nop.Core.Domain.FriendCircles
{
    /// <summary>
    /// 朋友圈图片
    /// </summary>
    public partial class FriendCirclePicture : BaseEntity
    {
        /// <summary>
        /// 朋友圈ID
        /// </summary>
        public int FriendCircleId { get; set; }

        /// <summary>
        /// 贡献人ID（可为空，用于奖励共享人）
        /// </summary>
        public int CustomerId { get; set; }

        /// <summary>
        /// 图片ID
        /// </summary>
        public int PictureId { get; set; }

        /// <summary>
        /// 图片名称
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 图片简介
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// 排序
        /// </summary>
        public int DisplayOrder { get; set; }
    }
}
