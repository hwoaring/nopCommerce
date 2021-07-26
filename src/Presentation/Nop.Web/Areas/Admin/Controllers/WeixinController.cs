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
using Senparc.Weixin.MP.Entities;


namespace Nop.Web.Areas.Admin.Controllers
{
    public partial class WeixinController : BaseAdminController
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
        private readonly IWxUserService _wUserService;
        private readonly IWxLocationService _wLocationService;
        private readonly IQrCodeLimitService _wQrCodeLimitService;
        private readonly IQrCodeLimitUserService _wQrCodeLimitUserService;
        private readonly IQrCodeLimitBindingSourceService _qrCodeLimitBindingSourceService;
        private readonly IQrCodeSupplierVoucherCouponMappingService _qrCodeSupplierVoucherCouponMappingService;
        private readonly IWxMenuService _wMenuService;
        private readonly IWxMenuButtonService _wMenuButtonService;
        private readonly IPictureService _pictureService;
        private readonly ISettingService _settingService;
        private readonly IStoreContext _storeContext;
        private readonly IUrlRecordService _urlRecordService;
        private readonly IWorkContext _workContext;
        private readonly IWeixinModelFactory _weixinModelFactory;
        private readonly SenparcWeixinSetting _senparcWeixinSetting;

        #endregion

        #region Ctor

        public WeixinController(
            IPermissionService permissionService,
            ICustomerActivityService customerActivityService,
            ICustomerService customerService,
            ILanguageService languageService,
            ILocalizationService localizationService,
            ILocalizedEntityService localizedEntityService,
            INopFileProvider fileProvider,
            INotificationService notificationService,
            IWxUserService wUserService,
            IWxLocationService wLocationService,
            IQrCodeLimitService wQrCodeLimitService,
            IQrCodeLimitUserService wQrCodeLimitUserService,
            IQrCodeLimitBindingSourceService qrCodeLimitBindingSourceService,
            IQrCodeSupplierVoucherCouponMappingService qrCodeSupplierVoucherCouponMappingService,
            IWxMenuService wMenuService,
            IWxMenuButtonService wMenuButtonService,
            IPictureService pictureService,
            ISettingService settingService,
            IStoreContext storeContext,
            IUrlRecordService urlRecordService,
            IWorkContext workContext,
            IWeixinModelFactory weixinModelFactory,
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
            _wMenuService = wMenuService;
            _wMenuButtonService = wMenuButtonService;
            _pictureService = pictureService;
            _settingService = settingService;
            _storeContext = storeContext;
            _urlRecordService = urlRecordService;
            _workContext = workContext;
            _weixinModelFactory = weixinModelFactory;
            _senparcWeixinSetting = senparcWeixinSetting;
        }

        #endregion

        #region Utilities

        #endregion

        #region Methods

        #region WUser Tag

        #endregion

        #region WUser Sys Tag

        #endregion

        #region WUser list / create / edit

        public virtual async Task<IActionResult> UserList()
        {
            if (!await _permissionService.AuthorizeAsync(StandardPermissionProvider.ManageWeixin))
                return AccessDeniedView();

            //prepare model
            var model = await _weixinModelFactory.PrepareUserSearchModelAsync(new UserSearchModel());

            return View(model);
        }

        [HttpPost]
        public virtual async Task<IActionResult> UserList(UserSearchModel searchModel)
        {
            if (!await _permissionService.AuthorizeAsync(StandardPermissionProvider.ManageWeixin))
                return await AccessDeniedDataTablesJson();

            //prepare model
            var model = await _weixinModelFactory.PrepareUserListModelAsync(searchModel);

            return Json(model);
        }

        public virtual async Task<IActionResult> UserEdit(int id)
        {
            if (!await _permissionService.AuthorizeAsync(StandardPermissionProvider.ManageWeixin))
                return AccessDeniedView();

            //try to get a weixin customer with the specified id
            var user = await _wUserService.GetWxUserByIdAsync(id);
            if (user == null)
                return RedirectToAction("UserList");

            //判断是否关注，是否需要同步用户数据到本地

            //prepare model
            var model = await _weixinModelFactory.PrepareUserModelAsync(null, user);

            return View(model);
        }

