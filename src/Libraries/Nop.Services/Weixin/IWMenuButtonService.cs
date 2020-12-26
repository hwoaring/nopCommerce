using System.Collections.Generic;
using System.Threading.Tasks;
using Nop.Core;
using Nop.Core.Domain.Weixin;

namespace Nop.Services.Weixin
{
    /// <summary>
    /// WMenu Button Service interface
    /// </summary>
    public partial interface IWMenuButtonService
    {

        Task InsertMenuButtonAsync(WMenuButton menuButton);

        Task DeleteMenuButtonAsync(WMenuButton menuButton);

        Task DeleteMenuButtonsAsync(IList<WMenuButton> menuButtons);

        Task UpdateMenuButtonAsync(WMenuButton menuButton);

        Task UpdateMenuButtonsAsync(IList<WMenuButton> menuButtons);

        Task<WMenuButton> GetMenuButtonByIdAsync(int id);

        Task<IList<int>> GetChildMenuButtonIdsAsync(int parentId, int storeId = 0, bool showHidden = false);

        Task<IList<WMenuButton>> GetMenuButtonsByMenuIdAsync(int menuId);

        Task<IList<WMenuButton>> GetMenuButtonsByParentIdAsync(int parentId);

        Task<IList<WMenuButton>> GetAllMenuButtonsAsync();

        Task<IPagedList<WMenuButton>> GetAllMenuButtonsAsync(string name = "", int menuId = 0, int parentId = 0, bool? published = null, int pageIndex = 0, int pageSize = int.MaxValue);

    }
}