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

        public virtual void InsertMenuButton(WMenuButton menuButton)
        {
            _wMenuButtonRepository.Insert(menuButton);
        }

        public virtual void DeleteMenuButton(WMenuButton menuButton)
        {
            _wMenuButtonRepository.Delete(menuButton);
        }

        public virtual void DeleteMenuButtons(IList<WMenuButton> menuButtons)
        {
            _wMenuButtonRepository.Delete(menuButtons);
        }

        public virtual void UpdateMenuButton(WMenuButton menuButton)
        {
            _wMenuButtonRepository.Update(menuButton);
        }

        public virtual void UpdateMenuButtons(IList<WMenuButton> menuButtons)
        {
            _wMenuButtonRepository.Update(menuButtons);
        }

        public virtual WMenuButton GetMenuButtonById(int id)
        {
            return _wMenuButtonRepository.GetById(id, cache => default);
        }

        public virtual IList<int> GetChildMenuButtonIds(int parentId)
        {
            //little hack for performance optimization
            //there's no need to invoke "GetAllCategoriesByParentCategoryId" multiple times (extra SQL commands) to load childs
            //so we load all categories at once (we know they are cached) and process them server-side
            var menuButtonIds = new List<int>();
            var menuButtons = GetAllMenuButtons()
                .Where(c => c.ParentId == parentId)
                .Select(c => c.Id)
                .ToList();
            menuButtonIds.AddRange(menuButtons);
            menuButtonIds.AddRange(menuButtons.SelectMany(cId => GetChildMenuButtonIds(cId)));

            return menuButtonIds;
        }

        public virtual IList<WMenuButton> GetMenuButtonsByMenuId(int menuId)
        {
            if (menuId == 0)
                return new List<WMenuButton>();

            var query = from t in _wMenuButtonRepository.Table
                        where t.WMenuId == menuId
                        orderby t.DisplayOrder, t.Id
                        select t;

            return query.ToList();
        }

        public virtual IList<WMenuButton> GetMenuButtonsByParentId(int parentId)
        {
            if (parentId == 0)
                return new List<WMenuButton>();

            var query = from t in _wMenuButtonRepository.Table
                        where t.ParentId == parentId
                        orderby t.DisplayOrder, t.Id
                        select t;

            return query.ToList();
        }

        public virtual IList<WMenuButton> GetAllMenuButtons()
        {
            var query = from t in _wMenuButtonRepository.Table
                        orderby t.DisplayOrder, t.Id
                        select t;

            return query.ToList();
        }

        public virtual IPagedList<WMenuButton> GetAllMenuButtons(string name = "", int menuId = 0, int parentId = 0, bool? published = null, int pageIndex = 0, int pageSize = int.MaxValue)
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

            return new PagedList<WMenuButton>(query, pageIndex, pageSize);
        }

        #endregion
    }
}