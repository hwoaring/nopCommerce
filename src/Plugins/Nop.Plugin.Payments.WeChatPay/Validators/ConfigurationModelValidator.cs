using FluentValidation;
using Nop.Plugin.Payments.WeChatPay.Models;
using Nop.Services.Localization;
using Nop.Web.Framework.Validators;

namespace Nop.Plugin.Payments.WeChatPay.Validators
{
    /// <summary>
    /// Represents a validator for <see cref="ConfigurationModel"/>
    /// </summary>
    public class ConfigurationModelValidator : BaseNopValidator<ConfigurationModel>
    {
        #region Ctor

        public ConfigurationModelValidator(ILocalizationService localizationService)
        {
            RuleFor(model => model.BaseApiUrl)
                .NotEmpty()
                .WithMessageAwait(localizationService.GetResourceAsync("Plugins.Payments.WeChatPay.Fields.BaseApiUrl.Required"))
                .When(model => string.IsNullOrEmpty(model.MerchantEmail));

            RuleFor(model => model.MerchantId)
                .NotEmpty()
                .WithMessageAwait(localizationService.GetResourceAsync("Plugins.Payments.WeChatPay.Fields.MerchantId.Required"))
                .When(model => string.IsNullOrEmpty(model.MerchantEmail));

            RuleFor(model => model.StoreId)
                .NotEmpty()
                .WithMessageAwait(localizationService.GetResourceAsync("Plugins.Payments.WeChatPay.Fields.StoreId.Required"))
                .When(model => string.IsNullOrEmpty(model.MerchantEmail));

            RuleFor(model => model.ApiToken)
                .NotEmpty()
                .WithMessageAwait(localizationService.GetResourceAsync("Plugins.Payments.WeChatPay.Fields.ApiToken.Required"))
                .When(model => string.IsNullOrEmpty(model.MerchantEmail));

            RuleFor(model => model.PaymentChannels)
                .NotEmpty()
                .WithMessageAwait(localizationService.GetResourceAsync("Plugins.Payments.WeChatPay.Fields.PaymentChannels.Required"))
                .When(model => string.IsNullOrEmpty(model.MerchantEmail));
        }

        #endregion
    }
}