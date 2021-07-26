using System.Collections.Generic;
using System.Threading.Tasks;
using Nop.Core;
using Nop.Core.Domain.Weixin;

namespace Nop.Services.Weixin
{
    /// <summary>
    /// WMenu Button Service interface
    /// </summary>
    public partial interface IWxMenuButtonService
    {

        Task InsertMenuButtonAsync(WxMenuButton menuButton);

        Task DeleteMenuButtonAsync(WxMenuButton menuButton);

        Task DeleteMenuButtonsAsync(IList<WxMenuButton> menuButtons);

        Task UpdateMenuButtonAsync(WxMenuButton menuButton);

        Task UpdateMenuButtonsAsync(IList<WxMenuButton> menuButtons);

        Task<WxMenuButton> GetMenuButtonByIdAsync(int id);

        Task<IList<int>> GetChildMenuButtonIdsAsync(int parentId, int storeId = 0, bool showHidden = false);

        Task<IList<WxMenuButton>> GetMenuButtonsByMenuIdAsync(int menuId);

        Task<IList<WxMenuButton>> GetMenuButtonsByParentIdAsync(int parentId);

        Task<IList<WxMenuButton>> GetAllMenuButtonsAsync();

        Task<IPagedList<WxMenuButton>> GetAllMenuButtonsAsync(string name = "", int menuId = 0, int parentId = 0, bool? published = null, int pageIndex = 0, int pageSize = int.MaxValue);

    }
}