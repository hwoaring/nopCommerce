using Nop.Core.Domain.Common;

namespace Nop.Core.Domain.Memberships
{
    /// <summary>
    /// 会员卡界面设置
    /// </summary>
    public partial class MembershipCardSetting : BaseEntity, ISoftDeletedEntity
    {
        /// <summary>
        /// 会员体系名称
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 描述
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// 会员卡Logo
        /// </summary>
        public string Logo { get; set; }

        /// <summary>
        /// 卡片图片
        /// </summary>
        public string CardImage { get; set; }

        /// <summary>
        /// 是否开启短信验证
        /// </summary>
        public bool SMSVerify { get; set; }

        /// <summary>
        /// 默认卡片
        /// </summary>
        public bool DefaultCard { get; set; }

        /// <summary>
        /// 绑定到Vendor
        /// </summary>
        public int VendorId { get; set; }

        /// <summary>
        /// 会员卡计算方式
        /// </summary>
        public int CalculationTypeId { get; set; }

        /// <summary>
        /// 会员卡计算周期
        /// </summary>
        public int CalculationPeriodTypeId { get; set; }

        /// <summary>
        /// 是否历史订单继承（开卡时是否统计历史订单）
        /// </summary>
        public bool HistoricalOrders { get; set; }

        /// <summary>
        /// 会员等级
        /// </summary>
        public int MemberLevel { get; set; }

        /// <summary>
        /// 会员等级名称
        /// </summary>
        public string MemberName { get; set; }

        /// <summary>
        /// 会员等级描述
        /// </summary>
        public string MemberDescription { get; set; }

        /// <summary>
        /// 本店消费金额满
        /// </summary>
        public decimal? MinConsumeAmounts { get; set; }

        /// <summary>
        /// 本店邀请/分享人数满
        /// </summary>
        public int MinInviteCounts { get; set; }

        /// <summary>
        /// 本店订单数
        /// </summary>
        public int MinOrders { get; set; }

        /// <summary>
        /// 本店积分满
        /// </summary>
        public int MinPoints { get; set; }

        /// <summary>
        /// 必须满足消费总金额（筛选条件为：且）
        /// </summary>
        public bool ConsumeAmountNecessary { get; set; }

        /// <summary>
        /// 必须满足分享/邀请人数（筛选条件为：且）
        /// </summary>
        public bool InviteCountNecessary { get; set; }

        /// <summary>
        /// 必须满足订单数（筛选条件为：且）
        /// </summary>
        public bool OrderNecessary { get; set; }

        /// <summary>
        /// 必须满足积分（筛选条件为：且）
        /// </summary>
        public bool PointNecessary { get; set; }

        /// <summary>
        /// 删除
        /// </summary>
        public bool Deleted { get; set; }
    }
}
