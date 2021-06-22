using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Nop.Core.Caching;
using Nop.Core.Domain.Common;
using Nop.Core.Domain.Directory;
using Nop.Data;
using Nop.Services.Localization;

namespace Nop.Services.Directory
{
    /// <summary>
    /// State province service
    /// </summary>
    public partial class StateProvinceService : IStateProvinceService
    {
        #region Fields

        private readonly IStaticCacheManager _staticCacheManager;
        private readonly ILocalizationService _localizationService;
        private readonly IRepository<StateProvince> _stateProvinceRepository;
        private readonly IRepository<DivisionsCode> _divisionsCodeRepository;

        #endregion

        #region Ctor

        public StateProvinceService(IStaticCacheManager staticCacheManager,
            ILocalizationService localizationService,
            IRepository<StateProvince> stateProvinceRepository,
            IRepository<DivisionsCode> divisionsCodeRepository)
        {
            _staticCacheManager = staticCacheManager;
            _localizationService = localizationService;
            _stateProvinceRepository = stateProvinceRepository;
            _divisionsCodeRepository = divisionsCodeRepository;
        }

        #endregion

        #region Methods
        /// <summary>
        /// Deletes a state/province
        /// </summary>
        /// <param name="stateProvince">The state/province</param>
        /// <returns>A task that represents the asynchronous operation</returns>
        public virtual async Task DeleteStateProvinceAsync(StateProvince stateProvince)
        {
            await _stateProvinceRepository.DeleteAsync(stateProvince);
        }

        /// <summary>
        /// Gets a state/province
        /// </summary>
        /// <param name="stateProvinceId">The state/province identifier</param>
        /// <returns>
        /// A task that represents the asynchronous operation
        /// The task result contains the state/province
        /// </returns>
        public virtual async Task<StateProvince> GetStateProvinceByIdAsync(int stateProvinceId)
        {
            return await _stateProvinceRepository.GetByIdAsync(stateProvinceId, cache => default);
        }

        /// <summary>
        /// Gets a state/province by abbreviation
        /// </summary>
        /// <param name="abbreviation">The state/province abbreviation</param>
        /// <param name="countryId">Country identifier; pass null to load the state regardless of a country</param>
        /// <returns>
        /// A task that represents the asynchronous operation
        /// The task result contains the state/province
        /// </returns>
        public virtual async Task<StateProvince> GetStateProvinceByAbbreviationAsync(string abbreviation, int? countryId = null)
        {
            if (string.IsNullOrEmpty(abbreviation))
                return null;

            var key = _staticCacheManager.PrepareKeyForDefaultCache(NopDirectoryDefaults.StateProvincesByAbbreviationCacheKey
                , abbreviation, countryId ?? 0);

            var query = _stateProvinceRepository.Table.Where(state => state.Abbreviation == abbreviation);

            //filter by country
            if (countryId.HasValue)
                query = query.Where(state => state.CountryId == countryId);

            return await _staticCacheManager.GetAsync(key, async () => await query.FirstOrDefaultAsync());
        }

        /// <summary>
        /// Gets a state/province by address 
        /// </summary>
        /// <param name="address">Address</param>
        /// <returns>
        /// A task that represents the asynchronous operation
        /// The task result contains the country
        /// </returns>
        public virtual async Task<StateProvince> GetStateProvinceByAddressAsync(Address address)
        {
            return await GetStateProvinceByIdAsync(address?.StateProvinceId ?? 0);
        }

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
        public virtual async Task<IList<StateProvince>> GetStateProvincesByCountryIdAsync(int countryId, int languageId = 0, bool showHidden = false)
        {
            var key = _staticCacheManager.PrepareKeyForDefaultCache(NopDirectoryDefaults.StateProvincesByCountryCacheKey, countryId, languageId, showHidden);

            return await _staticCacheManager.GetAsync(key, async () =>
            {
                var query = from sp in _stateProvinceRepository.Table
                            orderby sp.DisplayOrder, sp.Name
                            where sp.CountryId == countryId &&
                            (showHidden || sp.Published)
                            select sp;
                var stateProvinces = await query.ToListAsync();

                if (languageId > 0)
                    //we should sort states by localized names when they have the same display order
                    stateProvinces = await stateProvinces.ToAsyncEnumerable()
                        .OrderBy(c => c.DisplayOrder)
                        .ThenByAwait(async c => await _localizationService.GetLocalizedAsync(c, x => x.Name, languageId))
                        .ToListAsync();

                return stateProvinces;
            });
        }

