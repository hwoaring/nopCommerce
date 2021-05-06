using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Text;
using System.Text.Encodings.Web;
using Microsoft.AspNetCore.Mvc.Rendering;
using Nop.Core;
using Nop.Core.Domain.Weixin;
using Nop.Core.Domain.Directory;
using Nop.Core.Domain.Discounts;
using Nop.Core.Domain.Orders;
using Nop.Core.Domain.Tax;
using Nop.Core.Domain.Vendors;
using Nop.Services.Catalog;
using Nop.Services.Common;
using Nop.Services.Customers;
using Nop.Services.Directory;
using Nop.Services.Discounts;
using Nop.Services.Helpers;
using Nop.Services.Localization;
using Nop.Services.Media;
using Nop.Services.Orders;
using Nop.Services.Seo;
using Nop.Services.Shipping;
using Nop.Services.Stores;
using Nop.Web.Areas.Admin.Infrastructure.Mapper.Extensions;
using Nop.Web.Areas.Admin.Models.Weixin;
using Nop.Web.Areas.Admin.Models.Suppliers;
using Nop.Web.Areas.Admin.Models.Orders;
using Nop.Web.Framework.Extensions;
using Nop.Web.Framework.Factories;
using Nop.Web.Framework.Models.Extensions;
using OfficeOpenXml.FormulaParsing.Excel.Functions.Math;
using Nop.Services.Weixin;

namespace Nop.Web.Areas.Admin.Factories
{
    /// <summary>
    /// Represents the weixin model factory implementation
    /// </summary>
    public partial class WeixinModelFactory : IWeixinModelFactory
    {
        #region Fields

        private readonly CurrencySettings _currencySettings;
        private readonly IAclSupportedModelFactory _aclSupportedModelFactory;
        private readonly IAddressService _addressService;
        private readonly IBaseAdminModelFactory _baseAdminModelFactory;
        private readonly ICategoryService _categoryService;
        private readonly ICurrencyService _currencyService;
        private readonly ICustomerService _customerService;
        private readonly IDateTimeHelper _dateTimeHelper;
        private readonly IDiscountService _discountService;
        private readonly IDiscountSupportedModelFactory _discountSupportedModelFactory;
        private readonly ILocalizationService _localizationService;
        private readonly ILocalizedModelFactory _localizedModelFactory;
        private readonly IManufacturerService _manufacturerService;
        private readonly IMeasureService _measureService;
        private readonly IOrderService _orderService;
        private readonly IPictureService _pictureService;
        private readonly IProductAttributeFormatter _productAttributeFormatter;
        private readonly IProductAttributeParser _productAttributeParser;
        private readonly IProductAttributeService _productAttributeService;
        private readonly IProductService _productService;
        private readonly IProductTagService _productTagService;
        private readonly IProductTemplateService _productTemplateService;
        private readonly ISettingModelFactory _settingModelFactory;
        private readonly IShipmentService _shipmentService;
        private readonly IShippingService _shippingService;
        private readonly IShoppingCartService _shoppingCartService;
        private readonly ISpecificationAttributeService _specificationAttributeService;
        private readonly IStoreMappingSupportedModelFactory _storeMappingSupportedModelFactory;
        private readonly IStoreService _storeService;
        private readonly IUrlRecordService _urlRecordService;
        private readonly IWUserService _wUserService;
        private readonly IWUserTagService _wUserTagService;
        private readonly IWQrCodeLimitService _wQrCodeLimitService;
        private readonly IWQrCodeLimitUserService _wQrCodeLimitUserService;
        private readonly IQrCodeLimitBindingSourceService _qrCodeLimitBindingSourceService;
        private readonly IWMenuService _wMenuService;
        private readonly IWMenuButtonService _wMenuButtonService;
        private readonly IWorkContext _workContext;
        private readonly MeasureSettings _measureSettings;
        private readonly TaxSettings _taxSettings;
        private readonly VendorSettings _vendorSettings;

        #endregion

        #region Ctor

