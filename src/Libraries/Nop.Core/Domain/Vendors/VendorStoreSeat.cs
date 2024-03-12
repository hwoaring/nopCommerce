using Nop.Core.Domain.Common;
using Nop.Core.Domain.Localization;
using Nop.Core.Domain.Seo;

namespace Nop.Core.Domain.Vendors;

/// <summary>
/// 店铺座位号，酒店床位号管理
/// </summary>
public partial class VendorStoreSeat : BaseEntity, ISoftDeletedEntity
{
    /// <summary>
    /// 店铺id
    /// </summary>
    public int VendorStoreId { get; set; }

    /// <summary>
    /// 房间名称/座位名称
    /// </summary>
    public string SeatName { get; set; }

    /// <summary>
    /// 座位编号
    /// </summary>
    public string SeatNumber { get; set; }

    /// <summary>
    /// 最小人数
    /// </summary>
    public int MinCount { get; set; }

    /// <summary>
    /// 最大人数
    /// </summary>
    public int MaxCount { get; set; }

    /// <summary>
    /// 座位介绍
    /// </summary>
    public string Content { get; set; }

    /// <summary>
    /// 座位照片
    /// </summary>
    public int SeatPictureId { get; set; }

    /// <summary>
    /// 座位是否接受预定
    /// </summary>
    public bool EnableBooking { get; set; }

    /// <summary>
    /// 座位是否对外展示
    /// </summary>
    public bool Displayed { get; set; }

    /// <summary>
    /// 座位是否暂停接待
    /// </summary>
    public bool Suspend { get; set; }

    /// <summary>
    /// 删除
    /// </summary>
    public bool Deleted { get; set; }
}
