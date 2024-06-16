using Nop.Core.Domain.Common;

namespace Nop.Core.Domain.AntiFake;

/// <summary>
/// 防伪码（小码或盖内码）奖金派发清单（领取清单）
/// </summary>
public partial class AntiFakeRewardsPaid : BaseEntity, ISoftDeletedEntity
{
    /// <summary>
    /// 防伪码（小码或盖内码）奖金（或产品）详细信息ID
    /// </summary>
    public int AntiFakeRewardsCodeId { get; set; }

    /// <summary>
    /// 领取券的人ID
    /// </summary>
    public int CustomerId { get; set; }

    /// <summary>
    /// 电话号码
    /// </summary>
    public string PhoneNumber { get; set; }

    /// <summary>
    /// 领取金额或数量
    /// </summary>
    public decimal Amount { get; set; }

    /// <summary>
    /// 商户订单号
    /// </summary>
    public string OutTradeNo { get; set; }

    /// <summary>
    /// 三方支付返回订单号
    /// （现金支付时存储三方交易ID，卡券发放时存储资产卡券流水号SerialNumber）
    /// </summary>
    public string TransactionId { get; set; }

    /// <summary>
    /// 领取人地址的区划代码ID
    /// </summary>
    public int RegionCodeId { get; set; }

    /// <summary>
    /// 领取人经度值
    /// </summary>
    public decimal? Longitude { get; set; }

    /// <summary>
    /// 领取人纬度值
    /// </summary>
    public decimal? Latitude { get; set; }

    /// <summary>
    /// 创建时间/奖励发放时间
    /// </summary>
    public DateTime CreatDateOnUtc { get; set; }

    /// <summary>
    /// 支付状态（现金支付或卡券发放状态）
    /// false=未支付
    /// true=成功支付
    /// </summary>
    public bool RewardsHasPaid { get; set; }

    /// <summary>
    /// 是否导购领取
    /// </summary>
    public bool IsGuider { get; set; }

    /// <summary>
    /// 删除
    /// </summary>
    public bool Deleted { get; set; }
}
