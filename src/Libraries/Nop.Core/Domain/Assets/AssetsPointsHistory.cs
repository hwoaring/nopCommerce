using Nop.Core.Domain.Common;

namespace Nop.Core.Domain.Assets;

/// <summary>
/// 积分资产
/// </summary>
public partial class AssetsPointsHistory : BaseEntity, ISoftDeletedEntity
{
    /// <summary>
    /// 系统积分结算流水号（本系统内）
    /// </summary>
    public long SerialNumber { get; set; }

    /// <summary>
    /// 备用
    /// </summary>
    public int StoreId { get; set; }

    /// <summary>
    /// 资金属于零售商店铺ID/否则属于平台公用
    /// </summary>
    public int VendorStoreId { get; set; }

    /// <summary>
    /// 对应人员ID
    /// </summary>
    public int CustomerId { get; set; }

    /// <summary>
    /// 操作员ID
    /// </summary>
    public int OperatorCustomerId { get; set; }

    /// <summary>
    /// 创建方式
    /// </summary>
    public int AssetsCreatedTypeId { get; set; }

    /// <summary>
    /// 是否收入（收支标识：收入还是支出）
    /// </summary>
    public bool IsIncome { get; set; }

    /// <summary>
    /// Gets or sets the points redeemed/added
    /// </summary>
    public int Points { get; set; }

    /// <summary>
    /// Gets or sets the points balance
    /// </summary>
    public int? PointsBalance { get; set; }

    /// <summary>
    /// Gets or sets the used amount
    /// </summary>
    public decimal UsedAmount { get; set; }

    /// <summary>
    /// Gets or sets the message
    /// </summary>
    public string Message { get; set; }

    /// <summary>
    /// Gets or sets the date and time of instance creation
    /// </summary>
    public DateTime CreatedOnUtc { get; set; }

    /// <summary>
    /// Gets or sets the date and time when the points will no longer be valid
    /// </summary>
    public DateTime? EndDateUtc { get; set; }

    /// <summary>
    /// Gets or sets the number of valid points that have not yet spent (only for positive amount of points)
    /// </summary>
    public int? ValidPoints { get; set; }

    /// <summary>
    /// Used with order
    /// </summary>
    public Guid? UsedWithOrder { get; set; }

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
    /// 指定到属于某品牌的店铺都可使用（如红旗连锁，舞东风）
    /// </summary>
    public int LimitToVendorStoreBrandId { get; set; }

    /// <summary>
    /// 指定到Product
    /// </summary>
    public int LimitToProductId { get; set; }

    /// <summary>
    /// hash值，校验码，验证码本条数据的：收入+消费+余额+生成日期的hash值，避免人为修改数据
    /// 收入+消费+余额+生成日期等生产的hash值（校验规则暂未定）
    /// </summary>
    public string HashCode { get; set; }

    /// <summary>
    /// 锁定原因备注
    /// </summary>
    public string LockRemark { get; set; }

    /// <summary>
    /// 是否锁定
    /// </summary>
    public bool Locked { get; set; }

    /// <summary>
    /// 删除
    /// </summary>
    public bool Deleted { get; set; }
}
