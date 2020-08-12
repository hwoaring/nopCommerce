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
        QrCodeSupplierVoucherCouponListModel PrepareQrCodeSupplierVoucherCouponListModel(QrCodeSupplierVoucherCouponSearchModel searchModel, WQrCodeLimit qrCodeLimit);

        AddSupplierVoucherCouponRelatedSearchModel PrepareAddSupplierVoucherCouponRelatedSearchModel(AddSupplierVoucherCouponRelatedSearchModel searchModel);

        AddSupplierVoucherCouponRelatedCouponListModel PrepareAddSupplierVoucherCouponRelatedCouponListModel(AddSupplierVoucherCouponRelatedSearchModel searchModel);
    }
}