using Nop.Core.Domain.Common;

namespace Nop.Core.Domain.Weixin
{
    /// <summary>
    /// Represents an WxShareLink
    /// </summary>
    public partial class WxShareLink : BaseEntity, ISoftDeletedEntity
    {
        /// <summary>
        /// 对外链接字符串6位ID
        /// </summary>
        /// <returns></returns>
        public string LinkId { get; set; }
        /// <summary>
        /// 分享用户的ID
        /// </summary>
        /// <returns></returns>
        public int CustomerId { get; set; }

        /// <summary>
        /// 实际链接地址
        /// </summary>
        /// <returns></returns>
        public string Url { get; set; }
        /// <summary>
        /// 阅读统计（每次删除【WPageShareCount】时，累计加入）
        /// </summary>
        public int ViewCount { get; set; }
        /// <summary>
        /// 点赞统计（每次删除【WPageShareCount】时，累计加入）
        /// </summary>
        public int ThumbUpCount { get; set; }
        /// <summary>
        /// 创建时间（可用于指定本条数据有效期，超出有效期删除数据，减少空间占用）
        /// </summary>
        public int CreatTime { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public bool Deleted { get; set; }

    }
}
