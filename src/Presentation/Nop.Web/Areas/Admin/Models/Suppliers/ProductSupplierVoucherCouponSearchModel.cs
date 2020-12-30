using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc.Rendering;
using Nop.Web.Framework.Mvc.ModelBinding;
using Nop.Web.Framework.Models;

namespace Nop.Web.Areas.Admin.Models.Suppliers
{
    /// <summary>
    /// Represents a QrCode ProductSupplierVoucherCouponSearchModel SearchModel
    /// </summary>
    public partial record ProductSupplierVoucherCouponSearchModel : BaseSearchModel
    {

        #region Properties

        public int ProductId { get; set; }

        public int ProductAttributeValueId { get; set; }

        public int SupplierVoucherCouponId { get; set; }
        

        #endregion
    }
}