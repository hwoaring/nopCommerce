using Nop.Core.Domain.Localization;
using Nop.Core.Domain.Seo;

namespace Nop.Core.Domain.Publics
{
    /// <summary>
    /// 公共标签
    /// </summary>
    public partial class PublicTag : BaseEntity, ILocalizedEntity, ISlugSupported
    {
        /// <summary>
        /// Tag名称
        /// </summary>
        public string Name { get; set; }
    }
}