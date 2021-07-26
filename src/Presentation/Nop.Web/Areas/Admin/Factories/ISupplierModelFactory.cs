using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc.Rendering;
using Nop.Core.Domain.Weixin;
using Nop.Web.Areas.Admin.Models.Weixin;
using Nop.Core.Domain.Suppliers;
using Nop.Web.Areas.Admin.Models.Suppliers;

namespace Nop.Web.Areas.Admin.Factories
{
    /// <summary>
    /// Represents the Weixin model factory
    /// </summary>
    public partial interface ISupplierModelFactory
    {
        Task<QrCodeSupplierVoucherCouponListModel> PrepareQrCodeSupplierVoucherCouponListModelAsync(QrCodeSupplierVoucherCouponSearchModel searchModel, QrCodeLimit qrCodeLimit);

        Task<AddSupplierVoucherCouponRelatedSearchModel> PrepareAddSupplierVoucherCouponRelatedSearchModelAsync(AddSupplierVoucherCouponRelatedSearchModel searchModel);

        Task<AddSupplierVoucherCouponRelatedCouponListModel> PrepareAddSupplierVoucherCouponRelatedCouponListModelAsync(AddSupplierVoucherCouponRelatedSearchModel searchModel);
    }
}