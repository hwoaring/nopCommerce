using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Nop.Core;
using Nop.Core.Domain.Catalog;
using Nop.Core.Domain.Vendors;
using Nop.Core.Domain.Weixin;
using Nop.Core.Html;
using Nop.Data;
using Nop.Services.Events;

namespace Nop.Services.Weixin
{
    /// <summary>
    /// WUserService service
    /// </summary>
    public partial class WLocationService : IWLocationService
    {
        #region Fields

        private readonly IRepository<WLocation> _wLocationRepository;

        #endregion

        #region Ctor

        public WLocationService(
            IRepository<WLocation> wLocationRepository)
        {
            _wLocationRepository = wLocationRepository;
        }

        #endregion

        #region Methods

        public virtual async Task InsertLocationAsync(WLocation wlocation)
        {
            await _wLocationRepository.InsertAsync(wlocation);
        }

        public virtual async Task DeleteLocationAsync(WLocation location)
        {
            await _wLocationRepository.DeleteAsync(location);
        }

        public virtual async Task DeleteLocationsAsync(IList<WLocation> locations)
        {
            await _wLocationRepository.DeleteAsync(locations);
        }

        public virtual async Task UpdateLocationAsync(WLocation location)
        {
            await _wLocationRepository.UpdateAsync(location);
        }

        public virtual async Task<WLocation> GetLocationByIdAsync(int id)
        {
            return await _wLocationRepository.GetByIdAsync(id, cache => default);
        }

        public virtual async Task<WLocation> GetLocationByUserIdAsync(int userId)
        {
            if (userId == 0)
                return null;

            var query = from location in _wLocationRepository.Table
                        where location.UserId == userId
                        orderby location.Id descending
                        select location;

            return await query.FirstOrDefaultAsync();
        }

        public virtual async Task<IPagedList<WLocation>> GetLocationsAsync(int pageIndex = 0, int pageSize = int.MaxValue)
        {
            var query = _wLocationRepository.Table;

            query = query.OrderBy(l => l.Id);

            return await query.ToPagedListAsync(pageIndex, pageSize);
        }

        #endregion
    }
}