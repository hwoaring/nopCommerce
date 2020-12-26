using System.Collections.Generic;
using System.Threading.Tasks;
using Nop.Core;
using Nop.Core.Domain.Weixin;

namespace Nop.Services.Weixin
{
    /// <summary>
    /// WMenu Service interface
    /// </summary>
    public partial interface IWMenuService
    {

        Task InsertMenuAsync(WMenu menu);

        Task DeleteMenuAsync(WMenu menu);

        Task DeleteMenusAsync(IList<WMenu> menus);

        Task UpdateMenuAsync(WMenu menu);

        Task UpdateMenusAsync(IList<WMenu> menus);

        Task<WMenu> GetMenuByIdAsync(int id);

        Task<WMenu> GetMenuByMenuIdAsync(long menuId);

        Task<IPagedList<WMenu>> GetAllMenusAsync(string systemName = "", bool? personal = null, int pageIndex = 0, int pageSize = int.MaxValue, bool showDeleted = false);

    }
}