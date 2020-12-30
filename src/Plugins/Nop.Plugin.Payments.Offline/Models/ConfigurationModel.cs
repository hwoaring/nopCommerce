using System.Collections.Generic;
using Nop.Web.Framework.Mvc.ModelBinding;
using Nop.Web.Framework.Models;

namespace Nop.Plugin.Payments.Offline.Models
{
    public record ConfigurationModel : BaseNopModel, ILocalizedModel<ConfigurationModel.ConfigurationLocalizedModel>
    {
        public ConfigurationModel()
        {
            Locales = new List<ConfigurationLocalizedModel>();
        }

        public int ActiveStoreScopeConfiguration { get; set; }
        
        [NopResourceDisplayName("Plugins.Payment.Offline.DescriptionText")]
        public string DescriptionText { get; set; }
        public bool DescriptionText_OverrideForStore { get; set; }

        [NopResourceDisplayName("Plugins.Payment.Offline.WechatPaymentInfo")]
        public string WechatPaymentInfo { get; set; }
        public bool WechatPaymentInfo_OverrideForStore { get; set; }

        [NopResourceDisplayName("Plugins.Payment.Offline.AlipayPaymentInfo")]
        public string AlipayPaymentInfo { get; set; }
        public bool AlipayPaymentInfo_OverrideForStore { get; set; }

        [NopResourceDisplayName("Plugins.Payment.Offline.BankCardPaymentInfo")]
        public string BankCardPaymentInfo { get; set; }
        public bool BankCardPaymentInfo_OverrideForStore { get; set; }

        [NopResourceDisplayName("Plugins.Payment.Offline.AdditionalFee")]
        public decimal AdditionalFee { get; set; }
        public bool AdditionalFee_OverrideForStore { get; set; }

        [NopResourceDisplayName("Plugins.Payment.Offline.AdditionalFeePercentage")]
        public bool AdditionalFeePercentage { get; set; }
        public bool AdditionalFeePercentage_OverrideForStore { get; set; }

        [NopResourceDisplayName("Plugins.Payment.Offline.ShippableProductRequired")]
        public bool ShippableProductRequired { get; set; }
        public bool ShippableProductRequired_OverrideForStore { get; set; }

        public IList<ConfigurationLocalizedModel> Locales { get; set; }

        #region Nested class

        public partial class ConfigurationLocalizedModel : ILocalizedLocaleModel
        {
            public int LanguageId { get; set; }
            
            [NopResourceDisplayName("Plugins.Payment.Offline.DescriptionText")]
            public string DescriptionText { get; set; }
            [NopResourceDisplayName("Plugins.Payment.Offline.WechatPaymentInfo")]
            public string WechatPaymentInfo { get; set; }
            [NopResourceDisplayName("Plugins.Payment.Offline.AlipayPaymentInfo")]
            public string AlipayPaymentInfo { get; set; }
            [NopResourceDisplayName("Plugins.Payment.Offline.BankCardPaymentInfo")]
            public string BankCardPaymentInfo { get; set; }
        }

        #endregion

    }
}