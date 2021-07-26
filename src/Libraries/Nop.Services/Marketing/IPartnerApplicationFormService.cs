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
    public partial interface IPartnerApplicationFormService
    {
        Task InsertEntityAsync(PartnerApplicationForm entity);

        Task DeleteEntityAsync(PartnerApplicationForm entity, bool delete = false);

        Task DeleteEntitiesAsync(IList<PartnerApplicationForm> entities, bool deleted = false);

        Task UpdateEntityAsync(PartnerApplicationForm entity);

        Task UpdateEntitiesAsync(IList<PartnerApplicationForm> entities);

        Task<PartnerApplicationForm> GetEntityByIdAsync(int id);

        Task<PartnerApplicationForm> GetEntityByCustomerIdAsync(int customerId);

        Task<IList<PartnerApplicationForm>> GetEntitiesByIdsAsync(int[] entityIds);

        Task<IPagedList<PartnerApplicationForm>> GetEntitiesAsync(
            string telephoneNumber = "",
            int customerId = 0,
            DateTime? endDateTimeUtc = null,
            bool? approved = null,
            bool? locked = null,
            bool? deleted = null,
            int pageIndex = 0, int pageSize = int.MaxValue);
    }
}