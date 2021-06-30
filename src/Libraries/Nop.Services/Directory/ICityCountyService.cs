using System.Collections.Generic;
using System.Threading.Tasks;
using Nop.Core.Domain.Common;
using Nop.Core.Domain.Directory;

namespace Nop.Services.Directory
{
    /// <summary>
    ///  City County service interface
    /// </summary>
    public partial interface ICityCountyService
    {
        Task InsertCityCountyAsync(CityCounty cityCounty);

        Task UpdateCityCountyAsync(CityCounty cityCounty);

        Task DeleteCityCountyAsync(CityCounty cityCounty);

        Task<CityCounty> GetCityCountyByIdAsync(int cityCountyId);

        Task<CityCounty> GetCityCountyByAbbreviationAsync(string abbreviation, int? stateProvinceId = null);

        Task<CityCounty> GetCityCountyByAddressAsync(Address address);

        /// <summary>
        /// 获取城市表
        /// </summary>
        /// <param name="stateProvinceId"></param>
        /// <param name="languageId"></param>
        /// <param name="showHidden"></param>
        /// <returns></returns>
        Task<IList<CityCounty>> GetCitiesByStateProvinceIdAsync(int stateProvinceId, int languageId = 0, bool showHidden = false);

        /// <summary>
        /// 获取区县表
        /// </summary>
        /// <param name="stateProvinceId"></param>
        /// <param name="languageId"></param>
        /// <param name="showHidden"></param>
        /// <returns></returns>
        Task<IList<CityCounty>> GetCountiesByCityIdAsync(int cityId, int languageId = 0, bool showHidden = false);

        /// <summary>
        /// 获取城市和区县表
        /// </summary>
        /// <param name="stateProvinceId">省ID</param>
        /// <param name="languageId"></param>
        /// <param name="showHidden"></param>
        /// <returns></returns>
        Task<IList<CityCounty>> GetCityCountiesByStateProvinceIdAsync(int stateProvinceId, int languageId = 0, bool showHidden = false);


        Task<IList<CityCounty>> GetCityCountysAsync(bool showHidden = false); 
    }
}
