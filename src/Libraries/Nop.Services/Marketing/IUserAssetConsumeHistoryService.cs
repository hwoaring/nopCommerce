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
    public partial interface IUserAssetConsumeHistoryService
    {
        Task InsertEntityAsync(UserAssetConsumeHistory entity);

        Task DeleteEntityAsync(UserAssetConsumeHistory entity);

        Task DeleteEntitiesAsync(IList<UserAssetConsumeHistory> entities);

        Task UpdateEntityAsync(UserAssetConsumeHistory entity);

        Task UpdateEntitiesAsync(IList<UserAssetConsumeHistory> entities);

        Task<UserAssetConsumeHistory> GetEntityByIdAsync(int id);

        Task<IList<UserAssetConsumeHistory>> GetEntitiesByUserIdAsync(int userId, bool completed, bool isInvalid);

        Task<IList<UserAssetConsumeHistory>> GetEntitiesByUserAssetIncomeHistoryIdAsync(int userAssetIncomeHistoryId, bool completed, bool isInvalid);

        Task<IPagedList<UserAssetConsumeHistory>> GetEntitiesAsync(
            int ownerUserId = 0,
            int? userAssetIncomeHistoryId = 0,
            AssetConsumType? assetConsumType = null,
            bool? completed = null,
            bool? isInvalid = null,
            bool? deleted = null,
            int pageIndex = 0, int pageSize = int.MaxValue);
    }
}