using System.Collections.Generic;
using System.Threading.Tasks;
using Nop.Core;
using Nop.Core.Domain.Weixin;

namespace Nop.Services.Weixin
{
    /// <summary>
    /// WMenu Service interface
    /// </summary>
    public partial interface IWxMenuService
    {

        Task InsertMenuAsync(WxMenu menu);

        Task DeleteMenuAsync(WxMenu menu);

        Task DeleteMenusAsync(IList<WxMenu> menus);

        Task UpdateMenuAsync(WxMenu menu);

        Task UpdateMenusAsync(IList<WxMenu> menus);

        Task<WxMenu> GetMenuByIdAsync(int id);

        Task<WxMenu> GetMenuByMenuIdAsync(long menuId);

        Task<IPagedList<WxMenu>> GetAllMenusAsync(string systemName = "", bool? personal = null, int pageIndex = 0, int pageSize = int.MaxValue, bool showDeleted = false);

    }
}