using System.Collections.Generic;
using System.Threading.Tasks;
using Nop.Core;
using Nop.Core.Domain.Suppliers;

namespace Nop.Services.Suppliers
{
    /// <summary>
    /// Suppliers Service interface
    /// </summary>
    public partial interface ISupplierShopService
    {
        Task InsertEntityAsync(SupplierShop entity);

        Task DeleteEntityAsync(SupplierShop entity);

        Task DeleteEntitiesAsync(IList<SupplierShop> entities);

        Task UpdateEntityAsync(SupplierShop entity);

        Task UpdateEntitiesAsync(IList<SupplierShop> entities);

        Task<SupplierShop> GetEntityByIdAsync(int id);

        Task<IList<SupplierShop>> GetEntitiesByIdsAsync(int[] entityIds);

        Task<IList<SupplierShop>> GetEntitiesBySupplierIdAsync(int supplierId);

        Task<IPagedList<SupplierShop>> GetEntitiesAsync(
            int supplierId = 0,
            string name = "",
            bool? published = null,
            bool? deleted = null,
            int pageIndex = 0, int pageSize = int.MaxValue);
    }
}