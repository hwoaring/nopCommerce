using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.Rendering;
using Nop.Web.Framework.Models;
using Nop.Web.Framework.Mvc.ModelBinding;
using Nop.Core.Domain.Suppliers;

namespace Nop.Web.Areas.Admin.Models.Suppliers
{
    /// <summary>
    /// Represents a SupplierVoucherCouponModel
    /// </summary>
    public partial record SupplierVoucherCouponModel : BaseNopEntityModel
    {
        public SupplierVoucherCouponModel()
        {
            AvailablePromotionUseScopeTypes = new List<SelectListItem>();
            AvailableAssetTypes = new List<SelectListItem>();
            AvailableExpiredDateTypes = new List<SelectListItem>();

            QrCodeSupplierVoucherCouponSearchModel = new QrCodeSupplierVoucherCouponSearchModel();
            ProductSupplierVoucherCouponSearchModel = new ProductSupplierVoucherCouponSearchModel();
        }

        #region Properties

        [NopResourceDisplayName("Admin.Supplier.QrCodeLimitCoupons.Fields.SystemName")]
        public string SystemName { get; set; }

        [NopResourceDisplayName("Admin.Supplier.QrCodeLimitCoupons.Fields.Name")]
        public string Name { get; set; }

        [NopResourceDisplayName("Admin.Supplier.QrCodeLimitCoupons.Fields.Description")]
        public string Description { get; set; }

        [NopResourceDisplayName("Admin.Supplier.QrCodeLimitCoupons.Fields.Instructions")]
        public string Instructions { get; set; }

        [NopResourceDisplayName("Admin.Supplier.QrCodeLimitCoupons.Fields.ImageUrl")]
        public string ImageUrl { get; set; }

        [NopResourceDisplayName("Admin.Supplier.QrCodeLimitCoupons.Fields.SupplierId")]
        public int SupplierId { get; set; }

        [NopResourceDisplayName("Admin.Supplier.QrCodeLimitCoupons.Fields.SupplierShopId")]
        public int SupplierShopId { get; set; }

        [NopResourceDisplayName("Admin.Supplier.QrCodeLimitCoupons.Fields.PromotionUseScopeTypeId")]
        public int PromotionUseScopeTypeId { get; set; }
        public IList<SelectListItem> AvailablePromotionUseScopeTypes { get; set; }

        [NopResourceDisplayName("Admin.Supplier.QrCodeLimitCoupons.Fields.AssetTypeId")]
        public int AssetTypeId { get; set; }
        public IList<SelectListItem> AvailableAssetTypes { get; set; }

        [NopResourceDisplayName("Admin.Supplier.QrCodeLimitCoupons.Fields.MaxCardsNumber")]
        public int MaxCardsNumber { get; set; }

        [NopResourceDisplayName("Admin.Supplier.QrCodeLimitCoupons.Fields.MaxGiveNumber")]
        public int MaxGiveNumber { get; set; }

        [NopResourceDisplayName("Admin.Supplier.QrCodeLimitCoupons.Fields.LimitReceiveNumberDays")]
        public int LimitReceiveNumberDays { get; set; }

        [NopResourceDisplayName("Admin.Supplier.QrCodeLimitCoupons.Fields.LimitReceiveNumber")]
        public int LimitReceiveNumber { get; set; }

        [NopResourceDisplayName("Admin.Supplier.QrCodeLimitCoupons.Fields.LimitUsableNumber")]
        public int LimitUsableNumber { get; set; }

        [NopResourceDisplayName("Admin.Supplier.QrCodeLimitCoupons.Fields.TransferTimes")]
        public int TransferTimes { get; set; }

        [NopResourceDisplayName("Admin.Supplier.QrCodeLimitCoupons.Fields.Percentage")]
        public decimal Percentage { get; set; }

        [NopResourceDisplayName("Admin.Supplier.QrCodeLimitCoupons.Fields.MaxDiscountAmount")]
        public decimal MaxDiscountAmount { get; set; }

        [NopResourceDisplayName("Admin.Supplier.QrCodeLimitCoupons.Fields.Amount")]
        public decimal Amount { get; set; }

