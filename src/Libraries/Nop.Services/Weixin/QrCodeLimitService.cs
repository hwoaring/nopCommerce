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
    public partial class QrCodeLimitService : IQrCodeLimitService
    {
        #region Fields

        private readonly IRepository<QrCodeLimit> _wQrCodeLimitRepository;

        #endregion

        #region Ctor

        public QrCodeLimitService(
            IRepository<QrCodeLimit> wQrCodeLimitRepository)
        {
            _wQrCodeLimitRepository = wQrCodeLimitRepository;
        }

        #endregion

        #region Methods

        public virtual async Task InsertQrCodeLimitAsync(QrCodeLimit wQrCodeLimit)
        {
            await _wQrCodeLimitRepository.InsertAsync(wQrCodeLimit);
        }

        public virtual async Task UpdateQrCodeLimitAsync(QrCodeLimit wQrCodeLimit)
        {
            await _wQrCodeLimitRepository.UpdateAsync(wQrCodeLimit);
        }

        public virtual async Task UpdateQrCodeLimitsAsync(IList<QrCodeLimit> wQrCodeLimits)
        {
            await _wQrCodeLimitRepository.UpdateAsync(wQrCodeLimits);
        }

        public virtual async Task<QrCodeLimit> GetQrCodeLimitByIdAsync(int id)
        {
            return await _wQrCodeLimitRepository.GetByIdAsync(id, cache => default);
        }

        public virtual async Task<QrCodeLimit> GetQrCodeLimitByQrCodeIdAsync(int qrCodeId)
        {
            if (qrCodeId == 0)
                return null;

            var query = from t in _wQrCodeLimitRepository.Table
                        orderby t.Id
                        where t.QrCodeId == qrCodeId
                        select t;

            return await query.FirstOrDefaultAsync();
        }

        public virtual async Task<IList<QrCodeLimit>> GetQrCodeLimitsByIdsAsync(int[] wQrCodeLimitIds)
        {
            if (wQrCodeLimitIds is null)
                return new List<QrCodeLimit>();

            var query = from t in _wQrCodeLimitRepository.Table
                        where wQrCodeLimitIds.Contains(t.Id)
                        select t;

            return await query.ToListAsync();
        }

        public virtual async Task<IPagedList<QrCodeLimit>> GetQrCodeLimitsAsync(
            string sysName="",
            int storeId = 0, 
            int? qrCodeCategoryId = null, 
            int? qrCodeChannelId = null, 
            bool? fixedUse = null, 
            bool? hasCreated = null, 
            int pageIndex = 0, int pageSize = int.MaxValue)
        {
            var query = _wQrCodeLimitRepository.Table;

            if (!string.IsNullOrEmpty(sysName))
                query = query.Where(v => v.SysName.Contains(sysName));

            if (storeId > 0)
                query = query.Where(v => v.StoreId == storeId);

            if (qrCodeCategoryId.HasValue && qrCodeCategoryId > 0)
                query = query.Where(v => v.QrCodeCategoryId == qrCodeCategoryId);

            if (qrCodeChannelId.HasValue && qrCodeChannelId > 0)
                query = query.Where(v => v.QrCodeChannelId == qrCodeChannelId);

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