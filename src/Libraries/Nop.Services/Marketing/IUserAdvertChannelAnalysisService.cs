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
    public partial interface IUserAdvertChannelAnalysisService
    {
        Task InsertEntityAsync(UserAdvertChannelAnalysis entity);

        Task DeleteEntityAsync(UserAdvertChannelAnalysis entity);

        Task DeleteEntitiesAsync(IList<UserAdvertChannelAnalysis> entities);

        Task UpdateEntityAsync(UserAdvertChannelAnalysis entity);

        Task UpdateEntitiesAsync(IList<UserAdvertChannelAnalysis> entities);

        Task<UserAdvertChannelAnalysis> GetEntityByIdAsync(int id);

        Task<UserAdvertChannelAnalysis> GetEntitiesByUserIdAsync(int wuserId);

        Task<IList<UserAdvertChannelAnalysis>> GetEntitiesByProductIdAsync(int productId);

        Task<IList<UserAdvertChannelAnalysis>> GetEntitiesBySupplierIdAsync(int supplierId, int supplierShopId);


        Task<IPagedList<UserAdvertChannelAnalysis>> GetEntitiesAsync(
            int userId = 0,
            int supplierId = 0,
            int supplierShopId = 0,
            int productId = 0,
            int pageIndex = 0, int pageSize = int.MaxValue);

    }
}