using Nop.Core.Domain.Localization;
using Nop.Core.Domain.Seo;

namespace Nop.Core.Domain.RelationShips
{
    /// <summary>
    /// 个人联系表标签映射
    /// </summary>
    public partial class PersonalRelationTagMapping : BaseEntity
    {
        /// <summary>
        /// 所属人客户id
        /// </summary>
        public int PersonalRelationShipId { get; set; }

        /// <summary>
        /// 标签ID
        /// </summary>
        public int PersonalRelationTagId { get; set; }
    }
}