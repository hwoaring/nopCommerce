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
    /// WQrCodeCategoryService
    /// </summary>
    public partial class QrCodeCategoryService : IQrCodeCategoryService
    {
        #region Fields

        private readonly IRepository<QrCodeCategory> _wQrCodeCategoryRepository;

        #endregion

        #region Ctor

        public QrCodeCategoryService(
            IRepository<QrCodeCategory> wQrCodeCategoryRepository)
        {
            _wQrCodeCategoryRepository = wQrCodeCategoryRepository;
        }

        #endregion

        #region Methods

        public virtual async Task InsertEntityAsync(QrCodeCategory entity)
        {
            await _wQrCodeCategoryRepository.InsertAsync(entity);
        }

        public virtual async Task UpdateEntityAsync(QrCodeCategory entity)
        {
            await _wQrCodeCategoryRepository.UpdateAsync(entity);
        }

        public virtual async Task UpdateEntitiesAsync(IList<QrCodeCategory> entities)
        {
            await _wQrCodeCategoryRepository.UpdateAsync(entities);
        }

        public virtual async Task<QrCodeCategory> GetEntityByIdAsync(int id)
        {
            return await _wQrCodeCategoryRepository.GetByIdAsync(id, cache => default);
        }

        public virtual async Task<IList<QrCodeCategory>> GetEntitiesByParentIdAsync(int parentId)
        {
            if (parentId == 0)
                return null;

            var query = from t in _wQrCodeCategoryRepository.Table
                        where t.ParentId == parentId &&
                        !t.Deleted
                        select t;

            return await query.ToListAsync();
        }

        public virtual async Task<IList<QrCodeCategory>> GetAllEntitiesAsync()
        {
            var query = from pt in _wQrCodeCategoryRepository.Table
                        where !pt.Deleted
                        orderby pt.Id
                        select pt;

            return await query.ToListAsync();
        }

        public virtual async Task<IPagedList<QrCodeCategory>> GetEntitiesAsync(bool showDeleted = false, int pageIndex = 0, int pageSize = int.MaxValue)
        {
            var query = _wQrCodeCategoryRepository.Table;

            if (!showDeleted)
                query = query.Where(v => !v.Deleted);

            return await query.ToPagedListAsync(pageIndex, pageSize);
        }


        #endregion
    }
}