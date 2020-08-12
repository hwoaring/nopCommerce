using System.Collections.Generic;
using Nop.Core;
using Nop.Core.Domain.Weixin;

namespace Nop.Services.Weixin
{
    /// <summary>
    /// WMenu Service interface
    /// </summary>
    public partial interface IWMenuService
    {

        void InsertMenu(WMenu menu);

        void DeleteMenu(WMenu menu, bool delete = false);

        void DeleteMenus(IList<WMenu> menus, bool deleted = false);

        void UpdateMenu(WMenu menu);

        void UpdateMenus(IList<WMenu> menus);

        WMenu GetMenuById(int id);

        WMenu GetMenuByMenuId(long menuId);

        IPagedList<WMenu> GetAllMenus(string systemName = "", bool? personal = null, int pageIndex = 0, int pageSize = int.MaxValue, bool showDeleted = false);

    }
}