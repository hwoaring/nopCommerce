using Nop.Core.Domain.Common;

namespace Nop.Core.Domain.FriendCircles
{
    /// <summary>
    /// 朋友圈信息
    /// </summary>
    public partial class FriendCircle : BaseEntity, ISoftDeletedEntity
    {
        /// <summary>
        /// Store ID
        /// </summary>
        public int StoreId { get; set; }

        /// <summary>
        /// 关联品牌
        /// </summary>
        public int BrandId { get; set; }

        /// <summary>
        /// 关联产品
        /// </summary>
        public int ProductId { get; set; }

        /// <summary>
        /// 发布人ID
        /// </summary>
        public int CustomerId { get; set; }

        /// <summary>
        /// 贡献人ID
        /// </summary>
        public int CreatorId { get; set; }

        /// <summary>
        /// 隐私策略
        /// </summary>
        public int FriendPrivacyTypeId { get; set; }

        /// <summary>
        /// 朋友圈文本信息
        /// </summary>
        public string Content { get; set; }

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
        /// 开启浏览统计
        /// </summary>
        public bool EnableViewsCount { get; set; }

        /// <summary>
        /// 浏览量
        /// </summary>
        public int ViewsCount { get; set; }

        /// <summary>
        /// 引用朋友圈的ID
        /// </summary>
        public int ForkFriendCircleId { get; set; }

        /// <summary>
        /// 是否引用他人的朋友圈（减少图片上传过程和图片空间占用）
        /// 引用的只能改变文字信息，其他信息不能动
        /// 要改变图片和视频只能收藏图片后直接使用
        /// </summary>
        public bool IsForksItem { get; set; }

        /// <summary>
        /// 第三方视频地址
        /// </summary>
        public string ExternalVideoUrl { get; set; }

        /// <summary>
        /// 使用第三方视频地址（抖音链接）
        /// </summary>
        public bool UseExternalVideo { get; set; }

        /// <summary>
        /// 是否视频格式
        /// </summary>
        public bool IsVideo { get; set; }

        /// <summary>
        /// 允许评论
        /// </summary>
        public bool AllowComment { get; set; }

        /// <summary>
        /// 是否审核通过
        /// </summary>
        public bool IsApproved { get; set; }

        /// <summary>
        /// 展示
        /// </summary>
        public bool Published { get; set; }

        /// <summary>
        /// 删除（删除引用项目时候，只删除本条记录信息，不删除相关图片和视频）
        /// </summary>
        public bool Deleted { get; set; }

        /// <summary>
        /// 更新时间(排序按更新时间排序，可以避免重复提交相同内容)
        /// </summary>
        public DateTime UpdatedOnUtc { get; set; }

        /// <summary>
        /// 创建时间
        /// </summary>
        public DateTime CreatedOnUtc { get; set; }
    }
}