using System;
using System.Collections.Generic;
using System.Linq;
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

        public virtual void InsertEntity(QrCodeLimitBindingSource entity)
        {
            _qrCodeLimitBindingSourceRepository.Insert(entity);
        }

        public virtual void DeleteEntity(QrCodeLimitBindingSource entity)
        {
            _qrCodeLimitBindingSourceRepository.Delete(entity);
        }

        public virtual void DeleteEntities(IList<QrCodeLimitBindingSource> entities)
        {
            _qrCodeLimitBindingSourceRepository.Delete(entities);
        }

        public virtual void UpdateEntity(QrCodeLimitBindingSource entity)
        {
            _qrCodeLimitBindingSourceRepository.Update(entity);
        }

        public virtual void UpdateEntities(IList<QrCodeLimitBindingSource> entities)
        {
            _qrCodeLimitBindingSourceRepository.Update(entities);
        }

        public virtual QrCodeLimitBindingSource GetEntityById(int id)
        {
            if (id == 0)
                return null;

            return _qrCodeLimitBindingSourceRepository.GetById(id, cache => default);
        }

        public virtual QrCodeLimitBindingSource GetEntityByQrcodeLimitId(int qrCodeLimitId)
        {
            if (qrCodeLimitId == 0)
                return null;

            var query = from t in _qrCodeLimitBindingSourceRepository.Table
                        where t.QrCodeLimitId == qrCodeLimitId
                        select t;

            return query.FirstOrDefault();
        }

        public virtual List<QrCodeLimitBindingSource> GetEntitiesByIds(int[] wEntityIds)
        {
            if (wEntityIds is null)
                return new List<QrCodeLimitBindingSource>();

            var query = from t in _qrCodeLimitBindingSourceRepository.Table
                        where wEntityIds.Contains(t.Id) &&
                        t.Published
                        select t;

            return query.ToList();
        }

        public virtual IPagedList<QrCodeLimitBindingSource> GetEntities(
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

            return new PagedList<QrCodeLimitBindingSource>(query, pageIndex, pageSize);
        }

        #endregion
    }
}