using FluentMigrator.Builders.Create.Table;
using Nop.Core.Domain.Assets;
using Nop.Core.Domain.Customers;
using Nop.Data.Extensions;


namespace Nop.Data.Mapping.Builders.Assets
{
    /// <summary>
    /// Represents a affiliate entity builder
    /// </summary>
    public partial class AssetsSharesHistoryBuilder : NopEntityBuilder<AssetsSharesHistory>
    {
        #region Methods

        /// <summary>
        /// Apply entity configuration
        /// </summary>
        /// <param name="table">Create table expression builder</param>
        public override void MapEntity(CreateTableExpressionBuilder table)
        {
            table
                .WithColumn(nameof(AssetsSharesHistory.CustomerId)).AsInt32().ForeignKey<Customer>()
                .WithColumn(nameof(AssetsSharesHistory.Message)).AsString(512).Nullable()
                .WithColumn(nameof(AssetsSharesHistory.HashCode)).AsAnsiString(128).Nullable()

                .WithColumn(nameof(AssetsSharesHistory.UseUpDateOnUtc)).AsDateTime2().Nullable()
                .WithColumn(nameof(AssetsSharesHistory.EndDateUtc)).AsDateTime2().Nullable()
                ;
        }

        #endregion

    }
}
