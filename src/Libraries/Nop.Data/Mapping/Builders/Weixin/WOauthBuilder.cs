using FluentMigrator.Builders.Create.Table;
using Nop.Core.Domain.Weixin;
using Nop.Core.Domain.Customers;
using Nop.Core.Domain.Stores;
using Nop.Data.Extensions;

namespace Nop.Data.Mapping.Builders.Weixin
{
    /// <summary>
    /// Represents a vendor note entity builder
    /// </summary>
    public partial class WOauthBuilder : NopEntityBuilder<WOauth>
    {
        #region Methods

        /// <summary>
        /// Apply entity configuration
        /// </summary>
        /// <param name="table">Create table expression builder</param>
        public override void MapEntity(CreateTableExpressionBuilder table)
        {
            table
                .WithColumn(nameof(WOauth.CustomerId)).AsInt32().ForeignKey<Customer>()
                .WithColumn(nameof(WOauth.StoreId)).AsInt32().ForeignKey<Store>()
                .WithColumn(nameof(WOauth.OpenId)).AsAnsiString(32).NotNullable()
                .WithColumn(nameof(WOauth.AccessToken)).AsAnsiString(128).NotNullable()
                .WithColumn(nameof(WOauth.RefreshToken)).AsAnsiString(128).NotNullable()
                .WithColumn(nameof(WOauth.Scope)).AsString(128).Nullable()
                .WithColumn(nameof(WOauth.UnionId)).AsAnsiString(100).NotNullable()
                .WithColumn(nameof(WOauth.OauthApiName)).AsAnsiString(128).NotNullable()
                ;
        }

        #endregion
    }
}
