using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Nop.Core;
using Nop.Core.Domain.Catalog;
using Nop.Core.Domain.Vendors;
using Nop.Core.Domain.Weixin;
using Nop.Core.Html;
using Nop.Data;
using Nop.Services.Events;

namespace Nop.Services.Weixin
{
    /// <summary>
    /// WQrCodeLimitUser Service
    /// </summary>
    public partial class QrCodeLimitBindingSourceService : IQrCodeLimitBindingSourceService
    {
        #region Fields

        private readonly IRepository<QrCodeLimitBindingSource> _qrCodeLimitBindingSourceRepository;

        #endregion

        #region Ctor

        public QrCodeLimitBindingSourceService(
            IRepository<QrCodeLimitBindingSource> qrCodeLimitBindingSourceRepository)
        {
            _qrCodeLimitBindingSourceRepository = qrCodeLimitBindingSourceRepository;
        }

        #endregion

        #region Methods

        public virtual async Task InsertEntityAsync(QrCodeLimitBindingSource entity)
        {
            await _qrCodeLimitBindingSourceRepository.InsertAsync(entity);
        }

        public virtual async Task DeleteEntityAsync(QrCodeLimitBindingSource entity)
        {
            await _qrCodeLimitBindingSourceRepository.DeleteAsync(entity);
        }

        public virtual async Task DeleteEntitiesAsync(IList<QrCodeLimitBindingSource> entities)
        {
            await _qrCodeLimitBindingSourceRepository.DeleteAsync(entities);
        }

        public virtual async Task UpdateEntityAsync(QrCodeLimitBindingSource entity)
        {
            await _qrCodeLimitBindingSourceRepository.UpdateAsync(entity);
        }

        public virtual async Task UpdateEntitiesAsync(IList<QrCodeLimitBindingSource> entities)
        {
            await _qrCodeLimitBindingSourceRepository.UpdateAsync(entities);
        }

        public virtual async Task<QrCodeLimitBindingSource> GetEntityByIdAsync(int id)
        {
            if (id == 0)
                return null;

            return await _qrCodeLimitBindingSourceRepository.GetByIdAsync(id, cache => default);
        }

        public virtual async Task<QrCodeLimitBindingSource> GetEntityByQrcodeLimitIdAsync(int qrCodeLimitId)
        {
            if (qrCodeLimitId == 0)
                return null;

            var query = from t in _qrCodeLimitBindingSourceRepository.Table
                        where t.QrCodeLimitId == qrCodeLimitId
                        select t;

            return await query.FirstOrDefaultAsync();
        }

        public virtual async Task<IList<QrCodeLimitBindingSource>> GetEntitiesByIdsAsync(int[] wEntityIds)
        {
            return await _qrCodeLimitBindingSourceRepository.GetByIdsAsync(wEntityIds, cache => default);
        }

        public virtual async Task<IPagedList<QrCodeLimitBindingSource>> GetEntitiesAsync(
            int qrCodeLimitId = 0, 
            int supplierId = 0, 
            int supplierShopId = 0, 
            int productId = 0, 
            bool? published = null, 
            int pageIndex = 0, int pageSize = int.MaxValue)
        {
            var query = _qrCodeLimitBindingSourceRepository.Table;

            if (qrCodeLimitId > 0)
                query = query.Where(v => v.QrCodeLimitId == qrCodeLimitId);
            if (supplierId > 0)
                query = query.Where(v => v.SupplierId == supplierId);
            if (supplierShopId > 0)
                query = query.Where(v => v.SupplierShopId == supplierShopId);
            if (productId > 0)
                query = query.Where(v => v.ProductId == productId);

            if (published.HasValue)
                query = query.Where(v => v.Published == published);

            query = query.OrderBy(v => v.Id);

            return await query.ToPagedListAsync(pageIndex, pageSize);
        }

        #endregion
    }
}