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

        public virtual void InsertMenu(WMenu menu)
        {
            _wMenuRepository.Insert(menu);
        }

        public virtual void DeleteMenu(WMenu menu, bool delete = false)
        {
            if (menu == null)
                throw new ArgumentNullException(nameof(menu));

            menu.Deleted = true;
            _wMenuRepository.Update(menu);
        }

        public virtual void DeleteMenus(IList<WMenu> menus, bool deleted = false)
        {
            if (menus == null)
                throw new ArgumentNullException(nameof(menus));

            foreach (var menu in menus)
            {
                menu.Deleted = true;
            }

            _wMenuRepository.Update(menus);
        }

        public virtual void UpdateMenu(WMenu menu)
        {
            _wMenuRepository.Update(menu);
        }

        public virtual void UpdateMenus(IList<WMenu> menus)
        {
            _wMenuRepository.Update(menus);
        }

        public virtual WMenu GetMenuById(int id)
        {
            return _wMenuRepository.GetById(id, cache => default);
        }

        public virtual WMenu GetMenuByMenuId(long menuId)
        {
            if (menuId == 0)
                return null;

            var query = from t in _wMenuRepository.Table
                        where t.MenuId == menuId
                        orderby t.Id
                        select t;

            return query.FirstOrDefault();
        }

        public virtual IPagedList<WMenu> GetAllMenus(string systemName = "", bool? personal = null, int pageIndex = 0, int pageSize = int.MaxValue, bool showDeleted = false)
        {
            var query = _wMenuRepository.Table;

            if (!string.IsNullOrEmpty(systemName))
                query = query.Where(v => v.SystemName.Contains(systemName));

            if (personal.HasValue)
                query = query.Where(v => v.Personal);

            if (!showDeleted)
                query = query.Where(v => !v.Deleted);

            return new PagedList<WMenu>(query, pageIndex, pageSize);
        }

        #endregion
    }
}