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
    public partial interface IOfficialCustomerService
    {
        Task InsertEntityAsync(OfficialCustomer entity);

        Task DeleteEntityAsync(OfficialCustomer entity, bool delete = false);

        Task DeleteEntitiesAsync(IList<OfficialCustomer> entities, bool deleted = false);

        Task UpdateEntityAsync(OfficialCustomer entity);

        Task UpdateEntitiesAsync(IList<OfficialCustomer> entities);

        Task<OfficialCustomer> GetEntityByIdAsync(int id);

        Task<IList<int>> GetCategoryIdsByIdAsync(int id);

        Task<IList<OfficialCustomer>> GetEntitiesByIdsAsync(int[] entityIds);

        Task<IPagedList<OfficialCustomer>> GetEntitiesAsync(
            int storeId = 0,
            bool? published = null,
            bool? deleted = null,
            int pageIndex = 0, int pageSize = int.MaxValue);
    }
}