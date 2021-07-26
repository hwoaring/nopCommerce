using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Nop.Core;
using Nop.Core.Domain.Weixin;
using Nop.Core.Domain.Marketing;
using Nop.Core.Domain.Suppliers;

namespace Nop.Services.Marketing
{
    /// <summary>
    /// Suppliers Service interface
    /// </summary>
    public partial interface IUserAssetIncomeHistoryService
    {
        Task InsertEntityAsync(UserAssetIncomeHistory entity);

        Task InsertEntityBysupplierVoucherCouponParamsAsync(SupplierVoucherCoupon supplierVoucherCoupon, int ownerCustomerId, int orderItemId = 0, AssetConsumType? assetConsumType = null, SceneType? sceneType = null);

        Task DeleteEntityAsync(UserAssetIncomeHistory entity);

        Task DeleteEntitiesAsync(IList<UserAssetIncomeHistory> entities);

        Task UpdateEntityAsync(UserAssetIncomeHistory entity);

        Task UpdateEntitiesAsync(IList<UserAssetIncomeHistory> entities);
        /// <summary>
        /// 没有激活的卡券进行激活操作
        /// </summary>
        /// <param name="entity"></param>
        Task ActiveEntityAsync(int userAssetIncomeHistoryId);

        Task<UserAssetIncomeHistory> GetEntityByIdAsync(int id);

        Task<IList<UserAssetIncomeHistory>> GetEntitiesByOwnerCustomerIdAsync(int ownerCustomerId);

        Task<IList<UserAssetIncomeHistory>> GetEntitiesBySupplierIdAsync(int ownerCustomerId, int supplierId, int? supplierShopId = null, bool? onlyUsable = null);

        Task<IList<UserAssetIncomeHistory>> GetEntitiesBySupplierVoucherCouponIdAsync(int ownerCustomerId, int supplierVoucherCouponId, bool? onlyUsable = null);

        Task<IPagedList<UserAssetIncomeHistory>> GetEntitiesAsync(
            int ownerCustomerId = 0,
            int supplierId = 0,
            int supplierShopId = 0,
            int supplierVoucherCouponId = 0,
            string giftCardCouponCode = "",
            AssetType? assetType = null,
            AssetConsumType? assetConsumType = null,
            bool? completed = null,
            bool? approved = null,
            bool? isInvalid = null,
            bool? deleted = null,
            int pageIndex = 0, int pageSize = int.MaxValue);
    }
}