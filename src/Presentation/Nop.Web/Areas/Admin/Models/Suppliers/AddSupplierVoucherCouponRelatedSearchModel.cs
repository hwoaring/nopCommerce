using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc.Rendering;
using Nop.Web.Framework.Mvc.ModelBinding;
using Nop.Web.Framework.Models;

namespace Nop.Web.Areas.Admin.Models.Suppliers
{
    /// <summary>
    /// Represents a AddSupplierVoucherCouponRelatedSearchModel
    /// </summary>
    public partial record AddSupplierVoucherCouponRelatedSearchModel : BaseSearchModel
    {
        #region Ctor

        public AddSupplierVoucherCouponRelatedSearchModel()
        {
            AvailableSuppliers = new List<SelectListItem>();
            AvailableSupplierShops = new List<SelectListItem>();
            AvailableAssetTypes = new List<SelectListItem>();
        }

        #endregion

        #region Properties

        [NopResourceDisplayName("Admin.Suppliers.SupplierVoucherCoupons.List.SearchSystemName")]
        public string SearchSystemName { get; set; }

        [NopResourceDisplayName("Admin.Suppliers.SupplierVoucherCoupons.List.SearchSystemName")]
        public int SupplierId { get; set; }
        public IList<SelectListItem> AvailableSuppliers { get; set; }

        [NopResourceDisplayName("Admin.Suppliers.SupplierVoucherCoupons.List.SupplierShopId")]
        public int SupplierShopId { get; set; }
        public IList<SelectListItem> AvailableSupplierShops { get; set; }

        [NopResourceDisplayName("Admin.Suppliers.SupplierVoucherCoupons.List.AssetTypeId")]
        public int AssetTypeId { get; set; }
        public IList<SelectListItem> AvailableAssetTypes { get; set; }

        #endregion
    }
}