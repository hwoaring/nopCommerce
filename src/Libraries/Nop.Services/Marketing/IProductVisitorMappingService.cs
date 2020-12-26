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
    public partial interface IProductVisitorMappingService
    {
        Task InsertEntityAsync(ProductVisitorMapping entity);

        Task DeleteEntityAsync(ProductVisitorMapping entity);

        Task DeleteEntitiesAsync(IList<ProductVisitorMapping> entities);

        Task UpdateEntityAsync(ProductVisitorMapping entity);

        Task UpdateEntitiesAsync(IList<ProductVisitorMapping> entities);

        Task<ProductVisitorMapping> GetEntitiesByProductIdAsync(int productId);

        Task<IList<int>> GetVisitorIdsByProductIdAsync(int productId);

    }
}