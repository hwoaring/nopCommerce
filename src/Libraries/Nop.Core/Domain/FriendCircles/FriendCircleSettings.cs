using Nop.Core.Configuration;

namespace Nop.Core.Domain.FriendCircles
{
    /// <summary>
    /// 朋友圈设置
    /// </summary>
    public partial class FriendCircleSettings : ISettings
    {
        /// <summary>
        /// 开启朋友圈
        /// </summary>
        public bool Enabled { get; set; }

        /// <summary>
        /// 开启朋友圈创建人贡献内容
        /// </summary>
        public bool EnableCreators { get; set; }

        /// <summary>
        /// 每人每天朋友圈最多评论次数
        /// </summary>
        public int MaxCommentsOneDay { get; set; }

        /// <summary>
        /// 最大文字数量（0=未设置）
        /// </summary>
        public int MaxTextLength { get; set; }

        /// <summary>
        /// 单张图片最大质量（0=未设置，单位Kb）
        /// </summary>
        public int MaxPictureQuality { get; set; }

        /// <summary>
        /// 用户最大未审核条数（限制用户攻击刷单）
        /// </summary>
        public int MaxUnApprovedCounts { get; set; }

        /// <summary>
        /// 允许未注册用户评论
        /// </summary>
        public bool AllowNotRegisteredUsersToComments { get; set; }

        /// <summary>
        /// 新评论提醒
        /// </summary>
        public bool NotifyAboutNewComments { get; set; }

        /// <summary>
        /// 每次刷新数量
        /// </summary>
        public int RefreshCount { get; set; }

        /// <summary>
        /// 每页面展示数量
        /// </summary>
        public int PageSize { get; set; }

        /// <summary>
        /// 评论必须被审核
        /// </summary>
        public bool MustBeApproved { get; set; }

        /// <summary>
        /// 提醒内容（朋友圈发布规则：如不允许出现个人联系信息和二维码）
        /// </summary>
        public string RemindContent { get; set; }

        /// <summary>
        /// 三方平台视频域名，用于正则表达式验证，多个域名用分号分开
        /// </summary>
        public string ExternalVideoDomains { get; set;}

    }
}