using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.Rendering;
using Nop.Core.Domain.Shares;
using Nop.Web.Areas.Admin.Models.Shares;
using Nop.Web.Framework.Models;
using Nop.Web.Framework.Mvc.ModelBinding;

namespace Nop.Web.Areas.Admin.Models.News;

/// <summary>
/// Represents a news item model
/// </summary>
public partial record NewsItemModel : BaseNopEntityModel, IStoreMappingSupportedModel
{
    #region Ctor

    public NewsItemModel()
    {
        AvailableLanguages = new List<SelectListItem>();

        SelectedStoreIds = new List<int>();
        AvailableStores = new List<SelectListItem>();

        //新增属性
        SharePage = new SharePageModel();
    }

    #endregion

    #region Properties

    [NopResourceDisplayName("Admin.ContentManagement.News.NewsItems.Fields.Language")]
    public int LanguageId { get; set; }

    public IList<SelectListItem> AvailableLanguages { get; set; }

    [NopResourceDisplayName("Admin.ContentManagement.News.NewsItems.Fields.Language")]
    public string LanguageName { get; set; }

    //store mapping
    [NopResourceDisplayName("Admin.ContentManagement.News.NewsItems.Fields.LimitedToStores")]
    public IList<int> SelectedStoreIds { get; set; }

    public IList<SelectListItem> AvailableStores { get; set; }

    [NopResourceDisplayName("Admin.ContentManagement.News.NewsItems.Fields.Title")]
    public string Title { get; set; }

    [NopResourceDisplayName("Admin.ContentManagement.News.NewsItems.Fields.Short")]
    public string Short { get; set; }

    [NopResourceDisplayName("Admin.ContentManagement.News.NewsItems.Fields.Full")]
    public string Full { get; set; }

    [NopResourceDisplayName("Admin.ContentManagement.News.NewsItems.Fields.AllowComments")]
    public bool AllowComments { get; set; }

    [NopResourceDisplayName("Admin.ContentManagement.News.NewsItems.Fields.StartDate")]
    [UIHint("DateTimeNullable")]
    public DateTime? StartDateUtc { get; set; }

    [NopResourceDisplayName("Admin.ContentManagement.News.NewsItems.Fields.EndDate")]
    [UIHint("DateTimeNullable")]
    public DateTime? EndDateUtc { get; set; }

    [NopResourceDisplayName("Admin.ContentManagement.News.NewsItems.Fields.MetaKeywords")]
    public string MetaKeywords { get; set; }

    [NopResourceDisplayName("Admin.ContentManagement.News.NewsItems.Fields.MetaDescription")]
    public string MetaDescription { get; set; }

    [NopResourceDisplayName("Admin.ContentManagement.News.NewsItems.Fields.MetaTitle")]
    public string MetaTitle { get; set; }

    [NopResourceDisplayName("Admin.ContentManagement.News.NewsItems.Fields.SeName")]
    public string SeName { get; set; }

    [NopResourceDisplayName("Admin.ContentManagement.News.NewsItems.Fields.Published")]
    public bool Published { get; set; }

    public int ApprovedComments { get; set; }

    public int NotApprovedComments { get; set; }

    [NopResourceDisplayName("Admin.ContentManagement.News.NewsItems.Fields.CreatedOn")]
    public DateTime CreatedOn { get; set; }


    //新增属性
    public SharePageModel SharePage { get; set; }


    [NopResourceDisplayName("Admin.ContentManagement.News.NewsItems.Fields.NewsTemplateId")]
    public int NewsTemplateId { get; set; }

    [NopResourceDisplayName("Admin.ContentManagement.News.NewsItems.Fields.PageStyleTypeId")]
    public int PageStyleTypeId { get; set; }

    [NopResourceDisplayName("Admin.ContentManagement.News.NewsItems.Fields.CustomerId")]
    public int CustomerId { get; set; }

    [NopResourceDisplayName("Admin.ContentManagement.News.NewsItems.Fields.AuthorName")]
    public string AuthorName { get; set; }

    [NopResourceDisplayName("Admin.ContentManagement.News.NewsItems.Fields.PublisherArea")]
    public string PublisherArea { get; set; }

    [NopResourceDisplayName("Admin.ContentManagement.News.NewsItems.Fields.PublisherIp")]
    public string PublisherIp { get; set; }

    [NopResourceDisplayName("Admin.ContentManagement.News.NewsItems.Fields.SubTitle")]
    public string SubTitle { get; set; }

    [NopResourceDisplayName("Admin.ContentManagement.News.NewsItems.Fields.CoverImageId")]
    public int CoverImageId { get; set; }

    [NopResourceDisplayName("Admin.ContentManagement.News.NewsItems.Fields.SourceName")]
    public string SourceName { get; set; }

    [NopResourceDisplayName("Admin.ContentManagement.News.NewsItems.Fields.SourceUrl")]
    public string SourceUrl { get; set; }

    [NopResourceDisplayName("Admin.ContentManagement.News.NewsItems.Fields.JumpToSourceUrl")]
    public bool JumpToSourceUrl { get; set; }

    [NopResourceDisplayName("Admin.ContentManagement.News.NewsItems.Fields.IsApproved")]
    public bool IsApproved { get; set; }

    [NopResourceDisplayName("Admin.ContentManagement.News.NewsItems.Fields.EnableViewsCount")]
    public bool EnableViewsCount { get; set; }

    [NopResourceDisplayName("Admin.ContentManagement.News.NewsItems.Fields.ViewsCount")]
    public int ViewsCount { get; set; }

    [NopResourceDisplayName("Admin.ContentManagement.News.NewsItems.Fields.IsAdvert")]
    public bool IsAdvert { get; set; }

    [NopResourceDisplayName("Admin.ContentManagement.News.NewsItems.Fields.AsTopNews")]
    public bool AsTopNews { get; set; }

    [NopResourceDisplayName("Admin.ContentManagement.News.NewsItems.Fields.AsRedNews")]
    public bool AsRedNews { get; set; }

    [NopResourceDisplayName("Admin.ContentManagement.News.NewsItems.Fields.AsHotNews")]
    public bool AsHotNews { get; set; }

    [NopResourceDisplayName("Admin.ContentManagement.News.NewsItems.Fields.AsSlideNews")]
    public bool AsSlideNews { get; set; }

    [UIHint("DateTimeNullable")]
    [NopResourceDisplayName("Admin.ContentManagement.News.NewsItems.Fields.UpdatedOnUtc")]
    public DateTime? UpdatedOnUtc { get; set; }

    #endregion
}