        [NopResourceDisplayName("Admin.Supplier.QrCodeLimitCoupons.Fields.UpAmountCanUsed")]
        public decimal UpAmountCanUsed { get; set; }

        [NopResourceDisplayName("Admin.Supplier.QrCodeLimitCoupons.Fields.UpProfitCanUsed")]
        public decimal UpProfitCanUsed { get; set; }

        [NopResourceDisplayName("Admin.Supplier.QrCodeLimitCoupons.Fields.UpCountCanUsed")]
        public int UpCountCanUsed { get; set; }

        [NopResourceDisplayName("Admin.Supplier.QrCodeLimitCoupons.Fields.ExpiredDateTypeId")]
        public int ExpiredDateTypeId { get; set; }
        public IList<SelectListItem> AvailableExpiredDateTypes { get; set; }

        [NopResourceDisplayName("Admin.Supplier.QrCodeLimitCoupons.Fields.ExpiredDays")]
        public int ExpiredDays { get; set; }

        [NopResourceDisplayName("Admin.Supplier.QrCodeLimitCoupons.Fields.StartUseDateTime")]
        [UIHint("DateTimeNullable")]
        public DateTime? StartUseDateTime { get; set; }

        [NopResourceDisplayName("Admin.Supplier.QrCodeLimitCoupons.Fields.EndUseDateTime")]
        [UIHint("DateTimeNullable")]
        public DateTime EndUseDateTime { get; set; }

        [NopResourceDisplayName("Admin.Supplier.QrCodeLimitCoupons.Fields.AutoApproved")]
        public bool AutoApproved { get; set; }

        [NopResourceDisplayName("Admin.Supplier.QrCodeLimitCoupons.Fields.GetForFree")]
        public bool GetForFree { get; set; }

        [NopResourceDisplayName("Admin.Supplier.QrCodeLimitCoupons.Fields.AutoActive")]
        public bool AutoActive { get; set; }

        [NopResourceDisplayName("Admin.Supplier.QrCodeLimitCoupons.Fields.AllowPartnerGive")]
        public bool AllowPartnerGive { get; set; }

        [NopResourceDisplayName("Admin.Supplier.QrCodeLimitCoupons.Fields.Published")]
        public bool Published { get; set; }

        [NopResourceDisplayName("Admin.Supplier.QrCodeLimitCoupons.Fields.Locked")]
        public bool Locked { get; set; }

        [NopResourceDisplayName("Admin.Supplier.QrCodeLimitCoupons.Fields.NewUserGift")]
        public bool NewUserGift { get; set; }

        [NopResourceDisplayName("Admin.Supplier.QrCodeLimitCoupons.Fields.OfflineConsume")]
        public bool OfflineConsume { get; set; }

        [NopResourceDisplayName("Admin.Supplier.QrCodeLimitCoupons.Fields.Deleted")]
        public bool Deleted { get; set; }

        [NopResourceDisplayName("Admin.Supplier.QrCodeLimitCoupons.Fields.DisplayOrder")]
        public int DisplayOrder { get; set; }

        [NopResourceDisplayName("Admin.Supplier.QrCodeLimitCoupons.Fields.CreatUserId")]
        public int CreatUserId { get; set; }

        [NopResourceDisplayName("Admin.Supplier.QrCodeLimitCoupons.Fields.StartDateTimeUtc")]
        [UIHint("DateTime")]
        public DateTime StartDateTimeUtc { get; set; }

        [NopResourceDisplayName("Admin.Supplier.QrCodeLimitCoupons.Fields.EndDateTimeUtc")]
        [UIHint("DateTime")]
        public DateTime EndDateTimeUtc { get; set; }

        [NopResourceDisplayName("Admin.Supplier.QrCodeLimitCoupons.Fields.CreatedOnUtc")]
        [UIHint("DateTime")]
        public DateTime CreatedOnUtc { get; set; }

        public QrCodeSupplierVoucherCouponSearchModel QrCodeSupplierVoucherCouponSearchModel { get; set; }

        public ProductSupplierVoucherCouponSearchModel ProductSupplierVoucherCouponSearchModel { get; set; }

        #endregion
    }
}