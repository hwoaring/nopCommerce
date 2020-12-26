using System.Collections.Generic;
using System.Threading.Tasks;
using Nop.Core;
using Nop.Core.Domain.Weixin;

namespace Nop.Services.Weixin
{
    /// <summary>
    /// WQrCodeLimit Service interface
    /// </summary>
    public partial interface IWQrCodeLimitService
    {
        Task InsertWQrCodeLimitAsync(WQrCodeLimit wQrCodeLimit);

        Task UpdateWQrCodeLimitAsync(WQrCodeLimit wQrCodeLimit);

        Task UpdateWQrCodeLimitsAsync(IList<WQrCodeLimit> wQrCodeLimits);

        Task<WQrCodeLimit> GetWQrCodeLimitByIdAsync(int id);

        Task<WQrCodeLimit> GetWQrCodeLimitByQrCodeIdAsync(int qrCodeId);

        Task<IList<WQrCodeLimit>> GetWUsersByIdsAsync(int[] wQrCodeLimitIds);

        Task<IPagedList<WQrCodeLimit>> GetWQrCodeLimitsAsync(string sysName="", int? wConfigId = null, int? wQrCodeCategoryId = null, int? wQrCodeChannelId = null, bool? fixedUse = null, bool? hasCreated = null, int pageIndex = 0, int pageSize = int.MaxValue);

    }
}