        [HttpPost, ParameterBasedOnFormName("save-continue", "continueEditing")]
        [FormValueRequired("save", "save-continue")]
        public virtual async Task<IActionResult> UserEdit(UserModel model, bool continueEditing, IFormCollection form)
        {
            if (!await _permissionService.AuthorizeAsync(StandardPermissionProvider.ManageWeixin))
                return AccessDeniedView();

            //try to get a weixin user with the specified id
            var user = await _wUserService.GetWxUserByIdAsync(model.Id);
            if (user == null)
                return RedirectToAction("UserList");

            if (ModelState.IsValid)
            {
                try
                {
                    user.Remark = model.Remark; //更改到微信后台同步
                    user.SysRemark = model.SysRemark;
                    user.TagIdList = model.TagIdList;//更改到微信后台同步
                    user.CheckInTypeId = model.CheckInTypeId;
                    user.SubscribeSceneTypeId = model.SubscribeSceneTypeId;
                    user.RoleTypeId = model.RoleTypeId;
                    user.SceneTypeId = model.SceneTypeId;
                    user.Status = model.Status;
                    user.SupplierShopId = model.SupplierShopId;
                    user.QrScene = model.QrScene;
                    user.QrSceneStr = model.QrSceneStr;
                    user.AllowResponse = model.AllowResponse;
                    user.AllowNotice = model.AllowNotice;
                    user.AllowOrderNotice = model.AllowOrderNotice;

                    await _wUserService.UpdateWxUserAsync(user);

                    //activity log
                    await _customerActivityService.InsertActivityAsync("EditUser",
                        string.Format(await _localizationService.GetResourceAsync("ActivityLog.EditUser"), user.Id), user);

                    _notificationService.SuccessNotification(await _localizationService.GetResourceAsync("Admin.Weixin.Users.Updated"));

                    if (!continueEditing)
                        return RedirectToAction("UserList");

                    return RedirectToAction("UserEdit", new { id = user.Id });
                }
                catch (Exception exc)
                {
                    _notificationService.ErrorNotification(exc.Message);
                }
            }

            //prepare model
            model = await _weixinModelFactory.PrepareUserModelAsync(model, user, true);

            //if we got this far, something failed, redisplay form
            return View(model);
        }


        #endregion

        #region Location list

        #endregion

        #region QrCodeLimit list

        public virtual async Task<IActionResult> QrCodeLimitList()
        {
            if (!await _permissionService.AuthorizeAsync(StandardPermissionProvider.ManageWeixin))
                return AccessDeniedView();

            //prepare model
            var model = await _weixinModelFactory.PrepareQrCodeLimitSearchModelAsync(new QrCodeLimitSearchModel());

            return View(model);
        }

        [HttpPost]
        public virtual async Task<IActionResult> QrCodeLimitList(QrCodeLimitSearchModel searchModel)
        {
            if (!await _permissionService.AuthorizeAsync(StandardPermissionProvider.ManageWeixin))
                return await AccessDeniedDataTablesJson();

            //prepare model
            var model = await _weixinModelFactory.PrepareQrCodeLimitListModelAsync(searchModel);

            return Json(model);
        }

        public virtual async Task<IActionResult> QrCodeLimitCreate()
        {
            if (!await _permissionService.AuthorizeAsync(StandardPermissionProvider.ManageWeixin))
                return AccessDeniedView();

            //prepare model
            var model = await _weixinModelFactory.PrepareQrCodeLimitModelAsync(new QrCodeLimitModel(), null);

            return View(model);
        }

