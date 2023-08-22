namespace Nop.Core.Domain.Vendors
{
    /// <summary>
    /// 供应商自定义商品分类
    /// </summary>
    public partial class VendorCategory : BaseEntity
    {
        /// <summary>
        /// 供应商ID
        /// </summary>
        public int VendorId { get; set; }

        /// <summary>
        /// 类别名称
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 描述
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// 模板ID
        /// </summary>
        public int CategoryTemplateId { get; set; }

        /// <summary>
        /// SEO关键词
        /// </summary>
        public string MetaKeywords { get; set; }

        /// <summary>
        /// SEO描述
        /// </summary>
        public string MetaDescription { get; set; }

        /// <summary>
        /// SEO标题
        /// </summary>
        public string MetaTitle { get; set; }

        /// <summary>
        /// 父级分类ID
        /// </summary>
        public int ParentCategoryId { get; set; }

        /// <summary>
        /// 图片ID
        /// </summary>
        public int PictureId { get; set; }

        /// <summary>
        /// 分页大小
        /// </summary>
        public int PageSize { get; set; }

        /// <summary>
        /// 排序
        /// </summary>
        public int DisplayOrder { get; set; }

        /// <summary>
        /// 发布
        /// </summary>
        public bool Published { get; set; }

    }
}
