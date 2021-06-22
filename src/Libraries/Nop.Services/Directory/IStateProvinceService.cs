using System.Collections.Generic;
using System.Threading.Tasks;
using Nop.Core.Domain.Common;
using Nop.Core.Domain.Directory;

namespace Nop.Services.Directory
{
    /// <summary>
    /// State province service interface
    /// </summary>
    public partial interface IStateProvinceService
    {
        /// <summary>
        /// Deletes a state/province
        /// </summary>
        /// <param name="stateProvince">The state/province</param>
        /// <returns>A task that represents the asynchronous operation</returns>
        Task DeleteStateProvinceAsync(StateProvince stateProvince);

        /// <summary>
        /// Gets a state/province
        /// </summary>
        /// <param name="stateProvinceId">The state/province identifier</param>
        /// <returns>
        /// A task that represents the asynchronous operation
        /// The task result contains the state/province
        /// </returns>
        Task<StateProvince> GetStateProvinceByIdAsync(int stateProvinceId);

        /// <summary>
        /// Gets a state/province by abbreviation
        /// </summary>
        /// <param name="abbreviation">The state/province abbreviation</param>
        /// <param name="countryId">Country identifier; pass null to load the state regardless of a country</param>
        /// <returns>
        /// A task that represents the asynchronous operation
        /// The task result contains the state/province
        /// </returns>
        Task<StateProvince> GetStateProvinceByAbbreviationAsync(string abbreviation, int? countryId = null);

        /// <summary>
        /// Gets a state/province by address 
        /// </summary>
        /// <param name="address">Address</param>
        /// <returns>
        /// A task that represents the asynchronous operation
        /// The task result contains the country
        /// </returns>
        Task<StateProvince> GetStateProvinceByAddressAsync(Address address);

        /// <summary>
        /// Gets a state/province collection by country identifier
        /// </summary>
        /// <param name="countryId">Country identifier</param>
        /// <param name="languageId">Language identifier. It's used to sort states by localized names (if specified); pass 0 to skip it</param>
        /// <param name="showHidden">A value indicating whether to show hidden records</param>
        /// <returns>
        /// A task that represents the asynchronous operation
        /// The task result contains the states
        /// </returns>
        Task<IList<StateProvince>> GetStateProvincesByCountryIdAsync(int countryId, int languageId = 0, bool showHidden = false);

        /// <summary>
        /// 获取区划码（子级查询或模糊查询）
        /// </summary>
        /// <param name="areaCode"></param>
        /// <param name="showHidden"></param>
        /// <returns></returns>
        Task<IList<DivisionsCode>> GetSubDivisionsCodesAsync(string areaCode, bool showHidden = false);

        /// <summary>
        /// 获取区划码
        /// </summary>
        /// <param name="showHidden"></param>
        /// <returns></returns>
        Task<IList<DivisionsCode>> GetDivisionsCodesAsync(bool showHidden = false);

        /// <summary>
        /// 获取区划码
        /// </summary>
        /// <param name="areaCode"></param>
        /// <returns></returns>
        Task<DivisionsCode> GetDivisionsCodeByAreaCodeAsync(string areaCode);

        /// <summary>
        /// 获取热门区划码
        /// </summary>
        /// <param name="areaLevel">默认选择2级</param>
        /// <param name="showHidden"></param>
        /// <returns></returns>
        Task<IList<DivisionsCode>> GetDivisionsCodesByHotAsync(int areaLevel = 2, bool showHidden = false);

        /// <summary>
        /// 插入区划码
        /// </summary>
        /// <param name="divisionsCode"></param>
        /// <returns></returns>
        Task InsertDivisionsCodeAsync(DivisionsCode divisionsCode);

        /// <summary>
        /// 更新区划码
        /// </summary>
        /// <param name="divisionsCode"></param>
        /// <returns></returns>
        Task UpdateDivisionsCodeAsync(DivisionsCode divisionsCode);

        /// <summary>
        /// Gets all states/provinces
        /// </summary>
        /// <param name="showHidden">A value indicating whether to show hidden records</param>
        /// <returns>
        /// A task that represents the asynchronous operation
        /// The task result contains the states
        /// </returns>
        Task<IList<StateProvince>> GetStateProvincesAsync(bool showHidden = false);

        /// <summary>
        /// Inserts a state/province
        /// </summary>
        /// <param name="stateProvince">State/province</param>
        /// <returns>A task that represents the asynchronous operation</returns>
        Task InsertStateProvinceAsync(StateProvince stateProvince);

        /// <summary>
        /// Updates a state/province
        /// </summary>
        /// <param name="stateProvince">State/province</param>
        /// <returns>A task that represents the asynchronous operation</returns>
        Task UpdateStateProvinceAsync(StateProvince stateProvince);
    }
}
