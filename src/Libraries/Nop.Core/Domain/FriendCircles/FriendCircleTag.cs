using Nop.Core.Domain.Localization;
using Nop.Core.Domain.Seo;

namespace Nop.Core.Domain.FriendCircles
{
    /// <summary>
    /// 朋友圈标签，话题
    /// </summary>
    public partial class FriendCircleTag : BaseEntity, ILocalizedEntity, ISlugSupported
    {
        /// <summary>
        /// 标签名称，话题名称
        /// </summary>
        public string Name { get; set; }
    }
}