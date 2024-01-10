using FluentMigrator.Builders.Create.Table;
using Nop.Core.Domain.Assets;
using Nop.Core.Domain.Customers;
using Nop.Data.Extensions;


namespace Nop.Data.Mapping.Builders.Assets
{
    /// <summary>
    /// Represents a affiliate entity builder
    /// </summary>
    public partial class AssetsPointsHistoryBuilder : NopEntityBuilder<AssetsPointsHistory>
    {
        #region Methods

        /// <summary>
        /// Apply entity configuration
        /// </summary>
        /// <param name="table">Create table expression builder</param>
        public override void MapEntity(CreateTableExpressionBuilder table)
        {
            table
                .WithColumn(nameof(AssetsPointsHistory.CustomerId)).AsInt32().ForeignKey<Customer>()
                .WithColumn(nameof(AssetsPointsHistory.Message)).AsString(512).Nullable()
                .WithColumn(nameof(AssetsPointsHistory.HashCode)).AsAnsiString(128).Nullable()
                .WithColumn(nameof(AssetsPointsHistory.LockRemark)).AsString(128).Nullable()

                .WithColumn(nameof(AssetsPointsHistory.EndDateUtc)).AsDateTime2().Nullable()

                ;
        }

        #endregion

    }
}
