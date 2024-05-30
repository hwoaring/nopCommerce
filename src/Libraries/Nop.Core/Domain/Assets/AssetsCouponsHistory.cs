using Nop.Core.Domain.Common;
using Nop.Core.Domain.Coupons;

namespace Nop.Core.Domain.Assets;

/// <summary>
/// 卡券资产
/// </summary>
public partial class AssetsCouponsHistory : BaseEntity, ISoftDeletedEntity
{
    /// <summary>
    /// 备用
    /// </summary>
    public int StoreId { get; set; }

    /// <summary>
    /// 对应人员ID
    /// </summary>
    public int CustomerId { get; set; }

    /// <summary>
    /// 本单系统内部交易流水号（供应商结算流水号）
    /// </summary>
    public long SerialNumber { get; set; }

    /// <summary>
    /// 操作员ID
    /// </summary>
    public int OperatorCustomerId { get; set; }

    /// <summary>
    /// 创建方式
    /// </summary>
    public int AssetsCreatedTypeId { get; set; }

    /// <summary>
    /// 卡券类型ID
    /// </summary>
    public int CouponsTypeId { get; set; }

    /// <summary>
    /// 卡券名称
    /// </summary>
    public string Name { get; set; }

    /// <summary>
    /// 使用规则（使用限制信息，比如：周几可使用，节假日是否可用）
    /// </summary>
    public string UsageRulesContent { get; set; }

    /// <summary>
    /// 内容
    /// </summary>
    public string Content { get; set; }

    /// <summary>
    /// 卡号/核销码
    /// </summary>
    public string CardNumber { get; set; }

    /// <summary>
    /// 核销码需要密码（密码通过关注的公众号或短信发放）
    /// </summary>
    public bool NeedPassWord { get; set; }

    /// <summary>
    /// 核销密码/兑换密码
    /// </summary>
    public string PassWord { get; set; }

    /// <summary>
    /// 核销密码/兑换密码过期时间
    /// </summary>
    public DateTime? PassWordExpireDateUtc { get; set; }

    /// <summary>
    /// 是否产品兑换券（抵用券的一种特殊形式，兑换指定规格的指定产品，需要绑定到指定产品ID）
    /// </summary>
    public bool ExchangeVoucher { get; set; }

    /// <summary>
    /// 兑换单位：瓶、箱，张，个等
    /// </summary>
    public string ExchangeUnit { get; set; }

    /// <summary>
    /// DeliverCustomerId ，发货人ID，或者线下兑换人ID，用于记录谁发货货款结算给谁
    /// （卡券资产中也有兑换人，防伪码奖励中也有兑换人，怎么把3处兑换人合并到一张表）
    /// 同一订单，可能有不同的发货人
    /// </summary>
    public int DeliverCustomerId { get; set; }

    /// <summary>
    /// 线下取货，代发货：取货日期
    /// 同一订单，可能有不同的发货人
    /// </summary>
    public DateTime PickupDateOnUtc { get; set; }

    /// <summary>
    /// 卡券logo（或者小图标）
    /// </summary>
    public int LogoPictureId { get; set; }

    /// <summary>
    /// 卡券背景图
    /// </summary>
    public int BackgroundPictureId { get; set; }

    /// <summary>
    /// 卡券购买价格（现价）
    /// </summary>
    public decimal Price { get; set; }

    /// <summary>
    /// 卡券原价
    /// </summary>
    public decimal OldPrice { get; set; }

    /// <summary>
    /// 是否绑定证件使用
    /// </summary>
    public bool LimitToBindID { get; set; }

    /// <summary>
    /// 绑定的证件类型（Common中的IDType）
    /// </summary>
    public int BindIDTypeId { get; set; }

    /// <summary>
    /// 国籍（身份证默认为中国）
    /// </summary>
    public string BindIDNationality { get; set; }

    /// <summary>
    /// 绑定的身份证号码（要求实名的）
    /// </summary>
    public string BindIDNumber { get; set; }

    /// <summary>
    /// 绑定的身份证姓名（要求实名的）
    /// </summary>
    public string BindIDName { get; set; }

    /// <summary>
    /// 绑定的电话、绑定的联系方式
    /// </summary>
    public string BindPhone { get; set; }

    /// <summary>
    /// 是否次数卡片，次卡
    /// </summary>
    public bool IsTimesCard { get; set; }

    /// <summary>
    /// 次卡总次数
    /// </summary>
    public int TimesValue { get; set; }

