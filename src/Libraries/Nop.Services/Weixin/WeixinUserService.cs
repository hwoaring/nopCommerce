using System.Linq.Dynamic.Core.Tokenizer;
using Irony.Parsing;
using Nop.Core;
using Nop.Core.Caching;
using Nop.Core.Domain.Catalog;
using Nop.Core.Domain.Customers;
using Nop.Core.Domain.Vendors;
using Nop.Core.Domain.Weixin;
using Nop.Data;
using Nop.Services.Customers;
using Nop.Services.Html;

namespace Nop.Services.Weixin
{
    /// <summary>
    /// 微信用户 service
    /// </summary>
    public partial class WeixinUserService : IWeixinUserService
    {
        #region Fields

        protected readonly IRepository<Customer> _customerRepository;
        protected readonly IRepository<WeixinUser> _weixinUserRepository;

        #endregion

        #region Ctor

        public WeixinUserService(IRepository<Customer> customerRepository,
            IRepository<WeixinUser> weixinUserRepository)
        {
            _customerRepository = customerRepository;
            _weixinUserRepository = weixinUserRepository;
        }

        #endregion

        #region Methods

        public virtual async Task<WeixinUser> GetWeixinUserByIdAsync(int id)
        {
            return await _weixinUserRepository.GetByIdAsync(id, cache => default);
        }

        public virtual async Task<WeixinUser> GetWeixinUserByOpenIdAsync(string openId)
        {
            if (string.IsNullOrWhiteSpace(openId))
                return null;

            return await (from w in _weixinUserRepository.Table
                               where w.OpenId == openId
                               orderby w.Id
                               select w).FirstOrDefaultAsync();
        }

        public virtual async Task<WeixinUser> GetWeixinUserByCustomerIdAsync(int customerId)
        {
            if (customerId == 0)
                return null;

            return await (from w in _weixinUserRepository.Table
                          where w.CustomerId == customerId
                          orderby w.Id
                          select w).FirstOrDefaultAsync();
        }

        public virtual async Task<IList<WeixinUser>> GetWeixinUsersByCustomerIdsAsync(int[] customerIds)
        {
            if (customerIds == null)
                return null;

            var query = from w in _weixinUserRepository.Table
                        where customerIds.Contains(w.CustomerId)
                        select w;
            return await query.ToListAsync();
        }

        public virtual async Task InsertWeixinUserAsync(WeixinUser weixinUser)
        {
            await _weixinUserRepository.InsertAsync(weixinUser);
        }

        public virtual async Task UpdateWeixinUserAsync(WeixinUser weixinUser)
        {
            await _weixinUserRepository.UpdateAsync(weixinUser);
        }

        public virtual async Task DeleteWeixinUserAsync(WeixinUser weixinUser)
        {
            await _weixinUserRepository.DeleteAsync(weixinUser);
        }

        public virtual async Task<IPagedList<WeixinUser>> GetAllWeixinUsersAsync(
            int storeId = 0, 
            string nickName = "", 
            int pageIndex = 0, int pageSize = int.MaxValue, bool showHidden = false)
        {
            var weixinUsers = await _weixinUserRepository.GetAllPagedAsync(query =>
            {
                if (storeId > 0)
                    query = query.Where(w => w.StoreId.Equals(storeId));

                if (!string.IsNullOrWhiteSpace(nickName))
                    query = query.Where(w => w.NickName.Contains(nickName));

                query = query.OrderBy(w => w.Id);

                return query;
            }, pageIndex, pageSize);

            return weixinUsers;
        }

        #endregion
    }
}