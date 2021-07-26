using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Nop.Core;
using Nop.Core.Domain.Catalog;
using Nop.Core.Domain.Marketing;
using Nop.Core.Domain.Suppliers;
using Nop.Core.Html;
using Nop.Data;
using Nop.Services.Events;

namespace Nop.Services.Marketing
{
    /// <summary>
    /// WConfig Service
    /// </summary>
    public partial class UserAssetConsumeHistoryService : IUserAssetConsumeHistoryService
    {
        #region Fields

        private readonly IRepository<UserAssetConsumeHistory> _userAssetConsumeHistoryRepository;

        #endregion

        #region Ctor

        public UserAssetConsumeHistoryService(
            IRepository<UserAssetConsumeHistory> userAssetConsumeHistoryRepository)
        {
            _userAssetConsumeHistoryRepository = userAssetConsumeHistoryRepository;
        }

        #endregion

        #region Methods

        public virtual async Task InsertEntityAsync(UserAssetConsumeHistory entity)
        {
            await _userAssetConsumeHistoryRepository.InsertAsync(entity);
        }

        public virtual async Task DeleteEntityAsync(UserAssetConsumeHistory entity)
        {
            await _userAssetConsumeHistoryRepository.DeleteAsync(entity);
        }

        public virtual async Task DeleteEntitiesAsync(IList<UserAssetConsumeHistory> entities)
        {
            await _userAssetConsumeHistoryRepository.DeleteAsync(entities);
        }

        public virtual async Task UpdateEntityAsync(UserAssetConsumeHistory entity)
        {
            await _userAssetConsumeHistoryRepository.UpdateAsync(entity);
        }

        public virtual async Task UpdateEntitiesAsync(IList<UserAssetConsumeHistory> entities)
        {
            await _userAssetConsumeHistoryRepository.UpdateAsync(entities);
        }

        public virtual async Task<UserAssetConsumeHistory> GetEntityByIdAsync(int id)
        {
            return await _userAssetConsumeHistoryRepository.GetByIdAsync(id, cache => default);
        }

        public virtual async Task<IList<UserAssetConsumeHistory>> GetEntitiesByCustomerIdAsync(
            int customerId,
            bool completed,
            bool isInvalid)
        {
            if (customerId == 0)
                return new List<UserAssetConsumeHistory>();

            var query = from t in _userAssetConsumeHistoryRepository.Table
                        where t.CustomerId == customerId &&
                        t.Completed == completed &&
                        t.IsInvalid == isInvalid
                        select t;

            return await query.ToListAsync();
        }

        public virtual async Task<IList<UserAssetConsumeHistory>> GetEntitiesByUserAssetIncomeHistoryIdAsync(
            int userAssetIncomeHistoryId, 
            bool completed, 
            bool isInvalid)
        {
            if (userAssetIncomeHistoryId == 0)
                return new List<UserAssetConsumeHistory>();

            var query = from t in _userAssetConsumeHistoryRepository.Table
                        where t.UserAssetIncomeHistoryId == userAssetIncomeHistoryId &&
                        t.Completed == completed &&
                        t.IsInvalid == isInvalid
                        select t;

            return await query.ToListAsync();
        }

        public virtual async Task<IPagedList<UserAssetConsumeHistory>> GetEntitiesAsync(
            int customerId = 0,
            int? userAssetIncomeHistoryId = 0,
            AssetConsumType? assetConsumType = null,
            bool? completed = null,
            bool? isInvalid = null,
            bool? deleted = null,
            int pageIndex = 0, int pageSize = int.MaxValue)
        {
            var query = _userAssetConsumeHistoryRepository.Table;
            query = query.Where(q => q.CustomerId == customerId);

            if (userAssetIncomeHistoryId.HasValue && userAssetIncomeHistoryId > 0)
                query = query.Where(q => q.UserAssetIncomeHistoryId == userAssetIncomeHistoryId);
            if (assetConsumType.HasValue)
                query = query.Where(q => q.AssetConsumType == assetConsumType);
            if (completed.HasValue)
                query = query.Where(q => q.Completed == completed);
            if (isInvalid.HasValue)
                query = query.Where(q => q.IsInvalid == isInvalid);
            if (deleted.HasValue)
                query = query.Where(q => q.Deleted == deleted);

            return await query.ToPagedListAsync(pageIndex, pageSize);
        }

        #endregion
    }
}