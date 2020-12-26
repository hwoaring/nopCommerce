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
    public partial interface IProductSupplierVoucherCouponMappingService
    {
        Task InsertEntityAsync(ProductSupplierVoucherCouponMapping entity);

        Task DeleteEntityAsync(ProductSupplierVoucherCouponMapping entity);

        Task DeleteEntitiesAsync(IList<ProductSupplierVoucherCouponMapping> entities);

        Task UpdateEntityAsync(ProductSupplierVoucherCouponMapping entity);

        Task UpdateEntitiesAsync(IList<ProductSupplierVoucherCouponMapping> entities);

        Task<ProductSupplierVoucherCouponMapping> GetEntityByIdAsync(int id);


        Task<IList<ProductSupplierVoucherCouponMapping>> GetEntitiesByIdsAsync(int[] entityIds);

        Task<IPagedList<ProductSupplierVoucherCouponMapping>> GetEntitiesAsync(
            int productId=0,
            int? productAttributeValueId=0,
            int supplierVoucherCouponId=0,
            int? customerRoleId=0,
            int storeId=0,
            DateTime? startDateTimeUtc=null,
            DateTime? endDateTimeUtc=null,
            int pageIndex = 0, int pageSize = int.MaxValue);

    }
}