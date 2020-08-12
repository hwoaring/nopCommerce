using System;
using System.Collections.Generic;
using System.Linq;
using Nop.Core;
using Nop.Core.Domain.Catalog;
using Nop.Core.Domain.Vendors;
using Nop.Core.Domain.Weixin;
using Nop.Core.Html;
using Nop.Data;
using Nop.Services.Caching.Extensions;
using Nop.Services.Events;

namespace Nop.Services.Weixin
{
    /// <summary>
    /// WQrCodeCategoryService
    /// </summary>
    public partial class WQrCodeCategoryService : IWQrCodeCategoryService
    {
        #region Fields

        private readonly IEventPublisher _eventPublisher;
        private readonly IRepository<WQrCodeCategory> _wQrCodeCategoryRepository;

        #endregion

        #region Ctor

        public WQrCodeCategoryService(IEventPublisher eventPublisher,
            IRepository<WQrCodeCategory> wQrCodeCategoryRepository)
        {
            _eventPublisher = eventPublisher;
            _wQrCodeCategoryRepository = wQrCodeCategoryRepository;
        }

        #endregion

        #region Methods

        public virtual void InsertEntity(WQrCodeCategory entity)
        {
            if (entity == null)
                throw new ArgumentNullException(nameof(entity));

            _wQrCodeCategoryRepository.Insert(entity);

            //event notification
            _eventPublisher.EntityInserted(entity);
        }

        public virtual void UpdateEntity(WQrCodeCategory entity)
        {
            if (entity == null)
                throw new ArgumentNullException(nameof(entity));

            _wQrCodeCategoryRepository.Update(entity);

            //event notification
            _eventPublisher.EntityUpdated(entity);
        }

        public virtual void UpdateEntities(IList<WQrCodeCategory> entities)
        {
            if (entities == null)
                throw new ArgumentNullException(nameof(entities));

            //update
            _wQrCodeCategoryRepository.Update(entities);

            //event notification
            foreach (var entity in entities)
            {
                _eventPublisher.EntityUpdated(entity);
            }
        }

        public virtual WQrCodeCategory GetEntityById(int id)
        {
            if (id == 0)
                return null;

            return _wQrCodeCategoryRepository.GetById(id);
        }

        public virtual List<WQrCodeCategory> GetEntitiesByParentId(int parentId)
        {
            if (parentId == 0)
                return null;

            var query = from t in _wQrCodeCategoryRepository.Table
                        where t.ParentId == parentId &&
                        !t.Deleted
                        select t;

            return query.ToList();
        }

        public virtual IList<WQrCodeCategory> GetAllEntities()
        {
            var query = from pt in _wQrCodeCategoryRepository.Table
                        where !pt.Deleted
                        orderby pt.Id
                        select pt;

            return query.ToList();
        }

        public virtual IPagedList<WQrCodeCategory> GetEntities(bool showDeleted = false, int pageIndex = 0, int pageSize = int.MaxValue)
        {
            var query = _wQrCodeCategoryRepository.Table;

            if (!showDeleted)
                query = query.Where(v => !v.Deleted);

            return new PagedList<WQrCodeCategory>(query, pageIndex, pageSize);
        }


        #endregion
    }
}