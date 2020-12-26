using System.Collections.Generic;
using System.Threading.Tasks;
using Nop.Core;
using Nop.Core.Domain.Weixin;

namespace Nop.Services.Weixin
{
    /// <summary>
    /// WMessage Service interface
    /// </summary>
    public partial interface IWMessageService
    {
        Task InsertWMessageAsync(WMessage wMessage);

        Task DeleteWMessageAsync(WMessage wMessage);

        Task DeleteWMessagesAsync(IList<WMessage> wMessages);

        Task UpdateWMessageAsync(WMessage wMessage);

        Task UpdateWMessagesAsync(IList<WMessage> wMessages);

        Task<WMessage> GetWMessageByIdAsync(int id);

        Task<IList<WMessage>> GetWMessagesByIdsAsync(int[] wMessageIds);

        Task<IPagedList<WMessage>> GetWMessagesAsync(string title = "", bool? published = null, bool? deleted = null, int pageIndex = 0, int pageSize = int.MaxValue);

    }
}