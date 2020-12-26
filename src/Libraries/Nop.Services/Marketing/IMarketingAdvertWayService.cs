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
    public partial interface IMarketingAdvertWayService
    {
        Task InsertEntityAsync(MarketingAdvertWay entity);

        Task DeleteEntityAsync(MarketingAdvertWay entity, bool delete = false);

        Task DeleteEntitiesAsync(IList<MarketingAdvertWay> entities, bool deleted = false);

        Task UpdateEntityAsync(MarketingAdvertWay entity);

        Task UpdateEntitiesAsync(IList<MarketingAdvertWay> entities);

        Task<MarketingAdvertWay> GetEntityByIdAsync(int id);

        Task<string> GetEntinyNameByIdAsync(int id);

        Task<IList<MarketingAdvertWay>> GetEntitiesByIdsAsync(int[] entityIds);

        Task<IPagedList<MarketingAdvertWay>> GetEntitiesAsync(
            string name = "",
            bool? deleted = null,
            int pageIndex = 0, int pageSize = int.MaxValue);
    }
}