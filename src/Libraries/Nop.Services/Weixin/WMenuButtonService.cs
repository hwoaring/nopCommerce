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
    /// WMenuButtonService
    /// </summary>
    public partial class WMenuButtonService : IWMenuButtonService
    {
        #region Fields

        private readonly IEventPublisher _eventPublisher;
        private readonly IRepository<WMenuButton> _wMenuButtonRepository;

        #endregion

        #region Ctor

        public WMenuButtonService(IEventPublisher eventPublisher,
            IRepository<WMenuButton> wMenuButtonRepository)
        {
            _eventPublisher = eventPublisher;
            _wMenuButtonRepository = wMenuButtonRepository;
        }

        #endregion

        #region Methods

        public virtual void InsertMenuButton(WMenuButton menuButton)
        {
            if (menuButton == null)
                throw new ArgumentNullException(nameof(menuButton));

            _wMenuButtonRepository.Insert(menuButton);

            //event notification
            _eventPublisher.EntityInserted(menuButton);
        }

        public virtual void DeleteMenuButton(WMenuButton menuButton)
        {
            if (menuButton == null)
                throw new ArgumentNullException(nameof(menuButton));

            _wMenuButtonRepository.Delete(menuButton);

            //event notification
            _eventPublisher.EntityDeleted(menuButton);
        }

        public virtual void DeleteMenuButtons(IList<WMenuButton> menuButtons)
        {
            if (menuButtons == null)
                throw new ArgumentNullException(nameof(menuButtons));

            _wMenuButtonRepository.Delete(menuButtons);

            foreach (var menuButton in menuButtons)
            {
                //event notification
                _eventPublisher.EntityDeleted(menuButton);
            }
        }

        public virtual void UpdateMenuButton(WMenuButton menuButton)
        {
            if (menuButton == null)
                throw new ArgumentNullException(nameof(menuButton));

            _wMenuButtonRepository.Update(menuButton);

            //event notification
            _eventPublisher.EntityUpdated(menuButton);
        }

        public virtual void UpdateMenuButtons(IList<WMenuButton> menuButtons)
        {
            if (menuButtons == null)
                throw new ArgumentNullException(nameof(menuButtons));

            //update
            _wMenuButtonRepository.Update(menuButtons);

            //event notification
            foreach (var menuButton in menuButtons)
            {
                _eventPublisher.EntityUpdated(menuButton);
            }
        }

        public virtual WMenuButton GetMenuButtonById(int id)
        {
            if (id == 0)
                return null;

            return _wMenuButtonRepository.GetById(id);
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