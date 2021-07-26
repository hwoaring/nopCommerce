using System.Collections.Generic;
using System.Threading.Tasks;
using Nop.Core;
using Nop.Core.Domain.Weixin;

namespace Nop.Services.Weixin
{
    /// <summary>
    /// WLocation service interface
    /// </summary>
    public partial interface IWxLocationService
    {
        Task InsertLocationAsync(WxLocation wxlocation);

        Task DeleteLocationAsync(WxLocation wxlocation);

        Task DeleteLocationsAsync(IList<WxLocation> wxlocations);

        Task UpdateLocationAsync(WxLocation wxlocation);

        Task<WxLocation> GetLocationByIdAsync(int id);

        Task<WxLocation> GetLocationByCustomerIdAsync(int customerId);

        Task<IPagedList<WxLocation>> GetLocationsAsync(int pageIndex = 0, int pageSize = int.MaxValue);

    }
}