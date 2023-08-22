using Nop.Core.Domain.Common;

namespace Nop.Core.Domain.Memberships
{
    /// <summary>
    /// 会员抵用券/优惠券记录
    /// </summary>
    public partial class MemberCouponsRecords : BaseEntity, ISoftDeletedEntity
    {
        /// <summary>
        /// 发放公司ID
        /// </summary>
        public int VendorStoreId { get; set; }
    }
}
