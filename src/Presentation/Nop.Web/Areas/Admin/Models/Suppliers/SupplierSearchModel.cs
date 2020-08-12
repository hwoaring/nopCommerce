using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc.Rendering;
using Nop.Web.Framework.Mvc.ModelBinding;
using Nop.Web.Framework.Models;

namespace Nop.Web.Areas.Admin.Models.Weixin
{
    /// <summary>
    /// Represents a Supplier Search Model
    /// </summary>
    public partial class SupplierSearchModel : BaseSearchModel
    {

        #region Properties

        [NopResourceDisplayName("Admin.Suppliers.Suppliers.List.SearchName")]
        public string SearchName { get; set; }

        [NopResourceDisplayName("Admin.Suppliers.Suppliers.List.SearchContact")]
        public string SearchContact { get; set; }

        [NopResourceDisplayName("Admin.Suppliers.Suppliers.List.SearchContactNumber")]
        public string SearchContactNumber { get; set; }

        #endregion
    }
}