using System;
using System.ComponentModel.DataAnnotations;
using Nop.Web.Framework.Models;
using Nop.Web.Framework.Mvc.ModelBinding;
using Nop.Core.Domain.Weixin;

namespace Nop.Web.Areas.Admin.Models.Suppliers
{
    /// <summary>
    /// Represents a Supplier Shop Model
    /// </summary>
    public partial class SupplierShopModel : BaseNopEntityModel
    {
        #region Properties

        [NopResourceDisplayName("Admin.Suppliers.SupplierShops.Fields.SupplierId")]
        public int SupplierId { get; set; }
        public string SupplierNameString { get; set; }

        [NopResourceDisplayName("Admin.Suppliers.SupplierShops.Fields.Name")]
        public string Name { get; set; }

        [NopResourceDisplayName("Admin.Suppliers.SupplierShops.Fields.Description")]
        public string Description { get; set; }

        [NopResourceDisplayName("Admin.Suppliers.SupplierShops.Fields.Content")]
        public string Content { get; set; }

        [NopResourceDisplayName("Admin.Suppliers.SupplierShops.Fields.ImageUrl")]
        public string ImageUrl { get; set; }

        [NopResourceDisplayName("Admin.Suppliers.SupplierShops.Fields.ThumbImageUrl")]
        public string ThumbImageUrl { get; set; }

        [NopResourceDisplayName("Admin.Suppliers.SupplierShops.Fields.Country")]
        public string Country { get; set; }

        [NopResourceDisplayName("Admin.Suppliers.SupplierShops.Fields.Province")]
        public string Province { get; set; }

        [NopResourceDisplayName("Admin.Suppliers.SupplierShops.Fields.City")]
        public string City { get; set; }

        [NopResourceDisplayName("Admin.Suppliers.SupplierShops.Fields.District")]
        public string District { get; set; }

        [NopResourceDisplayName("Admin.Suppliers.SupplierShops.Fields.Address")]
        public string Address { get; set; }

        [NopResourceDisplayName("Admin.Suppliers.SupplierShops.Fields.Contact")]
        public string Contact { get; set; }

        [NopResourceDisplayName("Admin.Suppliers.SupplierShops.Fields.ContactNumber")]
        public string ContactNumber { get; set; }

        [NopResourceDisplayName("Admin.Suppliers.SupplierShops.Fields.QrCodeUrl")]
        public string QrCodeUrl { get; set; }

        [NopResourceDisplayName("Admin.Suppliers.SupplierShops.Fields.Latitude")]
        public decimal Latitude { get; set; }

        [NopResourceDisplayName("Admin.Suppliers.SupplierShops.Fields.Longitude")]
        public decimal Longitude { get; set; }

        [NopResourceDisplayName("Admin.Suppliers.SupplierShops.Fields.Precision")]
        public decimal Precision { get; set; }

        [NopResourceDisplayName("Admin.Suppliers.SupplierShops.Fields.OpenTime")]
        public string OpenTime { get; set; }

        [NopResourceDisplayName("Admin.Suppliers.SupplierShops.Fields.Notices")]
        public string Notices { get; set; }

        [NopResourceDisplayName("Admin.Suppliers.SupplierShops.Fields.Status")]
        public int Status { get; set; }

        [NopResourceDisplayName("Admin.Suppliers.SupplierShops.Fields.Published")]
        public bool Published { get; set; }

        [NopResourceDisplayName("Admin.Suppliers.SupplierShops.Fields.Deleted")]
        public bool Deleted { get; set; }

        #endregion
    }
}