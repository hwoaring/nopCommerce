using System.Collections.Generic;
using Nop.Web.Framework.Models;

namespace Nop.Web.Areas.Admin.Models.Suppliers
{
    /// <summary>
    /// Represents a AddSupplierVoucherCouponRelatedMode
    /// </summary>
    public partial record AddSupplierVoucherCouponRelatedModel : BaseNopModel
    {
        #region Ctor

        public AddSupplierVoucherCouponRelatedModel()
        {
            SelectedSupplierVoucherCouponIds = new List<int>();
        }
        #endregion

        #region Properties

        public int RelatedId { get; set; }

        public IList<int> SelectedSupplierVoucherCouponIds { get; set; }

        #endregion
    }
}