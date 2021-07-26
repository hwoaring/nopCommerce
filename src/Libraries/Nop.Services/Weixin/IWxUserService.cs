using System.Collections.Generic;
using System.Threading.Tasks;
using Nop.Core;
using Nop.Core.Domain.Weixin;

namespace Nop.Services.Weixin
{
    /// <summary>
    /// WUser service interface
    /// </summary>
    public partial interface IWxUserService
    {
        /// <summary>
        /// 添加新用户
        /// </summary>
        /// <param name="wuser"></param>
        Task InsertWxUserAsync(WxUser wuser);

        /// <summary>
        /// 删除用户
        /// </summary>
        /// <param name="wUser"></param>
        Task DeleteWxUserAsync(WxUser wUser);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="wUsers"></param>
        Task DeleteWxUsersAsync(IList<WxUser> wUsers);

        /// <summary>
        /// 更新用户信息
        /// </summary>
        /// <param name="wuser"></param>
        Task UpdateWxUserAsync(WxUser wuser);

        /// <summary>
        /// 更新用户信息
        /// </summary>
        /// <param name="wuser"></param>
        Task UpdateWxUsersAsync(IList<WxUser> wUsers);

        /// <summary>
        /// 获取用户信息
        /// </summary>
        /// <param name="wUserId"></param>
        /// <returns></returns>
        Task<WxUser> GetWxUserByIdAsync(int id);

        /// <summary>
        /// 获取用户信息
        /// </summary>
        /// <param name="CustomerId"></param>
        /// <returns></returns>
        Task<WxUser> GetWxUserByCustomerIdAsync(int customerId);

        /// <summary>
        /// 获取用户信息
        /// </summary>
        /// <param name="openId"></param>
        /// <returns></returns>
        Task<WxUser> GetWxUserByOpenIdAsync(string openId);

        /// <summary>
        /// 获取用户信息
        /// </summary>
        /// <param name="wUserIds"></param>
        /// <returns></returns>
        Task<IList<WxUser>> GetWxUsersByIdsAsync(int[] wUserIds);

        /// <summary>
        /// 获取全部用户
        /// </summary>
        /// <param name="pageIndex"></param>
        /// <param name="pageSize"></param>
        /// <param name="showDeleted"></param>
        /// <returns></returns>
        Task<IPagedList<WxUser>> GetAllUsersAsync(string nickName = null, string remark = null, int pageIndex = 0, int pageSize = int.MaxValue, bool showDeleted = false);

    }
}