using FluentMigrator.Builders.Create.Table;
using Nop.Core.Domain.Customers;
using Nop.Core.Domain.Weixins;
using Nop.Data.Extensions;

namespace Nop.Data.Mapping.Builders.Weixins
{
    /// <summary>
    /// Represents a vendor entity builder
    /// </summary>
    public partial class WeixinOAuthBuilder : NopEntityBuilder<WeixinOAuth>
    {
        #region Methods

        /// <summary>
        /// Apply entity configuration
        /// </summary>
        /// <param name="table">Create table expression builder</param>
        public override void MapEntity(CreateTableExpressionBuilder table)
        {
            table
                .WithColumn(nameof(WeixinOAuth.UnionId)).AsAnsiString(64).Nullable()
                .WithColumn(nameof(WeixinOAuth.OpenId)).AsAnsiString(64).NotNullable()
                .WithColumn(nameof(WeixinOAuth.AccessToken)).AsAnsiString(64).NotNullable()
                .WithColumn(nameof(WeixinOAuth.RefreshToken)).AsAnsiString(64).NotNullable()
                .WithColumn(nameof(WeixinOAuth.Scope)).AsAnsiString(64).Nullable()
                ;
        }

        #endregion
    }
}