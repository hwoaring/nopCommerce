using System;
using System.Collections.Generic;
using System.Linq;
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

        public virtual void InsertEntity(SupplierVoucherCoupon entity)
        {
            _supplierVoucherCouponRepository.Insert(entity);
        }

        public virtual void DeleteEntity(SupplierVoucherCoupon entity, bool delete = false)
        {
            if (entity == null)
                throw new ArgumentNullException(nameof(entity));

            if (delete)
            {
                _supplierVoucherCouponRepository.Delete(entity);
            }
            else
            {
                entity.Deleted = true;
                _supplierVoucherCouponRepository.Update(entity);
            }
        }

        public virtual void DeleteEntities(IList<SupplierVoucherCoupon> entities, bool deleted = false)
        {
            if (entities == null)
                throw new ArgumentNullException(nameof(entities));

            if (deleted)
            {
                _supplierVoucherCouponRepository.Delete(entities);
            }
            else
            {
                foreach (var entity in entities)
                {
                    entity.Deleted = true;
                }
                _supplierVoucherCouponRepository.Update(entities);
            }
        }

        public virtual void UpdateEntity(SupplierVoucherCoupon entity)
        {
            _supplierVoucherCouponRepository.Update(entity);
        }

        public virtual void UpdateEntities(IList<SupplierVoucherCoupon> entities)
        {
            _supplierVoucherCouponRepository.Update(entities);
        }

        public virtual SupplierVoucherCoupon GetEntityById(int id)
        {
            return _supplierVoucherCouponRepository.GetById(id, cache => default);
        }

        public virtual List<SupplierVoucherCoupon> GetEntitiesByIds(int[] entityIds)
        {
            if (entityIds is null)
                return new List<SupplierVoucherCoupon>();

            var query = from t in _supplierVoucherCouponRepository.Table
                        where entityIds.Contains(t.Id) &&
                        t.StartDateTimeUtc < DateTime.UtcNow &&
                        t.EndDateTimeUtc >= DateTime.UtcNow &&
                        !t.Deleted &&
                        !t.Locked &&
                        t.Published
                        select t;

            return query.ToList();
        }

        public virtual List<SupplierVoucherCoupon> GetEntitiesBySupplier(int supplierId, int supplierShopId = 0)
        {
            if (supplierId == 0)
                return new List<SupplierVoucherCoupon>();

            var query = _supplierVoucherCouponRepository.Table;
            query = query.Where(q => q.SupplierId == supplierId);

            if (supplierShopId > 0)
                query = query.Where(q => q.SupplierShopId == supplierShopId);

            query = query.Where(q => !q.Deleted);

            return query.ToList();
        }

        public virtual IPagedList<SupplierVoucherCoupon> GetEntities(
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

            return new PagedList<SupplierVoucherCoupon>(query, pageIndex, pageSize);
        }

        #endregion
    }
}