        [HttpPost, ParameterBasedOnFormName("save-continue", "continueEditing")]
        [FormValueRequired("save", "save-continue")]
        public virtual async Task<IActionResult> QrCodeLimitCreate(QrCodeLimitModel model, bool continueEditing, IFormCollection form)
        {
            if (!await _permissionService.AuthorizeAsync(StandardPermissionProvider.ManageWeixin))
                return AccessDeniedView();

            if(string.IsNullOrWhiteSpace(model.SysName))
                ModelState.AddModelError(string.Empty, "System Name Not Empty");


            if (ModelState.IsValid)
            {
                //fill entity from model
                var qrCodeLimit = model.ToEntity<QrCodeLimit>();
                qrCodeLimit.QrCodeActionType = QrCodeActionType.QR_LIMIT_SCENE;

                await _wQrCodeLimitService.InsertQrCodeLimitAsync(qrCodeLimit);

                //插入bingdingSource
                model.BindingSource.QrCodeLimitId = qrCodeLimit.Id;
                var qrCodeLimitBindingSource = model.BindingSource.ToEntity<QrCodeLimitBindingSource>();
                await _qrCodeLimitBindingSourceService.InsertEntityAsync(qrCodeLimitBindingSource);

                //复制备份当前ID到QrCodeId中
                qrCodeLimit.QrCodeId = qrCodeLimit.Id;

                //创建qrcode Ticket
                if(string.IsNullOrWhiteSpace(qrCodeLimit.Ticket))
                {
                    var qrcodeResult = Senparc.Weixin.MP.AdvancedAPIs.QrCodeApi.Create(_senparcWeixinSetting.WeixinAppId, 0, qrCodeLimit.Id, Senparc.Weixin.MP.QrCode_ActionName.QR_LIMIT_SCENE);
                    if (qrcodeResult.errcode == ReturnCode.请求成功)
                    {
                        qrCodeLimit.Ticket = qrcodeResult.ticket;
                        qrCodeLimit.Url = qrcodeResult.url;
                    }
                }

                await _wQrCodeLimitService.UpdateQrCodeLimitAsync(qrCodeLimit);

                //activity log
                await _customerActivityService.InsertActivityAsync("AddNewQrCodeLimit",
                    string.Format(await _localizationService.GetResourceAsync("ActivityLog.AddNewQrCodeLimit"), qrCodeLimit.Id), qrCodeLimit);
                _notificationService.SuccessNotification(await _localizationService.GetResourceAsync("Admin.Weixin.QrCodeLimits.Added"));

                if (!continueEditing)
                    return RedirectToAction("QrCodeLimitList");

                return RedirectToAction("QrCodeLimitEdit", new { id = qrCodeLimit.Id });
            }

            //prepare model
            model = await _weixinModelFactory.PrepareQrCodeLimitModelAsync(model, null, true);

            //if we got this far, something failed, redisplay form
            return View(model);
        }

        public virtual async Task<IActionResult> QrCodeLimitEdit(int id)
        {
            if (!await _permissionService.AuthorizeAsync(StandardPermissionProvider.ManageWeixin))
                return AccessDeniedView();

            //try to get a weixin customer with the specified id
            var qrcodeLimit = await _wQrCodeLimitService.GetQrCodeLimitByIdAsync(id);
            if (qrcodeLimit == null)
                return RedirectToAction("QrCodeLimitList");

            //prepare model
            var model = await _weixinModelFactory.PrepareQrCodeLimitModelAsync(null, qrcodeLimit);

            return View(model);
        }