    /// <summary>
    /// 次卡剩余次数
    /// </summary>
    public int RemainTimesValue { get; set; }

    /// <summary>
    /// 卡券显示的金额/数量（票面显示数值）
    /// </summary>
    public decimal CouponsAmount { get; set; }

    /// <summary>
    /// 销售金额（客户购买实际支付金额，不显示）
    /// </summary>
    public decimal SalesAmount { get; set; }

    /// <summary>
    /// 结算金额（向供应商结算金额，不显示），需要减去佣金金额
    /// </summary>
    public decimal SettlementAmount { get; set; }

    /// <summary>
    /// 资产使用方式（线下消费，变卖/转让/转卖，兑换，抽奖）
    /// </summary>
    public int AssetsUsedTypeId { get; set; }

    /// <summary>
    /// 已经使用金额/单次使用或可拆分分开使用记录
    /// </summary>
    public decimal UsedAmount { get; set; }

    /// <summary>
    /// 已使用次数
    /// </summary>
    public int UsedCounts { get; set; }

    /// <summary>
    /// 针对分享的佣金金额（向供应商结算前，需要减去）
    /// </summary>
    public decimal CommissionAmount { get; set; }

    /// <summary>
    /// 佣金是否卡券形式，否则是现金形式（卡券形式的现金券也可以限定使用商家：如红旗连锁，舞东风等）
    /// </summary>
    public decimal CommissionAmountAsCoupons { get; set; }

    /// <summary>
    /// 推荐人ID（针对分享返佣使用）
    /// </summary>
    public int ReferrerCustomerId { get; set; }

    /// <summary>
    /// 佣金Commission结算到个人现金资产结算ID
    /// </summary>
    public int AssetsCashsHistoryId { get; set; }

    /// <summary>
    /// 是否可以拆分分开使用
    /// </summary>
    public bool EnableSplit { get; set; }

    /// <summary>
    /// 使用固定的使用时间（如门票等必须确定使用时间
    /// 确定的时间使用StartDateUtc和EndDateUtc记录，两个日期为同一天
    /// 分别是当日的0:0:0秒和23：59：59秒，如果有下班时间的，结束时间记为下班时间
    /// </summary>
    public bool UseFixedUsageDate { get; set; }

    /// <summary>
    /// 开始时间
    /// </summary>
    public DateTime? StartDateUtc { get; set; }

    /// <summary>
    /// 结束时间
    /// </summary>
    public DateTime? EndDateUtc { get; set; }

    /// <summary>
    /// 创建时间
    /// </summary>
    public DateTime CreatedOnUtc { get; set; }

    /// <summary>
    /// 是否已使用/核销
    /// </summary>
    public bool Used { get; set; }

    /// <summary>
    /// 核销/验证人员ID（没有绑定到店铺使用的券，结算时结算到验证人ID账户名下）
    /// 绑定店铺的：验证后结算到VendorStore店铺下。
    /// </summary>
    public int CheckCustomerId { get; set; }

    /// <summary>
    /// 使用时间/核销时间
    /// </summary>
    public DateTime? UsedDateUtc { get; set; }

    /// <summary>
    /// 状态：0=待审核/1=有效/2=无效
    /// </summary>
    public int AssetsStatusId { get; set; }

    /// <summary>
    /// 是否可退票
    /// </summary>
    public bool EnableRefund { get; set; }

    /// <summary>
    /// 未使用自动退票/过期可以退票
    /// </summary>
    public bool EnableExpiredRefund { get; set; }

    /// <summary>
    /// 是否已退款或退票
    /// </summary>
    public bool Refunded { get; set; }

    /// <summary>
    /// 最晚可退款时间
    /// </summary>
    public DateTime? LatestRefundDateUtc { get; set; }

    /// <summary>
    /// 过期退票时间（过期几天后可退）
    /// </summary>
    public DateTime? ExpiredRefundDateUtc { get; set; }

    /// <summary>
    /// 退款时间
    /// </summary>
    public DateTime? RefundDateUtc { get; set; }

    /// <summary>
    /// 退款原因
    /// </summary>
    public string RefundReason { get; set; }

    /// <summary>
    /// 本券使用最低消费金额限制
    /// </summary>
    public decimal MinConsumeAmount { get; set; }

    /// <summary>
    /// 是否需要出票（针对门票机票等需要打印实际票的订单）
    /// </summary>
    public bool NeedIssued { get; set; }

