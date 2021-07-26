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
    public partial class WxUserService : IWxUserService
    {
        #region Fields

        private readonly IRepository<WxUser> _wUserRepository;

        #endregion

        #region Ctor

        public WxUserService(
            IRepository<WxUser> wUserRepository)
        {
            _wUserRepository = wUserRepository;
        }

        #endregion

        #region Methods

        /// <summary>
        /// 添加新用户
        /// </summary>
        /// <param name="wuser"></param>
        public virtual async Task InsertWxUserAsync(WxUser wuser)
        {
            await _wUserRepository.InsertAsync(wuser);
        }

        /// <summary>
        /// 删除用户
        /// </summary>
        /// <param name="wUser"></param>
        /// <param name="delete">是否真删除，否则只更改删除标志</param>
        public virtual async Task DeleteWxUserAsync(WxUser wUser)
        {
            await _wUserRepository.DeleteAsync(wUser);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="wUsers"></param>
        /// <param name="deleted">是否真删除，否则只更改删除标志</param>
        public virtual async Task DeleteWxUsersAsync(IList<WxUser> wUsers)
        {
            await _wUserRepository.DeleteAsync(wUsers);
        }

        /// <summary>
        /// 更新用户信息
        /// </summary>
        /// <param name="wuser"></param>
        public virtual async Task UpdateWxUserAsync(WxUser wuser)
        {
            await _wUserRepository.UpdateAsync(wuser);
        }

        /// <summary>
        /// 更新用户信息
        /// </summary>
        /// <param name="wuser"></param>
        public virtual async Task UpdateWxUsersAsync(IList<WxUser> wUsers)
        {
            await _wUserRepository.UpdateAsync(wUsers);
        }

        /// <summary>
        /// 获取用户信息
        /// </summary>
        /// <param name="wUserId"></param>
        /// <returns></returns>
        public virtual async Task<WxUser> GetWxUserByIdAsync(int id)
        {
            return await _wUserRepository.GetByIdAsync(id, cache => default);
        }

        /// <summary>
        /// 获取用户信息
        /// </summary>
        /// <param name="CustomerId"></param>
        /// <returns></returns>
        public virtual async Task<WxUser> GetWxUserByCustomerIdAsync(int customerId)
        {
            if (customerId == 0)
                return null;

            var query = from t in _wUserRepository.Table
                        where t.CustomerId == customerId
                        select t;

            return await query.FirstOrDefaultAsync();
        }

        /// <summary>
        /// 获取用户信息
        /// </summary>
        /// <param name="openId"></param>
        /// <returns></returns>
        public virtual async Task<WxUser> GetWxUserByOpenIdAsync(string openId)
        {
            if (string.IsNullOrEmpty(openId))
                return null;

            openId = openId.Trim();

            var query = from t in _wUserRepository.Table
                        where t.OpenId == openId
                        select t;

            return await query.FirstOrDefaultAsync();
        }

        /// <summary>
        /// 获取用户信息
        /// </summary>
        /// <param name="wUserIds"></param>
        /// <returns></returns>
        public virtual async Task<IList<WxUser>> GetWxUsersByIdsAsync(int[] wUserIds)
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
        public virtual async Task<IPagedList<WxUser>> GetAllUsersAsync(
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

            query = query.OrderBy(v => v.CreatTime).ThenBy(v => v.Id);

            return await query.ToPagedListAsync(pageIndex, pageSize);
        }

        #endregion
    }
}