        [HttpPost, ParameterBasedOnFormName("save-continue", "continueEditing")]
        [FormValueRequired("save", "save-continue")]
        public virtual async Task<IActionResult> QrCodeLimitEdit(QrCodeLimitModel model, bool continueEditing, IFormCollection form)
        {
            if (!await _permissionService.AuthorizeAsync(StandardPermissionProvider.ManageWeixin))
                return AccessDeniedView();

            //try to get a weixin user with the specified id
            var qrcodeLimit = await _wQrCodeLimitService.GetQrCodeLimitByIdAsync(model.Id);
            if (qrcodeLimit == null)
                return RedirectToAction("QrCodeLimitList");

            if (ModelState.IsValid)
            {
                try
                {
                    qrcodeLimit.QrCodeCategoryId = model.QrCodeCategoryId;
                    qrcodeLimit.QrCodeChannelId = model.QrCodeChannelId;
                    qrcodeLimit.SysName = model.SysName;
                    qrcodeLimit.Description = model.Description;
                    qrcodeLimit.TagIdList = model.TagIdList;
                    qrcodeLimit.FixedUse = model.FixedUse;

                    //创建qrcode Ticket
                    if (string.IsNullOrWhiteSpace(qrcodeLimit.Ticket))
                    {
                        var qrcodeResult = Senparc.Weixin.MP.AdvancedAPIs.QrCodeApi.Create(_senparcWeixinSetting.WeixinAppId, 0, qrcodeLimit.Id, Senparc.Weixin.MP.QrCode_ActionName.QR_LIMIT_SCENE);
                        if (qrcodeResult.errcode == ReturnCode.请求成功)
                        {
                            qrcodeLimit.Ticket = qrcodeResult.ticket;
                            qrcodeLimit.Url = qrcodeResult.url;
                        }
                    }

                    await _wQrCodeLimitService.UpdateQrCodeLimitAsync(qrcodeLimit);

                    //更新binding source
                    var qrCodeLimitBindingSource = await _qrCodeLimitBindingSourceService.GetEntityByQrcodeLimitIdAsync(qrcodeLimit.Id);
                    if (qrCodeLimitBindingSource == null)
                    {
                        await _qrCodeLimitBindingSourceService.InsertEntityAsync(new QrCodeLimitBindingSource()
                        {
                            QrCodeLimitId = qrcodeLimit.Id,
                            SupplierId = model.BindingSource.SupplierId,
                            SupplierShopId = model.BindingSource.SupplierShopId,
                            ProductId = model.BindingSource.ProductId,
                            Address = model.BindingSource.Address,
                            MarketingAdvertWayId = model.BindingSource.MarketingAdvertWayId,
                            UseFixUrl = model.BindingSource.UseFixUrl,
                            Url = model.BindingSource.Url,
                            MessageResponse = model.BindingSource.MessageResponse,
                            SceneTypeId = model.BindingSource.SceneTypeId,
                            MessageTypeId = model.BindingSource.MessageTypeId,
                            Content = model.BindingSource.Content,
                            UseBindingMessage = model.BindingSource.UseBindingMessage
                        });

                    }
                    else
                    {
                        qrCodeLimitBindingSource.SupplierId = model.BindingSource.SupplierId;
                        qrCodeLimitBindingSource.SupplierShopId = model.BindingSource.SupplierShopId;
                        qrCodeLimitBindingSource.ProductId = model.BindingSource.ProductId;
                        qrCodeLimitBindingSource.Address = model.BindingSource.Address;
                        qrCodeLimitBindingSource.MarketingAdvertWayId = model.BindingSource.MarketingAdvertWayId;
                        qrCodeLimitBindingSource.UseFixUrl = model.BindingSource.UseFixUrl;
                        qrCodeLimitBindingSource.Url = model.BindingSource.Url;
                        qrCodeLimitBindingSource.MessageResponse = model.BindingSource.MessageResponse;
                        qrCodeLimitBindingSource.SceneTypeId = model.BindingSource.SceneTypeId;
                        qrCodeLimitBindingSource.MessageTypeId = model.BindingSource.MessageTypeId;
                        qrCodeLimitBindingSource.Content = model.BindingSource.Content;
                        qrCodeLimitBindingSource.UseBindingMessage = model.BindingSource.UseBindingMessage;
                        qrCodeLimitBindingSource.Published = model.BindingSource.Published;

                        await _qrCodeLimitBindingSourceService.UpdateEntityAsync(qrCodeLimitBindingSource);
                    }

                    //activity log
                    await _customerActivityService.InsertActivityAsync("EditQrCodeLimit",
                        string.Format(await _localizationService.GetResourceAsync("ActivityLog.EditQrCodeLimit"), qrcodeLimit.Id), qrcodeLimit);

                    _notificationService.SuccessNotification(await _localizationService.GetResourceAsync("Admin.Weixin.QrCodeLimits.Updated"));

                    if (!continueEditing)
                        return RedirectToAction("QrCodeLimitList");

                    return RedirectToAction("QrCodeLimitEdit", new { id = qrcodeLimit.Id });
                }
                catch (Exception exc)
                {
                    _notificationService.ErrorNotification(exc.Message);
                }
            }

            //prepare model
            model = await _weixinModelFactory.PrepareQrCodeLimitModelAsync(model, qrcodeLimit, true);

            //if we got this far, something failed, redisplay form
            return View(model);
        }

        [HttpPost]
        public virtual async Task<IActionResult> QrCodeLimitUserList(QrCodeLimitUserSearchModel searchModel)
        {
            if (!await _permissionService.AuthorizeAsync(StandardPermissionProvider.ManageWeixin))
                return await AccessDeniedDataTablesJson();

            //try to get a product with the specified id
            var qrCodeLimit = await _wQrCodeLimitService.GetQrCodeLimitByIdAsync(searchModel.QrCodeLimitId)
                ?? throw new ArgumentException("No QrCodeLimit found with the specified id");

            //prepare model
            var model = await _weixinModelFactory.PrepareQrCodeLimitUserListModelAsync(searchModel, qrCodeLimit);

            return Json(model);
        }

        [HttpPost]
        public virtual async Task<IActionResult> QrCodeLimitUserDelete(int id)
        {
            if (!await _permissionService.AuthorizeAsync(StandardPermissionProvider.ManageWeixin))
                return AccessDeniedView();

            //try to get a qrCodeLimitUser
            var qrCodeLimitUser = await _wQrCodeLimitUserService.GetEntityByIdAsync(id)
                ?? throw new ArgumentException("No QrCodeLimitUser found with the specified id");

            await _wQrCodeLimitUserService.DeleteEntityAsync(qrCodeLimitUser);

            return new NullJsonResult();
        }

