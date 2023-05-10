using Nop.Core.Domain.Common;

namespace Nop.Core.Domain.SecureCode
{
    /// <summary>
    /// 产品信息
    /// </summary>
    public partial class SecureCodeProduct : BaseEntity, ISoftDeletedEntity
    {
        /// <summary>
        /// 生产公司ID
        /// </summary>
        public int ManufacturerId { get; set; }

        /// <summary>
        /// 对外查询使用的产品安全参数码
        /// </summary>
        public string SecurityProductId { get; set; }

        /// <summary>
        /// 产品名称
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// 产品副名称
        /// </summary>
        public string SubTitle { get; set; }

        /// <summary>
        /// 图片URL
        /// </summary>
        public string ImagesUrl { get; set; }

        /// <summary>
        /// 产品参数
        /// </summary>
        public string ProductParameters { get; set; }

        /// <summary>
        /// 指导价格
        /// </summary>
        public decimal Price { get; set; }

        /// <summary>
        /// 产品描述
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// 产品内容
        /// </summary>
        public string Content { get; set; }

        /// <summary>
        /// 激活
        /// </summary>
        public bool Actived { get; set; }

        /// <summary>
        /// 删除
        /// </summary>
        public bool Deleted { get; set; }

        /// <summary>
        /// 创建时间
        /// </summary>
        public DateTime CreatedUtc { get; set; }
    }
}