        public WeixinModelFactory(
            CurrencySettings currencySettings,
            IAclSupportedModelFactory aclSupportedModelFactory,
            IAddressService addressService,
            IBaseAdminModelFactory baseAdminModelFactory,
            ICategoryService categoryService,
            ICurrencyService currencyService,
            ICustomerService customerService,
            IDateTimeHelper dateTimeHelper,
            IDiscountService discountService,
            IDiscountSupportedModelFactory discountSupportedModelFactory,
            ILocalizationService localizationService,
            ILocalizedModelFactory localizedModelFactory,
            IManufacturerService manufacturerService,
            IMeasureService measureService,
            IOrderService orderService,
            IPictureService pictureService,
            IProductAttributeFormatter productAttributeFormatter,
            IProductAttributeParser productAttributeParser,
            IProductAttributeService productAttributeService,
            IProductService productService,
            IProductTagService productTagService,
            IProductTemplateService productTemplateService,
            ISettingModelFactory settingModelFactory,
            IShipmentService shipmentService,
            IShippingService shippingService,
            IShoppingCartService shoppingCartService,
            ISpecificationAttributeService specificationAttributeService,
            IStoreMappingSupportedModelFactory storeMappingSupportedModelFactory,
            IStoreService storeService,
            IUrlRecordService urlRecordService,
            IWUserService wUserService,
            IWUserTagService wUserTagService,
            IWQrCodeLimitService wQrCodeLimitService,
            IWQrCodeLimitUserService wQrCodeLimitUserService,
            IQrCodeLimitBindingSourceService qrCodeLimitBindingSourceService,
            IWMenuService wMenuService,
            IWMenuButtonService wMenuButtonService,
            IWorkContext workContext,
            MeasureSettings measureSettings,
            TaxSettings taxSettings,
            VendorSettings vendorSettings)
        {
            _currencySettings = currencySettings;
            _aclSupportedModelFactory = aclSupportedModelFactory;
            _addressService = addressService;
            _baseAdminModelFactory = baseAdminModelFactory;
            _categoryService = categoryService;
            _currencyService = currencyService;
            _customerService = customerService;
            _dateTimeHelper = dateTimeHelper;
            _discountService = discountService;
            _discountSupportedModelFactory = discountSupportedModelFactory;
            _localizationService = localizationService;
            _localizedModelFactory = localizedModelFactory;
            _manufacturerService = manufacturerService;
            _measureService = measureService;
            _measureSettings = measureSettings;
            _orderService = orderService;
            _pictureService = pictureService;
            _productAttributeFormatter = productAttributeFormatter;
            _productAttributeParser = productAttributeParser;
            _productAttributeService = productAttributeService;
            _productService = productService;
            _productTagService = productTagService;
            _productTemplateService = productTemplateService;
            _settingModelFactory = settingModelFactory;
            _shipmentService = shipmentService;
            _shippingService = shippingService;
            _shoppingCartService = shoppingCartService;
            _specificationAttributeService = specificationAttributeService;
            _storeMappingSupportedModelFactory = storeMappingSupportedModelFactory;
            _storeService = storeService;
            _urlRecordService = urlRecordService;
            _wUserService = wUserService;
            _wUserTagService = wUserTagService;
            _wQrCodeLimitService = wQrCodeLimitService;
            _wQrCodeLimitUserService = wQrCodeLimitUserService;
            _qrCodeLimitBindingSourceService = qrCodeLimitBindingSourceService;
            _wMenuService = wMenuService;
            _wMenuButtonService = wMenuButtonService;
            _workContext = workContext;
            _taxSettings = taxSettings;
            _vendorSettings = vendorSettings;
        }

        #endregion

        #region Utilities

        #endregion

        #region Methods


        #region UserModel