        public virtual async Task<IActionResult> QrCodeLimitUserAddPopup(int qrCodeLimitId)
        {
            if (!await _permissionService.AuthorizeAsync(StandardPermissionProvider.ManageWeixin))
                return AccessDeniedView();

            //prepare model
            var model = await _weixinModelFactory.PrepareAddUserRelatedSearchModelAsync(new AddUserRelatedSearchModel());

            return View(model);
        }

        [HttpPost]
        public virtual async Task<IActionResult> QrCodeLimitUserAddPopupList(AddUserRelatedSearchModel searchModel)
        {
            if (!await _permissionService.AuthorizeAsync(StandardPermissionProvider.ManageWeixin))
                return await AccessDeniedDataTablesJson();

            //prepare model
            var model = await _weixinModelFactory.PrepareAddUserRelatedUserListModelAsync(searchModel);

            return Json(model);
        }

        [HttpPost]
        [FormValueRequired("save")]
        public virtual async Task<IActionResult> QrCodeLimitUserAddPopup(AddUserRelatedModel model)
        {
            if (!await _permissionService.AuthorizeAsync(StandardPermissionProvider.ManageWeixin))
                return AccessDeniedView();

            var selectedUsers = await _wUserService.GetWxUsersByIdsAsync(model.SelectedUserIds.ToArray());

            if(selectedUsers.Any())
            {
                var existingRelatedUsers = await _wQrCodeLimitUserService.GetEntitiesByQrcodeLimitIdAsync(model.RelatedId);
                foreach (var user in selectedUsers)
                {
                    if (!user.Subscribe || existingRelatedUsers.Any(t => t.CustomerId == user.CustomerId))
                        continue;

                    await _wQrCodeLimitUserService.InsertEntityAsync(new QrCodeLimitUserMapping
                    {
                        CustomerId = user.CustomerId,
                        QrCodeLimitId = model.RelatedId,
                        ExpireTime = DateTime.Now.AddDays(30),
                        Published = true
                    });
                }
            }

            ViewBag.RefreshPage = true;

            return View(new AddUserRelatedSearchModel());
        }

        public virtual async Task<IActionResult> QrCodeLimitUserEditPopup(int id)
        {
            if (!await _permissionService.AuthorizeAsync(StandardPermissionProvider.ManageWeixin))
                return AccessDeniedView();

            //try to get entity with the specified id
            var qrcodeLimitUser = await _wQrCodeLimitUserService.GetEntityByIdAsync(id) ?? 
                throw new ArgumentException("No QrCodeLimitUser found with the specified id");

            //prepare model
            var model = await _weixinModelFactory.PrepareQrCodeLimitUserModelAsync(null, qrcodeLimitUser);

            return View(model);
        }

        [HttpPost, ParameterBasedOnFormName("save-continue", "continueEditing")]
        [FormValueRequired("save", "save-continue")]
        public virtual async Task<IActionResult> QrCodeLimitUserEditPopup(QrCodeLimitUserModel model, bool continueEditing, IFormCollection form)
        {
            if (!await _permissionService.AuthorizeAsync(StandardPermissionProvider.ManageWeixin))
                return AccessDeniedView();

            //try to get a entity with the specified id
            var qrcodeLimitUser = await _wQrCodeLimitUserService.GetEntityByIdAsync(model.Id) ??
                throw new ArgumentException("No QrCodeLimitUser found with the specified id");

            if (ModelState.IsValid)
            {
                try
                {
                    qrcodeLimitUser.UserName = model.UserName;
                    qrcodeLimitUser.Description = model.Description;
                    qrcodeLimitUser.TelNumber = model.TelNumber;
                    qrcodeLimitUser.AddressInfo = model.AddressInfo;
                    qrcodeLimitUser.ExpireTime = model.ExpireTime;
                    qrcodeLimitUser.Published = model.Published;

                    await _wQrCodeLimitUserService.UpdateEntityAsync(qrcodeLimitUser);

                    //activity log
                    await _customerActivityService.InsertActivityAsync("EditQrCodeLimitUser",
                        string.Format(await _localizationService.GetResourceAsync("ActivityLog.EditQrCodeLimitUser"), qrcodeLimitUser.Id), qrcodeLimitUser);

                    _notificationService.SuccessNotification(await _localizationService.GetResourceAsync("Admin.Weixin.QrCodeLimitUsers.Updated"));

                    if (!continueEditing)
                        ViewBag.RefreshPage = true;

                    return View(model);
                }
                catch (Exception exc)
                {
                    _notificationService.ErrorNotification(exc.Message);
                }
            }

            //prepare model
            model = await _weixinModelFactory.PrepareQrCodeLimitUserModelAsync(model, qrcodeLimitUser, true);

            //if we got this far, something failed, redisplay form
            return View(model);
        }


