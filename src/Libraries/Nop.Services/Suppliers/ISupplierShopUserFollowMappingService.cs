using System.Collections.Generic;
using System.Threading.Tasks;
using Nop.Core;
using Nop.Core.Domain.Suppliers;

namespace Nop.Services.Suppliers
{
    /// <summary>
    /// Suppliers Service interface
    /// </summary>
    public partial interface ISupplierShopUserFollowMappingService
    {
        Task InsertEntityAsync(SupplierShopUserFollowMapping entity);

        Task DeleteEntityAsync(SupplierShopUserFollowMapping entity);

        Task DeleteEntitiesAsync(IList<SupplierShopUserFollowMapping> entities);

        Task UpdateEntityAsync(SupplierShopUserFollowMapping entity);

    }
}