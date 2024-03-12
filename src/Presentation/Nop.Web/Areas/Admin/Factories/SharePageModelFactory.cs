using DocumentFormat.OpenXml.EMMA;
using Nop.Core.Domain.Affiliates;
using Nop.Core.Domain.Common;
using Nop.Core.Domain.Customers;
using Nop.Core.Domain.Publics;
using Nop.Core.Domain.Shares;
using Nop.Services.Shares;
using Nop.Web.Areas.Admin.Infrastructure.Mapper.Extensions;
using Nop.Web.Areas.Admin.Models.Affiliates;
using Nop.Web.Areas.Admin.Models.Catalog;
using Nop.Web.Areas.Admin.Models.Customers;
using Nop.Web.Areas.Admin.Models.Shares;

namespace Nop.Web.Areas.Admin.Factories;

/// <summary>
/// Represents 分享页 the share page model factory implementation
/// </summary>
public partial class SharePageModelFactory : ISharePageModelFactory
{
    #region Fields

    protected readonly ISharePageService _sharePageService;

    #endregion

    #region Ctor

    public SharePageModelFactory(ISharePageService sharePageService)
    {
        _sharePageService = sharePageService;
    }

    #endregion

    #region Utilities
    /// <summary>
    /// 保存分享页设置
    /// </summary>
    /// <param name="entityId"></param>
    /// <param name="model"></param>
    /// <param name="publicEntityType">页面默认类型</param>
    /// <returns></returns>
    public virtual async Task SaveSharePageAsync(int entityId, SharePageModel model,  PublicEntityType publicEntityType)
    {
        var sharePage = await _sharePageService.GetSharePageByEntityIdAsync(entityId, publicEntityType);
        if (sharePage == null)
        {
            sharePage = model.ToEntity<SharePage>();
            sharePage.EntityId = entityId;
            sharePage.PublicEntityType = publicEntityType;
            await _sharePageService.InsertSharePageAsync(sharePage);
        }
        else
        {
            sharePage = model.ToEntity(sharePage);
            sharePage.EntityId = entityId;
            sharePage.PublicEntityType = publicEntityType;
            await _sharePageService.UpdateSharePageAsync(sharePage);
        }
    }
    #endregion

    #region Methods

    /// <summary>
    /// 准备分享页面
    /// </summary>
    /// <param name="model">参数不能为空</param>
    /// <param name="sharePage"></param>
    /// <returns></returns>
    public virtual async Task<SharePageModel> PrepareSharePageModelAsync(SharePageModel model, SharePage sharePage, bool excludeProperties = false)
    {
        return null;
    }

    public virtual async Task<SharePageModel> PrepareSharePageModelAsync(int entityId, PublicEntityType publicEntityType, bool excludeProperties = false)
    {
        return null;
    }

    #endregion
}