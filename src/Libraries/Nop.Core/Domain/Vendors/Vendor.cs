using Nop.Core.Domain.Common;
using Nop.Core.Domain.Localization;
using Nop.Core.Domain.Seo;

namespace Nop.Core.Domain.Vendors;

/// <summary>
/// Represents a vendor
/// </summary>
public partial class Vendor : BaseEntity, ILocalizedEntity, ISlugSupported, ISoftDeletedEntity
{
    /// <summary>
    /// Gets or sets the name
    /// </summary>
    public string Name { get; set; }

    /// <summary>
    /// Gets or sets the email
    /// </summary>
    public string Email { get; set; }

    /// <summary>
    /// Gets or sets the description
    /// </summary>
    public string Description { get; set; }

    /// <summary>
    /// Gets or sets the picture identifier
    /// </summary>
    public int PictureId { get; set; }

    /// <summary>
    /// Gets or sets the address identifier
    /// </summary>
    public int AddressId { get; set; }

    /// <summary>
    /// Gets or sets the admin comment
    /// </summary>
    public string AdminComment { get; set; }

    /// <summary>
    /// Gets or sets a value indicating whether the entity is active
    /// </summary>
    public bool Active { get; set; }

    /// <summary>
    /// Gets or sets a value indicating whether the entity has been deleted
    /// </summary>
    public bool Deleted { get; set; }

    /// <summary>
    /// Gets or sets the display order
    /// </summary>
    public int DisplayOrder { get; set; }

    /// <summary>
    /// Gets or sets the meta keywords
    /// </summary>
    public string MetaKeywords { get; set; }

    /// <summary>
    /// Gets or sets the meta description
    /// </summary>
    public string MetaDescription { get; set; }

    /// <summary>
    /// Gets or sets the meta title
    /// </summary>
    public string MetaTitle { get; set; }

    /// <summary>
    /// Gets or sets the page size
    /// </summary>
    public int PageSize { get; set; }

    /// <summary>
    /// Gets or sets a value indicating whether customers can select the page size
    /// </summary>
    public bool AllowCustomersToSelectPageSize { get; set; }

    /// <summary>
    /// Gets or sets the available customer selectable page size options
    /// </summary>
    public string PageSizeOptions { get; set; }

    /// <summary>
    /// Gets or sets a value indicating whether the price range filtering is enabled
    /// </summary>
    public bool PriceRangeFiltering { get; set; }

    /// <summary>
    /// Gets or sets the "from" price
    /// </summary>
    public decimal PriceFrom { get; set; }

    /// <summary>
    /// Gets or sets the "to" price
    /// </summary>
    public decimal PriceTo { get; set; }

    /// <summary>
    /// Gets or sets a value indicating whether the price range should be entered manually
    /// </summary>
    public bool ManuallyPriceRange { get; set; }



    #region === 扩展属性 ===

    /// <summary>
    /// 超级管理员，创建人ID、总权限管理人ID（备用）
    /// </summary>
    public int CreatedCustomerId { get; set; }

    /// <summary>
    /// 从哪个Store创建（备用）
    /// </summary>
    public int CreatedInStoreId { get; set; }

    /// <summary>
    /// 创建时间
    /// </summary>
    public DateTime? CreatOnUtc { get; set; }

    /// <summary>
    /// 是否有个人统计表格（在Form中区分由vendor推荐的客户，可用于销售现场登记或邀请登记）
    /// </summary>
    public bool EnableVendorForm { get; set; }

    /// <summary>
    /// 是否允许调整自己的产品价格
    /// </summary>
    public bool ManageOwnProductPrices { get; set; }

    /// <summary>
    /// 对外展示统一加密id（URL参数）
    /// </summary>
    public long UnifiedId { get; set; }

    /// <summary>
    /// Vendor推荐人的vendorid号，上级代理Id号（备用）
    /// </summary>
    public int ReferrerVendorId { get; set; }

    /// <summary>
    /// Vendor类型：代理，烟酒门市，终端，个人团购渠道
    /// </summary>
    public int VendorTypeId { get; set; }

    /// <summary>
    /// 昵称（自定义个人对外分享的名称）
    /// </summary>
    public string NickName { get; set; }

    /// <summary>
    /// 联系电话
    /// </summary>
    public string PhoneNumber { get; set; }

    /// <summary>
    /// 供应商等级（分销商等级）
    /// </summary>
    public int Level { get; set; }

    /// <summary>
    /// 代理商有货时候仓库地址
    /// </summary>
    public int VendorWarehouseId { get; set; }

    /// <summary>
    /// 是否门店导购员：给门店导购发送特殊推销推广奖励信息，或者导购扫码（扫密码或盖内码）
    /// 导购将获得推销的开瓶奖励
    /// </summary>
    public bool ShoppingGuide { get; set; }

    /// <summary>
    /// 是否有线下门店
    /// </summary>
    public bool HasVendorStore { get; set; }

    /// <summary>
    /// 个人销售二维码
    /// </summary>
    public int QrcodePictureId { get; set; }

    /// <summary>
    /// 个人销售在微信官方平台的永久二维码数字ID（一共10万个，一个人最多分配一次）
    /// </summary>
    public int LimitQrcodeId { get; set; }

    /// <summary>
    /// 是否允许防伪码跟踪信息换入（防伪码设置成为自己的联系方式）
    /// </summary>
    public bool EnableAntiFakeIn { get; set; }

    /// <summary>
    /// 是否允许防伪码跟踪信息换出（允许他人申请防伪码修改他人的联系方式）
    /// </summary>
    public bool EnableAntiFakeOut { get; set; }

    /// <summary>
    /// 是否自动允许申请人申请更改联系方式，不需要源所有人审核（下级分销人申请）
    /// </summary>
    public bool AutoAntiFakeOutToChildVendor { get; set; }

    /// <summary>
    /// 是否自动允许源拥有人申请更改联系方式，不需要现用有人审核（防止源拥有人悄悄设置为本人联系信息）
    /// </summary>
    public bool AutoAntiFakeOutToParentVendor { get; set; }

    /// <summary>
    /// 审核通过
    /// </summary>
    public bool Approved { get; set; }

    /// <summary>
    /// 锁定（特殊原因，后台锁定）
    /// </summary>
    public bool Locked { get; set; }

    /// <summary>
    /// 个人控制：可以自己打开和关闭Vendor功能
    /// </summary>
    public bool CloseVendor { get; set; }

    /// <summary>
    /// 个人控制：公开展示，或直接显示推荐的联系方式,客户可以直接联系，表明自己是供应商
    /// </summary>
    public bool DisplayContactInfo { get; set; }

    /// <summary>
    /// 个人信息展示样式
    /// </summary>
    public int ContactInfoStyle { get; set; }

    #endregion

}
