using FluentMigrator.Builders.Create.Table;
using Nop.Core.Domain.Assets;
using Nop.Core.Domain.Customers;
using Nop.Data.Extensions;


namespace Nop.Data.Mapping.Builders.Assets
{
    /// <summary>
    /// Represents a affiliate entity builder
    /// </summary>
    public partial class AssetsCashsBuilder : NopEntityBuilder<AssetsCashs>
    {
        #region Methods

        /// <summary>
        /// Apply entity configuration
        /// </summary>
        /// <param name="table">Create table expression builder</param>
        public override void MapEntity(CreateTableExpressionBuilder table)
        {
            table
                .WithColumn(nameof(AssetsCashs.CustomerId)).AsInt32().ForeignKey<Customer>()
                .WithColumn(nameof(AssetsCashs.CardNumber)).AsAnsiString(64).Nullable()
                .WithColumn(nameof(AssetsCashs.Remarks)).AsString(128).Nullable()
                .WithColumn(nameof(AssetsCashs.Password)).AsAnsiString(16).Nullable()
                .WithColumn(nameof(AssetsCashs.HashCode)).AsString(128).Nullable()
                ;
        }

        #endregion
    }
}
