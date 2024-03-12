using FluentValidation;
using Nop.Core.Domain.Catalog;
using Nop.Core.Domain.Shares;
using Nop.Services.Localization;
using Nop.Services.Seo;
using Nop.Web.Areas.Admin.Models.Shares;
using Nop.Web.Framework.Validators;

namespace Nop.Web.Areas.Admin.Validators.Catalog;

public partial class SharePageValidator : BaseNopValidator<SharePageModel>
{
    public SharePageValidator(ILocalizationService localizationService)
    {
        RuleFor(x => x.Title)
            .NotEmpty()
            .WithMessageAwait(localizationService.GetResourceAsync("Admin.Share.Fields.Title.Required"))
            .When(x => x.EnableSharePage);

        RuleFor(x => x.Description)
            .NotEmpty()
            .WithMessageAwait(localizationService.GetResourceAsync("Admin.Share.Fields.Description.Required"))
            .When(x => x.EnableSharePage);
        ;

        SetDatabaseValidationRules<SharePage>();
    }
}