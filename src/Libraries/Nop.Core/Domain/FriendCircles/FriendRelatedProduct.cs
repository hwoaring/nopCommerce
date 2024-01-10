namespace Nop.Core.Domain.FriendCircles
{
    /// <summary>
    /// 朋友圈相关产品（便于下单）
    /// </summary>
    public partial class FriendRelatedProduct : BaseEntity
    {
        /// <summary>
        /// 第一个产品ID
        /// </summary>
        public int ProductId1 { get; set; }

        /// <summary>
        /// 第二个产品ID
        /// </summary>
        public int ProductId2 { get; set; }

        /// <summary>
        /// 排序
        /// </summary>
        public int DisplayOrder { get; set; }
    }
}
