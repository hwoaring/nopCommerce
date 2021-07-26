using Nop.Core.Domain.Common;

namespace Nop.Core.Domain.Weixin
{
    /// <summary>
    /// Represents an WxUserSysTag
    /// </summary>
    public partial class WxUserSysTag : BaseEntity, ISoftDeletedEntity
    {
        /// <summary>
        /// StoreId
        /// </summary>
        public int StoreId { get; set; }

        /// <summary>
        /// 系统标志名称
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// 系统标志描述
        /// </summary>
        public string Description { get; set; }
        /// <summary>
        /// 删除
        /// </summary>
        public bool Deleted { get; set; }

    }
}
