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
    public partial class QrCodeLimitUserService : IQrCodeLimitUserService
    {
        #region Fields

        private readonly IRepository<WxUser> _wUserRepository;
        private readonly IRepository<QrCodeLimit> _wQrCodeLimitRepository;
        private readonly IRepository<QrCodeLimitUserMapping> _wQrCodeLimitUserMappingRepository;

        #endregion

        #region Ctor

        public QrCodeLimitUserService(
            IRepository<WxUser> wUserRepository,
            IRepository<QrCodeLimit> wQrCodeLimitRepository,
            IRepository<QrCodeLimitUserMapping> wQrCodeLimitUserMappingRepository)
        {
            _wUserRepository = wUserRepository;
            _wQrCodeLimitRepository = wQrCodeLimitRepository;
            _wQrCodeLimitUserMappingRepository = wQrCodeLimitUserMappingRepository;
        }

        #endregion

        #region Methods

        public virtual async Task InsertEntityAsync(QrCodeLimitUserMapping entity)
        {
            await _wQrCodeLimitUserMappingRepository.InsertAsync(entity);
        }

        public virtual async Task DeleteEntityAsync(QrCodeLimitUserMapping entity)
        {
            await _wQrCodeLimitUserMappingRepository.DeleteAsync(entity);
        }

        public virtual async Task DeleteEntitiesAsync(IList<QrCodeLimitUserMapping> entities)
        {
            await _wQrCodeLimitUserMappingRepository.DeleteAsync(entities);
        }

        public virtual async Task UpdateEntityAsync(QrCodeLimitUserMapping entity)
        {
            await _wQrCodeLimitUserMappingRepository.UpdateAsync(entity);
        }

        public virtual async Task UpdateEntitiesAsync(IList<QrCodeLimitUserMapping> entities)
        {
            await _wQrCodeLimitUserMappingRepository.UpdateAsync(entities);
        }

        public virtual async Task<QrCodeLimitUserMapping> GetEntityByIdAsync(int id)
        {
            return await _wQrCodeLimitUserMappingRepository.GetByIdAsync(id, cache => default);
        }

        public virtual async Task<QrCodeLimitUserMapping> GetActiveEntityByQrCodeLimitIdOrCustomerIdAsync(int qrCodeLimitId, int customerId)
        {
            if (qrCodeLimitId == 0 && customerId == 0)
                return null;

            var query = _wQrCodeLimitUserMappingRepository.Table;
            query = query.Where(t => t.Published);
            query = query.Where(t => t.ExpireTime > DateTime.Now);
            if (qrCodeLimitId > 0)
            {
                query = query.Where(t => t.QrCodeLimitId == qrCodeLimitId);
            } 
            if (customerId > 0)
            {
                query = query.Where(t => t.CustomerId == customerId);
            }

            return await query.FirstOrDefaultAsync();
        }

        public virtual async Task<QrCodeLimitUserMapping> GetEntityByQrCodeLimitIdAndCustomerIdAsync(int qrCodeLimitId, int customerId)
        {
            if (qrCodeLimitId == 0 || customerId == 0)
                return null;

            var query = from t in _wQrCodeLimitUserMappingRepository.Table
                        where t.QrCodeLimitId == qrCodeLimitId &&
                        t.CustomerId == customerId
                        select t;

            return await query.FirstOrDefaultAsync();
        }

        public virtual async Task<IList<QrCodeLimitUserMapping>> GetEntitiesByQrcodeLimitIdAsync(int qrCodeLimitId)
        {
            if (qrCodeLimitId == 0)
                return new List<QrCodeLimitUserMapping>();

            var query = from t in _wQrCodeLimitUserMappingRepository.Table
                        where t.QrCodeLimitId == qrCodeLimitId
                        select t;

            return await query.ToListAsync();
        }

        public virtual async Task<IList<QrCodeLimitUserMapping>> GetEntitiesByCustomerIdAsync(int customerId)
        {
            if (customerId == 0)
                return new List<QrCodeLimitUserMapping>();

            var query = from t in _wQrCodeLimitUserMappingRepository.Table
                        where t.CustomerId == customerId
                        select t;

            return await query.ToListAsync();
        }

        public virtual async Task<IList<QrCodeLimitUserMapping>> GetEntitiesByIdsAsync(int[] wEntityIds)
        {
            if (wEntityIds is null)
                return new List<QrCodeLimitUserMapping>();

            var query = from t in _wQrCodeLimitUserMappingRepository.Table
                        where wEntityIds.Contains(t.Id)
                        select t;

            return await query.ToListAsync();
        }

        public virtual async Task<IPagedList<QrCodeLimitUserMapping>> GetEntitiesAsync(
            int customerId = 0,
            int qrCodeLimitId = 0,
            DateTime? expireTime = null,
            bool? published = null,
            int pageIndex = 0, int pageSize = int.MaxValue)
        {
            var query = _wQrCodeLimitUserMappingRepository.Table;

            if (customerId > 0)
                query = query.Where(v => v.CustomerId == customerId);
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