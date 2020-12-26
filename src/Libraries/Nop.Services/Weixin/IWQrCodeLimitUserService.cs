using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Nop.Core;
using Nop.Core.Domain.Weixin;

namespace Nop.Services.Weixin
{
    /// <summary>
    /// WQrCodeLimitUser Service interface
    /// </summary>
    public partial interface IWQrCodeLimitUserService
    {
        #region WQrCodeLimitUserMapping

        Task InsertEntityAsync(WQrCodeLimitUserMapping entity);

        Task DeleteEntityAsync(WQrCodeLimitUserMapping entity);

        Task DeleteEntitiesAsync(IList<WQrCodeLimitUserMapping> entities);

        Task UpdateEntityAsync(WQrCodeLimitUserMapping entity);

        Task UpdateEntitiesAsync(IList<WQrCodeLimitUserMapping> entities);

        Task<WQrCodeLimitUserMapping> GetEntityByIdAsync(int id);

        Task<WQrCodeLimitUserMapping> GetActiveEntityByQrCodeLimitIdOrUserIdAsync(int qrCodeLimitId, int userId);

        Task<WQrCodeLimitUserMapping> GetEntityByQrCodeLimitIdAndUserIdAsync(int qrCodeLimitId, int userId);

        Task<IList<WQrCodeLimitUserMapping>> GetEntitiesByQrcodeLimitIdAsync(int qrCodeLimitId);

        Task<IList<WQrCodeLimitUserMapping>> GetEntitiesByUserIdAsync(int userId);

        Task<IList<WQrCodeLimitUserMapping>> GetEntitiesByIdsAsync(int[] wEntityIds);

        Task<IPagedList<WQrCodeLimitUserMapping>> GetEntitiesAsync(int userId = 0, int qrCodeLimitId = 0, DateTime? expireTime = null, bool? published = null, int pageIndex = 0, int pageSize = int.MaxValue);

        #endregion
    }
}