using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Nop.Core.Domain.Stores;
using Nop.Data;

namespace Nop.Services.Stores
{
    /// <summary>
    /// Store service
    /// </summary>
    public partial class StoreRegionalContactService : IStoreRegionalContactService
    {
        #region Fields

        private readonly IRepository<StoreRegionalContact> _storeRegionalContactRepository;

        #endregion

        #region Ctor

        public StoreRegionalContactService(IRepository<StoreRegionalContact> storeRegionalContactRepository)
        {
            _storeRegionalContactRepository = storeRegionalContactRepository;
        }

        #endregion

        #region Utilities

        /// <summary>
        /// Parse comma-separated Hosts
        /// </summary>
        /// <param name="store">Store</param>
        /// <returns>Comma-separated hosts</returns>
        protected virtual string[] ParseRegionalKeyValues(StoreRegionalContact storeRegionalContact)
        {
            if (storeRegionalContact == null)
                throw new ArgumentNullException(nameof(storeRegionalContact));

            var parsedValues = new List<string>();
            if (string.IsNullOrEmpty(storeRegionalContact.RegionalKey))
                return parsedValues.ToArray();

            var regionalKeys = storeRegionalContact.RegionalKey.Split(new[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
            foreach (var regionalKey in regionalKeys)
            {
                var tmp = regionalKey.Trim();
                if (!string.IsNullOrEmpty(tmp))
                    parsedValues.Add(tmp);
            }

            return parsedValues.ToArray();
        }

        #endregion

        #region Methods

        /// <summary>
        /// Inserts a StoreRegionalContact
        /// </summary>
        /// <param name="StoreRegionalContact">StoreRegionalContact</param>
        /// <returns>A task that represents the asynchronous operation</returns>
        public virtual async Task InsertStoreRegionalContactAsync(StoreRegionalContact storeRegionalContact)
        {
            await _storeRegionalContactRepository.InsertAsync(storeRegionalContact);
        }

        /// <summary>
        /// Updates the StoreRegionalContact
        /// </summary>
        /// <param name="StoreRegionalContact">StoreRegionalContact</param>
        /// <returns>A task that represents the asynchronous operation</returns>
        public virtual async Task UpdateStoreRegionalContactAsync(StoreRegionalContact storeRegionalContact)
        {
            await _storeRegionalContactRepository.UpdateAsync(storeRegionalContact);
        }

        /// <summary>
        /// Deletes a StoreRegionalContact
        /// </summary>
        /// <param name="StoreRegionalContact">StoreRegionalContact</param>
        /// <returns>A task that represents the asynchronous operation</returns>
        public virtual async Task DeleteStoreRegionalContactAsync(StoreRegionalContact storeRegionalContact)
        {
            if (storeRegionalContact == null)
                throw new ArgumentNullException(nameof(storeRegionalContact));

            await _storeRegionalContactRepository.DeleteAsync(storeRegionalContact);
        }

        public virtual async Task<StoreRegionalContact> GetStoreRegionalContactByIdAsync(int storeRegionalContactId)
        {
            if (storeRegionalContactId == 0)
                return null;

            return await _storeRegionalContactRepository.GetByIdAsync(storeRegionalContactId, cache => default);
        }

        public virtual async Task<StoreRegionalContact> GetStoreRegionalContactByStoreIdAndRegionalKeyAsync(int storeId, string regionalKey, bool showHidden = true)
        {
            if (storeId == 0 || string.IsNullOrEmpty(regionalKey))
                return null;

            var query = from src in _storeRegionalContactRepository.Table
                        where src.StoreId == storeId &&
                        src.RegionalKey.Contains(regionalKey) &&
                        (showHidden || src.Published)
                        orderby src.Id
                        select src;

            return await query.FirstOrDefaultAsync();
        }

        public virtual async Task<IList<StoreRegionalContact>> GetAllStoreRegionalContactsAsync(bool showHidden = true)
        {
            var query = from src in _storeRegionalContactRepository.Table
                        where (showHidden || src.Published)
                        orderby src.Id
                        select src;

            return await query.ToListAsync();
        }

        public virtual async Task<IList<StoreRegionalContact>> GetStoreRegionalContactsByStoreIdAsync(int storeId, bool showHidden = true)
        {
            if (storeId == 0)
                return new List<StoreRegionalContact>();

            var query = from src in _storeRegionalContactRepository.Table
                        where src.StoreId == storeId &&
                              (showHidden || src.Published)
                        orderby src.Id
                        select src;

            return await query.ToListAsync();
        }

        public virtual bool ContainsRegionalKeyValue(StoreRegionalContact storeRegionalContact, string regionalKey)
        {
            if (storeRegionalContact == null)
                throw new ArgumentNullException(nameof(storeRegionalContact));

            if (string.IsNullOrEmpty(regionalKey))
                return false;

            var contains = ParseRegionalKeyValues(storeRegionalContact).Any(x => x.Equals(regionalKey, StringComparison.InvariantCultureIgnoreCase));

            return contains;
        }

        #endregion
    }
}