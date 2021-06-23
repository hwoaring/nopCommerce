using Nop.Core.Domain.Localization;
using Nop.Core.Domain.Seo;

namespace Nop.Core.Domain.Catalog
{
    /// <summary>
    /// 产品服务内容标签
    /// </summary>
    public partial class ProductLable : BaseEntity
    {
        /// <summary>
        /// Gets or sets the name
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 描述
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// 用于CSS格式
        /// </summary>
        public string CssName { get; set; }

        /// <summary>
        /// 默认内容
        /// </summary>
        public string Content { get; set; }

        /// <summary>
        /// 分组ID
        /// </summary>
        public int ProductLableGroupId { get; set; }

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