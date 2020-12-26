using System.Collections.Generic;
using System.Threading.Tasks;
using Nop.Core;
using Nop.Core.Domain.Weixin;

namespace Nop.Services.Weixin
{
    /// <summary>
    /// WUser service interface
    /// </summary>
    public partial interface IWUserService
    {
        /// <summary>
        /// 添加新用户
        /// </summary>
        /// <param name="wuser"></param>
        Task InsertWUserAsync(WUser wuser);

        /// <summary>
        /// 删除用户
        /// </summary>
        /// <param name="wUser"></param>
        Task DeleteWUserAsync(WUser wUser);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="wUsers"></param>
        Task DeleteWUsersAsync(IList<WUser> wUsers);

        /// <summary>
        /// 更新用户信息
        /// </summary>
        /// <param name="wuser"></param>
        Task UpdateWUserAsync(WUser wuser);

        /// <summary>
        /// 更新用户信息
        /// </summary>
        /// <param name="wuser"></param>
        Task UpdateWUsersAsync(IList<WUser> wUsers);

        /// <summary>
        /// 获取用户信息
        /// </summary>
        /// <param name="wUserId"></param>
        /// <returns></returns>
        Task<WUser> GetWUserByIdAsync(int id);

        /// <summary>
        /// 获取用户信息
        /// </summary>
        /// <param name="openId"></param>
        /// <returns></returns>
        Task<WUser> GetWUserByOpenIdAsync(string openId);

        /// <summary>
        /// 获取用户信息
        /// </summary>
        /// <param name="openIdHash"></param>
        /// <returns></returns>
        Task<WUser> GetWUserByOpenIdHashAsync(long openIdHash);

        /// <summary>
        /// 获取用户信息
        /// </summary>
        /// <param name="wUserIds"></param>
        /// <returns></returns>
        Task<IList<WUser>> GetWUsersByIdsAsync(int[] wUserIds);

        /// <summary>
        /// 获取用户基本信息
        /// </summary>
        /// <param name="openId"></param>
        /// <returns></returns>
        Task<WUserBaseInfo> GetWUserBaseInfoAsync(string openId, bool containAllOpenid = false);

        /// <summary>
        /// 获取用户基本信息
        /// </summary>
        /// <param name="openIds"></param>
        /// <returns></returns>
        Task<IList<WUserBaseInfo>> GetWUserBaseInfoByOpenIdsAsync(string[] openIds, bool containAllOpenid = false);

        /// <summary>
        /// 获取全部用户
        /// </summary>
        /// <param name="pageIndex"></param>
        /// <param name="pageSize"></param>
        /// <param name="showDeleted"></param>
        /// <returns></returns>
        Task<IPagedList<WUser>> GetAllUsersAsync(string nickName = null, string remark = null, int pageIndex = 0, int pageSize = int.MaxValue, bool showDeleted = false);

        /// <summary>
        /// 获取自己推荐的用户列表信息
        /// </summary>
        /// <param name="refereeId"></param>
        /// <param name="wConfigId"></param>
        /// <param name="pageIndex"></param>
        /// <param name="pageSize"></param>
        /// <param name="showDeleted"></param>
        /// <returns></returns>
        Task<IPagedList<WUser>> GetRefereeUsersAsync(int refereeId, int wConfigId = 0, int pageIndex = 0, int pageSize = int.MaxValue, bool showDeleted = false);

    }
}