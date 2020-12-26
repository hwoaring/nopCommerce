using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Humanizer;
using Nop.Core;
using Nop.Core.Domain.Marketing;

namespace Nop.Services.Marketing
{
    /// <summary>
    /// Suppliers Service interface
    /// </summary>
    public partial interface IProductUserFollowMappingService
    {
        Task InsertEntityAsync(ProductUserFollowMapping entity);

        Task DeleteEntityAsync(ProductUserFollowMapping entity);

        Task DeleteEntitiesAsync(IList<ProductUserFollowMapping> entities);

        Task UpdateEntityAsync(ProductUserFollowMapping entity);

        Task UpdateEntitiesAsync(IList<ProductUserFollowMapping> entities);

        Task<ProductUserFollowMapping> GetEntityByIdAsync(int id);

        Task<IList<ProductUserFollowMapping>> GetEntitiesByIdsAsync(int[] entityIds);

        Task<IList<ProductUserFollowMapping>> GetEntitiesByProductIdAsync(int productId);

        Task<IList<ProductUserFollowMapping>> GetEntitiesByUserIdAsync(int userId);

        Task<int> GetUserFollowCountAsync(int productId);

        Task<IList<int>> GetFollowUserIdByProductIdAsync(int productId);

        Task<IList<int>> GetFollowProductIdByUserIdAsync(int wuserId);

        Task<IPagedList<ProductUserFollowMapping>> GetEntitiesAsync(
            int productId = 0,
            int userId = 0,
            bool? subscribe = null,
            int pageIndex = 0, int pageSize = int.MaxValue);
    }
}