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
    /// WMenuService
    /// </summary>
    public partial class WMenuService : IWMenuService
    {
        #region Fields

        private readonly IRepository<WMenu> _wMenuRepository;

        #endregion

        #region Ctor

        public WMenuService(
            IRepository<WMenu> wMenuRepository)
        {
            _wMenuRepository = wMenuRepository;
        }

        #endregion

        #region Methods

        public virtual async Task InsertMenuAsync(WMenu menu)
        {
            await _wMenuRepository.InsertAsync(menu);
        }

        public virtual async Task DeleteMenuAsync(WMenu menu)
        {
            await _wMenuRepository.DeleteAsync(menu);
        }

        public virtual async Task DeleteMenusAsync(IList<WMenu> menus)
        {
            await _wMenuRepository.DeleteAsync(menus);
        }

        public virtual async Task UpdateMenuAsync(WMenu menu)
        {
            await _wMenuRepository.UpdateAsync(menu);
        }

        public virtual async Task UpdateMenusAsync(IList<WMenu> menus)
        {
            await _wMenuRepository.UpdateAsync(menus);
        }

        public virtual async Task<WMenu> GetMenuByIdAsync(int id)
        {
            return await _wMenuRepository.GetByIdAsync(id, cache => default);
        }

        public virtual async Task<WMenu> GetMenuByMenuIdAsync(long menuId)
        {
            if (menuId == 0)
                return null;

            var query = from t in _wMenuRepository.Table
                        where t.MenuId == menuId
                        orderby t.Id
                        select t;

            return await query.FirstOrDefaultAsync();
        }

        public virtual async Task<IPagedList<WMenu>> GetAllMenusAsync(string systemName = "", bool? personal = null, int pageIndex = 0, int pageSize = int.MaxValue, bool showDeleted = false)
        {
            var query = _wMenuRepository.Table;

            if (!string.IsNullOrEmpty(systemName))
                query = query.Where(v => v.SystemName.Contains(systemName));

            if (personal.HasValue)
                query = query.Where(v => v.Personal);

            if (!showDeleted)
                query = query.Where(v => !v.Deleted);

            return await query.ToPagedListAsync(pageIndex, pageSize);
        }

        #endregion
    }
}