using Nop.Core.Domain.Common;
using Nop.Core.Domain.Publics;
using Nop.Core.Domain.Shares;

namespace Nop.Services.Shares;

/// <summary>
/// 分享页 service interface
/// </summary>
public partial interface ISharePageService
{
    Task InsertSharePageAsync(SharePage sharePage);

    Task UpdateSharePageAsync(SharePage sharePage);

    Task DeleteSharePageAsync(SharePage sharePage);

    Task DeleteSharePageAsync(int entityId, PublicEntityType publicEntityType);

    Task<SharePage> GetSharePageByIdAsync(int sharePageId);

    Task<SharePage> GetSharePageByEntityIdAsync(int entityId, PublicEntityType publicEntityType);


}