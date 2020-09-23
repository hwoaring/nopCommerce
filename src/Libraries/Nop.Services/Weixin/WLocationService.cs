using System;
using System.Collections.Generic;
using System.Linq;
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

        public virtual void InsertLocation(WLocation wlocation)
        {
            _wLocationRepository.Insert(wlocation);
        }

        public virtual void DeleteLocation(WLocation location)
        {
            _wLocationRepository.Delete(location);
        }

        public virtual void DeleteLocations(IList<WLocation> locations)
        {
            _wLocationRepository.Delete(locations);
        }

        public virtual void UpdateLocation(WLocation location)
        {
            _wLocationRepository.Update(location);
        }

        public virtual WLocation GetLocationById(int id)
        {
            return _wLocationRepository.GetById(id, cache => default);
        }

        public virtual WLocation GetLocationByUserId(int userId)
        {
            if (userId == 0)
                return null;

            var query = from location in _wLocationRepository.Table
                        where location.UserId == userId
                        orderby location.Id descending
                        select location;

            return query.FirstOrDefault();
        }

        public virtual IPagedList<WLocation> GetLocations(int pageIndex = 0, int pageSize = int.MaxValue)
        {
            var query = _wLocationRepository.Table;

            query = query.OrderBy(l => l.Id);

            return new PagedList<WLocation>(query, pageIndex, pageSize);
        }

        #endregion
    }
}