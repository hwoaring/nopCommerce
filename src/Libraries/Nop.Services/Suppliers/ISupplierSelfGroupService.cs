using System.Collections.Generic;
using System.Threading.Tasks;
using Nop.Core;
using Nop.Core.Domain.Suppliers;

namespace Nop.Services.Suppliers
{
    /// <summary>
    /// Suppliers Service interface
    /// </summary>
    public partial interface ISupplierSelfGroupService
    {
        Task InsertEntityAsync(SupplierSelfGroup entity);

        Task DeleteEntityAsync(SupplierSelfGroup entity, bool delete = false);

        Task DeleteEntitiesAsync(IList<SupplierSelfGroup> entities, bool deleted = false);

        Task UpdateEntityAsync(SupplierSelfGroup entity);

        Task UpdateEntitiesAsync(IList<SupplierSelfGroup> entities);

        Task<SupplierSelfGroup> GetEntityByIdAsync(int id);

        Task<IList<SupplierSelfGroup>> GetEntitiesBySupplierIdAsync(int supplierId);

        Task<IList<SupplierSelfGroup>> GetEntitiesByIdsAsync(int[] entityIds);

        Task<IPagedList<SupplierSelfGroup>> GetEntitiesAsync(
            int supplierId = 0,
            bool? published = null,
            bool? deleted = null,
            int pageIndex = 0, int pageSize = int.MaxValue);
    }
}