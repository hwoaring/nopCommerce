using System.Net.NetworkInformation;
using Nop.Core.Domain.Seo;
using Nop.Core.Domain.Stores;

namespace Nop.Core.Domain.News
{
    /// <summary>
    /// 文章阅读数据分析
    /// </summary>
    public partial class NewsAnalyse : BaseEntity
    {
        /// <summary>
        /// 文章ID
        /// </summary>
        public int NewsItemId { get; set; }

        /// <summary>
        /// 父级分享人ID
        /// </summary>
        public int ParentCustomerId { get; set; }

        /// <summary>
        /// 分享人ID
        /// </summary>
        public int CustomerId { get; set; }

        /// <summary>
        /// 阅读次数
        /// </summary>
        public int ViewCount { get; set; }

        /// <summary>
        /// 分享次数
        /// </summary>
        public int Forks { get; set; }
    }
}