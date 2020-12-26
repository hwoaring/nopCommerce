using System.Collections.Generic;
using System.Threading.Tasks;
using Nop.Core;
using Nop.Core.Domain.Weixin;

namespace Nop.Services.Weixin
{
    /// <summary>
    /// WLocation service interface
    /// </summary>
    public partial interface IWLocationService
    {
        Task InsertLocationAsync(WLocation wlocation);

        Task DeleteLocationAsync(WLocation wlocation);

        Task DeleteLocationsAsync(IList<WLocation> wlocations);

        Task UpdateLocationAsync(WLocation wlocation);

        Task<WLocation> GetLocationByIdAsync(int id);

        Task<WLocation> GetLocationByUserIdAsync(int userId);

        Task<IPagedList<WLocation>> GetLocationsAsync(int pageIndex = 0, int pageSize = int.MaxValue);

    }
}