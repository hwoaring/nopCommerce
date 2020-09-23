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
using LinqToDB.Linq;

namespace Nop.Services.Suppliers
{
    /// <summary>
    /// WConfig Service
    /// </summary>
    public partial class QrCodeSupplierVoucherCouponMappingService : IQrCodeSupplierVoucherCouponMappingService
    {
        #region Fields

        private readonly IRepository<QrCodeSupplierVoucherCouponMapping> _qrCodeSupplierVoucherCouponMappingRepository;

        #endregion

        #region Ctor

        public QrCodeSupplierVoucherCouponMappingService(
            IRepository<QrCodeSupplierVoucherCouponMapping> qrCodeSupplierVoucherCouponMappingRepository)
        {
            _qrCodeSupplierVoucherCouponMappingRepository = qrCodeSupplierVoucherCouponMappingRepository;
        }

        #endregion

        #region Methods

        public virtual void InsertEntity(QrCodeSupplierVoucherCouponMapping entity)
        {
            _qrCodeSupplierVoucherCouponMappingRepository.Insert(entity);
        }

        public virtual void DeleteEntity(QrCodeSupplierVoucherCouponMapping entity)
        {
            _qrCodeSupplierVoucherCouponMappingRepository.Delete(entity);
        }

        public virtual void DeleteEntities(IList<QrCodeSupplierVoucherCouponMapping> entities)
        {
            _qrCodeSupplierVoucherCouponMappingRepository.Delete(entities);
        }

        public virtual void UpdateEntity(QrCodeSupplierVoucherCouponMapping entity)
        {
            _qrCodeSupplierVoucherCouponMappingRepository.Update(entity);
        }

        public virtual void UpdateEntities(IList<QrCodeSupplierVoucherCouponMapping> entities)
        {
            _qrCodeSupplierVoucherCouponMappingRepository.Update(entities);
        }

        public virtual QrCodeSupplierVoucherCouponMapping GetEntityById(int id)
        {
            return _qrCodeSupplierVoucherCouponMappingRepository.GetById(id, cache => default);
        }

        public virtual List<QrCodeSupplierVoucherCouponMapping> GetEntitiesByIds(int[] entityIds)
        {
            if (entityIds is null)
                return new List<QrCodeSupplierVoucherCouponMapping>();

            var query = from t in _qrCodeSupplierVoucherCouponMappingRepository.Table
                        where entityIds.Contains(t.Id)
                        select t;

            return query.ToList();
        }

        public virtual List<QrCodeSupplierVoucherCouponMapping> GetEntitiesByQrCodeId(int qrCodeId, bool qrcodeLimitId = true, bool showAll = false)
        {
            if (qrCodeId == 0)
                return new List<QrCodeSupplierVoucherCouponMapping>();

            var query = _qrCodeSupplierVoucherCouponMappingRepository.Table;
            query = query.Where(q => q.QrCodeId == qrCodeId);
            query = query.Where(q => q.QrcodeLimit == qrcodeLimitId);

            if (!showAll)
            {
                query = query.Where(q => q.Published);
                query = query.Where(q => q.StartDateTime.HasValue && q.StartDateTime < DateTime.Now);
                query = query.Where(q => q.EndDateTime.HasValue && q.EndDateTime >= DateTime.Now);
            }

            return query.ToList();
        }

        public virtual IPagedList<QrCodeSupplierVoucherCouponMapping> GetEntities(
            int qrCodeId = 0,
            int supplierVoucherCouponId = 0,
            bool? qrcodeLimit = null,
            bool? published = null,
            DateTime? startDateTime = null,
            DateTime? endDateTime = null,
            int pageIndex = 0, int pageSize = int.MaxValue)
        {
            var query = _qrCodeSupplierVoucherCouponMappingRepository.Table;

            if (qrCodeId > 0)
                query = query.Where(q => q.QrCodeId == qrCodeId);
            if (supplierVoucherCouponId>0)
                query = query.Where(q => q.SupplierVoucherCouponId== supplierVoucherCouponId);
            if (qrcodeLimit.HasValue)
                query = query.Where(q => q.QrcodeLimit == qrcodeLimit);
            if (published.HasValue)
                query = query.Where(q => q.Published == published);
            if (startDateTime.HasValue)
                query = query.Where(q => q.StartDateTime > startDateTime);
            if (endDateTime.HasValue)
                query = query.Where(q => q.EndDateTime <= endDateTime);

            return new PagedList<QrCodeSupplierVoucherCouponMapping>(query, pageIndex, pageSize);
        }


        #endregion
    }
}