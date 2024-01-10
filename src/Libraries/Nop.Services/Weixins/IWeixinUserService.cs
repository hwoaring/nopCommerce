using Nop.Core;
using Nop.Core.Domain.Vendors;
using Nop.Core.Domain.Weixins;

namespace Nop.Services.Weixins
{
    /// <summary>
    /// 微信用户服务接口
    /// </summary>
    public partial interface IWeixinUserService
    {
        Task<WeixinUser> GetWeixinUserByIdAsync(int id);

        Task<WeixinUser> GetWeixinUserByOpenIdAsync(string openId);

        Task<WeixinUser> GetWeixinUserByCustomerIdAsync(int customerId);

        Task<IList<WeixinUser>> GetWeixinUsersByCustomerIdsAsync(int[] customerIds);

        Task InsertWeixinUserAsync(WeixinUser weixinUser);

        Task UpdateWeixinUserAsync(WeixinUser weixinUser);

        Task DeleteWeixinUserAsync(WeixinUser weixinUser);

        Task<IPagedList<WeixinUser>> GetAllWeixinUsersAsync(string nickName = "", int pageIndex = 0, int pageSize = int.MaxValue, bool showHidden = false);

    }
}