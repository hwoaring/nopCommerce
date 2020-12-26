using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Nop.Core;
using Nop.Core.Domain.Marketing;

namespace Nop.Services.Marketing
{
    /// <summary>
    /// Suppliers Service interface
    /// </summary>
    public partial interface IProductAdvertImageService
    {
        Task InsertEntityAsync(ProductAdvertImage entity);

        Task DeleteEntityAsync(ProductAdvertImage entity);

        Task DeleteEntitiesAsync(IList<ProductAdvertImage> entities);

        Task UpdateEntityAsync(ProductAdvertImage entity);

        Task UpdateEntitiesAsync(IList<ProductAdvertImage> entities);

        Task<ProductAdvertImage> GetEntityByIdAsync(int id);

        Task<IList<ProductAdvertImage>> GetEntitiesByIdsAsync(int[] entityIds);

        Task<IList<ProductAdvertImage>> GetEntitiesByProductIdAsync(int productId, int top = 1, bool asc = true);

        Task<IList<ProductAdvertImage>> GetEntitiesBySupplierVoucherCouponIdAsync(int supplierVoucherCouponId, int top = 1, bool asc = true);

        Task<IPagedList<ProductAdvertImage>> GetEntitiesAsync(
            string title = "",
            int productId = 0,
            bool? isDiscountAdver = null,
            bool? published = null,
            bool? deleted = null,
            int pageIndex = 0, int pageSize = int.MaxValue);
    }
}