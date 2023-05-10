using System.Net.NetworkInformation;
using Nop.Core.Domain.Seo;
using Nop.Core.Domain.Stores;

namespace Nop.Core.Domain.News
{
    /// <summary>
    /// 文章收藏
    /// </summary>
    public partial class NewsCommentFavoriteMapping : BaseEntity
    {
        /// <summary>
        /// 文章ID
        /// </summary>
        public int NewsCommentId { get; set; }

        /// <summary>
        /// 收藏人ID
        /// </summary>
        public int CustomerId { get; set; }

        /// <summary>
        /// 已点赞
        /// </summary>
        public bool Liked { get; set; }
    }
}