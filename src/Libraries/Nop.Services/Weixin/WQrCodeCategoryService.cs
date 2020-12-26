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

        public virtual async Task InsertEntityAsync(WQrCodeCategory entity)
        {
            await _wQrCodeCategoryRepository.InsertAsync(entity);
        }

        public virtual async Task UpdateEntityAsync(WQrCodeCategory entity)
        {
            await _wQrCodeCategoryRepository.UpdateAsync(entity);
        }

        public virtual async Task UpdateEntitiesAsync(IList<WQrCodeCategory> entities)
        {
            await _wQrCodeCategoryRepository.UpdateAsync(entities);
        }

        public virtual async Task<WQrCodeCategory> GetEntityByIdAsync(int id)
        {
            return await _wQrCodeCategoryRepository.GetByIdAsync(id, cache => default);
        }

        public virtual async Task<IList<WQrCodeCategory>> GetEntitiesByParentIdAsync(int parentId)
        {
            if (parentId == 0)
                return null;

            var query = from t in _wQrCodeCategoryRepository.Table
                        where t.ParentId == parentId &&
                        !t.Deleted
                        select t;

            return await query.ToListAsync();
        }

        public virtual async Task<IList<WQrCodeCategory>> GetAllEntitiesAsync()
        {
            var query = from pt in _wQrCodeCategoryRepository.Table
                        where !pt.Deleted
                        orderby pt.Id
                        select pt;

            return await query.ToListAsync();
        }

        public virtual async Task<IPagedList<WQrCodeCategory>> GetEntitiesAsync(bool showDeleted = false, int pageIndex = 0, int pageSize = int.MaxValue)
        {
            var query = _wQrCodeCategoryRepository.Table;

            if (!showDeleted)
                query = query.Where(v => !v.Deleted);

            return await query.ToPagedListAsync(pageIndex, pageSize);
        }


        #endregion
    }
}