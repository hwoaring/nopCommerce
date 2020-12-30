using Nop.Web.Framework.Models;

namespace Nop.Plugin.Payments.Offline.Models
{
    public record PaymentInfoModel : BaseNopModel
    {
        public string DescriptionText { get; set; }
        public string WechatPaymentInfo { get; set; }
        public string AlipayPaymentInfo { get; set; }
        public string BankCardPaymentInfo { get; set; }
    }
}