using Nop.Core.Domain.Common;
using Nop.Core.Domain.Coupons;

namespace Nop.Core.Domain.Catalog;

/// <summary>
/// 卡券、红包类产品扩展属性
/// </summary>
public partial class ProductCouponsAttribute : BaseEntity
{
    /// <summary>
    /// 产品ID
    /// </summary>
    public int ProductId { get; set; }

    /// <summary>
    /// 产品分类属性
    /// </summary>
    public int ProductAttributeId { get; set; }

    /// <summary>
    /// 卡券类型ID
    /// </summary>
    public int CouponsTypeId { get; set; }

    /// <summary>
    /// 是否产品兑换券（抵用券的一种特殊形式，兑换指定规格的指定产品，需要绑定到指定产品ID）
    /// </summary>
    public bool ExchangeVoucher { get; set; }

    /// <summary>
    /// 卡券是否需要提供联系方式（多张卡券都是一个联系电话，并非实名认证绑定的电话）
    /// </summary>
    public bool RequireBindPhone { get; set; }

    /// <summary>
    /// 实名：是否要实名购买
    /// </summary>
    public bool RealNamePurchase { get; set; }

    /// <summary>
    /// 实名：实名后是否启用年龄段折扣规则
    /// </summary>
    public bool EnableAgeDiscountRules { get; set; }

    /// <summary>
    /// 实名：年龄段折扣规则（[0-12,0.5][60-100,0.5]，不设置阶段的按默认价格）
    /// </summary>
    public string AgeDiscountRules { get; set; }

    /// <summary>
    /// 实名：是否绑定电话
    /// </summary>
    public bool RealNamePhoneBind { get; set; }

    /// <summary>
    /// 实名：是否每张实名都需要提供一个电话
    /// </summary>
    public bool RequireBindPhoneEachRealName { get; set; }

    /// <summary>
    /// 是否次数卡片，次卡
    /// </summary>
    public bool IsTimesCard { get; set; }

    /// <summary>
    /// 次数值，次卡总次数
    /// </summary>
    public int TimesValue { get; set; }

    /// <summary>
    /// 卡券显示的金额/数量（票面显示数值）
    /// 卡片除了可以按次数使用，还可以一次性抵用某一活动金额
    /// </summary>
    public decimal CouponsAmount { get; set; }

    /// <summary>
    /// 卡券logo（或者小图标）
    /// </summary>
    public int LogoPictureId { get; set; }

    /// <summary>
    /// 卡券背景图
    /// </summary>
    public int BackgroundPictureId { get; set; }

    /// <summary>
    /// 核销码需要密码（密码通过关注的公众号或短信发放）
    /// </summary>
    public bool NeedPassWord { get; set; }

    /// <summary>
    /// 是否可以拆分分开使用
    /// </summary>
    public bool EnableSplit { get; set; }

    /// <summary>
    /// 购买后立刻可用
    /// </summary>
    public bool StartDateImmediately { get; set; }

    /// <summary>
    /// 是否使用固定开始有效期
    /// </summary>
    public bool UseFixedStartDateUtc { get; set; }

    /// <summary>
    /// 购买后有效期开始延迟天数（如果填写小数，则按下单时间转换为准确的分钟数）
    /// </summary>
    public decimal StartDateDelayDays { get; set; }

    /// <summary>
    /// 可以设置固定的开始时间（最早使用时间）
    /// </summary>
    public DateTime? StartDateUtc { get; set; }

    /// <summary>
    /// 是否使用固定结束时间
    /// </summary>
    public bool UseFixedEndDateUtc { get; set; }

    /// <summary>
    /// 购买后有效期结束延迟天数（如果填写小数，则按下单时间转换为准确的分钟数）
    /// </summary>
    public decimal EndDateDelayDays { get; set; }

    /// <summary>
    /// 可以设置固定的结束时间（最晚使用时间）
    /// </summary>
    public DateTime? EndDateUtc { get; set; }

    /// <summary>
    /// 购买后默认状态：0=待审核/1=有效/2=无效
    /// </summary>
    public int DefaultAssetsStatusId { get; set; }

    /// <summary>
    /// 本券使用最低消费金额限制
    /// </summary>
    public decimal MinConsumeAmount { get; set; }

    /// <summary>
    /// 是否允许转卖
    /// </summary>
    public bool EnableReSell { get; set; }

    /// <summary>
    /// 最大允许转卖次数
    /// </summary>
    public int MaxReSellCount { get; set; }

    /// <summary>
    /// 如果卡券有有效期，则转卖后不更新有效期
    /// 如果卡券没有有效期，转卖后设置为购买当天后多少天内必须使用。
    /// </summary>
    public int ReSellUsageEndDays { get; set; }

    /// <summary>
    /// 转卖允许最低折扣（降价最低折扣，如：20，表示降价80%以内）
    /// </summary>
    public decimal MinPercentReSell { get; set; }

    /// <summary>
    /// 转卖允许最高幅度（涨价最高比例：如：20，表示涨价20%以内）
    /// </summary>
    public decimal MaxPercentReSell { get; set; }

    /// <summary>
    /// 出票：是否需要出票（针对门票机票等需要打印实际票的订单）
    /// </summary>
    public bool NeedIssued { get; set; }

    /// <summary>
    /// 退款：允许出票后可退款
    /// </summary>
    public bool EnableIssuedReturn { get; set; }

    /// <summary>
    /// 是否需要电话预定（购买后需要单独电话预定）
    /// </summary>
    public bool NeedBooking { get; set; }

    /// <summary>
    /// 指定到Store
    /// </summary>
    public int LimitToStoreId { get; set; }

    /// <summary>
    /// 指定到VendorStore
    /// </summary>
    public int LimitToVendorStoreId { get; set; }

    /// <summary>
    /// 指定到Brand
    /// </summary>
    public int LimitToBrandId { get; set; }

    /// <summary>
    /// 指定到Product
    /// </summary>
    public int LimitToProductId { get; set; }


    /// <summary>
    /// 卡券类型ID
    /// </summary>
    public CouponsType CouponsType
    {
        get => (CouponsType)CouponsTypeId;
        set => CouponsTypeId = (int)value;
    }

}
