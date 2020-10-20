using Nop.Web.Framework.Models;

namespace Nop.Web.Models.Checkout
{
    public partial class OnePagePaymentModel : BaseNopModel
    {
        /// <summary>
        /// 是否需要邮寄
        /// </summary>
        public bool ShippingRequired { get; set; }
        /// <summary>
        /// 是否需要联系人信息
        /// </summary>
        public bool ContactInfoRequired { get; set; }
        /// <summary>
        /// 是否需要身份证信息
        /// </summary>
        public bool IDCardRequired { get; set; }
        /// <summary>
        /// 是否显示账单地址
        /// </summary>
        public bool DisableBillingAddressCheckoutStep { get; set; }
        /// <summary>
        /// 邮寄地址
        /// </summary>
        public CheckoutShippingAddressModel ShippingAddress { get; set; }
    }
}