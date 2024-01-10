using Nop.Core.Domain.Common;

namespace Nop.Core.Domain.AntiFake
{
    /// <summary>
    /// 防伪营销现金奖励
    /// </summary>
    public partial class AntiFakeCashRewards : BaseEntity, ISoftDeletedEntity
    {
        /// <summary>
        /// 奖励设置批次
        /// </summary>
        public int AntiFakeCashRewardsConfigId { get; set; }

        /// <summary>
        /// 奖励绑定的密码编码或瓶盖内码
        /// </summary>
        public long CashRewardsCode { get; set; }

        /// <summary>
        /// 条码类型：
        /// 8=防伪小码密码
        /// 4=瓶盖码（内）
        /// </summary>
        public int CashRewardsCodeType { get; set; }

        /// <summary>
        /// 奖励类型（1=现金，2=赠送某一产品）
        /// </summary>
        public int CashRewardsItemType { get; set; }

        /// <summary>
        /// 奖励产品ID
        /// </summary>
        public int RewardsProductId { get; set; }

        /// <summary>
        /// 奖励金额或奖励产品数量（普通消费者的开盖奖励或密码奖励）
        /// </summary>
        public decimal Amount { get; set; }

        /// <summary>
        /// 奖励金额（只针对店铺推销员的导购现金奖励）
        /// </summary>
        public decimal SalesAmount { get; set; }

        /// <summary>
        /// 红包校验码（对应编码编号+奖励类型+产品ID+金额）
        /// </summary>
        public string HashCode { get; set; }

        /// <summary>
        /// 领取券的人ID
        /// </summary>
        public int CustomerId { get; set; }

        /// <summary>
        /// 领取人地址的区划代码
        /// </summary>
        public int ChinaRegionCode { get; set; }

        /// <summary>
        /// 领取人经度值
        /// </summary>
        public decimal? Longitude { get; set; }

        /// <summary>
        /// 领取人纬度值
        /// </summary>
        public decimal? Latitude { get; set; }

        /// <summary>
        /// 券领取的时间（领取绑定到个人）
        /// </summary>
        public DateTime? ReceivedDateUtc { get; set; }

        /// <summary>
        /// 兑换销售商ID（有货的销售）
        /// </summary>
        public int ExchangeVendorId { get; set; }

        /// <summary>
        /// 兑换时间（兑换为现金或奖品的交易时间）
        /// </summary>
        public DateTime? ExchangeDateUtc { get; set; }

        /// <summary>
        /// 删除
        /// </summary>
        public bool Deleted { get; set; }
    }
}
