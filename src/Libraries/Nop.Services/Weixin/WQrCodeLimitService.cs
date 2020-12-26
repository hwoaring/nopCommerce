using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Nop.Core;
using Nop.Core.Domain.Catalog;
using Nop.Core.Domain.Vendors;
using Nop.Core.Domain.Weixin;
using Nop.Core.Html;
using Nop.Data;
using Nop.Services.Events;

namespace Nop.Services.Weixin
{
    /// <summary>
    /// WUserService
    /// </summary>
    public partial class WQrCodeLimitService : IWQrCodeLimitService
    {
        #region Fields

        private readonly IRepository<WQrCodeLimit> _wQrCodeLimitRepository;

        #endregion

        #region Ctor

        public WQrCodeLimitService(
            IRepository<WQrCodeLimit> wQrCodeLimitRepository)
        {
            _wQrCodeLimitRepository = wQrCodeLimitRepository;
        }

        #endregion

        #region Methods

        public virtual async Task InsertWQrCodeLimitAsync(WQrCodeLimit wQrCodeLimit)
        {
            await _wQrCodeLimitRepository.InsertAsync(wQrCodeLimit);
        }

        public virtual async Task UpdateWQrCodeLimitAsync(WQrCodeLimit wQrCodeLimit)
        {
            await _wQrCodeLimitRepository.UpdateAsync(wQrCodeLimit);
        }

        public virtual async Task UpdateWQrCodeLimitsAsync(IList<WQrCodeLimit> wQrCodeLimits)
        {
            await _wQrCodeLimitRepository.UpdateAsync(wQrCodeLimits);
        }

        public virtual async Task<WQrCodeLimit> GetWQrCodeLimitByIdAsync(int id)
        {
            return await _wQrCodeLimitRepository.GetByIdAsync(id, cache => default);
        }

        public virtual async Task<WQrCodeLimit> GetWQrCodeLimitByQrCodeIdAsync(int qrCodeId)
        {
            if (qrCodeId == 0)
                return null;

            var query = from t in _wQrCodeLimitRepository.Table
                        orderby t.Id
                        where t.QrCodeId == qrCodeId
                        select t;

            return await query.FirstOrDefaultAsync();
        }

        public virtual async Task<IList<WQrCodeLimit>> GetWUsersByIdsAsync(int[] wQrCodeLimitIds)
        {
            if (wQrCodeLimitIds is null)
                return new List<WQrCodeLimit>();

            var query = from t in _wQrCodeLimitRepository.Table
                        where wQrCodeLimitIds.Contains(t.Id)
                        select t;

            return await query.ToListAsync();
        }

        public virtual async Task<IPagedList<WQrCodeLimit>> GetWQrCodeLimitsAsync(
            string sysName="",
            int? wConfigId = null, 
            int? wQrCodeCategoryId = null, 
            int? wQrCodeChannelId = null, 
            bool? fixedUse = null, 
            bool? hasCreated = null, 
            int pageIndex = 0, int pageSize = int.MaxValue)
        {
            var query = _wQrCodeLimitRepository.Table;

            if (!string.IsNullOrEmpty(sysName))
                query = query.Where(v => v.SysName.Contains(sysName));

            if (wConfigId.HasValue && wConfigId > 0)
                query = query.Where(v => v.WConfigId == wConfigId);

            if (wQrCodeCategoryId.HasValue && wQrCodeCategoryId > 0)
                query = query.Where(v => v.WQrCodeCategoryId == wQrCodeCategoryId);

            if (wQrCodeChannelId.HasValue && wQrCodeChannelId > 0)
                query = query.Where(v => v.WQrCodeChannelId == wQrCodeChannelId);

            if (hasCreated.HasValue)
            {
                if (hasCreated.Value)
                    query = query.Where(v => !string.IsNullOrEmpty(v.Ticket));
                else
                    query = query.Where(v => string.IsNullOrEmpty(v.Ticket));
            }
                
            if (fixedUse.HasValue)
                query = query.Where(v => v.FixedUse == fixedUse);

            query = query.OrderBy(v => v.Id);

            return await query.ToPagedListAsync(pageIndex, pageSize);
        }


        #endregion
    }
}