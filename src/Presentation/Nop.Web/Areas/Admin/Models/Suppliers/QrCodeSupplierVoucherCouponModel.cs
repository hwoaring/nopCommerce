using System;
using System.ComponentModel.DataAnnotations;
using Nop.Web.Framework.Models;
using Nop.Web.Framework.Mvc.ModelBinding;
using Nop.Core.Domain.Suppliers;

namespace Nop.Web.Areas.Admin.Models.Suppliers
{
    /// <summary>
    /// Represents a QrCodeSupplierVoucherCouponModel
    /// </summary>
    public partial class QrCodeSupplierVoucherCouponModel : BaseNopEntityModel
    {
        #region Properties

        [NopResourceDisplayName("Admin.Weixin.QrCodeLimits.Fields.SysName")]
        public string QrCodeSysName { get; set; }

        [NopResourceDisplayName("Admin.Supplier.QrCodeLimitCoupons.Fields.SystemName")]
        public string SupplierVoucherCouponSysName { get; set; }

        [NopResourceDisplayName("Admin.Supplier.QrCodeLimitCoupons.Fields.QrCodeId")]
        public int QrCodeId { get; set; }

        [NopResourceDisplayName("Admin.Supplie.QrCodeLimitCoupons.Fields.SupplierVoucherCouponId")]
        public int SupplierVoucherCouponId { get; set; }

        [NopResourceDisplayName("Admin.Supplier.QrCodeLimitCoupons.Fields.QrcodeLimit")]
        public bool QrcodeLimit { get; set; }

        [NopResourceDisplayName("Admin.Supplier.QrCodeLimitCoupons.Fields.Published")]
        public bool Published { get; set; }

        [NopResourceDisplayName("Admin.Supplier.QrCodeLimitCoupons.Fields.StartDateTime")]
        [UIHint("DateTimeNullable")]
        public DateTime? StartDateTime { get; set; }

        [NopResourceDisplayName("Admin.Supplier.QrCodeLimitCoupons.Fields.EndDateTime")]
        [UIHint("DateTimeNullable")]
        public DateTime? EndDateTime { get; set; }

        #endregion
    }
}