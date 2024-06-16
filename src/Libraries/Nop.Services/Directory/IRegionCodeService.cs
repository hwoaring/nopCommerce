using Nop.Core.Domain.Common;
using Nop.Core.Domain.Directory;

namespace Nop.Services.Directory;

/// <summary>
/// RegionCode Service interface
/// </summary>
public partial interface IRegionCodeService
{
    Task DeleteRegionCodeAsync(RegionCode regionCode);

    Task<RegionCode> GetRegionCodeByIdAsync(int regionCodeId);

    Task<RegionCode> GetRegionCodeByCodeAsync(string code, int? countryId = null);

    Task<RegionCode> GetRegionCodeByNameAsync(string name, bool likeQuery = false, int? countryId = null);

    Task<RegionCode> GetRegionCodeByAddressAsync(Address address);

    Task<IList<RegionCode>> GetRegionCodesByCountryIdAsync(int countryId, bool showHidden = false);

    Task<IList<RegionCode>> GetNextRegionCodesAsync(int countryId, string code, bool showHidden = false);

    Task<IList<RegionCode>> GetRegionCodesAsync(bool showHidden = false);

    Task InsertRegionCodeAsync(RegionCode regionCode);

    Task UpdateRegionCodeAsync(RegionCode regionCode);
}