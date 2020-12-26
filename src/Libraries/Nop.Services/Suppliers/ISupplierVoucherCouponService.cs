using System.Collections.Generic;
using System.Threading.Tasks;
using Nop.Core;
using Nop.Core.Domain.Suppliers;
using Nop.Core.Domain.Marketing;
using System;

namespace Nop.Services.Suppliers
{
    /// <summary>
    /// Suppliers Service interface
    /// </summary>
    public partial interface ISupplierVoucherCouponService
    {
        Task InsertEntityAsync(SupplierVoucherCoupon entity);

        Task DeleteEntityAsync(SupplierVoucherCoupon entity);

        Task DeleteEntitiesAsync(IList<SupplierVoucherCoupon> entities);

        Task UpdateEntityAsync(SupplierVoucherCoupon entity);

        Task UpdateEntitiesAsync(IList<SupplierVoucherCoupon> entities);

        Task<SupplierVoucherCoupon> GetEntityByIdAsync(int id);

        Task<IList<SupplierVoucherCoupon>> GetEntitiesByIdsAsync(int[] entityIds);

        Task<IList<SupplierVoucherCoupon>> GetEntitiesBySupplierAsync(int supplierId, int supplierShopId = 0);

        Task<IPagedList<SupplierVoucherCoupon>> GetEntitiesAsync(
            string name = "",
            int supplierId = 0,
            int? supplierShopId = 0,
            AssetType? assetType = null,
            bool? getForFree = null,
            bool? published = null,
            bool? locked = null,
            bool? newUserGift = null,
            bool? offlineConsume = null,
            bool? deleted = null,
            int pageIndex = 0, int pageSize = int.MaxValue);

    }
}