using System.Collections.Generic;
using System.Threading.Tasks;
using Nop.Core;
using Nop.Core.Domain.Suppliers;

namespace Nop.Services.Suppliers
{
    /// <summary>
    /// Suppliers Service interface
    /// </summary>
    public partial interface ISupplierImageService
    {
        Task InsertEntityAsync(SupplierImage entity);

        Task DeleteEntityAsync(SupplierImage entity, bool delete = false);

        Task DeleteEntitiesAsync(IList<SupplierImage> entities, bool deleted = false);

        Task UpdateEntityAsync(SupplierImage entity);

        Task UpdateEntitiesAsync(IList<SupplierImage> entities);

        Task<SupplierImage> GetEntityByIdAsync(int id);

        Task<IList<SupplierImage>> GetEntitiesByIdsAsync(int[] entityIds);

        Task<IPagedList<SupplierImage>> GetEntitiesAsync(
            int supplierShopId = 0,
            int supplierImageTypeId = 0,
            bool? published = null,
            bool? deleted = null,
            int pageIndex = 0, int pageSize = int.MaxValue);
    }
}