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
    public partial interface IUserAssetService
    {
        Task InsertEntityAsync(UserAsset entity);

        Task DeleteEntityAsync(UserAsset entity);

        Task DeleteEntitiesAsync(IList<UserAsset> entities);

        Task UpdateEntityAsync(UserAsset entity);

        Task UpdateEntitiesAsync(IList<UserAsset> entities);

        Task<UserAsset> GetEntityByIdAsync(int id);

        Task<UserAsset> GetEntityByCustomerIdAsync(int customerId);

    }
}