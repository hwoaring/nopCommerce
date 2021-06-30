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
    public partial class DivisionsCodeService : IDivisionsCodeService
    {
        #region Fields

        private readonly IStaticCacheManager _staticCacheManager;
        private readonly ILocalizationService _localizationService;
        private readonly IRepository<DivisionsCode> _divisionsCodeRepository;

        #endregion

        #region Ctor

        public DivisionsCodeService(IStaticCacheManager staticCacheManager,
            ILocalizationService localizationService,
            IRepository<DivisionsCode> divisionsCodeRepository)
        {
            _staticCacheManager = staticCacheManager;
            _localizationService = localizationService;
            _divisionsCodeRepository = divisionsCodeRepository;
        }

        #endregion

        #region Methods

        public virtual async Task<IList<DivisionsCode>> GetAvailableProvince(bool showHidden = false)
        {
            return (await GetDivisionsCodesAsync(showHidden))
                .Where(dc => dc.AreaLevel == 1)
                .OrderBy(dc => dc.AreaName)
                .ToList();
        }

        /// <summary>
        /// 获取区划码（子级查询或模糊查询）
        /// </summary>
        /// <param name="areaCode"></param>
        /// <param name="showHidden"></param>
        /// <returns></returns>
        public virtual async Task<IList<DivisionsCode>> GetSubDivisionsCodesAsync(string areaCode, bool showHidden = false)
        {
            if (string.IsNullOrEmpty(areaCode))
                return new List<DivisionsCode>();

            var all = await GetDivisionsCodesAsync(showHidden);
            var divisionsCode = all.Where(dc => dc.AreaCode == areaCode).FirstOrDefault();

            if (divisionsCode == null)
                return new List<DivisionsCode>();

            var query = all.Where(dc => dc.AreaCode.StartsWith(divisionsCode.AreaCode.Substring(0, 2)));
            query = query.Where(dc => dc.AreaLevel == divisionsCode.AreaLevel + 1);
            query = query.OrderBy(dc => dc.DisplayOrder).ThenBy(dc => dc.AreaName);

            return query.ToList();
        }

        /// <summary>
        /// 获取区划码
        /// </summary>
        /// <param name="showHidden"></param>
        /// <returns></returns>
        public virtual async Task<IList<DivisionsCode>> GetDivisionsCodesAsync(bool showHidden = false)
        {
            var query = from dc in _divisionsCodeRepository.Table
                        orderby dc.Id
                        where showHidden || dc.Published
                        select dc;

            var key = _staticCacheManager.PrepareKeyForDefaultCache(NopDirectoryDefaults.DivisionsCodesAllCacheKey, showHidden);

            return await _staticCacheManager.GetAsync(key, async () => await query.ToListAsync());
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