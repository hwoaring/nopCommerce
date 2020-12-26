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
    public partial interface IProductMarketLabelService
    {
        Task InsertEntityAsync(ProductMarketLabel entity);

        Task DeleteEntityAsync(ProductMarketLabel entity, bool delete = false);

        Task DeleteEntitiesAsync(IList<ProductMarketLabel> entities, bool deleted = false);

        Task UpdateEntityAsync(ProductMarketLabel entity);

        Task UpdateEntitiesAsync(IList<ProductMarketLabel> entities);

        Task<ProductMarketLabel> GetEntityByIdAsync(int id);

        Task<IList<ProductMarketLabel>> GetEntitiesByIdsAsync(int[] entityIds);

        Task<IPagedList<ProductMarketLabel>> GetEntitiesAsync(
            bool? published = null,
            bool? deleted = null,
            int pageIndex = 0, int pageSize = int.MaxValue);
    }
}