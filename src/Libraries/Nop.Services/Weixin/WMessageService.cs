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
    /// WMessageService
    /// </summary>
    public partial class WMessageService : IWMessageService
    {
        #region Fields

        private readonly IRepository<WMessage> _wMessageRepository;

        #endregion

        #region Ctor

        public WMessageService(
            IRepository<WMessage> wMessageRepository)
        {
            _wMessageRepository = wMessageRepository;
        }

        #endregion

        #region Methods

        public virtual async Task InsertWMessageAsync(WMessage wMessage)
        {
            await _wMessageRepository.InsertAsync(wMessage);
        }

        public virtual async Task DeleteWMessageAsync(WMessage wMessage)
        {
            await _wMessageRepository.DeleteAsync(wMessage);
        }

        public virtual async Task DeleteWMessagesAsync(IList<WMessage> wMessages)
        {
            await _wMessageRepository.DeleteAsync(wMessages);
        }

        public virtual async Task UpdateWMessageAsync(WMessage wMessage)
        {
            await _wMessageRepository.UpdateAsync(wMessage);
        }

        public virtual async Task UpdateWMessagesAsync(IList<WMessage> wMessages)
        {
            await _wMessageRepository.UpdateAsync(wMessages);
        }

        public virtual async Task<WMessage> GetWMessageByIdAsync(int id)
        {
            return await _wMessageRepository.GetByIdAsync(id, cache => default);
        }

        public virtual async Task<IList<WMessage>> GetWMessagesByIdsAsync(int[] wMessageIds)
        {
            return await _wMessageRepository.GetByIdsAsync(wMessageIds, cache => default);
        }

        public virtual async Task<IPagedList<WMessage>> GetWMessagesAsync(
            string title = "", 
            bool? published = null,
            bool? deleted = null, 
            int pageIndex = 0, int pageSize = int.MaxValue)
        {
            var query = _wMessageRepository.Table;

            if (!string.IsNullOrEmpty(title))
                query = query.Where(v => v.Title.Contains(title));
            if (published.HasValue)
                query = query.Where(v => v.Published == published);
            if (deleted.HasValue)
                query = query.Where(v => v.Deleted == deleted);

            query = query.OrderBy(v => v.CreatTime).ThenBy(v => v.Id);

            return await query.ToPagedListAsync(pageIndex, pageSize);
        }

        #endregion
    }
}