        #endregion

        #region Menu list/Creat/Edit

        public virtual async Task<IActionResult> MenuList()
        {
            if (!await _permissionService.AuthorizeAsync(StandardPermissionProvider.ManageWeixin))
                return AccessDeniedView();

            //prepare model
            var model = await _weixinModelFactory.PrepareMenuSearchModelAsync(new MenuSearchModel());

            return View(model);
        }

        [HttpPost]
        public virtual async Task<IActionResult> MenuList(MenuSearchModel searchModel)
        {
            if (!await _permissionService.AuthorizeAsync(StandardPermissionProvider.ManageWeixin))
                return await AccessDeniedDataTablesJson();

            //prepare model
            var model = await _weixinModelFactory.PrepareMenuListModelAsync(searchModel);

            return Json(model);
        }

        public virtual async Task<IActionResult> MenuCreate()
        {
            if (!await _permissionService.AuthorizeAsync(StandardPermissionProvider.ManageWeixin))
                return AccessDeniedView();

            //prepare model
            var model = await _weixinModelFactory.PrepareMenuModelAsync(new MenuModel(), null);

            return View(model);
        }

        [HttpPost, ParameterBasedOnFormName("save-continue", "continueEditing")]
        [FormValueRequired("save", "save-continue")]
        public virtual async Task<IActionResult> MenuCreate(MenuModel model, bool continueEditing, IFormCollection form)
        {
            if (!await _permissionService.AuthorizeAsync(StandardPermissionProvider.ManageWeixin))
                return AccessDeniedView();

            if (string.IsNullOrWhiteSpace(model.SystemName))
                model.SystemName = "Name Not Set";

            if (ModelState.IsValid)
            {
                //fill entity from model
                var menu = model.ToEntity<WxMenu>();

                await _wMenuService.InsertMenuAsync(menu);

                //activity log
                await _customerActivityService.InsertActivityAsync("AddNewMenu",
                    string.Format(await _localizationService.GetResourceAsync("ActivityLog.AddNewMenu"), menu.Id), menu);
                _notificationService.SuccessNotification(await _localizationService.GetResourceAsync("Admin.Weixin.Menus.Added"));

                if (!continueEditing)
                    return RedirectToAction("MenuList");

                return RedirectToAction("MenuEdit", new { id = menu.Id });
            }

            //prepare model
            model = await _weixinModelFactory.PrepareMenuModelAsync(model, null, true);

            //if we got this far, something failed, redisplay form
            return View(model);
        }


        public virtual async Task<IActionResult> MenuEdit(int id)
        {
            if (!await _permissionService.AuthorizeAsync(StandardPermissionProvider.ManageWeixin))
                return AccessDeniedView();

            //try to get a entity with the specified id
            var menu = await _wMenuService.GetMenuByIdAsync(id);
            if (menu == null)
                return RedirectToAction("MenuList");

            //prepare model
            var model = await _weixinModelFactory.PrepareMenuModelAsync(null, menu);

            return View(model);
        }

