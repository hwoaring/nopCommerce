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

        public virtual async Task InsertEntityAsync(UserAsset entity)
        {
            await _userAssetRepository.InsertAsync(entity);
        }

        public virtual async Task DeleteEntityAsync(UserAsset entity)
        {
            await _userAssetRepository.DeleteAsync(entity);
        }

        public virtual async Task DeleteEntitiesAsync(IList<UserAsset> entities)
        {
            await _userAssetRepository.DeleteAsync(entities);
        }

        public virtual async Task UpdateEntityAsync(UserAsset entity)
        {
            await _userAssetRepository.UpdateAsync(entity);
        }

        public virtual async Task UpdateEntitiesAsync(IList<UserAsset> entities)
        {
            await _userAssetRepository.UpdateAsync(entities);
        }

        public virtual async Task<UserAsset> GetEntityByIdAsync(int id)
        {
            return await _userAssetRepository.GetByIdAsync(id, cache => default);
        }

        public virtual async Task<UserAsset> GetEntityByCustomerIdAsync(int customerId)
        {
            if (customerId == 0)
                return null;

            var query = from t in _userAssetRepository.Table
                        where t.CustomerId== customerId
                        select t;

            return await query.FirstOrDefaultAsync();
        }
        #endregion
    }
}