        /// <summary>
        /// Prepare User model
        /// </summary>
        /// <param name="model">User model</param>
        /// <param name="product">User</param>
        /// <param name="excludeProperties">Whether to exclude populating of some properties of model</param>
        /// <returns>Product model</returns>
        public virtual Task<UserModel> PrepareUserModelAsync(UserModel model, WUser user, bool excludeProperties = false)
        {
            if (user != null)
            {
                //fill in model values from the entity
                model ??= new UserModel();

                model.Id = user.Id;

                //whether to fill in some of properties
                if (!excludeProperties)
                {
                    model.OpenId = user.OpenId;
                    model.RefereeId = user.RefereeId;
                    model.OriginalId = user.OriginalId;
                    model.OpenIdHash = user.OpenIdHash;
                    model.UnionId = user.UnionId;
                    model.NickName = user.NickName;
                    model.Province = user.Province;
                    model.City = user.City;
                    model.Country = user.Country;
                    model.HeadImgUrl = Senparc.Weixin.MP.CommonService.Utilities.HeadImageUrlHelper.GetHeadImageUrl(user.HeadImgUrl);
                    model.Remark = user.Remark;
                    model.SysRemark = user.SysRemark;
                    model.GroupId = user.GroupId;
                    model.TagIdList = user.TagIdList;
                    model.Sex = user.Sex;
                    model.CheckInTypeId = user.CheckInTypeId;
                    model.LanguageTypeId = user.LanguageTypeId;
                    model.SubscribeSceneTypeId = user.SubscribeSceneTypeId;
                    model.RoleTypeId = user.RoleTypeId;
                    model.SceneTypeId = user.SceneTypeId;
                    model.Status = user.Status;
                    model.SupplierShopId = user.SupplierShopId;
                    model.QrScene = user.QrScene;
                    model.QrSceneStr = user.QrSceneStr;
                    model.Subscribe = user.Subscribe;
                    model.AllowReferee = user.AllowReferee;
                    model.AllowResponse = user.AllowResponse;
                    model.AllowOrder = user.AllowOrder;
                    model.AllowNotice = user.AllowNotice;
                    model.AllowOrderNotice = user.AllowOrderNotice;
                    model.InBlackList = user.InBlackList;
                    model.Deleted = user.Deleted;

                    if (user.SubscribeTime == 0)
                        model.SubscribeTime = null;
                    else
                        model.SubscribeTime = Nop.Core.Weixin.Helpers.DateTimeHelper.GetDateTimeFromXml(user.SubscribeTime);

                    if (user.UnSubscribeTime == 0)
                        model.UnSubscribeTime = null;
                    else
                        model.UnSubscribeTime = Nop.Core.Weixin.Helpers.DateTimeHelper.GetDateTimeFromXml(user.UnSubscribeTime);

                    model.UpdateTime = user.UpdateTime;
                    model.CreatTime = user.CreatTime;
                }

            }
            else
            {
                
            }

            //set default values for the new model
            if (user == null)
            {
                
            }

            return Task.FromResult(model);
        }

        /// <summary>
        /// Prepare User search model
        /// </summary>
        /// <param name="searchModel">User search model</param>
        /// <returns>User search model</returns>
        public virtual Task<UserSearchModel> PrepareUserSearchModelAsync(UserSearchModel searchModel)
        {
            if (searchModel == null)
                throw new ArgumentNullException(nameof(searchModel));

            //prepare page parameters
            searchModel.SetGridPageSize();

            return Task.FromResult(searchModel);
        }

        /// <summary>
        /// Prepare paged User list model
        /// </summary>
        /// <param name="searchModel">User search model</param>
        /// <returns>User list model</returns>
        public virtual async Task<UserListModel> PrepareUserListModelAsync(UserSearchModel searchModel)
        {
            if (searchModel == null)
                throw new ArgumentNullException(nameof(searchModel));

            //get users
            var users = await _wUserService.GetAllUsersAsync(
                nickName: searchModel.SearchUserNickName,
                remark: searchModel.SearchUserRemark,
                pageIndex: searchModel.Page - 1, 
                pageSize: searchModel.PageSize);

            //prepare list model
            var model = await new UserListModel().PrepareToGridAsync(searchModel, users, () =>
            {
                return users.SelectAwait(async user =>
                {
                    //fill in model values from the entity
                    var userModel = user.ToModel<UserModel>();

                    if (!string.IsNullOrEmpty(user.HeadImgUrl))
                        userModel.HeadImgUrl = Senparc.Weixin.MP.CommonService.Utilities.HeadImageUrlHelper.GetHeadImageUrl(user.HeadImgUrl);

                    //convert dates to the user time
                    if (user.SubscribeTime > 0)
                        userModel.SubscribeTime = Nop.Core.Weixin.Helpers.DateTimeHelper.GetDateTimeFromXml(user.SubscribeTime);
                    if (user.UnSubscribeTime > 0)
                        userModel.UnSubscribeTime = Nop.Core.Weixin.Helpers.DateTimeHelper.GetDateTimeFromXml(user.UnSubscribeTime);
                    
                    userModel.UpdateTime = user.UpdateTime;
                    userModel.CreatTime = user.CreatTime;

                    return userModel;
                });
            });

            return model;
        }

        #endregion

        #region QrCodeLimitModel

