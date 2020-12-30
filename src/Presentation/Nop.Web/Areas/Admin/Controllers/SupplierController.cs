using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Text;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Primitives;
using Nop.Core;
using Nop.Core.Domain.Catalog;
using Nop.Core.Domain.Discounts;
using Nop.Core.Domain.Media;
using Nop.Core.Domain.Orders;
using Nop.Core.Domain.Vendors;
using Nop.Core.Domain.Suppliers;
using Nop.Core.Domain.Marketing;
using Nop.Core.Domain.Weixin;
using Nop.Core.Infrastructure;
using Nop.Services.Catalog;
using Nop.Services.Common;
using Nop.Services.Configuration;
using Nop.Services.Customers;
using Nop.Services.Discounts;
using Nop.Services.ExportImport;
using Nop.Services.Localization;
using Nop.Services.Logging;
using Nop.Services.Media;
using Nop.Services.Messages;
using Nop.Services.Orders;
using Nop.Services.Security;
using Nop.Services.Seo;
using Nop.Services.Marketing;
using Nop.Services.Suppliers;
using Nop.Services.Shipping;
using Nop.Services.Weixin;
using Nop.Web.Areas.Admin.Factories;
using Nop.Web.Areas.Admin.Infrastructure.Mapper.Extensions;
using Nop.Web.Areas.Admin.Models.Weixin;
using Nop.Web.Areas.Admin.Models.Suppliers;
using Nop.Web.Framework.Controllers;
using Nop.Web.Framework.Mvc;
using Nop.Web.Framework.Mvc.Filters;
using OfficeOpenXml.FormulaParsing.Excel.Functions.Math;
using Senparc.Weixin;
using Senparc.Weixin.TenPay.V2;
using Senparc.Weixin.Entities;
using Senparc.Weixin.MP;
using Senparc.Weixin.MP.AdvancedAPIs;
using Senparc.Weixin.MP.CommonAPIs;


namespace Nop.Web.Areas.Admin.Controllers
{
    public partial class SupplierController : BaseAdminController
    {
        #region Fields
        private readonly IPermissionService _permissionService;
        private readonly ICustomerActivityService _customerActivityService;
        private readonly ICustomerService _customerService;
        private readonly ILanguageService _languageService;
        private readonly ILocalizationService _localizationService;
        private readonly ILocalizedEntityService _localizedEntityService;
        private readonly INopFileProvider _fileProvider;
        private readonly INotificationService _notificationService;
        private readonly IWUserService _wUserService;
        private readonly IWLocationService _wLocationService;
        private readonly IWQrCodeLimitService _wQrCodeLimitService;
        private readonly IWQrCodeLimitUserService _wQrCodeLimitUserService;
        private readonly IQrCodeLimitBindingSourceService _qrCodeLimitBindingSourceService;
        private readonly IQrCodeSupplierVoucherCouponMappingService _qrCodeSupplierVoucherCouponMappingService;
        private readonly ISupplierVoucherCouponService _supplierVoucherCouponService;
        private readonly IPictureService _pictureService;
        private readonly ISettingService _settingService;
        private readonly IStoreContext _storeContext;
        private readonly IUrlRecordService _urlRecordService;
        private readonly IWorkContext _workContext;
        private readonly IWeixinModelFactory _weixinModelFactory;
        private readonly ISupplierModelFactory _supplierModelFactory;
        private readonly SenparcWeixinSetting _senparcWeixinSetting;

        #endregion

        #region Ctor

        public SupplierController(
            IPermissionService permissionService,
            ICustomerActivityService customerActivityService,
            ICustomerService customerService,
            ILanguageService languageService,
            ILocalizationService localizationService,
            ILocalizedEntityService localizedEntityService,
            INopFileProvider fileProvider,
            INotificationService notificationService,
            IWUserService wUserService,
            IWLocationService wLocationService,
            IWQrCodeLimitService wQrCodeLimitService,
            IWQrCodeLimitUserService wQrCodeLimitUserService,
            IQrCodeLimitBindingSourceService qrCodeLimitBindingSourceService,
            IQrCodeSupplierVoucherCouponMappingService qrCodeSupplierVoucherCouponMappingService,
            ISupplierVoucherCouponService supplierVoucherCouponService,
            IPictureService pictureService,
            ISettingService settingService,
            IStoreContext storeContext,
            IUrlRecordService urlRecordService,
            IWorkContext workContext,
            IWeixinModelFactory weixinModelFactory,
            ISupplierModelFactory supplierModelFactory,
            SenparcWeixinSetting senparcWeixinSetting)
        {
            _permissionService = permissionService;
            _customerActivityService = customerActivityService;
            _customerService = customerService;
            _languageService = languageService;
            _localizationService = localizationService;
            _localizedEntityService = localizedEntityService;
            _fileProvider = fileProvider;
            _notificationService = notificationService;
            _wUserService = wUserService;
            _wLocationService = wLocationService;
            _wQrCodeLimitService = wQrCodeLimitService;
            _wQrCodeLimitUserService = wQrCodeLimitUserService;
            _qrCodeLimitBindingSourceService = qrCodeLimitBindingSourceService;
            _qrCodeSupplierVoucherCouponMappingService = qrCodeSupplierVoucherCouponMappingService;
            _supplierVoucherCouponService = supplierVoucherCouponService;
            _pictureService = pictureService;
            _settingService = settingService;
            _storeContext = storeContext;
            _urlRecordService = urlRecordService;
            _workContext = workContext;
            _weixinModelFactory = weixinModelFactory;
            _supplierModelFactory = supplierModelFactory;
            _senparcWeixinSetting = senparcWeixinSetting;
        }