    /// <summary>
    /// 是否允许出票后可退
    /// </summary>
    public bool EnableIssuedReturn { get; set; }

    /// <summary>
    /// 是否已出票（针对门票机票等需要打印实际票的订单）
    /// </summary>
    public bool Issued { get; set; }

    /// <summary>
    /// 实际出票票号
    /// </summary>
    public string IssuedCardNumber { get; set; }

    /// <summary>
    /// 券使用后获得的积分
    /// </summary>
    public int Points { get; set; }

    /// <summary>
    /// 通过哪个外部实体ID创建（主要用于分享赚取的广告费时，记录SharePageRecords的ID值）
    /// 筛选ID时需要配合获取来源字段进行筛选
    /// </summary>
    public int CreatedWithEntityId { get; set; }

    /// <summary>
    /// 通过哪个订单创建/获得
    /// </summary>
    public Guid? CreatedWithOrder { get; set; }

    /// <summary>
    /// 通过哪个订单产品创建/获得
    /// </summary>
    public Guid? CreatedWithOrderItem { get; set; }

    /// <summary>
    /// 通过哪个订单使用/消费
    /// </summary>
    public Guid? UsedWithOrder { get; set; }

    /// <summary>
    /// 通过哪个订单使用/消费（可以拆分使用时，记录多个消费单的单号）
    /// </summary>
    public string UsedWithOrderString { get; set; }

    /// <summary>
    /// 指定到Store
    /// </summary>
    public int LimitToStoreId { get; set; }

    /// <summary>
    /// 指定到VendorStore
    /// </summary>
    public int LimitToVendorStoreId { get; set; }

    /// <summary>
    /// 指定到指定产品品牌Brand
    /// </summary>
    public int LimitToBrandId { get; set; }

    /// <summary>
    /// 指定到Product
    /// </summary>
    public int LimitToProductId { get; set; }

    /// <summary>
    /// 摘要
    /// </summary>
    public string Remark { get; set; }

    /// <summary>
    /// hash值，校验码，验证码本条数据的：收入+消费+余额+生成日期的hash值，避免人为修改数据
    /// 收入+消费+余额+生成日期等生产的hash值（校验规则暂未定）
    /// </summary>
    public string HashCode { get; set; }

    /// <summary>
    /// 转让，转卖金额
    /// </summary>
    public decimal ReSellAmount { get; set; }

    /// <summary>
    /// 是否允许转让，转卖
    /// </summary>
    public bool EnableReSell { get; set; }

    /// <summary>
    /// 转让，转卖了多少次
    /// </summary>
    public int ReSellCount { get; set; }

    /// <summary>
    /// 转让，转卖前，原持有人ID
    /// </summary>
    public int ReSellCustomerId { get; set; }

    /// <summary>
    /// 转让，转卖时间
    /// </summary>
    public DateTime? ReSellDateOnUtc { get; set; }

    /// <summary>
    /// 是否延期发货订单，超量销售的订单（进入顺位排序等待线下资源分配）
    /// </summary>
    public bool BackOrderItem { get; set; }

    /// <summary>
    /// 锁定原因备注
    /// </summary>
    public string LockRemark { get; set; }

    /// <summary>
    /// 是否锁定
    /// </summary>
    public bool Locked { get; set; }

    /// <summary>
    /// 是否需要电话预定（购买后需要单独电话预定）
    /// </summary>
    public bool NeedBooking { get; set; }

    /// <summary>
    /// 删除
    /// </summary>
    public bool Deleted { get; set; }



    /// <summary>
    /// 卡券类型ID
    /// </summary>
    public CouponsType CouponsType
    {
        get => (CouponsType)CouponsTypeId;
        set => CouponsTypeId = (int)value;
    }

    /// <summary>
    /// 创建方式
    /// </summary>
    public AssetsCreatedType AssetsCreatedType
    {
        get => (AssetsCreatedType)AssetsCreatedTypeId;
        set => AssetsCreatedTypeId = (int)value;
    }


    /// <summary>
    /// 绑定的证件类型（Common中的IDType）
    /// </summary>
    public IDType IDType
    {
        get => (IDType)BindIDTypeId;
        set => BindIDTypeId = (int)value;
    }


    /// <summary>
    /// 状态：0=待审核/10=有效/20=无效
    /// </summary>
    public AssetsStatus AssetsStatus
    {
        get => (AssetsStatus)AssetsStatusId;
        set => AssetsStatusId = (int)value;
    }
}
