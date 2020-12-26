using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Nop.Core;
using Nop.Core.Domain.Suppliers;

namespace Nop.Services.Suppliers
{
    /// <summary>
    /// Suppliers Service interface
    /// </summary>
    public partial interface IQrCodeSupplierVoucherCouponMappingService
    {
        Task InsertEntityAsync(QrCodeSupplierVoucherCouponMapping entity);

        Task DeleteEntityAsync(QrCodeSupplierVoucherCouponMapping entity);

        Task DeleteEntitiesAsync(IList<QrCodeSupplierVoucherCouponMapping> entities);

        Task UpdateEntityAsync(QrCodeSupplierVoucherCouponMapping entity);

        Task UpdateEntitiesAsync(IList<QrCodeSupplierVoucherCouponMapping> entities);

        Task<QrCodeSupplierVoucherCouponMapping> GetEntityByIdAsync(int id);

        Task<IList<QrCodeSupplierVoucherCouponMapping>> GetEntitiesByIdsAsync(int[] entityIds);

        Task<IList<QrCodeSupplierVoucherCouponMapping>> GetEntitiesByQrCodeIdAsync(int qrCodeId, bool qrcodeLimitId = true, bool showAll = false);

        Task<IPagedList<QrCodeSupplierVoucherCouponMapping>> GetEntitiesAsync(
            int qrCodeId = 0,
            int supplierVoucherCouponId = 0,
            bool? qrcodeLimit = null,
            bool? published = null,
            DateTime? startDateTime = null,
            DateTime? endDateTime = null,
            int pageIndex = 0, int pageSize = int.MaxValue);

    }
}