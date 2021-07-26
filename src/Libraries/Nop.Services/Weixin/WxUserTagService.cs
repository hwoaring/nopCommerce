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
    public partial class WxUserTagService : IWxUserTagService
    {
        #region Fields

        private readonly IRepository<WxUserTag> _wUserTagRepository;

        #endregion

        #region Ctor

        public WxUserTagService(
            IRepository<WxUserTag> wUserTagRepository)
        {
            _wUserTagRepository = wUserTagRepository;
        }

        #endregion

        #region Methods

        public virtual async Task InsertWxUserTagAsync(WxUserTag userTag)
        {
            await _wUserTagRepository.InsertAsync(userTag);
        }

        public virtual async Task DeleteWxUserTagAsync(WxUserTag userTag)
        {
            await _wUserTagRepository.DeleteAsync(userTag);
        }

        public virtual async Task DeleteWxUserTagsAsync(IList<WxUserTag> userTags)
        {
            await _wUserTagRepository.DeleteAsync(userTags);
        }

        public virtual async Task UpdateWxUserTagAsync(WxUserTag userTag)
        {
            await _wUserTagRepository.UpdateAsync(userTag);
        }

        public virtual async Task UpdateWxUserTagsAsync(IList<WxUserTag> userTags)
        {
            await _wUserTagRepository.UpdateAsync(userTags);
        }

        public virtual async Task<WxUserTag> GetWxUserTagByIdAsync(int id)
        {
            return await _wUserTagRepository.GetByIdAsync(id, cache => default);
        }

        public virtual async Task<WxUserTag> GetWxUserTagByOfficialIdAsync(int officialId, int? configId = null)
        {
            if (officialId == 0)
                return null;

            var query = _wUserTagRepository.Table;

            query = query.Where(v => v.OfficialId == officialId);

            return await query.FirstOrDefaultAsync();
        }

        public virtual async Task<IList<WxUserTag>> GetWxUserTagsByOfficialIdsAsync(int[] officialIds, int? configId = null)
        {
            if (officialIds is null)
                throw new ArgumentNullException(nameof(officialIds));

            var query = _wUserTagRepository.Table;

            query = query.Where(v => officialIds.Contains(v.OfficialId));

            query = query.OrderBy(v => v.UpdateTime).ThenBy(v => v.Id);

            return await query.ToListAsync();
        }

        public virtual async Task<IPagedList<WxUserTag>> GetWxUserTagsAsync(int? configId = null, int pageIndex = 0, int pageSize = int.MaxValue, bool showDeleted = false)
        {
            var query = _wUserTagRepository.Table;

            query = query.OrderBy(v => v.UpdateTime).ThenBy(v => v.Id);

            return await query.ToPagedListAsync(pageIndex, pageSize);
        }

        #endregion
    }
}