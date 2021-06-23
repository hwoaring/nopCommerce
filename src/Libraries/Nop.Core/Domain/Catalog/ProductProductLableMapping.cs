using Nop.Core.Domain.Localization;
using Nop.Core.Domain.Seo;

namespace Nop.Core.Domain.Catalog
{
    /// <summary>
    /// 产品服务内容标签映射
    /// </summary>
    public partial class ProductProductLableMapping : BaseEntity
    {
        public int ProductId { get; set; }

        public int ProductLableId { get; set; }

        public string Content { get; set; }
    }
}