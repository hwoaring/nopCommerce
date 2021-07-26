using System.Collections.Generic;
using System.Threading.Tasks;
using Nop.Core;
using Nop.Core.Domain.Weixin;

namespace Nop.Services.Weixin
{
    /// <summary>
    /// WMessage Service interface
    /// </summary>
    public partial interface IWxMessageService
    {
        Task InsertWxMessageAsync(WxMessage wMessage);

        Task DeleteWxMessageAsync(WxMessage wMessage);

        Task DeleteWxMessagesAsync(IList<WxMessage> wMessages);

        Task UpdateWxMessageAsync(WxMessage wMessage);

        Task UpdateWxMessagesAsync(IList<WxMessage> wMessages);

        Task<WxMessage> GetWxMessageByIdAsync(int id);

        Task<IList<WxMessage>> GetWxMessagesByIdsAsync(int[] wMessageIds);

        Task<IPagedList<WxMessage>> GetWxMessagesAsync(string title = "", bool? published = null, bool? deleted = null, int pageIndex = 0, int pageSize = int.MaxValue);

    }
}