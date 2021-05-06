using System;

namespace Nop.Core.Domain.Catalog
{
    /// <summary>
    /// Represents a Product Comment Image.商品评价图片记录表
    /// </summary>
    public partial class ProductCommentPicture : BaseEntity
    {
        /// <summary>
        /// 评论Id
        /// </summary>
        public int CommentId { get; set; }

        /// <summary>
        /// 图片id(关联文件记录表)
        /// </summary>
        public int PictureId { get; set; }

        /// <summary>
        /// 创建时间
        /// </summary>
        public DateTime CreatTimeUtc { get; set; }


    }
}
