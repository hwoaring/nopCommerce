using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.Rendering;
using Nop.Core.Domain.Catalog;
using Nop.Web.Framework.Models;
using Nop.Web.Framework.Mvc.ModelBinding;

namespace Nop.Web.Areas.Admin.Models.Shares;

public partial record SharePageModel : BaseNopEntityModel
{
    [NopResourceDisplayName("Admin.Share.Fields.EntityId")]
    public int EntityId { get; set; }

    [NopResourceDisplayName("Admin.Share.Fields.PublicEntityTypeId")]
    public int PublicEntityTypeId { get; set; }

    [NopResourceDisplayName("Admin.Share.Fields.BaseViewCount")]
    public int BaseViewCount { get; set; }

    [NopResourceDisplayName("Admin.Share.Fields.BaseRecommendeCount")]
    public int BaseRecommendeCount { get; set; }

    [NopResourceDisplayName("Admin.Share.Fields.BaseFavoriteCount")]
    public int BaseFavoriteCount { get; set; }

    [NopResourceDisplayName("Admin.Share.Fields.BaseThumbCount")]
    public int BaseThumbCount { get; set; }

    [NopResourceDisplayName("Admin.Share.Fields.BaseShareCount")]
    public int BaseShareCount { get; set; }

    [NopResourceDisplayName("Admin.Share.Fields.Title")]
    public string Title { get; set; }

    [NopResourceDisplayName("Admin.Share.Fields.Slogan")]
    public string Slogan { get; set; }

    [NopResourceDisplayName("Admin.Share.Fields.Description")]
    public string Description { get; set; }

    [NopResourceDisplayName("Admin.Share.Fields.Url")]
    public string Url { get; set; }

    [UIHint("Picture")]
    [NopResourceDisplayName("Admin.Share.Fields.SmallPictureId")]
    public int SmallPictureId { get; set; }

    [UIHint("Picture")]
    [NopResourceDisplayName("Admin.Share.Fields.BigPictureId")]
    public int BigPictureId { get; set; }

    [NopResourceDisplayName("Admin.Share.Fields.EnableSharePicture")]
    public bool EnableSharePicture { get; set; }

    [NopResourceDisplayName("Admin.Share.Fields.EnablePromotion")]
    public bool EnablePromotion { get; set; }

    [NopResourceDisplayName("Admin.Share.Fields.CashPromotion")]
    public bool CashPromotion { get; set; }

    [NopResourceDisplayName("Admin.Share.Fields.CommissionRatio")]
    public decimal CommissionRatio { get; set; }

    [NopResourceDisplayName("Admin.Share.Fields.ShareCycleDays")]
    public int ShareCycleDays { get; set; }

    [NopResourceDisplayName("Admin.Share.Fields.LimitToStoreId")]
    public int LimitToStoreId { get; set; }

    [NopResourceDisplayName("Admin.Share.Fields.LimitToVendorStoreId")]
    public int LimitToVendorStoreId { get; set; }

    [NopResourceDisplayName("Admin.Share.Fields.LimitToBrandId")]
    public int LimitToBrandId { get; set; }

    [NopResourceDisplayName("Admin.Share.Fields.LimitToProductId")]
    public int LimitToProductId { get; set; }

    [NopResourceDisplayName("Admin.Share.Fields.DisplaySharerCode")]
    public bool DisplaySharerCode { get; set; }

    [NopResourceDisplayName("Admin.Share.Fields.DisplaySharerUser")]
    public bool DisplaySharerUser { get; set; }

    [NopResourceDisplayName("Admin.Share.Fields.EnableSharePage")]
    public bool EnableSharePage { get; set; }
}