        [HttpPost, ParameterBasedOnFormName("save-continue", "continueEditing")]
        [FormValueRequired("save", "save-continue")]
        public virtual async Task<IActionResult> MenuEdit(MenuModel model, bool continueEditing, IFormCollection form)
        {
            if (!await _permissionService.AuthorizeAsync(StandardPermissionProvider.ManageWeixin))
                return AccessDeniedView();

            //try to get a entity with the specified id
            var menu = await _wMenuService.GetMenuByIdAsync(model.Id);
            if (menu == null)
                return RedirectToAction("MenuList");

            if (ModelState.IsValid)
            {
                try
                {
                    menu.SystemName = model.SystemName;
                    menu.Description = model.Description;
                    menu.TagId = model.TagId;
                    menu.Sex = model.Sex;
                    menu.ClientPlatformType = model.ClientPlatformType;
                    menu.Country = model.Country;
                    menu.Province = model.Province;
                    menu.City = model.City;
                    menu.LanguageTypeId = Convert.ToByte(model.LanguageTypeId);
                    menu.Status = Convert.ToByte(model.Status);
                    menu.DefaultMenu = model.DefaultMenu;
                    menu.Published = model.Published;
                    menu.Personal = model.Personal;

                    await _wMenuService.UpdateMenuAsync(menu);

                    //activity log
                    await _customerActivityService.InsertActivityAsync("EditMenu",
                        string.Format(await _localizationService.GetResourceAsync("ActivityLog.EditMenu"), menu.Id), menu);

                    _notificationService.SuccessNotification(await _localizationService.GetResourceAsync("Admin.Weixin.Menus.Updated"));

                    if (!continueEditing)
                        return RedirectToAction("MenuList");

                    return RedirectToAction("MenuEdit", new { id = menu.Id });
                }
                catch (Exception exc)
                {
                    _notificationService.ErrorNotification(exc.Message);
                }
            }

            //prepare model
            model = await _weixinModelFactory.PrepareMenuModelAsync(model, menu, true);

            //if we got this far, something failed, redisplay form
            return View(model);
        }

