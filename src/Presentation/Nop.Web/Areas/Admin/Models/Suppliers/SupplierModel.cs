using System;
using System.ComponentModel.DataAnnotations;
using Nop.Web.Framework.Models;
using Nop.Web.Framework.Mvc.ModelBinding;
using Nop.Core.Domain.Weixin;

namespace Nop.Web.Areas.Admin.Models.Suppliers
{
    /// <summary>
    /// Represents a Supplier Model
    /// </summary>
    public partial record SupplierModel : BaseNopEntityModel
    {
        #region Properties

        [NopResourceDisplayName("Admin.Suppliers.Suppliers.Fields.StoreId")]
        public int StoreId { get; set; }

        [NopResourceDisplayName("Admin.Suppliers.Suppliers.Fields.Name")]
        public string Name { get; set; }

        [NopResourceDisplayName("Admin.Suppliers.Suppliers.Fields.Country")]
        public string Country { get; set; }

        [NopResourceDisplayName("Admin.Suppliers.Suppliers.Fields.Province")]
        public string Province { get; set; }

        [NopResourceDisplayName("Admin.Suppliers.Suppliers.Fields.City")]
        public string City { get; set; }

        [NopResourceDisplayName("Admin.Suppliers.Suppliers.Fields.District")]
        public string District { get; set; }

        [NopResourceDisplayName("Admin.Suppliers.Suppliers.Fields.Address")]
        public string Address { get; set; }

        [NopResourceDisplayName("Admin.Suppliers.Suppliers.Fields.Contact")]
        public string Contact { get; set; }

        [NopResourceDisplayName("Admin.Suppliers.Suppliers.Fields.ContactNumber")]
        public string ContactNumber { get; set; }

        [NopResourceDisplayName("Admin.Suppliers.Suppliers.Fields.Industry")]
        public string Industry { get; set; }

        [NopResourceDisplayName("Admin.Suppliers.Suppliers.Fields.QrCodeUrl")]
        public string QrCodeUrl { get; set; }

        [NopResourceDisplayName("Admin.Suppliers.Suppliers.Fields.BusinessLicenseUrl")]
        public string BusinessLicenseUrl { get; set; }

        [NopResourceDisplayName("Admin.Suppliers.Suppliers.Fields.BusinessLicenseCode")]
        public string BusinessLicenseCode { get; set; }

        [NopResourceDisplayName("Admin.Suppliers.Suppliers.Fields.TaxLicenseUrl")]
        public string TaxLicenseUrl { get; set; }

        [NopResourceDisplayName("Admin.Suppliers.Suppliers.Fields.TaxLicenseCode")]
        public string TaxLicenseCode { get; set; }

        [NopResourceDisplayName("Admin.Suppliers.Suppliers.Fields.StartDateTimeUtc")]
        [UIHint("DateTimeNullable")]
        public DateTime? StartDateTimeUtc { get; set; }

        [NopResourceDisplayName("Admin.Suppliers.Suppliers.Fields.EndDateTimeUtc")]
        [UIHint("DateTimeNullable")]
        public DateTime? EndDateTimeUtc { get; set; }

        [NopResourceDisplayName("Admin.Suppliers.Suppliers.Fields.CooperationTypeId")]
        public int CooperationTypeId { get; set; }

        [NopResourceDisplayName("Admin.Suppliers.Suppliers.Fields.MaxShopCount")]
        public int MaxShopCount { get; set; }

        [NopResourceDisplayName("Admin.Suppliers.Suppliers.Fields.MaxGroupCount")]
        public int MaxGroupCount { get; set; }

        [NopResourceDisplayName("Admin.Suppliers.Suppliers.Fields.MaxImageCount")]
        public int MaxImageCount { get; set; }

        [NopResourceDisplayName("Admin.Suppliers.Suppliers.Fields.MaxStaffCount")]
        public int MaxStaffCount { get; set; }

        [NopResourceDisplayName("Admin.Suppliers.Suppliers.Fields.MaxProductCount")]
        public int MaxProductCount { get; set; }

        [NopResourceDisplayName("Admin.Suppliers.Suppliers.Fields.Status")]
        public int Status { get; set; }

        [NopResourceDisplayName("Admin.Suppliers.Suppliers.Fields.IsPersonal")]
        public bool IsPersonal { get; set; }

        [NopResourceDisplayName("Admin.Suppliers.Suppliers.Fields.Published")]
        public bool Published { get; set; }

        [NopResourceDisplayName("Admin.Suppliers.Suppliers.Fields.Deleted")]
        public bool Deleted { get; set; }

        #endregion
    }
}