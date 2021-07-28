﻿using Nop.Core.Configuration;

namespace Nop.Core.Domain.Vendors
{
    /// <summary>
    /// Vendor settings
    /// </summary>
    public class VendorSettings : ISettings
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
        /// Vendor 父级查询次数
        /// </summary>
        public int VendorParentLevel { get; set; }

        /// <summary>
        /// 指定Vendor子级查询次数
        /// </summary>
        public int VendorChildrenLevel { get; set; }

        /// <summary>
        /// 自助申请是否需要Vendor邀请才能申请
        /// </summary>
        public bool NeedVendorInvite { get; set; }

        /// <summary>
        /// 自助申请是否强制需要邀请码
        /// </summary>
        public bool InviteCodeEnable { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether vendors are allowed to import products
        /// </summary>
        public bool AllowVendorsToImportProducts { get; set; }
    }
}
