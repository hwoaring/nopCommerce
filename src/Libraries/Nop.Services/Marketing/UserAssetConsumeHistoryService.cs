using System;
using System.Collections.Generic;
using System.Linq;
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

        public virtual void InsertEntity(UserAssetConsumeHistory entity)
        {
            _userAssetConsumeHistoryRepository.Insert(entity);
        }

        public virtual void DeleteEntity(UserAssetConsumeHistory entity, bool delete = false)
        {
            if (entity == null)
                throw new ArgumentNullException(nameof(entity));

            if (delete)
            {
                _userAssetConsumeHistoryRepository.Delete(entity);
            }
            else
            {
                entity.Deleted = true;
                _userAssetConsumeHistoryRepository.Update(entity);
            }
        }

        public virtual void DeleteEntities(IList<UserAssetConsumeHistory> entities, bool deleted = false)
        {
            if (entities == null)
                throw new ArgumentNullException(nameof(entities));

            if (deleted)
            {
                _userAssetConsumeHistoryRepository.Delete(entities);
            }
            else
            {
                foreach (var entity in entities)
                {
                    entity.Deleted = true;
                }
                _userAssetConsumeHistoryRepository.Update(entities);
            }
        }

        public virtual void UpdateEntity(UserAssetConsumeHistory entity)
        {
            _userAssetConsumeHistoryRepository.Update(entity);
        }

        public virtual void UpdateEntities(IList<UserAssetConsumeHistory> entities)
        {
            _userAssetConsumeHistoryRepository.Update(entities);
        }

        public virtual UserAssetConsumeHistory GetEntityById(int id)
        {
            return _userAssetConsumeHistoryRepository.GetById(id, cache => default);
        }

        public virtual List<UserAssetConsumeHistory> GetEntitiesByUserId(
            int userId,
            bool completed,
            bool isInvalid)
        {
            if (userId == 0)
                return new List<UserAssetConsumeHistory>();

            var query = from t in _userAssetConsumeHistoryRepository.Table
                        where t.OwnerUserId == userId &&
                        t.Completed == completed &&
                        t.IsInvalid == isInvalid
                        select t;

            return query.ToList();
        }

        public virtual List<UserAssetConsumeHistory> GetEntitiesByUserAssetIncomeHistoryId(
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

            return query.ToList();
        }

        public virtual IPagedList<UserAssetConsumeHistory> GetEntities(
            int ownerUserId = 0,
            int? userAssetIncomeHistoryId = 0,
            AssetConsumType? assetConsumType = null,
            bool? completed = null,
            bool? isInvalid = null,
            bool? deleted = null,
            int pageIndex = 0, int pageSize = int.MaxValue)
        {
            var query = _userAssetConsumeHistoryRepository.Table;
            query = query.Where(q => q.OwnerUserId == ownerUserId);

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

            return new PagedList<UserAssetConsumeHistory>(query, pageIndex, pageSize);
        }

        #endregion
    }
}