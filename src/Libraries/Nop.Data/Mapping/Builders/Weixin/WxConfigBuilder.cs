using FluentMigrator.Builders.Create.Table;
using Nop.Core.Domain.Stores;
using Nop.Core.Domain.Weixin;
using Nop.Data.Extensions;

namespace Nop.Data.Mapping.Builders.Weixin
{
    /// <summary>
    /// Represents a vendor note entity builder
    /// </summary>
    public partial class WxConfigBuilder : NopEntityBuilder<WxConfig>
    {
        #region Methods

        /// <summary>
        /// Apply entity configuration
        /// </summary>
        /// <param name="table">Create table expression builder</param>
        public override void MapEntity(CreateTableExpressionBuilder table)
        {
            table
                .WithColumn(nameof(WxConfig.StoreId)).AsInt32().ForeignKey<Store>()
                .WithColumn(nameof(WxConfig.OriginalId)).AsAnsiString(32).NotNullable()
                .WithColumn(nameof(WxConfig.SystemName)).AsString(50).NotNullable()
                .WithColumn(nameof(WxConfig.Remark)).AsString(32).Nullable()
                .WithColumn(nameof(WxConfig.WeixinAppId)).AsAnsiString(64).Nullable()
                .WithColumn(nameof(WxConfig.WeixinAppSecret)).AsAnsiString(128).Nullable()
                .WithColumn(nameof(WxConfig.Token)).AsAnsiString(50).Nullable()
                .WithColumn(nameof(WxConfig.EncodingAESKey)).AsAnsiString(128).Nullable()
                .WithColumn(nameof(WxConfig.WxOpenAppId)).AsAnsiString(64).Nullable()
                .WithColumn(nameof(WxConfig.WxOpenAppSecret)).AsAnsiString(128).Nullable()
                .WithColumn(nameof(WxConfig.WxOpenToken)).AsAnsiString(32).Nullable()
                .WithColumn(nameof(WxConfig.WxOpenEncodingAESKey)).AsAnsiString(128).Nullable()
                .WithColumn(nameof(WxConfig.WeixinCorpId)).AsAnsiString(128).Nullable()
                .WithColumn(nameof(WxConfig.WeixinCorpAgentId)).AsAnsiString(128).Nullable()
                .WithColumn(nameof(WxConfig.WeixinCorpSecret)).AsAnsiString(128).Nullable()
                .WithColumn(nameof(WxConfig.WeixinCorpToken)).AsAnsiString(128).Nullable()
                .WithColumn(nameof(WxConfig.WeixinCorpEncodingAESKey)).AsAnsiString(128).Nullable()
                .WithColumn(nameof(WxConfig.TenPayV3AppId)).AsAnsiString(128).Nullable()
                .WithColumn(nameof(WxConfig.TenPayV3AppSecret)).AsAnsiString(128).Nullable()
                .WithColumn(nameof(WxConfig.TenPayV3SubAppId)).AsAnsiString(128).Nullable()
                .WithColumn(nameof(WxConfig.TenPayV3SubAppSecret)).AsAnsiString(128).Nullable()
                .WithColumn(nameof(WxConfig.TenPayV3MchId)).AsAnsiString(128).Nullable()
                .WithColumn(nameof(WxConfig.TenPayV3SubMchId)).AsAnsiString(128).Nullable()
                .WithColumn(nameof(WxConfig.TenPayV3Key)).AsAnsiString(128).Nullable()
                .WithColumn(nameof(WxConfig.TenPayV3CertPath)).AsAnsiString(128).Nullable()
                .WithColumn(nameof(WxConfig.TenPayV3CertSecret)).AsAnsiString(128).Nullable()
                .WithColumn(nameof(WxConfig.TenPayV3TenpayNotify)).AsAnsiString(128).Nullable()
                .WithColumn(nameof(WxConfig.TenPayV3WxOpenTenpayNotify)).AsAnsiString(128).Nullable()
                ;
        }

        #endregion
    }
}
