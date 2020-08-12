using System;
using System.ComponentModel.DataAnnotations;
using Nop.Web.Framework.Models;
using Nop.Web.Framework.Mvc.ModelBinding;
using Nop.Core.Domain.Weixin;

namespace Nop.Web.Areas.Admin.Models.Suppliers
{
    /// <summary>
    /// Represents a AddSupplierVoucherCouponRelatedCouponModel
    /// </summary>
    public partial class AddSupplierVoucherCouponRelatedCouponModel : BaseNopEntityModel
    {
        #region Properties

        [NopResourceDisplayName("Admin.Suppliers.SupplierVoucherCoupons.Fields.SystemName")]
        public string SystemName { get; set; }

        [NopResourceDisplayName("Admin.Suppliers.SupplierVoucherCoupons.Fields.Name")]
        public string Name { get; set; }

        [NopResourceDisplayName("Admin.Suppliers.SupplierVoucherCoupons.Fields.SupplierId")]
        public int SupplierId { get; set; }
        public string SupplierNameString { get; set; }

        [NopResourceDisplayName("Admin.Suppliers.SupplierVoucherCoupons.Fields.SupplierShopId")]
        public int SupplierShopId { get; set; }
        public string SupplierShopNameString { get; set; }

        [NopResourceDisplayName("Admin.Suppliers.SupplierVoucherCoupons.Fields.AssetTypeId")]
        public int AssetTypeId { get; set; }
        public string AssetTypeNameString { get; set; }

        [NopResourceDisplayName("Admin.Suppliers.SupplierVoucherCoupons.Fields.Published")]
        public bool Published { get; set; }

        [NopResourceDisplayName("Admin.Suppliers.SupplierVoucherCoupons.Fields.Locked")]
        public bool Locked { get; set; }

        #endregion
    }
}