        #endregion

        #region Utilities

        #endregion

        #region Methods

        #region Supplier- Creat/Edit/Delete

        #endregion

        #region QrCode-Coupons

        [HttpPost]
        public virtual async Task<IActionResult> QrCodeSupplierVoucherCouponList(QrCodeSupplierVoucherCouponSearchModel searchModel)
        {
            if (!await _permissionService.AuthorizeAsync(StandardPermissionProvider.ManageSuppliers))
                return await AccessDeniedDataTablesJson();

            //try to get a Entity with the specified id
            var qrCodeLimit = await _wQrCodeLimitService.GetWQrCodeLimitByIdAsync(searchModel.QrCodeId)
                ?? throw new ArgumentException("No QrCodeLimit found with the specified id");

            //prepare model
            var model = await _supplierModelFactory.PrepareQrCodeSupplierVoucherCouponListModelAsync(searchModel, qrCodeLimit);

            return Json(model);
        }

        [HttpPost]
        public virtual async Task<IActionResult> QrCodeSupplierVoucherCouponDelete(int id)
        {
            if (!await _permissionService.AuthorizeAsync(StandardPermissionProvider.ManageSuppliers))
                return AccessDeniedView();

            //try to get a qrCodeLimitUser
            var qrCodeSupplierVoucherCoupon = await _qrCodeSupplierVoucherCouponMappingService.GetEntityByIdAsync(id)
                ?? throw new ArgumentException("No QrCodeSupplierVoucherCoupon found with the specified id");

            await _qrCodeSupplierVoucherCouponMappingService.DeleteEntityAsync(qrCodeSupplierVoucherCoupon);

            return new NullJsonResult();
        }

        [HttpPost]
        public virtual async Task<IActionResult> QrCodeSupplierVoucherCouponUpdate(QrCodeSupplierVoucherCouponModel model)
        {
            if (!await _permissionService.AuthorizeAsync(StandardPermissionProvider.ManageSuppliers))
                return AccessDeniedView();

            //try to get a Entity with the specified id
            var qrCodeSupplierVoucherCoupon = await _qrCodeSupplierVoucherCouponMappingService.GetEntityByIdAsync(model.Id)
                ?? throw new ArgumentException("No QrCodeSupplierVoucherCouponMapping found with the specified id");

            qrCodeSupplierVoucherCoupon.Published = model.Published;
            qrCodeSupplierVoucherCoupon.StartDateTime = model.StartDateTime;
            qrCodeSupplierVoucherCoupon.EndDateTime = model.EndDateTime;

            await _qrCodeSupplierVoucherCouponMappingService.UpdateEntityAsync(qrCodeSupplierVoucherCoupon);

            return new NullJsonResult();
        }

        public virtual async Task<IActionResult> QrCodeSupplierVoucherCouponAddPopup(int qrCodeLimitId)
        {
            if (!await _permissionService.AuthorizeAsync(StandardPermissionProvider.ManageSuppliers))
                return AccessDeniedView();

            //prepare model
            var model = await _supplierModelFactory.PrepareAddSupplierVoucherCouponRelatedSearchModelAsync(new AddSupplierVoucherCouponRelatedSearchModel());

            return View(model);
        }

        [HttpPost]
        public virtual async Task<IActionResult> QrCodeSupplierVoucherCouponAddPopupList(AddSupplierVoucherCouponRelatedSearchModel searchModel)
        {
            if (!await _permissionService.AuthorizeAsync(StandardPermissionProvider.ManageSuppliers))
                return await AccessDeniedDataTablesJson();

            //prepare model
            var model = await _supplierModelFactory.PrepareAddSupplierVoucherCouponRelatedCouponListModelAsync(searchModel);

            return Json(model);
        }

        [HttpPost]
        [FormValueRequired("save")]
        public virtual async Task<IActionResult> QrCodeSupplierVoucherCouponAddPopup(AddSupplierVoucherCouponRelatedModel model)
        {
            if (!await _permissionService.AuthorizeAsync(StandardPermissionProvider.ManageSuppliers))
                return AccessDeniedView();

            var selectedSupplierVoucherCoupons = await _supplierVoucherCouponService.GetEntitiesByIdsAsync(model.SelectedSupplierVoucherCouponIds.ToArray());

            if (selectedSupplierVoucherCoupons.Any())
            {
                var existingRelatedCoupons = await _qrCodeSupplierVoucherCouponMappingService.GetEntitiesByQrCodeIdAsync(model.RelatedId);
                foreach (var supplierVoucherCoupon in selectedSupplierVoucherCoupons)
                {
                    if (supplierVoucherCoupon.Deleted || existingRelatedCoupons.Any(t => t.SupplierVoucherCouponId == supplierVoucherCoupon.Id))
                        continue;

                    await _qrCodeSupplierVoucherCouponMappingService.InsertEntityAsync(new QrCodeSupplierVoucherCouponMapping
                    {
                        QrCodeId = model.RelatedId,
                        SupplierVoucherCouponId = supplierVoucherCoupon.Id,
                        QrcodeLimit = true,
                        StartDateTime = DateTime.Now,
                        EndDateTime = DateTime.Now.AddDays(30),
                        Published = true
                    });
                }
            }

            ViewBag.RefreshPage = true;

            return View(new AddSupplierVoucherCouponRelatedSearchModel());
        }


        #endregion

        #endregion
    }
}