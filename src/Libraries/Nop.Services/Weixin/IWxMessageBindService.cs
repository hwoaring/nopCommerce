using System.Collections.Generic;
using System.Threading.Tasks;
using Nop.Core;
using Nop.Core.Domain.Weixin;

namespace Nop.Services.Weixin
{
    /// <summary>
    /// WMessageBind Service interface
    /// </summary>
    public partial interface IWxMessageBindService
    {
        Task InsertEntityAsync(WxMessageBindMapping messageBind);

        Task DeleteEntityAsync(WxMessageBindMapping messageBind);

        Task DeleteEntitiesAsync(IList<WxMessageBindMapping> messageBinds);

        Task UpdateEntityAsync(WxMessageBindMapping messageBind);

        Task UpdateEntitiesAsync(IList<WxMessageBindMapping> messageBinds);

        Task<WxMessageBindMapping> GetEntityByIdAsync(int id);

        Task<IList<WxMessageBindMapping>> GetEntitiesByIdsAsync(int[] messageBindIds);

        Task<IList<int>> GetMessageBindIdsAsync(int bindSceneId, MessageBindSceneType messageBindSceneType);

        Task<IList<WxMessageBindMapping>> GetEntitiesAsync(int messageId = 0, int bindSceneId = 0, MessageBindSceneType? messageBindSceneType = null, bool? published = null);

        Task<IPagedList<WxMessageBindMapping>> GetEntitiesAsync(int messageId = 0, int bindSceneId = 0, MessageBindSceneType? messageBindSceneType = null, bool? published = null, int pageIndex = 0, int pageSize = int.MaxValue);

    }
}