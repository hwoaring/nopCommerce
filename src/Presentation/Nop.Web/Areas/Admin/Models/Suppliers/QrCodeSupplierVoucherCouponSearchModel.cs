using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc.Rendering;
using Nop.Web.Framework.Mvc.ModelBinding;
using Nop.Web.Framework.Models;

namespace Nop.Web.Areas.Admin.Models.Suppliers
{
    /// <summary>
    /// Represents a QrCode SupplierVoucherCoupon SearchModel
    /// </summary>
    public partial record QrCodeSupplierVoucherCouponSearchModel : BaseSearchModel
    {

        #region Properties

        public int QrCodeId { get; set; }
        public int SupplierVoucherCouponId { get; set; }
        public bool QrcodeLimit { get; set; }

        #endregion
    }
}