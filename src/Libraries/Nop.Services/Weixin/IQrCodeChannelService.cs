using System.Collections.Generic;
using System.Threading.Tasks;
using Nop.Core;
using Nop.Core.Domain.Weixin;

namespace Nop.Services.Weixin
{
    /// <summary>
    /// WQrCodeChannel Service interface
    /// </summary>
    public partial interface IQrCodeChannelService
    {
        Task InsertEntityAsync(QrCodeChannel entity);

        Task UpdateEntityAsync(QrCodeChannel entity);

        Task UpdateEntitiesAsync(IList<QrCodeChannel> entities);

        Task<QrCodeChannel> GetEntityByIdAsync(int id);

        Task<IList<QrCodeChannel>> GetEntitiesByParentIdAsync(int parentId);

        Task<IList<QrCodeChannel>> GetAllEntitiesAsync();

        Task<IPagedList<QrCodeChannel>> GetEntitiesAsync(bool showDeleted = false, int pageIndex = 0, int pageSize = int.MaxValue);

    }
}