namespace Nop.Core.Domain.Vendors
{
    /// <summary>
    /// 商店座位或房间图片
    /// </summary>
    public partial class VendorStoreSeatPicture : BaseEntity
    {
        /// <summary>
        /// 商店房间/座位ID
        /// </summary>
        public int VendorStoreSeatId { get; set; }

        /// <summary>
        /// 图片id
        /// </summary>
        public int PictureId { get; set; }

        /// <summary>
        /// 排序
        /// </summary>
        public int DisplayOrder { get; set; }
    }
}
