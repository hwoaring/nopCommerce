using Nop.Core.Domain.Publics;
using Nop.Core.Domain.Shares;
using Nop.Web.Areas.Admin.Models.Shares;

namespace Nop.Web.Areas.Admin.Factories;

/// <summary>
/// Represents 分享页 the Share Page  model factory
/// </summary>
public partial interface ISharePageModelFactory
{
    Task SaveSharePageAsync(int entityId, SharePageModel model, PublicEntityType publicEntityType);

    /// <summary>
    /// 准备分享页面信息
    /// </summary>
    /// <param name="model"></param>
    /// <param name="sharePage"></param>
    /// <returns></returns>
    Task<SharePageModel> PrepareSharePageModelAsync(SharePageModel model, SharePage sharePage, bool excludeProperties = false);

    /// <summary>
    /// 准备分享页面信息
    /// </summary>
    /// <param name="entityId"></param>
    /// <param name="publicEntityType"></param>
    /// <param name="excludeProperties"></param>
    /// <returns></returns>
    Task<SharePageModel> PrepareSharePageModelAsync(int entityId, PublicEntityType publicEntityType, bool excludeProperties = false);
}