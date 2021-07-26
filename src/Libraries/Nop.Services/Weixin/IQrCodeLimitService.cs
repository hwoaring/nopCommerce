using System.Collections.Generic;
using System.Threading.Tasks;
using Nop.Core;
using Nop.Core.Domain.Weixin;

namespace Nop.Services.Weixin
{
    /// <summary>
    /// QrCodeLimit Service interface
    /// </summary>
    public partial interface IQrCodeLimitService
    {
        Task InsertQrCodeLimitAsync(QrCodeLimit qrCodeLimit);

        Task UpdateQrCodeLimitAsync(QrCodeLimit qrCodeLimit);

        Task UpdateQrCodeLimitsAsync(IList<QrCodeLimit> qrCodeLimits);

        Task<QrCodeLimit> GetQrCodeLimitByIdAsync(int id);

        Task<QrCodeLimit> GetQrCodeLimitByQrCodeIdAsync(int qrCodeId);

        Task<IList<QrCodeLimit>> GetQrCodeLimitsByIdsAsync(int[] qrCodeLimitIds);

        Task<IPagedList<QrCodeLimit>> GetQrCodeLimitsAsync(string sysName="", int storeId = 0, int? qrCodeCategoryId = null, int? qrCodeChannelId = null, bool? fixedUse = null, bool? hasCreated = null, int pageIndex = 0, int pageSize = int.MaxValue);

    }
}