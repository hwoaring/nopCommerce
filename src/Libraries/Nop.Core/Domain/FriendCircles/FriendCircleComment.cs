namespace Nop.Core.Domain.FriendCircles
{
    /// <summary>
    /// 朋友圈评论
    /// </summary>
    public partial class FriendCircleComment : BaseEntity
    {
        /// <summary>
        /// 朋友圈ID
        /// </summary>
        public int FriendCircleId { get; set; }

        /// <summary>
        /// 评论人ID
        /// </summary>
        public int CustomerId { get; set; }

        /// <summary>
        /// 评论内容
        /// </summary>
        public string CommentText { get; set; }

        /// <summary>
        /// 回复内容
        /// </summary>
        public string ReplyText { get; set; }

        /// <summary>
        /// 发布人IP
        /// </summary>
        public string PublisherIp { get; set; }

        /// <summary>
        /// 地址的区划代码ID
        /// </summary>
        public int RegionCodeId { get; set; }

        /// <summary>
        /// 经度值
        /// </summary>
        public decimal? Longitude { get; set; }

        /// <summary>
        /// 纬度值
        /// </summary>
        public decimal? Latitude { get; set; }

        /// <summary>
        /// 排序
        /// </summary>
        public int DisplayOrder { get; set; }

        /// <summary>
        /// 是否作者本人评论
        /// </summary>
        public bool IsAuthor { get; set; }

        /// <summary>
        /// 置顶
        /// </summary>
        public bool AsTop { get; set; }

        /// <summary>
        /// 是否审核通过
        /// </summary>
        public bool IsApproved { get; set; }

        /// <summary>
        /// 展示
        /// </summary>
        public bool Published { get; set; }

        /// <summary>
        /// 回复时间
        /// </summary>
        public DateTime? ReplyOnUtc { get; set; }

        /// <summary>
        /// 创建时间
        /// </summary>
        public DateTime CreatedOnUtc { get; set; }
    }
}