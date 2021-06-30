using System.Collections.Generic;
using System.Threading.Tasks;
using Nop.Core.Domain.Stores;

namespace Nop.Services.Stores
{
    /// <summary>
    /// Store service interface
    /// </summary>
    public partial interface IStoreRegionalContactService
    {
        /// <summary>
        /// Inserts a StoreRegionalContact
        /// </summary>
        /// <param name="StoreRegionalContact">StoreRegionalContact</param>
        /// <returns>A task that represents the asynchronous operation</returns>
        Task InsertStoreRegionalContactAsync(StoreRegionalContact storeRegionalContact);

        /// <summary>
        /// Updates the StoreRegionalContact
        /// </summary>
        /// <param name="StoreRegionalContact">StoreRegionalContact</param>
        /// <returns>A task that represents the asynchronous operation</returns>
        Task UpdateStoreRegionalContactAsync(StoreRegionalContact storeRegionalContact);

        /// <summary>
        /// Deletes a StoreRegionalContact
        /// </summary>
        /// <param name="StoreRegionalContact">StoreRegionalContact</param>
        /// <returns>A task that represents the asynchronous operation</returns>
        Task DeleteStoreRegionalContactAsync(StoreRegionalContact storeRegionalContact);

        Task<StoreRegionalContact> GetStoreRegionalContactByIdAsync(int storeRegionalContactId);

        Task<StoreRegionalContact> GetStoreRegionalContactByStoreIdAndRegionalKeyAsync(int storeId, string regionalKey, bool showHidden = true);

        Task<IList<StoreRegionalContact>> GetAllStoreRegionalContactsAsync(bool showHidden = true);

        Task<IList<StoreRegionalContact>> GetStoreRegionalContactsByStoreIdAsync(int storeId, bool showHidden = true);

        bool ContainsRegionalKeyValue(StoreRegionalContact storeRegionalContact, string regionalKey);
    }
}