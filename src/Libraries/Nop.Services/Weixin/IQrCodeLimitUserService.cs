using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Nop.Core;
using Nop.Core.Domain.Weixin;

namespace Nop.Services.Weixin
{
    /// <summary>
    /// QrCodeLimitUser Service interface
    /// </summary>
    public partial interface IQrCodeLimitUserService
    {
        #region QrCodeLimitUserMapping

        Task InsertEntityAsync(QrCodeLimitUserMapping entity);

        Task DeleteEntityAsync(QrCodeLimitUserMapping entity);

        Task DeleteEntitiesAsync(IList<QrCodeLimitUserMapping> entities);

        Task UpdateEntityAsync(QrCodeLimitUserMapping entity);

        Task UpdateEntitiesAsync(IList<QrCodeLimitUserMapping> entities);

        Task<QrCodeLimitUserMapping> GetEntityByIdAsync(int id);

        Task<QrCodeLimitUserMapping> GetActiveEntityByQrCodeLimitIdOrCustomerIdAsync(int qrCodeLimitId, int customerId);

        Task<QrCodeLimitUserMapping> GetEntityByQrCodeLimitIdAndCustomerIdAsync(int qrCodeLimitId, int customerId);

        Task<IList<QrCodeLimitUserMapping>> GetEntitiesByQrcodeLimitIdAsync(int qrCodeLimitId);

        Task<IList<QrCodeLimitUserMapping>> GetEntitiesByCustomerIdAsync(int customerId);

        Task<IList<QrCodeLimitUserMapping>> GetEntitiesByIdsAsync(int[] entityIds);

        Task<IPagedList<QrCodeLimitUserMapping>> GetEntitiesAsync(int customerId = 0, int qrCodeLimitId = 0, DateTime? expireTime = null, bool? published = null, int pageIndex = 0, int pageSize = int.MaxValue);

        #endregion
    }
}