        /// <summary>
        /// Prepare QrCodeLimit model
        /// </summary>
        /// <param name="model">QrCodeLimit model</param>
        /// <param name="QrCodeLimit">QrCodeLimit</param>
        /// <param name="excludeProperties">Whether to exclude populating of some properties of model</param>
        /// <returns>Product model</returns>
        public virtual async Task<QrCodeLimitModel> PrepareQrCodeLimitModelAsync(QrCodeLimitModel model, WQrCodeLimit qrCodeLimit, bool excludeProperties = false)
        {
            if (qrCodeLimit != null)
            {
                //fill in model values from the entity
                model ??= new QrCodeLimitModel();

                model.Id = qrCodeLimit.Id;

                //whether to fill in some of properties
                if (!excludeProperties)
                {
                    model.QrCodeId = qrCodeLimit.QrCodeId;
                    model.WConfigId = qrCodeLimit.WConfigId ?? 0;
                    model.WQrCodeCategoryId = qrCodeLimit.WQrCodeCategoryId ?? 0;
                    model.WQrCodeChannelId = qrCodeLimit.WQrCodeChannelId ?? 0;
                    model.QrCodeActionTypeId = qrCodeLimit.QrCodeActionTypeId;
                    model.SysName = qrCodeLimit.SysName;
                    model.Description = qrCodeLimit.Description;
                    model.Ticket = qrCodeLimit.Ticket;
                    model.Url = qrCodeLimit.Url;
                    model.SceneStr = qrCodeLimit.SceneStr;
                    model.TagIdList = qrCodeLimit.TagIdList;
                    model.FixedUse = qrCodeLimit.FixedUse;

                    //二维码图片链接
                    if (!string.IsNullOrEmpty(model.Ticket))
                        model.QrCodeImageUrl = Senparc.Weixin.MP.AdvancedAPIs.QrCodeApi.GetShowQrCodeUrl(model.Ticket);

                    var qrCodeLimitBindingSource = await _qrCodeLimitBindingSourceService.GetEntityByQrcodeLimitIdAsync(qrCodeLimit.Id);
                    if (qrCodeLimitBindingSource != null)
                    {
                        var qrCodeLimitBindingSourceModel = qrCodeLimitBindingSource.ToModel<QrCodeLimitBindingSourceModel>();
                        model.BindingSource = qrCodeLimitBindingSourceModel;
                    }
                }

                //prepare nested search model
                await PrepareQrCodeLimitUserSearchModelAsync(model.QrCodeLimitUserSearchModel, qrCodeLimit);
                await PrepareQrCodeSupplierVoucherCouponSearchModelAsync(model.QrCodeSupplierVoucherCouponSearchModel, qrCodeLimit);
            }
            else
            {

            }

            await _baseAdminModelFactory.PrepareQrCodeCategorysAsync(model.AvailableWQrCodeCategorys, false);
            await _baseAdminModelFactory.PrepareQrCodeChannelsAsync(model.AvailableWQrCodeChannels, false);

            //set default values for the new model
            if (qrCodeLimit == null)
            {
                model.FixedUse = false;
            }

            return model;
        }

        /// <summary>
        /// Prepare QrCodeLimit search model
        /// </summary>
        /// <param name="searchModel">QrCodeLimit search model</param>
        /// <returns>QrCodeLimit search model</returns>
        public virtual async Task<QrCodeLimitSearchModel> PrepareQrCodeLimitSearchModelAsync(QrCodeLimitSearchModel searchModel)
        {
            if (searchModel == null)
                throw new ArgumentNullException(nameof(searchModel));

            await _baseAdminModelFactory.PrepareQrCodeCategorysAsync(searchModel.AvailableCategories);

            await _baseAdminModelFactory.PrepareQrCodeChannelsAsync(searchModel.AvailableChannels);

            searchModel.AvailableFixedUseOptions.Add(new SelectListItem
            {
                Value = "0",
                Text = "All"
            });
            searchModel.AvailableFixedUseOptions.Add(new SelectListItem
            {
                Value = "1",
                Text = "Fixed Use"
            });
            searchModel.AvailableFixedUseOptions.Add(new SelectListItem
            {
                Value = "2",
                Text = "UnFixed Use"
            });

            searchModel.AvailableHasCreatedOptions.Add(new SelectListItem
            {
                Value = "0",
                Text = "All"
            });
            searchModel.AvailableHasCreatedOptions.Add(new SelectListItem
            {
                Value = "1",
                Text = "Created"
            });
            searchModel.AvailableHasCreatedOptions.Add(new SelectListItem
            {
                Value = "2",
                Text = "UnCreated"
            });

            //prepare page parameters
            searchModel.SetGridPageSize();

            return searchModel;
        }

