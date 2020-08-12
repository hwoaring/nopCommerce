using System.Collections.Generic;
using Nop.Core;
using Nop.Core.Domain.Weixin;

namespace Nop.Services.Weixin
{
    /// <summary>
    /// WMenu Button Service interface
    /// </summary>
    public partial interface IWMenuButtonService
    {

        void InsertMenuButton(WMenuButton menuButton);

        void DeleteMenuButton(WMenuButton menuButton);

        void DeleteMenuButtons(IList<WMenuButton> menuButtons);

        void UpdateMenuButton(WMenuButton menuButton);

        void UpdateMenuButtons(IList<WMenuButton> menuButtons);

        WMenuButton GetMenuButtonById(int id);

        IList<int> GetChildMenuButtonIds(int parentId);

        IList<WMenuButton> GetMenuButtonsByMenuId(int menuId);

        IList<WMenuButton> GetMenuButtonsByParentId(int parentId);

        IList<WMenuButton> GetAllMenuButtons();

        IPagedList<WMenuButton> GetAllMenuButtons(string name = "", int menuId = 0, int parentId = 0, bool? published = null, int pageIndex = 0, int pageSize = int.MaxValue);

    }
}