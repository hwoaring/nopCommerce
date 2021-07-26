using System.Collections.Generic;
using System.Threading.Tasks;
using Nop.Core;
using Nop.Core.Domain.Weixin;

namespace Nop.Services.Weixin
{
    /// <summary>
    /// WConfig Service interface
    /// </summary>
    public partial interface IWxConfigService
    {
        Task InsertWxConfigAsync(WxConfig wxConfig);

        Task DeleteWxConfigAsync(WxConfig wxConfig);

        Task DeleteWxConfigsAsync(IList<WxConfig> wxConfigs);

        Task UpdateWxConfigAsync(WxConfig wxConfig);

        Task UpdateWxConfigsAsync(IList<WxConfig> wxConfigs);

        Task<WxConfig> GetWxConfigByIdAsync(int id);

        Task<WxConfig> GetWxConfigByOriginalIdAsync(string originalId);

        Task<WxConfig> GetWxConfigByStoreIdAsync(int storeId);

        Task<IList<WxConfig>> GetWxConfigsByIdsAsync(int[] wxConfigIds);

        Task<IPagedList<WxConfig>> GetWxConfigsAsync(bool showDeleted = false, int pageIndex = 0, int pageSize = int.MaxValue);
    }
}