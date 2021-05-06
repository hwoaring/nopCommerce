using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Nop.Core;
using Nop.Core.Domain.Catalog;
using Nop.Core.Domain.Vendors;
using Nop.Core.Domain.Weixin;
using Nop.Core.Html;
using Nop.Data;
using Nop.Services.Events;

namespace Nop.Services.Weixin
{
    /// <summary>
    /// WUserService
    /// </summary>
    public partial class WUserService : IWUserService
    {
        #region Fields

        private readonly IRepository<WUser> _wUserRepository;

        #endregion

        #region Ctor

        public WUserService(
            IRepository<WUser> wUserRepository)
        {
            _wUserRepository = wUserRepository;
        }

        #endregion

        #region Methods

        /// <summary>
        /// 添加新用户
        /// </summary>
        /// <param name="wuser"></param>
        public virtual async Task InsertWUserAsync(WUser wuser)
        {
            await _wUserRepository.InsertAsync(wuser);
        }

        /// <summary>
        /// 删除用户
        /// </summary>
        /// <param name="wUser"></param>
        /// <param name="delete">是否真删除，否则只更改删除标志</param>
        public virtual async Task DeleteWUserAsync(WUser wUser)
        {
            await _wUserRepository.DeleteAsync(wUser);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="wUsers"></param>
        /// <param name="deleted">是否真删除，否则只更改删除标志</param>
        public virtual async Task DeleteWUsersAsync(IList<WUser> wUsers)
        {
            await _wUserRepository.DeleteAsync(wUsers);
        }

        /// <summary>
        /// 更新用户信息
        /// </summary>
        /// <param name="wuser"></param>
        public virtual async Task UpdateWUserAsync(WUser wuser)
        {
            await _wUserRepository.UpdateAsync(wuser);
        }

        /// <summary>
        /// 更新用户信息
        /// </summary>
        /// <param name="wuser"></param>
        public virtual async Task UpdateWUsersAsync(IList<WUser> wUsers)
        {
            await _wUserRepository.UpdateAsync(wUsers);
        }

        /// <summary>
        /// 获取用户信息
        /// </summary>
        /// <param name="wUserId"></param>
        /// <returns></returns>
        public virtual async Task<WUser> GetWUserByIdAsync(int id)
        {
            return await _wUserRepository.GetByIdAsync(id, cache => default);
        }

        /// <summary>
        /// 获取用户信息
        /// </summary>
        /// <param name="openId"></param>
        /// <returns></returns>
        public virtual async Task<WUser> GetWUserByOpenIdAsync(string openId)
        {
            if (string.IsNullOrEmpty(openId))
                return null;

            openId = openId.Trim();

            var query = from t in _wUserRepository.Table
                        where t.OpenId == openId
                        orderby t.Id
                        select t;

            return await query.FirstOrDefaultAsync();
        }

        /// <summary>
        /// 获取用户信息
        /// </summary>
        /// <param name="openIdHash"></param>
        /// <returns></returns>
        public virtual async Task<WUser> GetWUserByOpenIdHashAsync(long openIdHash)
        {
            if (openIdHash == 0)
                return null;

            var query = from user in _wUserRepository.Table
                        orderby user.Id
                        where !user.Deleted &&
                        user.OpenIdHash == openIdHash
                        select user;

            return await query.FirstOrDefaultAsync();
        }

        /// <summary>
        /// 获取用户信息
        /// </summary>
        /// <param name="wUserIds"></param>
        /// <returns></returns>
        public virtual async Task<IList<WUser>> GetWUsersByIdsAsync(int[] wUserIds)
        {
            return await _wUserRepository.GetByIdsAsync(wUserIds, cache => default);
        }

        /// <summary>
        /// 获取全部用户
        /// </summary>
        /// <param name="pageIndex"></param>
        /// <param name="pageSize"></param>
        /// <param name="showDeleted"></param>
        /// <returns></returns>
        public virtual async Task<IPagedList<WUser>> GetAllUsersAsync(
            string nickName = null,
            string remark = null,
            int pageIndex = 0,
            int pageSize = int.MaxValue,
            bool showDeleted = false)
        {
            var query = _wUserRepository.Table;

            if (!string.IsNullOrEmpty(nickName))
                query = query.Where(v => v.NickName.Contains(nickName));
            if (!string.IsNullOrEmpty(remark))
                query = query.Where(v => v.Remark.Contains(remark));

            if (!showDeleted)
                query = query.Where(v => !v.Deleted);

            query = query.OrderBy(v => v.CreatTime).ThenBy(v => v.Id);

            return await query.ToPagedListAsync(pageIndex, pageSize);
        }

        /// <summary>
        /// 获取自己推荐的用户列表信息
        /// </summary>
        /// <param name="refereeId"></param>
        /// <param name="wConfigId"></param>
        /// <param name="pageIndex"></param>
        /// <param name="pageSize"></param>
        /// <param name="showDeleted"></param>
        /// <returns></returns>
        public virtual async Task<IPagedList<WUser>> GetRefereeUsersAsync(int refereeId, int wConfigId = 0, int pageIndex = 0, int pageSize = int.MaxValue, bool showDeleted = false)
        {
            var query = _wUserRepository.Table;
            query = query.Where(user => user.RefereeId == refereeId);
            query = query.OrderBy(v => v.CreatTime).ThenBy(v => v.Id);

            return await query.ToPagedListAsync(pageIndex, pageSize);
        }

        #endregion
    }
}