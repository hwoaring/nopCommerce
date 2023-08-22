using Nop.Core.Domain.Common;
using static StackExchange.Redis.Role;

namespace Nop.Core.Domain.Memberships
{
    /// <summary>
    /// 会员卡记录
    /// </summary>
    public partial class MemberShipCard : BaseEntity, ISoftDeletedEntity
    {
        /// <summary>
        /// 用户ID
        /// </summary>
        public int CustomerId { get; set; }

        /// <summary>
        /// 归属:于供应商店铺的Id
        /// </summary>
        public int VendorStoreId { get; set; }

        /// <summary>
        /// 归属人ID
        /// </summary>
        public int BelongCustomerId { get; set; }

        /// <summary>
        /// 验证绑定的手机号
        /// </summary>
        public string BindPhoneNumber { get; set; }

        /// <summary>
        /// 会员卡号（前8位使用供应商店铺编号）
        /// </summary>
        public string MembershipCardNumber { get; set; }

        /// <summary>
        /// 会员等级
        /// </summary>
        public int MemberLenel { get; set; }

        /// <summary>
        /// 会员卡现金抵用金额
        /// </summary>
        public decimal Amounts { get; set; }

        /// <summary>
        /// 锁定的：金额
        /// </summary>
        public decimal AmountsLocked { get; set; }

        /// <summary>
        /// 平台专用点或专用金额
        /// </summary>
        public decimal PlatformAmounts { get; set; }

        /// <summary>
        /// 锁定的：平台专用点或专用金额
        /// </summary>
        public decimal PlatformAmountsLocked { get; set; }

        /// <summary>
        /// 积分
        /// </summary>
        public decimal Points { get; set; }

        /// <summary>
        /// 锁定的：积分
        /// </summary>
        public decimal PointsLocked { get; set; }

        /// <summary>
        /// 排序
        /// </summary>
        public int DisplayOrder { get; set; }

        /// <summary>
        /// 激活/是否已开卡
        /// </summary>
        public bool Actived { get; set; }

        /// <summary>
        /// 删除
        /// </summary>
        public bool Deleted { get; set; }

        /// <summary>
        /// 创建时间
        /// </summary>
        public DateTime CreatDateUtc { get; set; }
    }
}
