using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Nop.Core;
using Nop.Core.Domain.Suppliers;

namespace Nop.Services.Suppliers
{
    /// <summary>
    /// Suppliers Service interface
    /// </summary>
    public partial interface ISupplierService
    {
        Task InsertEntityAsync(Supplier entity);

        Task DeleteEntityAsync(Supplier entity, bool delete = false);

        Task DeleteEntitiesAsync(IList<Supplier> entities, bool deleted = false);

        Task UpdateEntityAsync(Supplier entity);

        Task UpdateEntitiesAsync(IList<Supplier> entities);

        Task<Supplier> GetEntityByIdAsync(int id);

        Task<IList<Supplier>> GetEntitiesByIdsAsync(int[] entityIds);

        Task<IList<Supplier>> GetEntitiesByStoreIdAsync(int stroeId);

        Task<IPagedList<Supplier>> GetEntitiesAsync(
            string name = "",
            int storeId = 0,
            DateTime? startDateTimeUtc = null,
            DateTime? endDateTimeUtc = null,
            bool? isPersonal = null,
            bool? published = null,
            bool? deleted = null,
            int pageIndex = 0, int pageSize = int.MaxValue);
    }
}