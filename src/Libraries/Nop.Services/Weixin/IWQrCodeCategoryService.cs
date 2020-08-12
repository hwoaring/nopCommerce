using System.Collections.Generic;
using Nop.Core;
using Nop.Core.Domain.Weixin;

namespace Nop.Services.Weixin
{
    /// <summary>
    /// WQrCodeCategory Service interface
    /// </summary>
    public partial interface IWQrCodeCategoryService
    {
        void InsertEntity(WQrCodeCategory entity);

        void UpdateEntity(WQrCodeCategory entity);

        void UpdateEntities(IList<WQrCodeCategory> entities);

        WQrCodeCategory GetEntityById(int id);

        List<WQrCodeCategory> GetEntitiesByParentId(int parentId);

        IList<WQrCodeCategory> GetAllEntities();

        IPagedList<WQrCodeCategory> GetEntities(bool showDeleted = false, int pageIndex = 0, int pageSize = int.MaxValue);

    }
}