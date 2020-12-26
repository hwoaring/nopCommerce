using System.Collections.Generic;
using System.Threading.Tasks;
using Nop.Core;
using Nop.Core.Domain.Weixin;

namespace Nop.Services.Weixin
{
    /// <summary>
    /// WConfig Service interface
    /// </summary>
    public partial interface IWConfigService
    {
        Task InsertWConfigAsync(WConfig wConfig);

        Task DeleteWConfigAsync(WConfig wConfig);

        Task DeleteWConfigsAsync(IList<WConfig> wConfigs);

        Task UpdateWConfigAsync(WConfig wConfig);

        Task UpdateWConfigsAsync(IList<WConfig> wConfigs);

        Task<WConfig> GetWConfigByIdAsync(int id);

        Task<WConfig> GetWConfigByOriginalIdAsync(string originalId);

        Task<WConfig> GetWConfigByStoreIdAsync(int storeId);

        Task<IList<WConfig>> GetWConfigsByIdsAsync(int[] wConfigIds);

        Task<IPagedList<WConfig>> GetWConfigsAsync(bool showDeleted = false, int pageIndex = 0, int pageSize = int.MaxValue);
    }
}