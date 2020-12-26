﻿using System;
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
    /// WMenuButtonService
    /// </summary>
    public partial class WMenuButtonService : IWMenuButtonService
    {
        #region Fields

        private readonly IRepository<WMenuButton> _wMenuButtonRepository;

        #endregion

        #region Ctor

        public WMenuButtonService(
            IRepository<WMenuButton> wMenuButtonRepository)
        {
            _wMenuButtonRepository = wMenuButtonRepository;
        }

        #endregion

        #region Methods

        public virtual async Task InsertMenuButtonAsync(WMenuButton menuButton)
        {
            await _wMenuButtonRepository.InsertAsync(menuButton);
        }

        public virtual async Task DeleteMenuButtonAsync(WMenuButton menuButton)
        {
            await _wMenuButtonRepository.DeleteAsync(menuButton);
        }

        public virtual async Task DeleteMenuButtonsAsync(IList<WMenuButton> menuButtons)
        {
            if (menuButtons == null)
                throw new ArgumentNullException(nameof(menuButtons));

            foreach (var menuButton in menuButtons)
                await DeleteMenuButtonAsync(menuButton);
        }

        public virtual async Task UpdateMenuButtonAsync(WMenuButton menuButton)
        {
            await _wMenuButtonRepository.UpdateAsync(menuButton);
        }

        public virtual async Task UpdateMenuButtonsAsync(IList<WMenuButton> menuButtons)
        {
            await _wMenuButtonRepository.UpdateAsync(menuButtons);
        }

        public virtual async Task<WMenuButton> GetMenuButtonByIdAsync(int id)
        {
            return await _wMenuButtonRepository.GetByIdAsync(id, cache => default);
        }

        public virtual async Task<IList<int>> GetChildMenuButtonIdsAsync(int parentId, int storeId = 0, bool showHidden = false)
        {
            //little hack for performance optimization
            //there's no need to invoke "GetAllCategoriesByParentCategoryId" multiple times (extra SQL commands) to load childs
            //so we load all categories at once (we know they are cached) and process them server-side
            var menuButtonIds = new List<int>();
            var menuButtons = (await GetAllMenuButtonsAsync())
                .Where(c => c.ParentId == parentId)
                .Select(c => c.Id)
                .ToList();
            menuButtonIds.AddRange(menuButtons);
            menuButtonIds.AddRange(await menuButtons.SelectManyAwait(async cId => await GetChildMenuButtonIdsAsync(cId, storeId, showHidden)).ToListAsync());

            return menuButtonIds;
        }

        public virtual async Task<IList<WMenuButton>> GetMenuButtonsByMenuIdAsync(int menuId)
        {
            if (menuId == 0)
                return new List<WMenuButton>();

            var query = from t in _wMenuButtonRepository.Table
                        where t.WMenuId == menuId
                        orderby t.DisplayOrder, t.Id
                        select t;

            return await query.ToListAsync();
        }

        public virtual async Task<IList<WMenuButton>> GetMenuButtonsByParentIdAsync(int parentId)
        {
            if (parentId == 0)
                return new List<WMenuButton>();

            var query = from t in _wMenuButtonRepository.Table
                        where t.ParentId == parentId
                        orderby t.DisplayOrder, t.Id
                        select t;

            return await query.ToListAsync();
        }

        public virtual async Task<IList<WMenuButton>> GetAllMenuButtonsAsync()
        {
            var query = from t in _wMenuButtonRepository.Table
                        orderby t.DisplayOrder, t.Id
                        select t;

            return await query.ToListAsync();
        }

        public virtual async Task<IPagedList<WMenuButton>> GetAllMenuButtonsAsync(string name = "", int menuId = 0, int parentId = 0, bool? published = null, int pageIndex = 0, int pageSize = int.MaxValue)
        {
            var query = _wMenuButtonRepository.Table;

            if (!string.IsNullOrEmpty(name))
                query = query.Where(v => v.Name.Contains(name));

            if (menuId > 0)
                query = query.Where(v => v.WMenuId == menuId);

            if (parentId > 0)
                query = query.Where(v => v.ParentId == parentId);

            if (published.HasValue)
                query = query.Where(v => v.Published);

            return await query.ToPagedListAsync(pageIndex, pageSize);
        }

        #endregion
    }
}