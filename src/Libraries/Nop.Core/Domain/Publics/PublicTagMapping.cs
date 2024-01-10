namespace Nop.Core.Domain.Publics
{
    /// <summary>
    /// 公共标签映射
    /// </summary>
    public partial class PublicTagMapping : BaseEntity
    {
        /// <summary>
        /// 实体ID
        /// </summary>
        public int PublicEntityId { get; set; }

        /// <summary>
        /// 实体类型ID
        /// </summary>
        public int PublicEntityTypeId { get; set; }

        /// <summary>
        /// 公共标签ID
        /// </summary>
        public int PublicTagId { get; set; }
    }
}