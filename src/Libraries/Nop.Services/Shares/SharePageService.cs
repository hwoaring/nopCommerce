using System.Net;
using System.Text.RegularExpressions;
using DocumentFormat.OpenXml.Office2010.Excel;
using Nop.Core.Domain.Common;
using Nop.Core.Domain.Discounts;
using Nop.Core.Domain.Publics;
using Nop.Core.Domain.Shares;
using Nop.Data;
using Nop.Services.Attributes;
using Nop.Services.Directory;
using Nop.Services.Localization;
using Nop.Services.Shares;

namespace Nop.Services.Shares;

/// <summary>
/// Address service
/// </summary>
public partial class SharePageService : ISharePageService
{
    #region Fields
    protected readonly IRepository<SharePage> _sharePageRepository;

    #endregion

    #region Ctor

    public SharePageService(IRepository<SharePage> sharePageRepository)
    {
        _sharePageRepository = sharePageRepository;
    }

    #endregion

    #region Methods

    public virtual async Task InsertSharePageAsync(SharePage sharePage)
    {
        ArgumentNullException.ThrowIfNull(sharePage);

        await _sharePageRepository.InsertAsync(sharePage);
    }

    public virtual async Task UpdateSharePageAsync(SharePage sharePage)
    {
        ArgumentNullException.ThrowIfNull(sharePage);

        await _sharePageRepository.UpdateAsync(sharePage);
    }

    public virtual async Task DeleteSharePageAsync(SharePage sharePage)
    {
        await _sharePageRepository.DeleteAsync(sharePage);
    }

    public virtual async Task DeleteSharePageAsync(int entityId, PublicEntityType publicEntityType)
    {
        var sharePage = await GetSharePageByEntityIdAsync(entityId, publicEntityType);
        if (sharePage != null)
            await DeleteSharePageAsync(sharePage);
    }

    public virtual async Task<SharePage> GetSharePageByIdAsync(int sharePageId)
    {
        return await _sharePageRepository.GetByIdAsync(sharePageId, cache => default, useShortTermCache: true);
    }

    public virtual async Task<SharePage> GetSharePageByEntityIdAsync(int entityId, PublicEntityType publicEntityType)
    {
        if (entityId == 0)
            return null;

        var query = from a in _sharePageRepository.Table
                    where a.EntityId == entityId && a.PublicEntityTypeId == (int)publicEntityType
                    select a;

        return await query.FirstOrDefaultAsync();
    }

    #endregion
}