        /// <summary>
        /// Gets all states/provinces
        /// </summary>
        /// <param name="showHidden">A value indicating whether to show hidden records</param>
        /// <returns>
        /// A task that represents the asynchronous operation
        /// The task result contains the states
        /// </returns>
        public virtual async Task<IList<StateProvince>> GetStateProvincesAsync(bool showHidden = false)
        {
            var query = from sp in _stateProvinceRepository.Table
                        orderby sp.CountryId, sp.DisplayOrder, sp.Name
                        where showHidden || sp.Published
                        select sp;


            var stateProvinces = await _staticCacheManager.GetAsync(_staticCacheManager.PrepareKeyForDefaultCache(NopDirectoryDefaults.StateProvincesAllCacheKey, showHidden), async () => await query.ToListAsync());

            return stateProvinces;
        }

        /// <summary>
        /// Inserts a state/province
        /// </summary>
        /// <param name="stateProvince">State/province</param>
        /// <returns>A task that represents the asynchronous operation</returns>
        public virtual async Task InsertStateProvinceAsync(StateProvince stateProvince)
        {
            await _stateProvinceRepository.InsertAsync(stateProvince);
        }

        /// <summary>
        /// Updates a state/province
        /// </summary>
        /// <param name="stateProvince">State/province</param>
        /// <returns>A task that represents the asynchronous operation</returns>
        public virtual async Task UpdateStateProvinceAsync(StateProvince stateProvince)
        {
            await _stateProvinceRepository.UpdateAsync(stateProvince);
        }

        /// <summary>
        /// 获取区划码（子级查询或模糊查询）
        /// </summary>
        /// <param name="areaCode"></param>
        /// <param name="showHidden"></param>
        /// <returns></returns>
        public virtual async Task<IList<DivisionsCode>> GetSubDivisionsCodesAsync(string areaCode, bool showHidden = false)
        {

            var divisionsCodes = await GetDivisionsCodesAsync(showHidden);

            if (string.IsNullOrEmpty(areaCode))
                return divisionsCodes.Where(dc => dc.AreaLevel == 1).ToList();

            var currentDivisionsCode = divisionsCodes.FirstOrDefault(dc => dc.AreaCode == areaCode);

            if (currentDivisionsCode == null)
                return new List<DivisionsCode>();

            var filterResults = divisionsCodes.Where(dc => dc.AreaLevel == currentDivisionsCode.AreaLevel + 1 && dc.AreaCode.StartsWith(currentDivisionsCode.AreaCode.Substring(0, 2))).ToList();

            return filterResults;
        }

        /// <summary>
        /// 获取区划码
        /// </summary>
        /// <param name="showHidden"></param>
        /// <returns></returns>
        public virtual async Task<IList<DivisionsCode>> GetDivisionsCodesAsync(bool showHidden = false)
        {
            var query = from dc in _divisionsCodeRepository.Table
                        orderby dc.AreaCode, dc.DisplayOrder
                        where showHidden || dc.Published
                        select dc;

            var divisionsCodes = await _staticCacheManager.GetAsync(_staticCacheManager.PrepareKeyForDefaultCache(NopDirectoryDefaults.DivisionsCodesAllCacheKey, showHidden), async () => await query.ToListAsync());
            return divisionsCodes;
        }

        /// <summary>
        /// 获取区划码
        /// </summary>
        /// <param name="areaCode"></param>
        /// <param name="showHidden"></param>
        /// <returns></returns>
        public virtual async Task<DivisionsCode> GetDivisionsCodeByAreaCodeAsync(string areaCode)
        {
            if (string.IsNullOrEmpty(areaCode))
                return null;

            var query = from dc in _divisionsCodeRepository.Table
                        where dc.AreaCode== areaCode
                        select dc;
            return await query.FirstOrDefaultAsync();
        }

        /// <summary>
        /// 获取热门区划码
        /// </summary>
        /// <param name="areaLevel">默认选择2级</param>
        /// <param name="showHidden"></param>
        /// <returns></returns>
        public virtual async Task<IList<DivisionsCode>> GetDivisionsCodesByHotAsync(int areaLevel = 2, bool showHidden = false)
        {
            var query = from dc in _divisionsCodeRepository.Table
                        where dc.AreaLevel == areaLevel &&
                        dc.HotArea == true &&
                        (showHidden || dc.Published)
                        orderby dc.DisplayOrder
                        select dc;
            return await query.ToListAsync();
        }

        /// <summary>
        /// 插入区划码
        /// </summary>
        /// <param name="divisionsCode"></param>
        /// <returns></returns>
        public virtual async Task InsertDivisionsCodeAsync(DivisionsCode divisionsCode)
        {
            await _divisionsCodeRepository.InsertAsync(divisionsCode);
        }

        /// <summary>
        /// 更新区划码
        /// </summary>
        /// <param name="divisionsCode"></param>
        /// <returns></returns>
        public virtual async Task UpdateDivisionsCodeAsync(DivisionsCode divisionsCode)
        {
            await _divisionsCodeRepository.UpdateAsync(divisionsCode);
        }

        #endregion
    }
}