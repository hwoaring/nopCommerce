namespace Nop.Core.Domain.Shares
{
    /// <summary>
    /// 分享页使用的海报图映射
    /// </summary>
    public partial class SharePageSharePictureMapping : BaseEntity
    {
        /// <summary>
        /// 分享页ID
        /// </summary>
        public int SharePageId { get; set; }

        /// <summary>
        /// 分享图片ID
        /// </summary>
        public int SharePictureId { get; set; }

        /// <summary>
        /// 排序
        /// </summary>
        public int DisplayOrder { get; set; }
    }
}
