using System.Collections.Generic;
using System.Threading.Tasks;
using Nop.Core;
using Nop.Core.Domain.Weixin;

namespace Nop.Services.Weixin
{
    /// <summary>
    /// WQrCodeCategory Service interface
    /// </summary>
    public partial interface IWQrCodeCategoryService
    {
        Task InsertEntityAsync(WQrCodeCategory entity);

        Task UpdateEntityAsync(WQrCodeCategory entity);

        Task UpdateEntitiesAsync(IList<WQrCodeCategory> entities);

        Task<WQrCodeCategory> GetEntityByIdAsync(int id);

        Task<IList<WQrCodeCategory>> GetEntitiesByParentIdAsync(int parentId);

        Task<IList<WQrCodeCategory>> GetAllEntitiesAsync();

        Task<IPagedList<WQrCodeCategory>> GetEntitiesAsync(bool showDeleted = false, int pageIndex = 0, int pageSize = int.MaxValue);

    }
}