        /// <summary>
        /// Prepare paged QrCodeLimit list model
        /// </summary>
        /// <param name="searchModel">QrCodeLimit search model</param>
        /// <returns>QrCodeLimit list model</returns>
        public virtual async Task<QrCodeLimitListModel> PrepareQrCodeLimitListModelAsync(QrCodeLimitSearchModel searchModel)
        {
            if (searchModel == null)
                throw new ArgumentNullException(nameof(searchModel));

            var overrideFixedUse = searchModel.SearchFixedUse == 0 ? null : (bool?)(searchModel.SearchFixedUse == 1);
            var overrideCreated = searchModel.SearchHasCreated == 0 ? null : (bool?)(searchModel.SearchHasCreated == 1);

            //get users
            var qrCodeLimits = await _wQrCodeLimitService.GetWQrCodeLimitsAsync(
                wConfigId: searchModel.WConfigId,
                wQrCodeCategoryId:searchModel.WQrCodeCategoryId,
                wQrCodeChannelId:searchModel.WQrCodeChannelId,
                fixedUse: overrideFixedUse,
                hasCreated: overrideCreated,
                pageIndex: searchModel.Page - 1, pageSize: searchModel.PageSize);

            //prepare list model
            var model = await new QrCodeLimitListModel().PrepareToGridAsync(searchModel, qrCodeLimits, () =>
            {
                return qrCodeLimits.SelectAwait(async qrCodeLimit =>
                {
                    //fill in model values from the entity
                    var qrCodeLimitModel = qrCodeLimit.ToModel<QrCodeLimitModel>();

                    if (!string.IsNullOrEmpty(qrCodeLimitModel.Ticket))
                        qrCodeLimitModel.QrCodeImageUrl = Senparc.Weixin.MP.AdvancedAPIs.QrCodeApi.GetShowQrCodeUrl(qrCodeLimitModel.Ticket);

                    return qrCodeLimitModel;
                });
            });

            return model;
        }

        public virtual async Task<QrCodeLimitUserListModel> PrepareQrCodeLimitUserListModelAsync(QrCodeLimitUserSearchModel searchModel, WQrCodeLimit qrCodeLimit)
        {
            if (searchModel == null)
                throw new ArgumentNullException(nameof(searchModel));

            if (qrCodeLimit == null)
                throw new ArgumentNullException(nameof(qrCodeLimit));

            var qrCodeLimitUsers = await _wQrCodeLimitUserService.GetEntitiesAsync(
                userId: searchModel.UserId,
                qrCodeLimitId: qrCodeLimit.Id,
                pageIndex: searchModel.Page - 1, pageSize: searchModel.PageSize);

            //prepare grid model
            var model = await new QrCodeLimitUserListModel().PrepareToGridAsync(searchModel, qrCodeLimitUsers, () =>
            {
                return qrCodeLimitUsers.SelectAwait(async qrCodeLimitUser =>
                {
                    //fill in model values from the entity
                    var qrCodeLimitUserModel = qrCodeLimitUser.ToModel<QrCodeLimitUserModel>();

                    var user = await _wUserService.GetWUserByIdAsync(qrCodeLimitUser.UserId);
                    if (user != null)
                    {
                        if (string.IsNullOrWhiteSpace(qrCodeLimitUserModel.UserName))
                            qrCodeLimitUserModel.UserName = user.NickName + (string.IsNullOrWhiteSpace(user.Remark) ? "" : " (" + user.Remark + ")");

                        qrCodeLimitUserModel.HeadImageUrl = Senparc.Weixin.MP.CommonService.Utilities.HeadImageUrlHelper.GetHeadImageUrl(user.HeadImgUrl, 64);
                    }

                    return qrCodeLimitUserModel;
                });
            });

            return model;
        }

        public virtual Task<AddUserRelatedSearchModel> PrepareAddUserRelatedSearchModelAsync(AddUserRelatedSearchModel searchModel)
        {
            if (searchModel == null)
                throw new ArgumentNullException(nameof(searchModel));

            //prepare page parameters
            searchModel.SetPopupGridPageSize();

            return Task.FromResult(searchModel);
        }

