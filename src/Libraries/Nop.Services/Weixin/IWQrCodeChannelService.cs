using System.Collections.Generic;
using Nop.Core;
using Nop.Core.Domain.Weixin;

namespace Nop.Services.Weixin
{
    /// <summary>
    /// WQrCodeChannel Service interface
    /// </summary>
    public partial interface IWQrCodeChannelService
    {
        void InsertEntity(WQrCodeChannel entity);

        void UpdateEntity(WQrCodeChannel entity);

        void UpdateEntities(IList<WQrCodeChannel> entities);

        WQrCodeChannel GetEntityById(int id);

        List<WQrCodeChannel> GetEntitiesByParentId(int parentId);

        IList<WQrCodeChannel> GetAllEntities();

        IPagedList<WQrCodeChannel> GetEntities(bool showDeleted = false, int pageIndex = 0, int pageSize = int.MaxValue);

    }
}