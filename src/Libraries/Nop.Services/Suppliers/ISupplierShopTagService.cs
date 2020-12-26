using System.Collections.Generic;
using System.Threading.Tasks;
using Nop.Core;
using Nop.Core.Domain.Suppliers;

namespace Nop.Services.Suppliers
{
    /// <summary>
    /// Suppliers Service interface
    /// </summary>
    public partial interface ISupplierShopTagService
    {
        Task InsertEntityAsync(SupplierShopTag entity);

        Task DeleteEntityAsync(SupplierShopTag entity, bool delete = false);

        Task DeleteEntitiesAsync(IList<SupplierShopTag> entities, bool deleted = false);

        Task UpdateEntityAsync(SupplierShopTag entity);

        Task UpdateEntitiesAsync(IList<SupplierShopTag> entities);

        Task<SupplierShopTag> GetEntityByIdAsync(int id);

        Task<IList<SupplierShopTag>> GetEntitiesByIdsAsync(int[] entityIds);

        Task<IPagedList<SupplierShopTag>> GetEntitiesAsync(
            string name = "",
            bool? published = null,
            bool? deleted = null,
            int pageIndex = 0, int pageSize = int.MaxValue);
    }
}