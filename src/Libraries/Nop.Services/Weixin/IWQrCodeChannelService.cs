using System.Collections.Generic;
using System.Threading.Tasks;
using Nop.Core;
using Nop.Core.Domain.Weixin;

namespace Nop.Services.Weixin
{
    /// <summary>
    /// WQrCodeChannel Service interface
    /// </summary>
    public partial interface IWQrCodeChannelService
    {
        Task InsertEntityAsync(WQrCodeChannel entity);

        Task UpdateEntityAsync(WQrCodeChannel entity);

        Task UpdateEntitiesAsync(IList<WQrCodeChannel> entities);

        Task<WQrCodeChannel> GetEntityByIdAsync(int id);

        Task<IList<WQrCodeChannel>> GetEntitiesByParentIdAsync(int parentId);

        Task<IList<WQrCodeChannel>> GetAllEntitiesAsync();

        Task<IPagedList<WQrCodeChannel>> GetEntitiesAsync(bool showDeleted = false, int pageIndex = 0, int pageSize = int.MaxValue);

    }
}