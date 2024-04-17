using System.Reflection.Emit;

namespace Nop.Core.Domain.Orders;

/// <summary>
/// 优惠功能，享受优惠时返回该字段
/// </summary>
public partial class OrderPromotion : BaseEntity
{
    /// <summary>
    /// 订单ID
    /// </summary>
    public int OrderId { get; set; }

    /// <summary>
    /// 是。券ID
    /// </summary>
    public string CouponId { get; set; }

    /// <summary>
    /// 否。优惠名称
    /// </summary>
    public string Name { get; set; }

    /// <summary>
    /// 否。GLOBAL：全场代金券
    /// </summary>
    public string PromotionScopeId { get; set; }

    /// <summary>
    /// 否。优惠类型，CASH：充值型代金券
    /// </summary>
    public string PromotionTypeId { get; set; }

    /// <summary>
    /// 是。优惠券面额
    /// </summary>
    public decimal Amount { get; set; }

    /// <summary>
    /// 否。优惠活动ID
    /// </summary>
    public int StockId { get; set; }

    /// <summary>
    /// 否。微信出资
    /// </summary>
    public decimal WechatpayContribute { get; set; }

    /// <summary>
    /// 否。商户出资
    /// </summary>
    public decimal MerchantContribute { get; set; }

    /// <summary>
    /// 否。其他出资
    /// </summary>
    public decimal OtherContribute { get; set; }

    /// <summary>
    /// 否.CNY：人民币，境内商户号仅支持人民币
    /// </summary>
    public string Currency { get; set; }
}
