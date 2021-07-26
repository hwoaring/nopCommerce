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
    public partial interface IPartnerServiceInfoService
    {
        Task InsertEntityAsync(PartnerServiceInfo entity);

        Task DeleteEntityAsync(PartnerServiceInfo entity, bool delete = false);

        Task DeleteEntitiesAsync(IList<PartnerServiceInfo> entities, bool deleted = false);

        Task UpdateEntityAsync(PartnerServiceInfo entity);

        Task UpdateEntitiesAsync(IList<PartnerServiceInfo> entities);

        Task<PartnerServiceInfo> GetEntityByIdAsync(int id);

        Task<PartnerServiceInfo> GetEntityByCustomerIdAsync(int customerId);

        Task<IList<PartnerServiceInfo>> GetEntitiesByIdsAsync(int[] entityIds);

        Task<IPagedList<PartnerServiceInfo>> GetEntitiesAsync(
            int customerId = 0,
            bool? published = null,
            bool? deleted = null,
            int pageIndex = 0, int pageSize = int.MaxValue);
    }
}