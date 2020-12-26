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
using OfficeOpenXml.FormulaParsing.Excel.Functions.Information;

namespace Nop.Services.Suppliers
{
    /// <summary>
    /// WConfig Service
    /// </summary>
    public partial class SupplierShopService : ISupplierShopService
    {
        #region Fields

        private readonly IRepository<SupplierShop> _supplierShopRepository;

        #endregion

        #region Ctor

        public SupplierShopService(
            IRepository<SupplierShop> supplierShopRepository)
        {
            _supplierShopRepository = supplierShopRepository;
        }

        #endregion

        #region Methods

        public virtual async Task InsertEntityAsync(SupplierShop supplierShop)
        {
            await _supplierShopRepository.InsertAsync(supplierShop);
        }

        public virtual async Task DeleteEntityAsync(SupplierShop supplierShop)
        {
            await _supplierShopRepository.DeleteAsync(supplierShop);
        }

        public virtual async Task DeleteEntitiesAsync(IList<SupplierShop> supplierShops)
        {
            await _supplierShopRepository.DeleteAsync(supplierShops);
        }

        public virtual async Task UpdateEntityAsync(SupplierShop supplierShop)
        {
            await _supplierShopRepository.UpdateAsync(supplierShop);
        }

        public virtual async Task UpdateEntitiesAsync(IList<SupplierShop> supplierShops)
        {
            await _supplierShopRepository.UpdateAsync(supplierShops);
        }

        public virtual async Task<SupplierShop> GetEntityByIdAsync(int id)
        {
            return await _supplierShopRepository.GetByIdAsync(id, cache => default);
        }

        public virtual async Task<IList<SupplierShop>> GetEntitiesByIdsAsync(int[] entityIds)
        {
            return await _supplierShopRepository.GetByIdsAsync(entityIds, cache => default);
        }

        public virtual async Task<IList<SupplierShop>> GetEntitiesBySupplierIdAsync(int supplierId)
        {
            if (supplierId <= 0)
                return new List<SupplierShop>();

            var query = from t in _supplierShopRepository.Table
                        where t.SupplierId == supplierId &&
                        !t.Deleted &&
                        t.Published
                        select t;

            return await query.ToListAsync();
        }

        public virtual async Task<IPagedList<SupplierShop>> GetEntitiesAsync(
            int supplierId = 0,
            string name = "",
            bool? published = null,
            bool? deleted = null,
            int pageIndex = 0, int pageSize = int.MaxValue)
        {
            var query = _supplierShopRepository.Table;

            if (supplierId > 0)
                query = query.Where(q => q.SupplierId == supplierId);
            if (!string.IsNullOrEmpty(name))
                query = query.Where(q => q.Name.Contains(name));
            if (published.HasValue)
                query = query.Where(q => q.Published==published);
            if (deleted.HasValue)
                query = query.Where(q => q.Deleted == deleted);

            return await query.ToPagedListAsync(pageIndex, pageSize);
        }

        #endregion
    }
}