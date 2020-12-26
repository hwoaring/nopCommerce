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
    /// WQrCodeLimitUser Service
    /// </summary>
    public partial class WQrCodeLimitUserService : IWQrCodeLimitUserService
    {
        #region Fields

        private readonly IRepository<WUser> _wUserRepository;
        private readonly IRepository<WQrCodeLimit> _wQrCodeLimitRepository;
        private readonly IRepository<WQrCodeLimitUserMapping> _wQrCodeLimitUserMappingRepository;

        #endregion

        #region Ctor

        public WQrCodeLimitUserService(
            IRepository<WUser> wUserRepository,
            IRepository<WQrCodeLimit> wQrCodeLimitRepository,
            IRepository<WQrCodeLimitUserMapping> wQrCodeLimitUserMappingRepository)
        {
            _wUserRepository = wUserRepository;
            _wQrCodeLimitRepository = wQrCodeLimitRepository;
            _wQrCodeLimitUserMappingRepository = wQrCodeLimitUserMappingRepository;
        }

        #endregion

        #region Methods

        public virtual async Task InsertEntityAsync(WQrCodeLimitUserMapping entity)
        {
            await _wQrCodeLimitUserMappingRepository.InsertAsync(entity);
        }

        public virtual async Task DeleteEntityAsync(WQrCodeLimitUserMapping entity)
        {
            await _wQrCodeLimitUserMappingRepository.DeleteAsync(entity);
        }

        public virtual async Task DeleteEntitiesAsync(IList<WQrCodeLimitUserMapping> entities)
        {
            await _wQrCodeLimitUserMappingRepository.DeleteAsync(entities);
        }

        public virtual async Task UpdateEntityAsync(WQrCodeLimitUserMapping entity)
        {
            await _wQrCodeLimitUserMappingRepository.UpdateAsync(entity);
        }

        public virtual async Task UpdateEntitiesAsync(IList<WQrCodeLimitUserMapping> entities)
        {
            await _wQrCodeLimitUserMappingRepository.UpdateAsync(entities);
        }

        public virtual async Task<WQrCodeLimitUserMapping> GetEntityByIdAsync(int id)
        {
            return await _wQrCodeLimitUserMappingRepository.GetByIdAsync(id, cache => default);
        }

        public virtual async Task<WQrCodeLimitUserMapping> GetActiveEntityByQrCodeLimitIdOrUserIdAsync(int qrCodeLimitId, int userId)
        {
            if (qrCodeLimitId == 0 && userId == 0)
                return null;

            var query = _wQrCodeLimitUserMappingRepository.Table;
            query = query.Where(t => t.Published);
            query = query.Where(t => t.ExpireTime > DateTime.Now);
            if (qrCodeLimitId > 0)
            {
                query = query.Where(t => t.QrCodeLimitId == qrCodeLimitId);
            } 
            if (userId > 0)
            {
                query = query.Where(t => t.UserId == userId);
            }

            return await query.FirstOrDefaultAsync();
        }

        public virtual async Task<WQrCodeLimitUserMapping> GetEntityByQrCodeLimitIdAndUserIdAsync(int qrCodeLimitId, int userId)
        {
            if (qrCodeLimitId == 0 || userId == 0)
                return null;

            var query = from t in _wQrCodeLimitUserMappingRepository.Table
                        where t.QrCodeLimitId == qrCodeLimitId &&
                        t.UserId == userId
                        select t;

            return await query.FirstOrDefaultAsync();
        }

        public virtual async Task<IList<WQrCodeLimitUserMapping>> GetEntitiesByQrcodeLimitIdAsync(int qrCodeLimitId)
        {
            if (qrCodeLimitId == 0)
                return new List<WQrCodeLimitUserMapping>();

            var query = from t in _wQrCodeLimitUserMappingRepository.Table
                        where t.QrCodeLimitId == qrCodeLimitId
                        select t;

            return await query.ToListAsync();
        }

        public virtual async Task<IList<WQrCodeLimitUserMapping>> GetEntitiesByUserIdAsync(int userId)
        {
            if (userId == 0)
                return new List<WQrCodeLimitUserMapping>();

            var query = from t in _wQrCodeLimitUserMappingRepository.Table
                        where t.UserId== userId
                        select t;

            return await query.ToListAsync();
        }

        public virtual async Task<IList<WQrCodeLimitUserMapping>> GetEntitiesByIdsAsync(int[] wEntityIds)
        {
            if (wEntityIds is null)
                return new List<WQrCodeLimitUserMapping>();

            var query = from t in _wQrCodeLimitUserMappingRepository.Table
                        where wEntityIds.Contains(t.Id)
                        select t;

            return await query.ToListAsync();
        }

        public virtual async Task<IPagedList<WQrCodeLimitUserMapping>> GetEntitiesAsync(
            int userId = 0,
            int qrCodeLimitId = 0,
            DateTime? expireTime = null,
            bool? published = null,
            int pageIndex = 0, int pageSize = int.MaxValue)
        {
            var query = _wQrCodeLimitUserMappingRepository.Table;

            if (userId > 0)
                query = query.Where(v => v.UserId == userId);
            if (qrCodeLimitId > 0)
                query = query.Where(v => v.QrCodeLimitId == qrCodeLimitId);
            if (expireTime.HasValue)
            {
                query = query.Where(v => v.ExpireTime >= expireTime);
            }
            if (published.HasValue)
                query = query.Where(v => v.Published == published);

            query = query.OrderBy(v => v.Id);

            return await query.ToPagedListAsync(pageIndex, pageSize);
        }


        #endregion
    }
}