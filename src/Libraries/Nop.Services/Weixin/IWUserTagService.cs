using System.Collections.Generic;
using System.Threading.Tasks;
using Nop.Core;
using Nop.Core.Domain.Weixin;

namespace Nop.Services.Weixin
{
    /// <summary>
    /// WUserTag service interface
    /// </summary>
    public partial interface IWUserTagService
    {
        Task InsertWUserTagAsync(WUserTag userTag);

        Task DeleteWUserTagAsync(WUserTag userTag);

        Task DeleteWUserTagsAsync(IList<WUserTag> userTags);

        Task UpdateWUserTagAsync(WUserTag userTag);

        Task UpdateWUserTagsAsync(IList<WUserTag> userTags);

        Task<WUserTag> GetWUserTagByIdAsync(int id);

        Task<WUserTag> GetWUserTagByOfficialIdAsync(int officialId, int? configId = null);

        Task<IList<WUserTag>> GetWUserTagsByOfficialIdsAsync(int[] officialIds, int? configId = null);

        Task<IPagedList<WUserTag>> GetWUserTagsAsync(int? configId = null, int pageIndex = 0, int pageSize = int.MaxValue, bool showDeleted = false);
    }
}