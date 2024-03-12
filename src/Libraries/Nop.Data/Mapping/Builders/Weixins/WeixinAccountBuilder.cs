using FluentMigrator.Builders.Create.Table;
using Nop.Core.Domain.Stores;
using Nop.Core.Domain.Weixins;
using Nop.Data.Extensions;

namespace Nop.Data.Mapping.Builders.Weixins
{
    /// <summary>
    /// Represents a vendor entity builder
    /// </summary>
    public partial class WeixinAccountBuilder : NopEntityBuilder<WeixinAccount>
    {
        #region Methods

        /// <summary>
        /// Apply entity configuration
        /// </summary>
        /// <param name="table">Create table expression builder</param>
        public override void MapEntity(CreateTableExpressionBuilder table)
        {
            table
                .WithColumn(nameof(WeixinAccount.StoreId)).AsInt32().ForeignKey<Store>()
                .WithColumn(nameof(WeixinAccount.Name)).AsString(64).NotNullable()
                .WithColumn(nameof(WeixinAccount.ApiCode)).AsAnsiString(32).NotNullable()
                .WithColumn(nameof(WeixinAccount.OriginalId)).AsAnsiString(64).Nullable()
                .WithColumn(nameof(WeixinAccount.SystemName)).AsString(64).Nullable()
                .WithColumn(nameof(WeixinAccount.Remark)).AsString(512).Nullable()

                .WithColumn(nameof(WeixinAccount.Token)).AsAnsiString(128).Nullable()
                .WithColumn(nameof(WeixinAccount.EncodingAESKey)).AsAnsiString(128).Nullable()
                .WithColumn(nameof(WeixinAccount.WeixinAppId)).AsAnsiString(128).Nullable()
                .WithColumn(nameof(WeixinAccount.WeixinAppSecret)).AsAnsiString(128).Nullable()
                .WithColumn(nameof(WeixinAccount.WxOpenAppId)).AsAnsiString(128).Nullable()
                .WithColumn(nameof(WeixinAccount.WxOpenAppSecret)).AsAnsiString(128).Nullable()
                .WithColumn(nameof(WeixinAccount.WxOpenToken)).AsAnsiString(128).Nullable()
                .WithColumn(nameof(WeixinAccount.WxOpenEncodingAESKey)).AsAnsiString(128).Nullable()
                .WithColumn(nameof(WeixinAccount.WeixinCorpId)).AsAnsiString(128).Nullable()
                .WithColumn(nameof(WeixinAccount.WeixinCorpAgentId)).AsAnsiString(128).Nullable()
                .WithColumn(nameof(WeixinAccount.WeixinCorpSecret)).AsAnsiString(128).Nullable()
                .WithColumn(nameof(WeixinAccount.WeixinCorpToken)).AsAnsiString(128).Nullable()
                .WithColumn(nameof(WeixinAccount.WeixinCorpEncodingAESKey)).AsAnsiString(128).Nullable()
                .WithColumn(nameof(WeixinAccount.WeixinPay_PartnerId)).AsAnsiString(128).Nullable()
                .WithColumn(nameof(WeixinAccount.WeixinPay_Key)).AsAnsiString(128).Nullable()
                .WithColumn(nameof(WeixinAccount.WeixinPay_AppId)).AsAnsiString(128).Nullable()
                .WithColumn(nameof(WeixinAccount.WeixinPay_AppKey)).AsAnsiString(128).Nullable()
                .WithColumn(nameof(WeixinAccount.WeixinPay_TenpayNotify)).AsAnsiString(128).Nullable()
                .WithColumn(nameof(WeixinAccount.TenPayV3_AppId)).AsAnsiString(128).Nullable()
                .WithColumn(nameof(WeixinAccount.TenPayV3_AppSecret)).AsAnsiString(128).Nullable()
                .WithColumn(nameof(WeixinAccount.TenPayV3_SubAppId)).AsAnsiString(128).Nullable()
                .WithColumn(nameof(WeixinAccount.TenPayV3_SubAppSecret)).AsAnsiString(128).Nullable()
                .WithColumn(nameof(WeixinAccount.TenPayV3_MchId)).AsAnsiString(128).Nullable()
                .WithColumn(nameof(WeixinAccount.TenPayV3_SubMchId)).AsAnsiString(128).Nullable()
                .WithColumn(nameof(WeixinAccount.TenPayV3_Key)).AsAnsiString(128).Nullable()
                .WithColumn(nameof(WeixinAccount.TenPayV3_CertPath)).AsAnsiString(1024).Nullable()
                .WithColumn(nameof(WeixinAccount.TenPayV3_CertSecret)).AsAnsiString(128).Nullable()
                .WithColumn(nameof(WeixinAccount.TenPayV3_TenpayNotify)).AsAnsiString(128).Nullable()
                .WithColumn(nameof(WeixinAccount.TenPayV3_PrivateKey)).AsAnsiString(128).Nullable()
                .WithColumn(nameof(WeixinAccount.TenPayV3_SerialNumber)).AsAnsiString(128).Nullable()
                .WithColumn(nameof(WeixinAccount.TenPayV3_ApiV3Key)).AsAnsiString(128).Nullable()
                .WithColumn(nameof(WeixinAccount.TenPayV3_WxOpenTenpayNotify)).AsAnsiString(128).Nullable()
                .WithColumn(nameof(WeixinAccount.Component_Appid)).AsAnsiString(128).Nullable()
                .WithColumn(nameof(WeixinAccount.Component_Secret)).AsAnsiString(128).Nullable()
                .WithColumn(nameof(WeixinAccount.Component_Token)).AsAnsiString(128).Nullable()
                .WithColumn(nameof(WeixinAccount.Component_EncodingAESKey)).AsAnsiString(128).Nullable()

                .WithColumn(nameof(WeixinAccount.ExpiredDateOnUtc)).AsDateTime2().Nullable()
                .WithColumn(nameof(WeixinAccount.UpdatedOnUtc)).AsDateTime2().Nullable()
                ;
        }

        #endregion
    }
}