        /// <summary>
        /// Prepare paged related product list model to add to the product
        /// </summary>
        /// <param name="searchModel">Related product search model to add to the product</param>
        /// <returns>Related product list model to add to the product</returns>
        public virtual async Task<AddUserRelatedUserListModel> PrepareAddUserRelatedUserListModelAsync(AddUserRelatedSearchModel searchModel)
        {
            if (searchModel == null)
                throw new ArgumentNullException(nameof(searchModel));

            //get users
            var users = await _wUserService.GetAllUsersAsync(
                nickName: searchModel.SearchUserNickName,
                remark: searchModel.SearchUserRemark,
                pageIndex: searchModel.Page - 1, pageSize: searchModel.PageSize);

            //prepare grid model
            var model = await new AddUserRelatedUserListModel().PrepareToGridAsync(searchModel, users, () =>
            {
                return users.SelectAwait(async user =>
                {
                    var userModel = user.ToModel<AddUserRelatedUserModel>();

                    userModel.NickName = user.NickName + (string.IsNullOrWhiteSpace(user.Remark) ? "" : " (" + user.Remark + ")");
                    userModel.HeadImgUrl = Senparc.Weixin.MP.CommonService.Utilities.HeadImageUrlHelper.GetHeadImageUrl(user.HeadImgUrl, 64);
                    return userModel;
                });
            });

            return model;
        }

        protected virtual Task<QrCodeLimitUserSearchModel> PrepareQrCodeLimitUserSearchModelAsync(QrCodeLimitUserSearchModel searchModel, WQrCodeLimit qrCodeLimit)
        {
            if (searchModel == null)
                throw new ArgumentNullException(nameof(searchModel));

            if (qrCodeLimit == null)
                throw new ArgumentNullException(nameof(qrCodeLimit));

            searchModel.QrCodeLimitId = qrCodeLimit.Id;

            //prepare page parameters
            searchModel.SetGridPageSize();

            return Task.FromResult(searchModel);
        }

        protected virtual Task<QrCodeSupplierVoucherCouponSearchModel> PrepareQrCodeSupplierVoucherCouponSearchModelAsync(QrCodeSupplierVoucherCouponSearchModel searchModel, WQrCodeLimit qrCodeLimit)
        {
            if (searchModel == null)
                throw new ArgumentNullException(nameof(searchModel));

            if (qrCodeLimit == null)
                throw new ArgumentNullException(nameof(qrCodeLimit));

            searchModel.QrCodeId = qrCodeLimit.Id;
            searchModel.QrcodeLimit = true;

            //prepare page parameters
            searchModel.SetGridPageSize();

            return Task.FromResult(searchModel);
        }

        public virtual async Task<QrCodeLimitUserModel> PrepareQrCodeLimitUserModelAsync(QrCodeLimitUserModel model, WQrCodeLimitUserMapping qrCodeLimitUser, bool excludeProperties = false)
        {
            if (qrCodeLimitUser != null)
            {
                //fill in model values from the entity
                model ??= new QrCodeLimitUserModel();

                model.Id = qrCodeLimitUser.Id;

                //whether to fill in some of properties
                if (!excludeProperties)
                {
                    model.UserId = qrCodeLimitUser.UserId;
                    model.QrCodeLimitId = qrCodeLimitUser.QrCodeLimitId;
                    model.UserName = qrCodeLimitUser.UserName;
                    model.Description = qrCodeLimitUser.Description;
                    model.TelNumber = qrCodeLimitUser.TelNumber;
                    model.AddressInfo = qrCodeLimitUser.AddressInfo;
                    model.ExpireTime = qrCodeLimitUser.ExpireTime;
                    model.Published = qrCodeLimitUser.Published;

                    var user = await _wUserService.GetWUserByIdAsync(model.UserId);
                    if (user != null)
                    {
                        if (string.IsNullOrEmpty(model.UserName))
                            model.UserNameTemp = user.NickName + (string.IsNullOrEmpty(user.Remark) ? "" : "(" + user.Remark + ")");
                    }
  

                }

            }
            else
            {

            }

            //set default values for the new model
            if (qrCodeLimitUser == null)
            {

            }

            return model;
        }

        #endregion


        #region Menu Model

