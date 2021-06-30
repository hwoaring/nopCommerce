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
    /// City County Service
    /// </summary>
    public partial class CityCountyService : ICityCountyService
    {
        #region Fields

        private readonly IStaticCacheManager _staticCacheManager;
        private readonly ILocalizationService _localizationService;
        private readonly IRepository<CityCounty> _cityCountyRepository;

        #endregion

        #region Ctor

        public CityCountyService(IStaticCacheManager staticCacheManager,
            ILocalizationService localizationService,
            IRepository<CityCounty> cityCountyRepository)
        {
            _staticCacheManager = staticCacheManager;
            _localizationService = localizationService;
            _cityCountyRepository = cityCountyRepository;
        }

        #endregion

        #region Methods

        public virtual async Task InsertCityCountyAsync(CityCounty cityCounty)
        {
            await _cityCountyRepository.InsertAsync(cityCounty);
        }

        public virtual async Task UpdateCityCountyAsync(CityCounty cityCounty)
        {
            await _cityCountyRepository.UpdateAsync(cityCounty);
        }

        public virtual async Task DeleteCityCountyAsync(CityCounty cityCounty)
        {
            await _cityCountyRepository.DeleteAsync(cityCounty);
        }

        public virtual async Task<CityCounty> GetCityCountyByIdAsync(int cityCountyId)
        {
            return await _cityCountyRepository.GetByIdAsync(cityCountyId, cache => default);
        }

        public virtual async Task<CityCounty> GetCityCountyByAbbreviationAsync(string abbreviation, int? stateProvinceId = null)
        {
            if (string.IsNullOrEmpty(abbreviation))
                return null;

            var key = _staticCacheManager.PrepareKeyForDefaultCache(NopDirectoryDefaults.CityCountiesByAbbreviationCacheKey
                , abbreviation, stateProvinceId ?? 0);

            var query = _cityCountyRepository.Table.Where(city => city.Abbreviation == abbreviation);

            //filter by country
            if (stateProvinceId.HasValue)
                query = query.Where(city => city.StateProvinceId == stateProvinceId);

            return await _staticCacheManager.GetAsync(key, async () => await query.FirstOrDefaultAsync());
        }

        public virtual async Task<CityCounty> GetCityCountyByAddressAsync(Address address)
        {
            return await GetCityCountyByIdAsync(address?.CityId ?? 0);
        }

        /// <summary>
        /// 获取城市表
        /// </summary>
        /// <param name="stateProvinceId"></param>
        /// <param name="languageId"></param>
        /// <param name="showHidden"></param>
        /// <returns></returns>
        public virtual async Task<IList<CityCounty>> GetCitiesByStateProvinceIdAsync(int stateProvinceId, int languageId = 0, bool showHidden = false)
        {
            if (stateProvinceId == 0)
                return new List<CityCounty>();

            var cityAndCounties = await GetCityCountiesByStateProvinceIdAsync(stateProvinceId, languageId, showHidden);
            var cities = await cityAndCounties.ToAsyncEnumerable()
                .Where(cc => cc.AreaLevel == 2)
                .OrderBy(cc => cc.Name)
                .ToListAsync();

            return cities;
        }

        /// <summary>
        /// 获取区县表
        /// </summary>
        /// <param name="stateProvinceId"></param>
        /// <param name="languageId"></param>
        /// <param name="showHidden"></param>
        /// <returns></returns>
        public virtual async Task<IList<CityCounty>> GetCountiesByCityIdAsync(int cityId, int languageId = 0, bool showHidden = false)
        {
            if (cityId == 0)
                return new List<CityCounty>();

            var cityCounty = await GetCityCountyByIdAsync(cityId);

            if (cityCounty != null)
                return new List<CityCounty>();

            var cityAndCounties = await GetCityCountiesByStateProvinceIdAsync(cityCounty.StateProvinceId, languageId, showHidden);
            var counties = await cityAndCounties.ToAsyncEnumerable()
                .Where(cc => cc.ParentId == cityId)
                .OrderBy(cc => cc.Name)
                .ToListAsync();

            return counties;

        }


        /// <summary>
        /// 获取城市和区县表
        /// </summary>
        /// <param name="stateProvinceId">省ID</param>
        /// <param name="languageId"></param>
        /// <param name="showHidden"></param>
        /// <returns></returns>
        public virtual async Task<IList<CityCounty>> GetCityCountiesByStateProvinceIdAsync(int stateProvinceId, int languageId = 0, bool showHidden = false)
        {
            if (stateProvinceId == 0)
                return new List<CityCounty>();

            var key = _staticCacheManager.PrepareKeyForDefaultCache(NopDirectoryDefaults.CityCountiesByStateProvinceCacheKey, stateProvinceId, languageId, showHidden);

            return await _staticCacheManager.GetAsync(key, async () =>
            {
                var query = from cc in _cityCountyRepository.Table
                            orderby cc.DisplayOrder, cc.Id
                            where cc.StateProvinceId == stateProvinceId &&
                            (showHidden || cc.Published)
                            select cc;
                var cityCounties = await query.ToListAsync();

                if (languageId > 0)
                    //we should sort states by localized names when they have the same display order
                    cityCounties = await cityCounties.ToAsyncEnumerable()
                        .OrderBy(c => c.DisplayOrder)
                        .ThenByAwait(async c => await _localizationService.GetLocalizedAsync(c, x => x.Name, languageId))
                        .ToListAsync();

                return cityCounties;
            });
        }

        public virtual async Task<IList<CityCounty>> GetCityCountysAsync(bool showHidden = false)
        {
            var query = from cc in _cityCountyRepository.Table
                        orderby cc.CountryId, cc.DisplayOrder, cc.Name
                        where showHidden || cc.Published
                        select cc;


            var cityCounties = await _staticCacheManager.GetAsync(_staticCacheManager.PrepareKeyForDefaultCache(NopDirectoryDefaults.CityCountiesAllCacheKey, showHidden), async () => await query.ToListAsync());

            return cityCounties;
        }

        #endregion
    }
}