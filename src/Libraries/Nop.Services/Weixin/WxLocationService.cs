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
    public partial class WxLocationService : IWxLocationService
    {
        #region Fields

        private readonly IRepository<WxLocation> _wLocationRepository;

        #endregion

        #region Ctor

        public WxLocationService(
            IRepository<WxLocation> wLocationRepository)
        {
            _wLocationRepository = wLocationRepository;
        }

        #endregion

        #region Methods

        public virtual async Task InsertLocationAsync(WxLocation wlocation)
        {
            await _wLocationRepository.InsertAsync(wlocation);
        }

        public virtual async Task DeleteLocationAsync(WxLocation location)
        {
            await _wLocationRepository.DeleteAsync(location);
        }

        public virtual async Task DeleteLocationsAsync(IList<WxLocation> locations)
        {
            await _wLocationRepository.DeleteAsync(locations);
        }

        public virtual async Task UpdateLocationAsync(WxLocation location)
        {
            await _wLocationRepository.UpdateAsync(location);
        }

        public virtual async Task<WxLocation> GetLocationByIdAsync(int id)
        {
            return await _wLocationRepository.GetByIdAsync(id, cache => default);
        }

        public virtual async Task<WxLocation> GetLocationByCustomerIdAsync(int customerId)
        {
            if (customerId == 0)
                return null;

            var query = from location in _wLocationRepository.Table
                        where location.CustomerId == customerId
                        select location;

            return await query.FirstOrDefaultAsync();
        }

        public virtual async Task<IPagedList<WxLocation>> GetLocationsAsync(int pageIndex = 0, int pageSize = int.MaxValue)
        {
            var query = _wLocationRepository.Table;

            query = query.OrderBy(l => l.Id);

            return await query.ToPagedListAsync(pageIndex, pageSize);
        }

        #endregion
    }
}