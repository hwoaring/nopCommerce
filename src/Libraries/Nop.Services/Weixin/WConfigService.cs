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
using Org.BouncyCastle.Bcpg.OpenPgp;

namespace Nop.Services.Weixin
{
    /// <summary>
    /// WConfig Service
    /// </summary>
    public partial class WConfigService : IWConfigService
    {
        #region Fields

        private readonly IRepository<WConfig> _wConfigRepository;

        #endregion

        #region Ctor

        public WConfigService(
            IRepository<WConfig> wConfigRepository)
        {
            _wConfigRepository = wConfigRepository;
        }

        #endregion

        #region Methods

        public virtual async Task InsertWConfigAsync(WConfig wConfig)
        {
            await _wConfigRepository.InsertAsync(wConfig);
        }

        public virtual async Task DeleteWConfigAsync(WConfig wConfig)
        {
            await _wConfigRepository.DeleteAsync(wConfig);
        }

        public virtual async Task DeleteWConfigsAsync(IList<WConfig> wConfigs)
        {
            await _wConfigRepository.DeleteAsync(wConfigs);
        }

        public virtual async Task UpdateWConfigAsync(WConfig wConfig)
        {
            await _wConfigRepository.UpdateAsync(wConfig);
        }

        public virtual async Task UpdateWConfigsAsync(IList<WConfig> wConfigs)
        {
            await _wConfigRepository.UpdateAsync(wConfigs);
        }

        public virtual async Task<WConfig> GetWConfigByIdAsync(int id)
        {
            return await _wConfigRepository.GetByIdAsync(id, cache => default);
        }

        public virtual async Task<WConfig> GetWConfigByOriginalIdAsync(string originalId)
        {
            if (string.IsNullOrEmpty(originalId))
                return null;

            originalId = originalId.Trim();

            var query = from t in _wConfigRepository.Table
                        where t.OriginalId == originalId &&
                        t.Published &&
                        !t.Deleted
                        select t;

            return await query.FirstOrDefaultAsync();
        }

        public virtual async Task<WConfig> GetWConfigByStoreIdAsync(int storeId)
        {
            if (storeId == 0)
                return null;

            var query = from t in _wConfigRepository.Table
                        where t.StoreId == storeId &&
                        t.Published &&
                        !t.Deleted
                        select t;

            return await query.FirstOrDefaultAsync();
        }

        public virtual async Task<IList<WConfig>> GetWConfigsByIdsAsync(int[] wConfigIds)
        {
            return await _wConfigRepository.GetByIdsAsync(wConfigIds, cache => default);
        }

        public virtual async Task<IPagedList<WConfig>> GetWConfigsAsync(bool showDeleted = false, int pageIndex = 0, int pageSize = int.MaxValue)
        {
            var query = _wConfigRepository.Table;

            if (!showDeleted)
                query = query.Where(v => v.Deleted);

            query = query.OrderBy(v => v.Id);

            return await query.ToPagedListAsync(pageIndex, pageSize);
        }

        #endregion
    }
}