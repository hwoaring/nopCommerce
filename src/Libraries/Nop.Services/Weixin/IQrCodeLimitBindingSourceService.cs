using System.Collections.Generic;
using System.Threading.Tasks;
using Nop.Core;
using Nop.Core.Domain.Weixin;

namespace Nop.Services.Weixin
{
    /// <summary>
    /// IQrCodeLimitBindingSourceService Service interface
    /// </summary>
    public partial interface IQrCodeLimitBindingSourceService
    {
        #region QrCodeLimitBindingSource

        Task InsertEntityAsync(QrCodeLimitBindingSource entity);

        Task DeleteEntityAsync(QrCodeLimitBindingSource entity);

        Task DeleteEntitiesAsync(IList<QrCodeLimitBindingSource> entities);

        Task UpdateEntityAsync(QrCodeLimitBindingSource entity);

        Task UpdateEntitiesAsync(IList<QrCodeLimitBindingSource> entities);

        Task<QrCodeLimitBindingSource> GetEntityByIdAsync(int id);

        Task<QrCodeLimitBindingSource> GetEntityByQrcodeLimitIdAsync(int qrCodeLimitId);

        Task<IList<QrCodeLimitBindingSource>> GetEntitiesByIdsAsync(int[] wEntityIds);

        Task<IPagedList<QrCodeLimitBindingSource>> GetEntitiesAsync(int qrCodeLimitId = 0, int supplierId = 0, int supplierShopId = 0, int productId = 0, bool? published = null, int pageIndex = 0, int pageSize = int.MaxValue);

        #endregion
    }
}