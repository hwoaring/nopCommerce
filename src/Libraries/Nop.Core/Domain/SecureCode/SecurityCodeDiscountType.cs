namespace Nop.Core.Domain.SecureCode
{
    /// <summary>
    /// 二维码促销类型
    /// </summary>
    public enum SecurityCodeDiscountType
    {
        /// <summary>
        /// 现金兑换券
        /// </summary>
        Cash = 1,

        /// <summary>
        /// 现金抵用券
        /// </summary>
        Voucher = 2,

        /// <summary>
        /// 换物券（再来一瓶，或者换其他指定的商品）
        /// </summary>
        Exchange = 3
    }
}
