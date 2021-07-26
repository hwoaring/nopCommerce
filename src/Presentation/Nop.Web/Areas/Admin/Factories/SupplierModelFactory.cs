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
using Nop.Core.Domain.Suppliers;
using Nop.Core.Domain.Marketing;
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
using Nop.Services.Suppliers;
using Nop.Services.Marketing;

namespace Nop.Web.Areas.Admin.Factories
{
    /// <summary>
    /// Represents the weixin model factory implementation
    /// </summary>
    public partial class SupplierModelFactory : ISupplierModelFactory
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
        private readonly IWxUserService _wUserService;
        private readonly IWxUserTagService _wUserTagService;
        private readonly IQrCodeLimitService _wQrCodeLimitService;
        private readonly IQrCodeLimitUserService _wQrCodeLimitUserService;
        private readonly IQrCodeLimitBindingSourceService _qrCodeLimitBindingSourceService;
        private readonly ISupplierVoucherCouponService _supplierVoucherCouponService;
        private readonly IQrCodeSupplierVoucherCouponMappingService _qrCodeSupplierVoucherCouponMappingService;
        private readonly IWorkContext _workContext;
        private readonly MeasureSettings _measureSettings;
        private readonly TaxSettings _taxSettings;
        private readonly VendorSettings _vendorSettings;

        #endregion

        #region Ctor

        public SupplierModelFactory(
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
            IWxUserService wUserService,
            IWxUserTagService wUserTagService,
            IQrCodeLimitService wQrCodeLimitService,
            IQrCodeLimitUserService wQrCodeLimitUserService,
            IQrCodeLimitBindingSourceService qrCodeLimitBindingSourceService,
            ISupplierVoucherCouponService supplierVoucherCouponService,
            IQrCodeSupplierVoucherCouponMappingService qrCodeSupplierVoucherCouponMappingService,
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
            _supplierVoucherCouponService = supplierVoucherCouponService;
            _qrCodeSupplierVoucherCouponMappingService = qrCodeSupplierVoucherCouponMappingService;
            _workContext = workContext;
            _taxSettings = taxSettings;
            _vendorSettings = vendorSettings;
        }

        #endregion

        #region Utilities

        #endregion

        #region Methods


        #region SupplierModel


        #endregion

        #region SupplierVoucherCouponModel

        public virtual async Task<QrCodeSupplierVoucherCouponListModel> PrepareQrCodeSupplierVoucherCouponListModelAsync(QrCodeSupplierVoucherCouponSearchModel searchModel, QrCodeLimit qrCodeLimit)
        {
            if (searchModel == null)
                throw new ArgumentNullException(nameof(searchModel));

            if (qrCodeLimit == null)
                throw new ArgumentNullException(nameof(qrCodeLimit));

            var qrCodeSupplierVoucherCoupons = await _qrCodeSupplierVoucherCouponMappingService.GetEntitiesAsync(
                qrCodeId: qrCodeLimit.Id,
                qrcodeLimit: searchModel.QrcodeLimit,
                pageIndex: searchModel.Page - 1, pageSize: searchModel.PageSize);

            //prepare grid model
            var model = await new QrCodeSupplierVoucherCouponListModel().PrepareToGridAsync(searchModel, qrCodeSupplierVoucherCoupons, () =>
            {
                return qrCodeSupplierVoucherCoupons.SelectAwait(async qrCodeSupplierVoucherCoupon =>
                {
                    //fill in model values from the entity
                    var qrCodeSupplierVoucherCouponModel = qrCodeSupplierVoucherCoupon.ToModel<QrCodeSupplierVoucherCouponModel>();

                    return qrCodeSupplierVoucherCouponModel;
                });
            });

            return model;
        }

        public virtual Task<AddSupplierVoucherCouponRelatedSearchModel> PrepareAddSupplierVoucherCouponRelatedSearchModelAsync(AddSupplierVoucherCouponRelatedSearchModel searchModel)
        {
            if (searchModel == null)
                throw new ArgumentNullException(nameof(searchModel));

            //prepare page parameters
            searchModel.SetPopupGridPageSize();

            return Task.FromResult(searchModel);
        }

        public virtual async Task<AddSupplierVoucherCouponRelatedCouponListModel> PrepareAddSupplierVoucherCouponRelatedCouponListModelAsync(AddSupplierVoucherCouponRelatedSearchModel searchModel)
        {
            if (searchModel == null)
                throw new ArgumentNullException(nameof(searchModel));

            AssetType? outassetType = null;
            var outassetTypeResult = Enum.TryParse(typeof(AssetType), searchModel.AssetTypeId.ToString(), out var overrideAssetType);
            if (outassetTypeResult)
                outassetType = (AssetType)overrideAssetType;

            //get users
            var supplierVoucherCoupons = await _supplierVoucherCouponService.GetEntitiesAsync(
                name: searchModel.SearchSystemName,
                supplierId: searchModel.SupplierId,
                supplierShopId: searchModel.SupplierShopId,
                assetType: outassetType,
                pageIndex: searchModel.Page - 1, pageSize: searchModel.PageSize);

            //prepare grid model
            var model = await new AddSupplierVoucherCouponRelatedCouponListModel().PrepareToGridAsync(searchModel, supplierVoucherCoupons, () =>
            {
                return supplierVoucherCoupons.SelectAwait(async supplierVoucherCoupon =>
                {
                    var supplierVoucherCouponModel = supplierVoucherCoupon.ToModel<AddSupplierVoucherCouponRelatedCouponModel>();

                    //获取供应商名称，店铺名称

                    return supplierVoucherCouponModel;
                });
            });

            return model;
        }




        #endregion


        #endregion
    }
}