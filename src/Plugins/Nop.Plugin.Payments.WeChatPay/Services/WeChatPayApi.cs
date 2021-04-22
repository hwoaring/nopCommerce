using System;
using System.Net.Http;
using System.Threading.Tasks;
using Nop.Plugin.Payments.WeChatPay.Models;

namespace Nop.Plugin.Payments.WeChatPay.Services
{
    /// <summary>
    /// Provides an default implementation the HTTP client to interact with the weChatPay endpoints
    /// </summary>
    public class WeChatPayApi : BaseHttpClient
    {
        #region Ctor

        public WeChatPayApi(WeChatPayPaymentSettings settings, HttpClient httpClient)
            : base(settings, httpClient)
        {
        }

        #endregion

        #region Methods

        public Task<ApiResponse<SecurePayPayload>> SecurePayAsync(SecurePayRequest request)
        {
            if (request is null)
                throw new ArgumentNullException(nameof(request));

            return PostAsync<ApiResponse<SecurePayPayload>>(Defaults.Api.Endpoints.SecurePayPath, request);
        }

        public Task<ApiResponse<CreateRefundPayload>> CreateRefundAsync(CreateRefundRequest request)
        {
            if (request is null)
                throw new ArgumentNullException(nameof(request));

            return PostAsync<ApiResponse<CreateRefundPayload>>(Defaults.Api.Endpoints.RefundPath, request);
        }

        public Task<ApiResponse<MerchantInfoPayload>> RequestDemoAsync(MerchantInfoRequest request)
        {
            if (request is null)
                throw new ArgumentNullException(nameof(request));

            return PostAsync<ApiResponse<MerchantInfoPayload>>(Defaults.Api.RequestDemoUrl, request);
        }

        #endregion
    }
}
