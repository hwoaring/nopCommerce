using System;
using System.Collections.Generic;
using System.Threading.Tasks;
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
    public partial class SupplierUserAuthorityMappingService : ISupplierUserAuthorityMappingService
    {
        #region Fields

        private readonly IRepository<SupplierUserAuthorityMapping> _supplierUserAuthorityMappingRepository;

        #endregion

        #region Ctor

        public SupplierUserAuthorityMappingService(
            IRepository<SupplierUserAuthorityMapping> supplierUserAuthorityMappingRepository)
        {
            _supplierUserAuthorityMappingRepository = supplierUserAuthorityMappingRepository;
        }

        #endregion

        #region Methods

        public virtual async Task InsertEntityAsync(SupplierUserAuthorityMapping entity)
        {
            await _supplierUserAuthorityMappingRepository.InsertAsync(entity);
        }

        public virtual async Task DeleteEntityAsync(SupplierUserAuthorityMapping entity)
        {
            await _supplierUserAuthorityMappingRepository.DeleteAsync(entity);
        }

        public virtual async Task DeleteEntitiesAsync(IList<SupplierUserAuthorityMapping> entities)
        {
            await _supplierUserAuthorityMappingRepository.DeleteAsync(entities);
        }

        public virtual async Task UpdateEntityAsync(SupplierUserAuthorityMapping entity)
        {
            await _supplierUserAuthorityMappingRepository.UpdateAsync(entity);
        }

        public virtual async Task UpdateEntitiesAsync(IList<SupplierUserAuthorityMapping> entities)
        {
            await _supplierUserAuthorityMappingRepository.UpdateAsync(entities);
        }

        public virtual async Task<SupplierUserAuthorityMapping> GetEntityByIdAsync(int id)
        {
            return await _supplierUserAuthorityMappingRepository.GetByIdAsync(id, cache => default);
        }

        public virtual async Task<SupplierUserAuthorityMapping> GetEntityByUserIdAsync(int userId)
        {
            if (userId == 0)
                return null;

            var query = from t in _supplierUserAuthorityMappingRepository.Table
                        where t.WUserId == userId &&
                        !t.Deleted &&
                        t.Published
                        select t;

            return await query.FirstOrDefaultAsync();
        }

        public virtual async Task<IList<SupplierUserAuthorityMapping>> GetEntitiesByIdsAsync(int[] entityIds)
        {
            return await _supplierUserAuthorityMappingRepository.GetByIdsAsync(entityIds, cache => default);
        }

        public virtual async Task<IList<SupplierUserAuthorityMapping>> GetEntitiesBySupplierIdAsync(int supplierId, int supplierShopId = 0)
        {
            if (supplierId == 0)
                return new List<SupplierUserAuthorityMapping>();

            var query = _supplierUserAuthorityMappingRepository.Table;
            query = query.Where(q => q.SupplierId == supplierId);

            if (supplierShopId > 0)
                query = query.Where(q => q.SupplierShopId == supplierShopId);

            query = query.Where(q => !q.Deleted);

            return await query.ToListAsync();
        }

        public virtual async Task<IPagedList<SupplierUserAuthorityMapping>> GetEntitiesAsync(
            int supplierId = 0,
            int supplierShopId = 0,
            bool? financialManager = null,
            bool? verifyManager = null,
            bool? orderConfirmer = null,
            bool? productPulisher = null,
            bool? published = null,
            bool? deleted = null,
            int pageIndex = 0, int pageSize = int.MaxValue)
        {
            var query = _supplierUserAuthorityMappingRepository.Table;

            query = query.Where(q => q.SupplierId == supplierId);
            if (supplierShopId > 0)
                query = query.Where(q => q.SupplierShopId == supplierShopId);

            if (financialManager.HasValue)
                query = query.Where(q => q.FinancialManager == financialManager);
            if (verifyManager.HasValue)
                query = query.Where(q => q.VerifyManager == verifyManager);
            if (orderConfirmer.HasValue)
                query = query.Where(q => q.OrderConfirmer == orderConfirmer);
            if (productPulisher.HasValue)
                query = query.Where(q => q.ProductPulisher == productPulisher);
            if (published.HasValue)
                query = query.Where(q => q.Published == published);
            if (deleted.HasValue)
                query = query.Where(q => q.Deleted == deleted);

            return await query.ToPagedListAsync(pageIndex, pageSize);
        }

        #endregion
    }
}