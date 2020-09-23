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
    public partial class UserAssetService : IUserAssetService
    {
        #region Fields

        private readonly IRepository<UserAsset> _userAssetRepository;

        #endregion

        #region Ctor

        public UserAssetService(
            IRepository<UserAsset> userAssetRepository)
        {
            _userAssetRepository = userAssetRepository;
        }

        #endregion

        #region Methods

        public virtual void InsertEntity(UserAsset entity)
        {
            _userAssetRepository.Insert(entity);
        }

        public virtual void DeleteEntity(UserAsset entity, bool delete = false)
        {
            if (entity == null)
                throw new ArgumentNullException(nameof(entity));

            if (delete)
            {
                _userAssetRepository.Delete(entity);
            }
            else
            {
                entity.Deleted = true;
                _userAssetRepository.Update(entity);
            }
        }

        public virtual void DeleteEntities(IList<UserAsset> entities, bool deleted = false)
        {
            if (entities == null)
                throw new ArgumentNullException(nameof(entities));

            if (deleted)
            {
                _userAssetRepository.Delete(entities);
            }
            else
            {
                foreach (var entity in entities)
                {
                    entity.Deleted = true;
                }
                _userAssetRepository.Update(entities);
            }
        }

        public virtual void UpdateEntity(UserAsset entity)
        {
            _userAssetRepository.Update(entity);
        }

        public virtual void UpdateEntities(IList<UserAsset> entities)
        {
            _userAssetRepository.Update(entities);
        }

        public virtual UserAsset GetEntityById(int id)
        {
            return _userAssetRepository.GetById(id, cache => default);
        }

        public virtual UserAsset GetEntityByUserId(int wuserId)
        {
            if (wuserId == 0)
                return null;

            var query = from t in _userAssetRepository.Table
                        where t.OwnerUserId==wuserId
                        select t;

            return query.FirstOrDefault();
        }
        #endregion
    }
}