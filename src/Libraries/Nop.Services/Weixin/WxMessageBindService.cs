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
    public partial class WxMessageBindService : IWxMessageBindService
    {
        #region Fields

        private readonly IRepository<WxMessageBindMapping> _wMessageBindRepository;

        #endregion

        #region Ctor

        public WxMessageBindService(
            IRepository<WxMessageBindMapping> wMessageBindRepository)
        {
            _wMessageBindRepository = wMessageBindRepository;
        }

        #endregion

        #region Methods

        public virtual async Task InsertEntityAsync(WxMessageBindMapping messageBind)
        {
            await _wMessageBindRepository.InsertAsync(messageBind);
        }

        public virtual async Task DeleteEntityAsync(WxMessageBindMapping messageBind)
        {
            await _wMessageBindRepository.DeleteAsync(messageBind);
        }

        public virtual async Task DeleteEntitiesAsync(IList<WxMessageBindMapping> messageBinds)
        {
            await _wMessageBindRepository.DeleteAsync(messageBinds);
        }

        public virtual async Task UpdateEntityAsync(WxMessageBindMapping messageBind)
        {
            await _wMessageBindRepository.UpdateAsync(messageBind);
        }

        public virtual async Task UpdateEntitiesAsync(IList<WxMessageBindMapping> messageBinds)
        {
            await _wMessageBindRepository.UpdateAsync(messageBinds);
        }

        public virtual async Task<WxMessageBindMapping> GetEntityByIdAsync(int id)
        {
            return await _wMessageBindRepository.GetByIdAsync(id, cache => default);
        }

        public virtual async Task<IList<WxMessageBindMapping>> GetEntitiesByIdsAsync(int[] messageBindIds)
        {
            return await _wMessageBindRepository.GetByIdsAsync(messageBindIds, cache => default);
        }

        public virtual async Task<IList<int>> GetMessageBindIdsAsync(int bindSceneId, MessageBindSceneType messageBindSceneType)
        {
            if (bindSceneId <= 0)
                return new List<int>();

            var query = from t in _wMessageBindRepository.Table
                        where t.BindSceneId == bindSceneId &&
                        t.MessageBindSceneType == messageBindSceneType &&
                        t.Published
                        orderby t.DisplayOrder
                        select t;

            var messageBinds = await query.ToListAsync();

            //sort by passed identifiers
            var sortedIds = new List<int>();
            foreach (var messageBind in messageBinds)
            {
                sortedIds.Add(messageBind.WxMessageId);
            }

            return sortedIds;
        }

        public virtual async Task<IList<WxMessageBindMapping>> GetEntitiesAsync(
            int messageId = 0,
            int bindSceneId = 0,
            MessageBindSceneType? messageBindSceneType = null,
            bool? published = null)
        {
            var query = _wMessageBindRepository.Table;

            if (messageId > 0)
                query = query.Where(v => v.WxMessageId == messageId);
            if (bindSceneId > 0)
                query = query.Where(v => v.BindSceneId == bindSceneId);
            if (messageBindSceneType != null)
                query = query.Where(v => v.MessageBindSceneType == messageBindSceneType);
            if (published.HasValue)
                query = query.Where(v => v.Published == published);

            query = query.OrderBy(v => v.DisplayOrder);

            return await query.ToListAsync();
        }

        public virtual async Task<IPagedList<WxMessageBindMapping>> GetEntitiesAsync(
            int messageId = 0, 
            int bindSceneId = 0, 
            MessageBindSceneType? messageBindSceneType = null,
            bool? published = null,
            int pageIndex = 0, int pageSize = int.MaxValue)
        {
            var query = _wMessageBindRepository.Table;

            if (messageId > 0)
                query = query.Where(v => v.WxMessageId == messageId);
            if (bindSceneId > 0)
                query = query.Where(v => v.BindSceneId == bindSceneId);
            if (messageBindSceneType != null)
                query = query.Where(v => v.MessageBindSceneType == messageBindSceneType);
            if (published.HasValue)
                query = query.Where(v => v.Published == published);

            query = query.OrderBy(v => v.DisplayOrder);

            return await query.ToPagedListAsync(pageIndex, pageSize);
        }

        #endregion
    }
}