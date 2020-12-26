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
    public partial interface IProductProductMarketLabelMappingService
    {
        Task InsertEntityAsync(ProductProductMarketLabelMapping entity);

        Task DeleteEntityAsync(ProductProductMarketLabelMapping entity);

        Task DeleteEntitiesAsync(IList<ProductProductMarketLabelMapping> entities);

        Task UpdateEntityAsync(ProductProductMarketLabelMapping entity);

        Task UpdateEntitiesAsync(IList<ProductProductMarketLabelMapping> entities);

        Task<ProductProductMarketLabelMapping> GetEntityByIdAsync(int productMarketLabelId, int productId);

        Task<IList<ProductProductMarketLabelMapping>> GetEntitiesByProductMarketLabelIdAsync(int productMarketLabelId);

        Task<IList<ProductProductMarketLabelMapping>> GetEntitiesByProductIdAsync(int productId);
    }
}