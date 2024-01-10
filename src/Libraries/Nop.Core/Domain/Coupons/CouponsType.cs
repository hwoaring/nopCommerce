namespace Nop.Core.Domain.Coupons
{
    /// <summary>
    /// 卡券类型
    /// </summary>
    public enum CouponsType
    {
        /// <summary>
        /// 折扣券（几折）
        /// </summary>
        Coupon = 0,

        /// <summary>
        /// 抵用券（当现金使用）
        /// </summary>
        Voucher = 1,

        /// <summary>
        /// 红包（当现金使用）
        /// </summary>
        RedPacket = 2,

        /// <summary>
        /// 门票
        /// </summary>
        Ticket = 3,
    }
}