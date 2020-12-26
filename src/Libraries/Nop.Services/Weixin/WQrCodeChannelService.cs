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
    /// WQrCodeChannelService
    /// </summary>
    public partial class WQrCodeChannelService : IWQrCodeChannelService
    {
        #region Fields

        private readonly IRepository<WQrCodeChannel> _wQrCodeChannelRepository;

        #endregion

        #region Ctor

        public WQrCodeChannelService(
            IRepository<WQrCodeChannel> wQrCodeChannelRepository)
        {
            _wQrCodeChannelRepository = wQrCodeChannelRepository;
        }

        #endregion

        #region Methods

        public virtual async Task InsertEntityAsync(WQrCodeChannel entity)
        {
            await _wQrCodeChannelRepository.InsertAsync(entity);
        }

        public virtual async Task UpdateEntityAsync(WQrCodeChannel entity)
        {
            await _wQrCodeChannelRepository.UpdateAsync(entity);
        }

        public virtual async Task UpdateEntitiesAsync(IList<WQrCodeChannel> entities)
        {
            await _wQrCodeChannelRepository.UpdateAsync(entities);
        }

        public virtual async Task<WQrCodeChannel> GetEntityByIdAsync(int id)
        {
            return await _wQrCodeChannelRepository.GetByIdAsync(id, cache => default);
        }

        public virtual async Task<IList<WQrCodeChannel>> GetEntitiesByParentIdAsync(int parentId)
        {
            if (parentId == 0)
                return null;

            var query = from t in _wQrCodeChannelRepository.Table
                        where t.ParentId == parentId &&
                        !t.Deleted
                        select t;

            return await query.ToListAsync();
        }

        public virtual async Task<IList<WQrCodeChannel>> GetAllEntitiesAsync()
        {
            var query = from pt in _wQrCodeChannelRepository.Table
                        where !pt.Deleted
                        orderby pt.Id
                        select pt;

            return await query.ToListAsync();
        }

        public virtual async Task<IPagedList<WQrCodeChannel>> GetEntitiesAsync(bool showDeleted = false, int pageIndex = 0, int pageSize = int.MaxValue)
        {
            var query = _wQrCodeChannelRepository.Table;

            if (!showDeleted)
                query = query.Where(v => !v.Deleted);

            return await query.ToPagedListAsync(pageIndex, pageSize);
        }


        #endregion
    }
}