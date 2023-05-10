using System.Net.NetworkInformation;
using Nop.Core.Domain.Seo;
using Nop.Core.Domain.Stores;

namespace Nop.Core.Domain.News
{
    /// <summary>
    /// 文章收藏
    /// </summary>
    public partial class NewsFavoriteMapping : BaseEntity
    {
        /// <summary>
        /// 文章ID
        /// </summary>
        public int NewsItemId { get; set; }

        /// <summary>
        /// 收藏人ID
        /// </summary>
        public int CustomerId { get; set; }

        /// <summary>
        /// 已收藏
        /// </summary>
        public bool Favorited { get; set; }

        /// <summary>
        /// 已点赞
        /// </summary>
        public bool Liked { get; set; }

        /// <summary>
        /// 标记为在读
        /// </summary>
        public bool Looked { get; set; }
    }
}