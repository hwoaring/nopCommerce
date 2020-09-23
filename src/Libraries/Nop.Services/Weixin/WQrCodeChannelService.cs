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

        public virtual void InsertEntity(WQrCodeChannel entity)
        {
            _wQrCodeChannelRepository.Insert(entity);
        }

        public virtual void UpdateEntity(WQrCodeChannel entity)
        {
            _wQrCodeChannelRepository.Update(entity);
        }

        public virtual void UpdateEntities(IList<WQrCodeChannel> entities)
        {
            _wQrCodeChannelRepository.Update(entities);
        }

        public virtual WQrCodeChannel GetEntityById(int id)
        {
            return _wQrCodeChannelRepository.GetById(id, cache => default);
        }

        public virtual List<WQrCodeChannel> GetEntitiesByParentId(int parentId)
        {
            if (parentId == 0)
                return null;

            var query = from t in _wQrCodeChannelRepository.Table
                        where t.ParentId == parentId &&
                        !t.Deleted
                        select t;

            return query.ToList();
        }

        public virtual IList<WQrCodeChannel> GetAllEntities()
        {
            var query = from pt in _wQrCodeChannelRepository.Table
                        where !pt.Deleted
                        orderby pt.Id
                        select pt;

            return query.ToList();
        }

        public virtual IPagedList<WQrCodeChannel> GetEntities(bool showDeleted = false, int pageIndex = 0, int pageSize = int.MaxValue)
        {
            var query = _wQrCodeChannelRepository.Table;

            if (!showDeleted)
                query = query.Where(v => !v.Deleted);

            return new PagedList<WQrCodeChannel>(query, pageIndex, pageSize);
        }


        #endregion
    }
}