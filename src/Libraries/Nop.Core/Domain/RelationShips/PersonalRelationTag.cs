
namespace Nop.Core.Domain.RelationShips
{
    /// <summary>
    /// 个人联系人关系标签
    /// </summary>
    public partial class PersonalRelationTag : BaseEntity
    {
        /// <summary>
        /// 所属人ID
        /// </summary>
        public int CustomerId { get; set; }

        /// <summary>
        /// 标签名称
        /// </summary>
        public string Name { get; set; }
    }
}