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
    public partial interface IProductExtendLabelService
    {
        Task InsertEntityAsync(ProductExtendLabel entity);

        Task DeleteEntityAsync(ProductExtendLabel entity);

        Task DeleteEntitiesAsync(IList<ProductExtendLabel> entities);

        Task UpdateEntityAsync(ProductExtendLabel entity);

        Task UpdateEntitiesAsync(IList<ProductExtendLabel> entities);

        Task<ProductExtendLabel> GetEntityByIdAsync(int id);

        Task<IList<ProductExtendLabel>> GetEntitiesByIdsAsync(int[] entityIds);

        Task<IPagedList<ProductExtendLabel>> GetEntitiesAsync(
            int storeId = 0,
            int categoryId = 0,
            bool? published = null,
            int pageIndex = 0, int pageSize = int.MaxValue);
    }
}