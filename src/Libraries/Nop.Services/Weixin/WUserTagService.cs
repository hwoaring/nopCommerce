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
    /// WUserTag Service
    /// </summary>
    public partial class WUserTagService : IWUserTagService
    {
        #region Fields

        private readonly IRepository<WUserTag> _wUserTagRepository;

        #endregion

        #region Ctor

        public WUserTagService(
            IRepository<WUserTag> wUserTagRepository)
        {
            _wUserTagRepository = wUserTagRepository;
        }

        #endregion

        #region Methods

        public virtual async Task InsertWUserTagAsync(WUserTag userTag)
        {
            await _wUserTagRepository.InsertAsync(userTag);
        }

        public virtual async Task DeleteWUserTagAsync(WUserTag userTag)
        {
            await _wUserTagRepository.DeleteAsync(userTag);
        }

        public virtual async Task DeleteWUserTagsAsync(IList<WUserTag> userTags)
        {
            await _wUserTagRepository.DeleteAsync(userTags);
        }

        public virtual async Task UpdateWUserTagAsync(WUserTag userTag)
        {
            await _wUserTagRepository.UpdateAsync(userTag);
        }

        public virtual async Task UpdateWUserTagsAsync(IList<WUserTag> userTags)
        {
            await _wUserTagRepository.UpdateAsync(userTags);
        }

        public virtual async Task<WUserTag> GetWUserTagByIdAsync(int id)
        {
            return await _wUserTagRepository.GetByIdAsync(id, cache => default);
        }

        public virtual async Task<WUserTag> GetWUserTagByOfficialIdAsync(int officialId, int? configId = null)
        {
            if (officialId == 0)
                return null;

            var query = _wUserTagRepository.Table;

            query = query.Where(v => v.OfficialId == officialId);

            if (configId.HasValue)
                query = query.Where(v => v.WConfigId == configId);

            return await query.FirstOrDefaultAsync();
        }

        public virtual async Task<IList<WUserTag>> GetWUserTagsByOfficialIdsAsync(int[] officialIds, int? configId = null)
        {
            if (officialIds is null)
                throw new ArgumentNullException(nameof(officialIds));

            var query = _wUserTagRepository.Table;

            query = query.Where(v => officialIds.Contains(v.OfficialId));

            if (configId.HasValue)
                query = query.Where(v => v.WConfigId == configId);

            query = query.OrderBy(v => v.UpdateTime).ThenBy(v => v.Id);

            return await query.ToListAsync();
        }

        public virtual async Task<IPagedList<WUserTag>> GetWUserTagsAsync(int? configId = null, int pageIndex = 0, int pageSize = int.MaxValue, bool showDeleted = false)
        {
            var query = _wUserTagRepository.Table;

            if (configId.HasValue)
                query = query.Where(v => v.WConfigId == configId);

            query = query.OrderBy(v => v.UpdateTime).ThenBy(v => v.Id);

            return await query.ToPagedListAsync(pageIndex, pageSize);
        }

        #endregion
    }
}