using System.Collections.Generic;
using System.Threading.Tasks;
using Nop.Core;
using Nop.Core.Domain.Weixin;

namespace Nop.Services.Weixin
{
    /// <summary>
    /// WMessageBind Service interface
    /// </summary>
    public partial interface IWMessageBindService
    {
        Task InsertEntityAsync(WMessageBindMapping messageBind);

        Task DeleteEntityAsync(WMessageBindMapping messageBind);

        Task DeleteEntitiesAsync(IList<WMessageBindMapping> messageBinds);

        Task UpdateEntityAsync(WMessageBindMapping messageBind);

        Task UpdateEntitiesAsync(IList<WMessageBindMapping> messageBinds);

        Task<WMessageBindMapping> GetEntityByIdAsync(int id);

        Task<IList<WMessageBindMapping>> GetEntitiesByIdsAsync(int[] messageBindIds);

        Task<IList<int>> GetMessageBindIdsAsync(int bindSceneId, WMessageBindSceneType messageBindSceneType);

        Task<IList<WMessageBindMapping>> GetEntitiesAsync(int messageId = 0, int bindSceneId = 0, WMessageBindSceneType? messageBindSceneType = null, bool? published = null);

        Task<IPagedList<WMessageBindMapping>> GetEntitiesAsync(int messageId = 0, int bindSceneId = 0, WMessageBindSceneType? messageBindSceneType = null, bool? published = null, int pageIndex = 0, int pageSize = int.MaxValue);

    }
}