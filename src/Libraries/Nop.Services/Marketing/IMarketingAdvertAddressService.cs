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
    public partial interface IMarketingAdvertAddressService
    {
        Task InsertEntityAsync(MarketingAdvertAddress entity);

        Task DeleteEntityAsync(MarketingAdvertAddress entity, bool delete = false);

        Task DeleteEntitiesAsync(IList<MarketingAdvertAddress> entities, bool deleted = false);

        Task UpdateEntityAsync(MarketingAdvertAddress entity);

        Task UpdateEntitiesAsync(IList<MarketingAdvertAddress> entities);

        Task<MarketingAdvertAddress> GetEntityByIdAsync(int id);

        Task<MarketingAdvertAddress> GetEntityByAddressAsync(string address);

        Task<string> GetAddressByIdAsync(int id);

        Task<IPagedList<MarketingAdvertAddress>> GetEntitiesAsync(
            bool? deleted = null,
            int pageIndex = 0, int pageSize = int.MaxValue);
    }
}