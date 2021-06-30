using System.Collections.Generic;
using System.Threading.Tasks;
using Nop.Core.Domain.Common;
using Nop.Core.Domain.Directory;

namespace Nop.Services.Directory
{
    /// <summary>
    /// Divisions Code service interface
    /// </summary>
    public partial interface IDivisionsCodeService
    {
        /// <summary>
        /// 获取可用省
        /// </summary>
        /// <param name="showHidden"></param>
        /// <returns></returns>
        Task<IList<DivisionsCode>> GetAvailableProvince(bool showHidden = false);

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

    }
}
