
namespace Nop.Core.Domain.Vendors;

/// <summary>
/// 店铺（菜单/产品）预定功能，主要餐饮行业使用
/// </summary>
public partial class VendorStoreBookingProduct : BaseEntity
{
    /// <summary>
    /// 店铺id
    /// </summary>
    public int VendorStoreId { get; set; }

    /// <summary>
    /// 座位号ID（无座位号的，作为临时菜单）
    /// </summary>
    public int VendorStoreSeatOrderId { get; set; }

    /// <summary>
    /// 创建人ID（可以是店铺工作人员）
    /// </summary>
    public int CustomerId { get; set; }

    /// <summary>
    /// 产品ID
    /// </summary>
    public int ProductId { get; set; }

    /// <summary>
    /// 数量
    /// </summary>
    public int Count { get; set; }

    /// <summary>
    /// 产品订单备注选项，多项以逗号分开
    /// </summary>
    public string ProductOrderNoticeIdList { get; set; }

    /// <summary>
    /// 客户已确认
    /// </summary>
    public bool CustomerConfirmed { get; set; }

    /// <summary>
    /// 后台已确认
    /// </summary>
    public bool VendorStoreConfirmed { get; set; }

    /// <summary>
    /// 确认已上菜
    /// </summary>
    public bool HasArrived { get; set; }

    /// <summary>
    /// 取消（后台操作）
    /// </summary>
    public bool Canceled { get; set; }

    /// <summary>
    /// 客户创建时间（确认时间）
    /// </summary>
    public DateTime CreatedOnUtc { get; set; }
}
