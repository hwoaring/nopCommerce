using Nop.Core.Domain.Common;

namespace Nop.Core.Domain.Memberships
{
    /// <summary>
    /// 会员金额收支明细
    /// </summary>
    public partial class MemberAmountsRecords : BaseEntity, ISoftDeletedEntity
    {
        /// <summary>
        /// 用户Id
        /// </summary>
        public int CustomerId { get; set; }

        /// <summary>
        /// 是否有指定可用的供应商店铺
        /// </summary>
        public int VendorStoreId { get; set; }

        /// <summary>
        /// 是否有指定可用的商品IDs
        /// </summary>
        public string SpecificProductIds { get; set; }

        /// <summary>
        /// 交易对方ID：
        /// 收入时：为支出方；支出时：为收入方ID
        /// </summary>
        public int CounterPartyId { get; set; }

        /// <summary>
        /// 归属的会员卡ID
        /// </summary>
        public int MemberShipCardId { get; set; }

        /// <summary>
        /// 订单ID
        /// </summary>
        public int OrderId { get; set; }

        /// <summary>
        /// 交易编号：如订单号，或第三方返回的交易号
        /// </summary>
        public string TransactionNumber { get; set; }

        /// <summary>
        /// 交易信息：交易返回的更多明细
        /// </summary>
        public string TransactionContent { get; set; }

        /// <summary>
        /// 交易平台：微信，支付宝，银行卡，现金
        /// </summary>
        public int PaymentPlatformTypeId { get; set; }

        /// <summary>
        /// 收支方式或平台：如签到，充值，订单，兑换等
        /// </summary>
        public int IncomeExpendTypeId { get; set; }

        /// <summary>
        /// 金额
        /// </summary>
        public decimal Amount { get; set; }

        /// <summary>
        /// 可用时间开始
        /// </summary>

        public DateTime? ExpireStartDateUtc { get; set; }

        /// <summary>
        /// 可用时间结束
        /// </summary>
        public DateTime? ExpireEndDateUtc { get; set; }

        /// <summary>
        /// 创建时间
        /// </summary>
        public DateTime CreatDateUtc { get; set; }

        /// <summary>
        /// 激活/可用
        /// </summary>
        public bool Actived { get; set; }

        /// <summary>
        /// 删除
        /// </summary>
        public bool Deleted { get; set; }

    }
}
