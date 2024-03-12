using Nop.Core.Domain.Common;

namespace Nop.Core.Domain.Vendors;

/// <summary>
/// 店铺座位订单
/// </summary>
public partial class VendorStoreSeatOrder : BaseEntity, ISoftDeletedEntity
{
    /// <summary>
    /// 店铺id
    /// </summary>
    public int VendorStoreId { get; set; }

    /// <summary>
    /// 默认为0，如果是预定订单则是预定单号ID
    /// </summary>
    public int VendorStoreBookingSeatId { get; set; }

    /// <summary>
    /// 消费人ID
    /// 如果VendorStoreBookingSeatId为0，这里可以再次绑定订单所属联系人，
    /// 便于添加发票信息和查看个人消费历史
    /// 通过会员卡信息查看联系电话等。
    /// </summary>
    public int CustomerId { get; set; }

    /// <summary>
    /// 添加该单的客服ID
    /// </summary>
    public int OperateCustomerId { get; set; }

    /// <summary>
    /// 确认的座位号
    /// </summary>
    public int VendorStoreSeatId { get; set; }

    /// <summary>
    /// 用餐时间轮次（0=未确定，早=1，中=2，3=晚）
    /// </summary>
    public int SeatRound { get; set; }

    /// <summary>
    /// 点餐密码
    /// </summary>
    public int OrderPassword { get; set; }

    /// <summary>
    /// 开始用餐时间
    /// </summary>
    public DateTime StartDateOnUtc { get; set; }

    /// <summary>
    /// 就餐人数
    /// </summary>
    public int Count { get; set; }

    /// <summary>
    /// 已收定金或金额
    /// </summary>
    public decimal ReceivedAmount { get; set; }

    /// <summary>
    /// 应付金额
    /// </summary>
    public decimal OleAmount { get; set; }

    /// <summary>
    /// 预约优惠（预定的享受优惠金额）
    /// </summary>
    public decimal BookingAdjustAmount { get; set; }

    /// <summary>
    /// 现金抵用券使用（抵扣）
    /// </summary>
    public decimal CoupondAdjustAmount { get; set; }

    /// <summary>
    /// 其他调整金额
    /// </summary>
    public decimal AdjustAmount { get; set; }

    /// <summary>
    /// 实付金额
    /// </summary>
    public decimal Amount { get; set; }

    /// <summary>
    /// 佣金金额（有推荐人，有佣金奖励政策的时候）
    /// </summary>
    public decimal CommissionAmount { get; set; }

    /// <summary>
    /// 发票开票信息
    /// </summary>
    public string InvoiceInfo { get; set; }

    /// <summary>
    /// 发票图
    /// </summary>
    public int InvoicePictureId { get; set; }

    /// <summary>
    /// 是否预定订单（否则为现场订单）
    /// </summary>
    public bool BookingOrder { get; set; }

    /// <summary>
    /// 是否已开始用餐
    /// </summary>
    public bool Started { get; set; }

    /// <summary>
    /// 是否已结账
    /// </summary>
    public bool Checkouted { get; set; }

    /// <summary>
    /// 佣金已结算
    /// </summary>
    public bool CommissionBalanced { get; set; }

    /// <summary>
    /// 是否有发票申请
    /// </summary>
    public bool InvoiceApplied { get; set; }

    /// <summary>
    /// 是否已开发票
    /// </summary>
    public bool InvoiceIssued { get; set; }

    /// <summary>
    /// 是否已领取或已经发给对方
    /// </summary>
    public bool InvoiceReceived { get; set; }

    /// <summary>
    /// 删除
    /// </summary>
    public bool Deleted { get; set; }

    /// <summary>
    /// 创建时间
    /// </summary>
    public DateTime CreatOnUtc { get; set; }
}