        public virtual Task<MenuSearchModel> PrepareMenuSearchModelAsync(MenuSearchModel searchModel)
        {
            if (searchModel == null)
                throw new ArgumentNullException(nameof(searchModel));

            searchModel.AvailablePersonals.Add(new SelectListItem
            {
                Value = "0",
                Text = "All"
            });
            searchModel.AvailablePersonals.Add(new SelectListItem
            {
                Value = "1",
                Text = "Personal Menu"
            });
            searchModel.AvailablePersonals.Add(new SelectListItem
            {
                Value = "2",
                Text = "Common Menu"
            });

            //prepare page parameters
            searchModel.SetGridPageSize();

            return Task.FromResult(searchModel);
        }

        public virtual async Task<MenuListModel> PrepareMenuListModelAsync(MenuSearchModel searchModel)
        {
            if (searchModel == null)
                throw new ArgumentNullException(nameof(searchModel));

            var overridePersonal = searchModel.SeletedPersonalId == 0 ? null : (bool?)(searchModel.SeletedPersonalId == 1);
            //get users
            var menus = await _wMenuService.GetAllMenusAsync(
                systemName: searchModel.SearchSystemName,
                personal: overridePersonal,
                pageIndex: searchModel.Page - 1, pageSize: searchModel.PageSize);

            //prepare list model
            var model = await new MenuListModel().PrepareToGridAsync(searchModel, menus, () =>
            {
                return menus.SelectAwait(async menu =>
                {
                    //fill in model values from the entity
                    var menuModel = menu.ToModel<MenuModel>();

                    return menuModel;
                });
            });

            return model;
        }

        public virtual async Task<MenuModel> PrepareMenuModelAsync(MenuModel model, WMenu menu, bool excludeProperties = false)
        {
            if (menu != null)
            {
                //fill in model values from the entity
                model ??= new MenuModel();

                model.Id = menu.Id;

                //whether to fill in some of properties
                if (!excludeProperties)
                {
                    model.MenuId = menu.MenuId;
                    model.SystemName = menu.SystemName;
                    model.Description = menu.Description;
                    model.MenuJsonCode = menu.MenuJsonCode;
                    model.TagId = menu.TagId;
                    model.Sex = menu.Sex;
                    model.ClientPlatformType = menu.ClientPlatformType;
                    model.Country = menu.Country;
                    model.Province = menu.Province;
                    model.City = menu.City;
                    model.LanguageTypeId = menu.LanguageTypeId;
                    model.Status = menu.Status;
                    model.PublishTime = menu.PublishTime;
                    model.UnPublishTime = menu.UnPublishTime;
                    model.DefaultMenu = menu.DefaultMenu;
                    model.IsMenuOpen = menu.IsMenuOpen;
                    model.Published = menu.Published;
                    model.Personal = menu.Personal;
                    model.Deleted = menu.Deleted;
                }

                //prepare nested search model
                await PrepareMenuButtonSearchModelAsync(model.MenuButtonSearchModel, menu);

            }
            else
            {

            }

            //set default values for the new model
            if (menu == null)
            {

            }

            return model;
        }

        protected virtual Task<MenuButtonSearchModel> PrepareMenuButtonSearchModelAsync(MenuButtonSearchModel searchModel, WMenu menu)
        {
            if (searchModel == null)
                throw new ArgumentNullException(nameof(searchModel));

            if (menu == null)
                throw new ArgumentNullException(nameof(menu));

            searchModel.MenuId = menu.Id;

            //prepare page parameters
            searchModel.SetGridPageSize();

            return Task.FromResult(searchModel);
        }

        public virtual async Task<MenuButtonListModel> PrepareMenuButtonListModelAsync(MenuButtonSearchModel searchModel, WMenu menu)
        {
            if (searchModel == null)
                throw new ArgumentNullException(nameof(searchModel));

            if (menu == null)
                throw new ArgumentNullException(nameof(menu));

            var menuButtons = (await _wMenuButtonService.GetMenuButtonsByMenuIdAsync(menu.Id)).ToPagedList(searchModel);

            //prepare grid model
            var model = await new MenuButtonListModel().PrepareToGridAsync(searchModel, menuButtons, () =>
            {
                return menuButtons.SelectAwait(async menuButton =>
                {
                    //fill in model values from the entity
                    var menuButtonModel = menuButton.ToModel<MenuButtonModel>();
                    menuButtonModel.MenuButtonTypeNameString = (Enum.TryParse(typeof(WMenuButtonType), menuButtonModel.MenuButtonTypeId.ToString(), out var parseResult) ? (WMenuButtonType)parseResult : WMenuButtonType.Click).ToString();

                    return menuButtonModel;
                });
            });

            return model;
        }





        #endregion

        #endregion
    }
}