        public virtual async Task<IActionResult> MenuPublish(int id)
        {
            if (!await _permissionService.AuthorizeAsync(StandardPermissionProvider.ManageWeixin))
                return AccessDeniedView();

            //try to get a entity with the specified id
            var menu = await _wMenuService.GetMenuByIdAsync(id);
            if (menu == null)
                return RedirectToAction("MenuList");

            var menuButtons = await _wMenuButtonService.GetMenuButtonsByMenuIdAsync(menu.Id);
            var baseButtons = menuButtons.Where(t => t.RootButton).OrderBy(t => t.DisplayOrder).ToList();

            if (baseButtons == null || baseButtons.Count == 0)
                return RedirectToAction("MenuList");

            var baseButtonMaxCount = 3;
            //var result = new GetMenuResult(new Senparc.Weixin.MP.Entities.Menu.ButtonGroup());
            //var resultFull = new GetMenuResultFull {
            //    menu = new MenuFull_ButtonGroup {
            //        button = new List<MenuFull_RootButton>()
            //    }
            //};
            var baseButtonList = new List<MenuFull_RootButton>();

            foreach (var baseButton in baseButtons)
            {
                if (baseButtonMaxCount < 1)
                    break;

                var subButtonList= new List<MenuFull_RootButton>();
                var subButtonMaxCount = 5;
                var subButtons = menuButtons.Where(t => t.ParentId == baseButton.Id).OrderBy(t => t.DisplayOrder).ToList();
                if (subButtons != null && subButtons.Count > 0)
                {
                    foreach (var subButton in subButtons)
                    {
                        if (subButtonMaxCount < 1)
                            break;

                        subButtonList.Add(new MenuFull_RootButton() {
                            appid = subButton.AppId,
                            key = subButton.Key,
                            media_id = subButton.MediaId,
                            name = subButton.Name,
                            pagepath = subButton.PagePath,
                            type = subButton.MenuButtonType.ToString().ToLower(),
                            url = subButton.Url
                        });

                        subButtonMaxCount--;
                    }
                }

                baseButtonList.Add(new MenuFull_RootButton {
                    appid = baseButton.AppId,
                    key = baseButton.Key,
                    media_id = baseButton.MediaId,
                    name = baseButton.Name,
                    pagepath = baseButton.PagePath,
                    type = baseButton.MenuButtonType.ToString().ToLower(),
                    url = baseButton.Url,
                    sub_button = subButtonList
                });

                baseButtonMaxCount--;

            }

            //Creat api post string 
            Senparc.Weixin.MP.Entities.Menu.MenuMatchRule menuMatchRule = new Senparc.Weixin.MP.Entities.Menu.MenuMatchRule()
            {
                city = menu.City,
                client_platform_type = menu.ClientPlatformType,
                country = menu.Country,
                //language = menu.LanguageType.ToString() == "0" ? "" : menu.LanguageType.ToString(),
                province = menu.Province,
                sex = menu.Sex,
                tag_id = menu.TagId
            };
            var useAddCondidionalApi = menu.Personal && menuMatchRule != null && !menuMatchRule.CheckAllNull();

            var menuResultFull = new GetMenuResultFull()
            {
                menu = new MenuFull_ButtonGroup() { button = baseButtonList }
            };

            try
            {
                //删除已经发布的个性化菜单
                if (menu.MenuId > 0)
                {
                    var resp = Senparc.Weixin.MP.CommonAPIs.CommonApi.DeleteMenuConditional(_senparcWeixinSetting.WeixinAppId, menu.MenuId.ToString());
                    if (resp.errcode == ReturnCode.请求成功)
                    {
                        menu.MenuId = 0;
                        menu.Published = false;
                        menu.UnPublishTime = (int)Nop.Core.Weixin.Helpers.DateTimeHelper.GetUnixDateTime(DateTime.Now);
                        menu.MenuJsonCode = "";

                        await _wMenuService.UpdateMenuAsync(menu);
                    }
                }

                //重新整理按钮信息
                WxJsonResult result = null;
                Senparc.Weixin.MP.Entities.Menu.IButtonGroupBase buttonGroup = null;
                if (useAddCondidionalApi)
                {
                    //个性化接口
                    buttonGroup = CommonApi.GetMenuFromJsonResult(menuResultFull, new Senparc.Weixin.MP.Entities.Menu.ConditionalButtonGroup()).menu;

                    var addConditionalButtonGroup = buttonGroup as Senparc.Weixin.MP.Entities.Menu.ConditionalButtonGroup;
                    addConditionalButtonGroup.matchrule = menuMatchRule;
                    result = CommonApi.CreateMenuConditional(_senparcWeixinSetting.WeixinAppId, addConditionalButtonGroup);
                    if (result.errcode == ReturnCode.请求成功)
                    {
                        var result2 = result as CreateMenuConditionalResult;

                        menu.MenuId = result2.menuid;
                        menu.Published = true;
                        menu.PublishTime = (int)Nop.Core.Weixin.Helpers.DateTimeHelper.GetUnixDateTime(DateTime.Now);
                        menu.MenuJsonCode = Json(addConditionalButtonGroup).ToString();

                        await _wMenuService.UpdateMenuAsync(menu);
                    }
                    else
                    {
                        _notificationService.ErrorNotification(result.errcode.ToString() + " : " + result.errmsg);
                        return RedirectToAction("MenuList");
                    }
                }
                else
                {
                    //普通接口
                    buttonGroup = CommonApi.GetMenuFromJsonResult(menuResultFull, new Senparc.Weixin.MP.Entities.Menu.ButtonGroup()).menu;
                    result = CommonApi.CreateMenu(_senparcWeixinSetting.WeixinAppId, buttonGroup);
                    if (result.errcode == ReturnCode.请求成功)
                    {
                        menu.Published = true;
                        menu.PublishTime = (int)Nop.Core.Weixin.Helpers.DateTimeHelper.GetUnixDateTime(DateTime.Now);
                        menu.MenuJsonCode = Json(buttonGroup).ToString();

                        await _wMenuService.UpdateMenuAsync(menu);
                    }
                    else
                    {
                        _notificationService.ErrorNotification(result.errcode.ToString() + " : " + result.errmsg);
                        return RedirectToAction("MenuList");
                    }
                }

            }
            catch (Exception ex)
            {
                _notificationService.ErrorNotification(ex.ToString());
                return RedirectToAction("MenuList");
            }

            //activity log
                await _customerActivityService.InsertActivityAsync("PublishNewMenu",
                    string.Format(await _localizationService.GetResourceAsync("ActivityLog.PublishNewMenu"), menu.Id), menu);
                _notificationService.SuccessNotification(await _localizationService.GetResourceAsync("Admin.Weixin.Menus.Published"));


            return RedirectToAction("MenuList");
        }

        [HttpPost]
        public virtual async Task<IActionResult> MenuButtonList(MenuButtonSearchModel searchModel)
        {
            if (!await _permissionService.AuthorizeAsync(StandardPermissionProvider.ManageWeixin))
                return await AccessDeniedDataTablesJson();

            //try to get a product with the specified id
            var menu = await _wMenuService.GetMenuByIdAsync(searchModel.MenuId)
                ?? throw new ArgumentException("No QrCodeLimit found with the specified id");

            //prepare model
            var model = await _weixinModelFactory.PrepareMenuButtonListModelAsync(searchModel, menu);

            return Json(model);
        }


        #endregion

        #region Messages list

        #endregion

        #region AutoReply Setting

        #endregion

        #endregion
    }
}