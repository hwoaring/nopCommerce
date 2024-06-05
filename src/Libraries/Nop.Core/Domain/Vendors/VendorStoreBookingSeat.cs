using Nop.Core.Domain.Common;

namespace Nop.Core.Domain.Vendors;

/// <summary>
/// 店铺（座位）预定功能
/// </summary>
public partial class VendorStoreBookingSeat : BaseEntity, ISoftDeletedEntity
{
    /// <summary>
    /// 店铺id
    /// </summary>
    public int VendorStoreId { get; set; }

    /// <summary>
    /// 预定人ID
    /// </summary>
    public int CustomerId { get; set; }

    /// <summary>
    /// 订餐推荐人（用于提成）
    /// </summary>
    public int ReferrerCustomerId { get; set; }

    /// <summary>
    /// 联系人
    /// </summary>
    public string Name { get; set; }

    /// <summary>
    /// 联系电话（确认电话后，点餐需要输入电话号码）
    /// </summary>
    public int Phone { get; set; }

    /// <summary>
    /// 内容（预定相关要求）
    /// </summary>
    public string Content { get; set; }

    /// <summary>
    /// 预定人数
    /// </summary>
    public int Count { get; set; }

    /// <summary>
    /// 预定日期和预计到店时间
    /// </summary>
    public DateTime? BookingStartDateOnUtc { get; set; }

    /// <summary>
    /// 预定座位轮次（0=未确定，早=1，中=2，3=晚）
    /// </summary>
    public int BookingSeatRound { get; set; }

    /// <summary>
    /// 最后确认时间（店铺客服和客人最后确认预约时间）
    /// </summary>
    public DateTime? LastConfirmDateUtc { get; set; }

    /// <summary>
    /// 订单取消时间
    /// </summary>
    public DateTime? CancelDateUtc { get; set; }

    /// <summary>
    /// 创建时间
    /// </summary>
    public DateTime CreatedOnUtc { get; set; }

    /// <summary>
    /// 预定确认（客服联系对方后确认预定信息）
    /// </summary>
    public bool Confirmed { get; set; }

    /// <summary>
    /// 确认到店/确认用餐（多次没有到店的列入VendorStore黑名单）
    /// </summary>
    public bool HasArrived { get; set; }

    /// <summary>
    /// 本单预定取消
    /// </summary>
    public bool Canceled { get; set; }

    /// <summary>
    /// 删除
    /// </summary>
    public bool Deleted { get; set; }
}
