using DocumentFormat.OpenXml.Bibliography;
using DocumentFormat.OpenXml.Vml.Spreadsheet;
using DocumentFormat.OpenXml.Wordprocessing;
using Nop.Core.Caching;
using Nop.Core.Domain.Common;
using Nop.Core.Domain.Directory;
using Nop.Data;
using Nop.Services.Localization;

namespace Nop.Services.Directory;

/// <summary>
/// Region code service
/// </summary>
public partial class RegionCodeService : IRegionCodeService
{
    #region Fields

    protected readonly IStaticCacheManager _staticCacheManager;
    protected readonly ILocalizationService _localizationService;
    protected readonly IRepository<RegionCode> _regionCodeRepository;

    #endregion

    #region Ctor

    public RegionCodeService(IStaticCacheManager staticCacheManager,
        ILocalizationService localizationService,
        IRepository<RegionCode> regionCodeRepository)
    {
        _staticCacheManager = staticCacheManager;
        _localizationService = localizationService;
        _regionCodeRepository = regionCodeRepository;
    }

    #endregion

    #region Methods

    public virtual async Task DeleteRegionCodeAsync(RegionCode regionCode)
    {
        await _regionCodeRepository.DeleteAsync(regionCode);
    }

    public virtual async Task<RegionCode> GetRegionCodeByIdAsync(int regionCodeId)
    {
        return await _regionCodeRepository.GetByIdAsync(regionCodeId, cache => default);
    }

    public virtual async Task<RegionCode> GetRegionCodeByCodeAsync(string code, int? countryId = null)
    {
        if (string.IsNullOrEmpty(code))
            return null;

        var query = _regionCodeRepository.Table.Where(regionCode => regionCode.Code == code);

        //filter by country
        if (countryId.HasValue)
            query = query.Where(regionCode => regionCode.CountryId == countryId);

        return await query.FirstOrDefaultAsync();
    }

    public virtual async Task<RegionCode> GetRegionCodeByNameAsync(string name, bool likeQuery = false, int? countryId = null)
    {
        if (string.IsNullOrEmpty(name))
            return null;

        var query = _regionCodeRepository.Table.Where(regionCode => likeQuery ? regionCode.Name.Contains(name) : regionCode.Name == name);

        //filter by country
        if (countryId.HasValue)
            query = query.Where(regionCode => regionCode.CountryId == countryId);

        return await query.FirstOrDefaultAsync();
    }

    public virtual async Task<RegionCode> GetRegionCodeByAddressAsync(Address address)
    {
        return await GetRegionCodeByIdAsync(address?.RegionCodeId ?? 0);
    }

    public virtual async Task<IList<RegionCode>> GetRegionCodesByCountryIdAsync(int countryId, bool showHidden = false)
    {
        var key = _staticCacheManager.PrepareKeyForDefaultCache(NopDirectoryDefaults.RegionCodesByCountryCacheKey, countryId, showHidden);

        return await _staticCacheManager.GetAsync(key, async () =>
        {
            var query = from rc in _regionCodeRepository.Table
                        orderby rc.DisplayOrder, rc.Name
                        where rc.CountryId == countryId &&
                              (showHidden || rc.Published)
                        select rc;

            return await query.ToListAsync();
        });
    }

    public virtual async Task<IList<RegionCode>> GetNextRegionCodesAsync(int countryId, string code, bool showHidden = false)
    {
        var allCountryRegionCode = await GetRegionCodesByCountryIdAsync(countryId, showHidden);
        var query = allCountryRegionCode.ToAsyncEnumerable();

        if (string.IsNullOrWhiteSpace(code))
        {
            query = query.Where(regionCode => regionCode.AreaLevel == 1);
        }
        else
        {
            if (code.EndsWith("0000"))
            {
                var codePrefix = code[..2];
                query = query.Where(regionCode => regionCode.Code.StartsWith(codePrefix));
                query = query.Where(regionCode => regionCode.AreaLevel == 2);
            }
            else if (code.EndsWith("00"))
            {
                var codePrefix = code[..4];
                query = query.Where(regionCode => regionCode.Code.StartsWith(codePrefix));
                query = query.Where(regionCode => regionCode.AreaLevel == 3);
            }
            else
                return null;
        }

        query = query.OrderBy(c => c.DisplayOrder).ThenBy(c => c.Name);

        return await query.ToListAsync();
    }

    public virtual async Task<IList<RegionCode>> GetRegionCodesAsync(bool showHidden = false)
    {
        var query = from rc in _regionCodeRepository.Table
            orderby rc.CountryId, rc.DisplayOrder, rc.Name
            where showHidden || rc.Published
            select rc;

        var regionCodes = await _staticCacheManager.GetAsync(_staticCacheManager.PrepareKeyForDefaultCache(NopDirectoryDefaults.RegionCodesAllCacheKey, showHidden), async () => await query.ToListAsync());

        return regionCodes;
    }

    public virtual async Task InsertRegionCodeAsync(RegionCode regionCode)
    {
        await _regionCodeRepository.InsertAsync(regionCode);
    }

    public virtual async Task UpdateRegionCodeAsync(RegionCode regionCode)
    {
        await _regionCodeRepository.UpdateAsync(regionCode);
    }

    #endregion
}