using FluentMigrator.Builders.Create.Table;
using Nop.Core.Domain.Weixin;
using Nop.Core.Domain.Customers;
using Nop.Core.Domain.Stores;
using Nop.Data.Extensions;

namespace Nop.Data.Mapping.Builders.Weixin
{
    /// <summary>
    /// Represents a WxOauthBuilder
    /// </summary>
    public partial class WxOauthBuilder : NopEntityBuilder<WxOauth>
    {
        #region Methods

        /// <summary>
        /// Apply entity configuration
        /// </summary>
        /// <param name="table">Create table expression builder</param>
        public override void MapEntity(CreateTableExpressionBuilder table)
        {
            table
                .WithColumn(nameof(WxOauth.CustomerId)).AsInt32().ForeignKey<Customer>()
                .WithColumn(nameof(WxOauth.OpenId)).AsAnsiString(64).NotNullable()
                .WithColumn(nameof(WxOauth.AccessToken)).AsAnsiString(128).NotNullable()
                .WithColumn(nameof(WxOauth.RefreshToken)).AsAnsiString(128).NotNullable()
                .WithColumn(nameof(WxOauth.Scope)).AsString(128).Nullable()
                .WithColumn(nameof(WxOauth.UnionId)).AsAnsiString(100).Nullable()
                .WithColumn(nameof(WxOauth.OauthApiName)).AsAnsiString(128).NotNullable()
                ;
        }

        #endregion
    }
}
