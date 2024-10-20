﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.Rendering;
using Nop.Web.Framework.Models;
using Nop.Web.Framework.Mvc.ModelBinding;
using Nop.Core.Domain.Weixin;
using Nop.Web.Areas.Admin.Models.Suppliers;

namespace Nop.Web.Areas.Admin.Models.Weixin
{
    /// <summary>
    /// Represents a QrCodeLimitModel
    /// </summary>
    public partial class QrCodeLimitModel : BaseNopEntityModel
    {
        public QrCodeLimitModel()
        {
            QrCodeLimitUserSearchModel = new QrCodeLimitUserSearchModel();
            QrCodeSupplierVoucherCouponSearchModel = new QrCodeSupplierVoucherCouponSearchModel();
            BindingSource = new QrCodeLimitBindingSourceModel();

            AvailableWQrCodeCategorys = new List<SelectListItem>();
            AvailableWQrCodeChannels = new List<SelectListItem>();
        }

        #region Properties

        [NopResourceDisplayName("Admin.Weixin.QrCodeLimits.Fields.QrCodeId")]
        public int QrCodeId { get; set; }

        [NopResourceDisplayName("Admin.Weixin.QrCodeLimits.Fields.WConfigId")]
        public int WConfigId { get; set; }

        [NopResourceDisplayName("Admin.Weixin.QrCodeLimits.Fields.WQrCodeCategoryId")]
        public int WQrCodeCategoryId { get; set; }
        public IList<SelectListItem> AvailableWQrCodeCategorys { get; set; }

        [NopResourceDisplayName("Admin.Weixin.QrCodeLimits.Fields.WQrCodeChannelId")]
        public int WQrCodeChannelId { get; set; }
        public IList<SelectListItem> AvailableWQrCodeChannels { get; set; }

        [NopResourceDisplayName("Admin.Weixin.QrCodeLimits.Fields.QrCodeActionTypeId")]
        public byte QrCodeActionTypeId { get; set; }

        [NopResourceDisplayName("Admin.Weixin.QrCodeLimits.Fields.SysName")]
        public string SysName { get; set; }
        [NopResourceDisplayName("Admin.Weixin.QrCodeLimits.Fields.Description")]
        public string Description { get; set; }

        [NopResourceDisplayName("Admin.Weixin.QrCodeLimits.Fields.Ticket")]
        public string Ticket { get; set; }
        public string QrCodeImageUrl { get; set; }

        [NopResourceDisplayName("Admin.Weixin.QrCodeLimits.Fields.Url")]
        public string Url { get; set; }

        [NopResourceDisplayName("Admin.Weixin.QrCodeLimits.Fields.SceneStr")]
        public string SceneStr { get; set; }

        [NopResourceDisplayName("Admin.Weixin.QrCodeLimits.Fields.TagIdList")]
        public string TagIdList { get; set; }

        [NopResourceDisplayName("Admin.Weixin.QrCodeLimits.Fields.FixedUse")]
        public bool FixedUse { get; set; }

        public QrCodeLimitUserSearchModel QrCodeLimitUserSearchModel { get; set; }

        public QrCodeSupplierVoucherCouponSearchModel QrCodeSupplierVoucherCouponSearchModel { get; set; }

        public QrCodeLimitBindingSourceModel BindingSource { get; set; }

        #endregion
    }
}