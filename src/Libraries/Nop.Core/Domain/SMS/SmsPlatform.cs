using Nop.Core.Domain.Common;

namespace Nop.Core.Domain.SMS
{
    /// <summary>
    /// 短信接口平台
    /// </summary>
    public partial class SmsPlatform : BaseEntity, ISoftDeletedEntity
    {
        /// <summary>
        /// 平台名称
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 平台链接
        /// </summary>
        public string Url { get; set; }

        /// <summary>
        /// 锁定
        /// </summary>
        public bool Locked { get; set; }

        /// <summary>
        /// 删除
        /// </summary>
        public bool Deleted { get; set; }

    }
}
