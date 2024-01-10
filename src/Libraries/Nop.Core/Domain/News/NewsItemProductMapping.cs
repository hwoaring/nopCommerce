namespace Nop.Core.Domain.News
{
    /// <summary>
    /// 新闻页相关产品（便于下单）
    /// </summary>
    public partial class NewsItemProductMapping : BaseEntity
    {
        /// <summary>
        /// 第一个产品ID
        /// </summary>
        public int NewsItemId { get; set; }

        /// <summary>
        /// 产品ID
        /// </summary>
        public int ProductId { get; set; }

        /// <summary>
        /// 排序
        /// </summary>
        public int DisplayOrder { get; set; }
    }
}
