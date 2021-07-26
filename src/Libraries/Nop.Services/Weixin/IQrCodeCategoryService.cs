using System.Collections.Generic;
using System.Threading.Tasks;
using Nop.Core;
using Nop.Core.Domain.Weixin;

namespace Nop.Services.Weixin
{
    /// <summary>
    /// WQrCodeCategory Service interface
    /// </summary>
    public partial interface IQrCodeCategoryService
    {
        Task InsertEntityAsync(QrCodeCategory entity);

        Task UpdateEntityAsync(QrCodeCategory entity);

        Task UpdateEntitiesAsync(IList<QrCodeCategory> entities);

        Task<QrCodeCategory> GetEntityByIdAsync(int id);

        Task<IList<QrCodeCategory>> GetEntitiesByParentIdAsync(int parentId);

        Task<IList<QrCodeCategory>> GetAllEntitiesAsync();

        Task<IPagedList<QrCodeCategory>> GetEntitiesAsync(bool showDeleted = false, int pageIndex = 0, int pageSize = int.MaxValue);

    }
}