using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Nop.Core;
using Nop.Core.Domain.Catalog;
using Nop.Core.Domain.Vendors;
using Nop.Core.Domain.Suppliers;
using Nop.Core.Html;
using Nop.Data;
using Nop.Services.Events;
using Nop.Core.Domain.Marketing;

namespace Nop.Services.Suppliers
{
    /// <summary>
    /// WConfig Service
    /// </summary>
    public partial class SupplierVoucherCouponService : ISupplierVoucherCouponService
    {
        #region Fields

        private readonly IRepository<SupplierVoucherCoupon> _supplierVoucherCouponRepository;

        #endregion

        #region Ctor

        public SupplierVoucherCouponService(
            IRepository<SupplierVoucherCoupon> supplierVoucherCouponRepository)
        {
            _supplierVoucherCouponRepository = supplierVoucherCouponRepository;
        }

        #endregion

        #region Methods

        public virtual async Task InsertEntityAsync(SupplierVoucherCoupon entity)
        {
            await _supplierVoucherCouponRepository.InsertAsync(entity);
        }

        public virtual async Task DeleteEntityAsync(SupplierVoucherCoupon entity)
        {
            await _supplierVoucherCouponRepository.DeleteAsync(entity);
        }

        public virtual async Task DeleteEntitiesAsync(IList<SupplierVoucherCoupon> entities)
        {
            await _supplierVoucherCouponRepository.DeleteAsync(entities);
        }

        public virtual async Task UpdateEntityAsync(SupplierVoucherCoupon entity)
        {
            await _supplierVoucherCouponRepository.UpdateAsync(entity);
        }

        public virtual async Task UpdateEntitiesAsync(IList<SupplierVoucherCoupon> entities)
        {
           await  _supplierVoucherCouponRepository.UpdateAsync(entities);
        }

        public virtual async Task<SupplierVoucherCoupon> GetEntityByIdAsync(int id)
        {
            return await _supplierVoucherCouponRepository.GetByIdAsync(id, cache => default);
        }

        public virtual async Task<IList<SupplierVoucherCoupon>> GetEntitiesByIdsAsync(int[] entityIds)
        {
            return await _supplierVoucherCouponRepository.GetByIdsAsync(entityIds, cache => default);
        }

        public virtual async Task<IList<SupplierVoucherCoupon>> GetEntitiesBySupplierAsync(int supplierId, int supplierShopId = 0)
        {
            if (supplierId == 0)
                return new List<SupplierVoucherCoupon>();

            var query = _supplierVoucherCouponRepository.Table;
            query = query.Where(q => q.SupplierId == supplierId);

            if (supplierShopId > 0)
                query = query.Where(q => q.SupplierShopId == supplierShopId);

            query = query.Where(q => !q.Deleted);

            return await query.ToListAsync();
        }

        public virtual async Task<IPagedList<SupplierVoucherCoupon>> GetEntitiesAsync(
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
            int pageIndex = 0, int pageSize = int.MaxValue)
        {
            var query = _supplierVoucherCouponRepository.Table;

            if (!string.IsNullOrEmpty(name))
                query = query.Where(q => q.Name.Contains(name) || q.SystemName.Contains(name));

            if (supplierId > 0)
                query = query.Where(q => q.SupplierId == supplierId);
            if (supplierShopId.HasValue && supplierShopId > 0)
                query = query.Where(q => q.SupplierShopId == supplierShopId);
            if (assetType.HasValue)
                query = query.Where(q => q.AssetType == assetType);
            if (getForFree.HasValue)
                query = query.Where(q => q.GetForFree);
            if (published.HasValue)
                query = query.Where(q => q.Published == published);
            if (locked.HasValue)
                query = query.Where(q => q.Locked == locked);
            if (newUserGift.HasValue)
                query = query.Where(q => q.NewUserGift == newUserGift);
            if (offlineConsume.HasValue)
                query = query.Where(q => q.OfflineConsume == offlineConsume);
            if (deleted.HasValue)
                query = query.Where(q => q.Deleted == deleted);

            return await query.ToPagedListAsync(pageIndex, pageSize);
        }

        #endregion
    }
}