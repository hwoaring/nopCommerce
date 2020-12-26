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
    public partial interface IProductProductExtendLabelMappingService
    {
        Task InsertEntityAsync(ProductProductExtendLabelMapping entity);

        Task DeleteEntityAsync(ProductProductExtendLabelMapping entity);

        Task UpdateEntityAsync(ProductProductExtendLabelMapping entity);

        Task<ProductProductExtendLabelMapping> GetEntityByProductIdAsync(int productId);
        Task<IList<int>> GetProductExtendLabelIdsByProductIdAsync(int productId);

    }
}