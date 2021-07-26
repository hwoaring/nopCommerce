using System.Collections.Generic;
using System.Threading.Tasks;
using Nop.Core;
using Nop.Core.Domain.Weixin;

namespace Nop.Services.Weixin
{
    /// <summary>
    /// WUserTag service interface
    /// </summary>
    public partial interface IWxUserTagService
    {
        Task InsertWxUserTagAsync(WxUserTag userTag);

        Task DeleteWxUserTagAsync(WxUserTag userTag);

        Task DeleteWxUserTagsAsync(IList<WxUserTag> userTags);

        Task UpdateWxUserTagAsync(WxUserTag userTag);

        Task UpdateWxUserTagsAsync(IList<WxUserTag> userTags);

        Task<WxUserTag> GetWxUserTagByIdAsync(int id);

        Task<WxUserTag> GetWxUserTagByOfficialIdAsync(int officialId, int? configId = null);

        Task<IList<WxUserTag>> GetWxUserTagsByOfficialIdsAsync(int[] officialIds, int? configId = null);

        Task<IPagedList<WxUserTag>> GetWxUserTagsAsync(int? configId = null, int pageIndex = 0, int pageSize = int.MaxValue, bool showDeleted = false);
    }
}