using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc.Rendering;
using Nop.Web.Framework.Mvc.ModelBinding;
using Nop.Web.Framework.Models;

namespace Nop.Web.Areas.Admin.Models.Weixin
{
    /// <summary>
    /// Represents a Supplier Shop Search Model
    /// </summary>
    public partial record SupplierShopSearchModel : BaseSearchModel
    {
        #region Ctor

        public SupplierShopSearchModel()
        {
            AvailableSuppliers = new List<SelectListItem>();
        }

        #endregion

        #region Properties

        [NopResourceDisplayName("Admin.Suppliers.SupplierShops.List.SupplierId")]
        public int SupplierId { get; set; }
        public IList<SelectListItem> AvailableSuppliers { get; set; }

        [NopResourceDisplayName("Admin.Suppliers.SupplierShops.List.SearchName")]
        public string SearchName { get; set; }

        [NopResourceDisplayName("Admin.Suppliers.SupplierShops.List.SearchContact")]
        public string SearchContact { get; set; }

        [NopResourceDisplayName("Admin.Suppliers.SupplierShops.List.SearchContactNumber")]
        public string SearchContactNumber { get; set; }

        #endregion
    }
}