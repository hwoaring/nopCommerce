using Nop.Core.Domain.Common;

namespace Nop.Core.Domain.Assets;

/// <summary>
/// 分享广告资产
/// </summary>
public partial class AssetsSharesHistory : BaseEntity, ISoftDeletedEntity
{
    /// <summary>
    /// Gets or sets the store identifier in which these reward points were awarded or redeemed
    /// </summary>
    public int StoreId { get; set; }

    /// <summary>
    /// 系统广告费结算流水号（本系统内）
    /// </summary>
    public long SerialNumber { get; set; }

    /// <summary>
    /// 广告费佣金Commission结算到个人现金资产结算ID
    /// </summary>
    public int AssetsCashsHistoryId { get; set; }

    /// <summary>
    /// 属于零售商店铺ID/否则属于平台公用
    /// </summary>
    public int VendorStoreId { get; set; }

    /// <summary>
    /// Gets or sets the customer identifier
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
    /// 结算的广告费
    /// </summary>
    public decimal Amounts { get; set; }

    /// <summary>
    /// Gets or sets the points balance
    /// </summary>
    public decimal? AmountsBalance { get; set; }

    /// <summary>
    /// Gets or sets the number of valid points that have not yet spent (only for positive amount of points)
    /// </summary>
    public int? ValidAmounts { get; set; }

    /// <summary>
    /// Gets or sets the used amount
    /// </summary>
    public decimal UsedAmounts { get; set; }

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
    /// 指定到属于某品牌的店铺都可使用（如红旗连锁，舞东风）
    /// </summary>
    public int LimitToVendorStoreBrandId { get; set; }

    /// <summary>
    /// 指定到Product
    /// </summary>
    public int LimitToProductId { get; set; }

    /// <summary>
    /// 本条记录金额用完时间（使用完成一段时间后，可以删除该记录）
    /// </summary>
    public DateTime? UseUpDateOnUtc { get; set; }

    /// <summary>
    /// Gets or sets the date and time when the points will no longer be valid
    /// </summary>
    public DateTime? EndDateUtc { get; set; }

    /// <summary>
    /// 通过哪个订单创建
    /// </summary>
    public Guid? CreatedWithOrder { get; set; }

    /// <summary>
    /// 通过哪个订单消费
    /// </summary>
    public Guid? UsedWithOrder { get; set; }

    /// <summary>
    /// Gets or sets the date and time of instance creation
    /// </summary>
    public DateTime CreatedOnUtc { get; set; }

    /// <summary>
    /// Gets or sets the message
    /// </summary>
    public string Message { get; set; }

    /// <summary>
    /// hash值，校验码，验证码本条数据的：收入+消费+余额+生成日期的hash值，避免人为修改数据
    /// 收入+消费+余额+生成日期等生产的hash值（校验规则暂未定）
    /// </summary>
    public string HashCode { get; set; }

    /// <summary>
    /// 删除
    /// </summary>
    public bool Deleted { get; set; }
}
