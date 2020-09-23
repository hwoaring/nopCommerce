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
    /// WQrCodeCategoryService
    /// </summary>
    public partial class WQrCodeCategoryService : IWQrCodeCategoryService
    {
        #region Fields

        private readonly IRepository<WQrCodeCategory> _wQrCodeCategoryRepository;

        #endregion

        #region Ctor

        public WQrCodeCategoryService(
            IRepository<WQrCodeCategory> wQrCodeCategoryRepository)
        {
            _wQrCodeCategoryRepository = wQrCodeCategoryRepository;
        }

        #endregion

        #region Methods

        public virtual void InsertEntity(WQrCodeCategory entity)
        {
            _wQrCodeCategoryRepository.Insert(entity);
        }

        public virtual void UpdateEntity(WQrCodeCategory entity)
        {
            _wQrCodeCategoryRepository.Update(entity);
        }

        public virtual void UpdateEntities(IList<WQrCodeCategory> entities)
        {
            _wQrCodeCategoryRepository.Update(entities);
        }

        public virtual WQrCodeCategory GetEntityById(int id)
        {
            return _wQrCodeCategoryRepository.GetById(id, cache => default);
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