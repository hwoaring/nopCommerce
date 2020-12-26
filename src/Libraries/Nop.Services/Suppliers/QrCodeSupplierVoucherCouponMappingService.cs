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

        public virtual async Task InsertEntityAsync(QrCodeSupplierVoucherCouponMapping entity)
        {
            await _qrCodeSupplierVoucherCouponMappingRepository.InsertAsync(entity);
        }

        public virtual async Task DeleteEntityAsync(QrCodeSupplierVoucherCouponMapping entity)
        {
            await _qrCodeSupplierVoucherCouponMappingRepository.DeleteAsync(entity);
        }

        public virtual async Task DeleteEntitiesAsync(IList<QrCodeSupplierVoucherCouponMapping> entities)
        {
            await _qrCodeSupplierVoucherCouponMappingRepository.DeleteAsync(entities);
        }

        public virtual async Task UpdateEntityAsync(QrCodeSupplierVoucherCouponMapping entity)
        {
            await _qrCodeSupplierVoucherCouponMappingRepository.UpdateAsync(entity);
        }

        public virtual async Task UpdateEntitiesAsync(IList<QrCodeSupplierVoucherCouponMapping> entities)
        {
            await _qrCodeSupplierVoucherCouponMappingRepository.UpdateAsync(entities);
        }

        public virtual async Task<QrCodeSupplierVoucherCouponMapping> GetEntityByIdAsync(int id)
        {
            return await _qrCodeSupplierVoucherCouponMappingRepository.GetByIdAsync(id, cache => default);
        }

        public virtual async Task<IList<QrCodeSupplierVoucherCouponMapping>> GetEntitiesByIdsAsync(int[] entityIds)
        {
            return await _qrCodeSupplierVoucherCouponMappingRepository.GetByIdsAsync(entityIds, cache => default);
        }

        public virtual async Task<IList<QrCodeSupplierVoucherCouponMapping>> GetEntitiesByQrCodeIdAsync(int qrCodeId, bool qrcodeLimitId = true, bool showAll = false)
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

            return await query.ToListAsync();
        }

        public virtual async Task<IPagedList<QrCodeSupplierVoucherCouponMapping>> GetEntitiesAsync(
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

            return await query.ToPagedListAsync(pageIndex, pageSize);
        }


        #endregion
    }
}