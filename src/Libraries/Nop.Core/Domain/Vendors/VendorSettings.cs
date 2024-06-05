using Nop.Core.Configuration;

namespace Nop.Core.Domain.Vendors;

/// <summary>
/// Vendor settings
/// </summary>
public partial class VendorSettings : ISettings
{
    /// <summary>
    /// Gets or sets the default value to use for Vendor page size options (for new vendors)
    /// </summary>
    public string DefaultVendorPageSizeOptions { get; set; }

    /// <summary>
    /// Gets or sets the value indicating how many vendors to display in vendors block
    /// </summary>
    public int VendorsBlockItemsToDisplay { get; set; }

    /// <summary>
    /// Gets or sets a value indicating whether to display vendor name on the product details page
    /// </summary>
    public bool ShowVendorOnProductDetailsPage { get; set; }

    /// <summary>
    /// Gets or sets a value indicating whether to display vendor name on the order details page
    /// </summary>
    public bool ShowVendorOnOrderDetailsPage { get; set; }

    /// <summary>
    /// Gets or sets a value indicating whether customers can contact vendors
    /// </summary>
    public bool AllowCustomersToContactVendors { get; set; }

    /// <summary>
    /// Gets or sets a value indicating whether users can fill a form to become a new vendor
    /// </summary>
    public bool AllowCustomersToApplyForVendorAccount { get; set; }

    /// <summary>
    /// Gets or sets a value indicating whether vendors have to accept terms of service during registration
    /// </summary>
    public bool TermsOfServiceEnabled { get; set; }

    /// <summary>
    /// Gets or sets a value that indicates whether it is possible to carry out advanced search in the store by vendor
    /// </summary>
    public bool AllowSearchByVendor { get; set; }

    /// <summary>
    /// Get or sets a value indicating whether vendor can edit information about itself (public store)
    /// </summary>
    public bool AllowVendorsToEditInfo { get; set; }

    /// <summary>
    /// Gets or sets a value indicating whether the store owner is notified that the vendor information has been changed
    /// </summary>
    public bool NotifyStoreOwnerAboutVendorInformationChange { get; set; }

    /// <summary>
    /// Gets or sets a maximum number of products per vendor
    /// </summary>
    public int MaximumProductNumber { get; set; }

    /// <summary>
    /// Gets or sets a value indicating whether vendors are allowed to import products
    /// </summary>
    public bool AllowVendorsToImportProducts { get; set; }

    #region

    /// <summary>
    /// 销售店铺自定义类别最大数量
    /// </summary>
    public int MaxVendorStoreCategoryCount { get; set; }

    /// <summary>
    /// 销售可以自定义的分享场景数量
    /// </summary>
    public int MaxShareSceneCount { get; set; }

    /// <summary>
    /// 销售可以自定义推广产品分组数量（便于和朋友圈分组隐私对应）
    /// </summary>
    public int MaxVendorProductGroupCount { get; set; }

    /// <summary>
    /// 销售提交第三方平台订单最大提交未审核订单量（防止恶意提交，审核后可以继续提交）
    /// </summary>
    public int MaxVendorSaleOrderCount { get; set; }

    /// <summary>
    /// 个人最大可注册个人商店数量
    /// </summary>
    public int MaxVendorStoreCount { get; set; }

    #endregion


}
