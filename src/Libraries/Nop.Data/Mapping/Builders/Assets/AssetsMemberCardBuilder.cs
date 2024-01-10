using FluentMigrator.Builders.Create.Table;
using Nop.Core.Domain.Assets;
using Nop.Core.Domain.Customers;
using Nop.Data.Extensions;


namespace Nop.Data.Mapping.Builders.Assets
{
    /// <summary>
    /// Represents a affiliate entity builder
    /// </summary>
    public partial class AssetsMemberCardBuilder : NopEntityBuilder<AssetsMemberCard>
    {
        #region Methods

        /// <summary>
        /// Apply entity configuration
        /// </summary>
        /// <param name="table">Create table expression builder</param>
        public override void MapEntity(CreateTableExpressionBuilder table)
        {
            table
                .WithColumn(nameof(AssetsMemberCard.CustomerId)).AsInt32().ForeignKey<Customer>()
                .WithColumn(nameof(AssetsMemberCard.Relationship)).AsString(32).Nullable()
                .WithColumn(nameof(AssetsMemberCard.HashCode)).AsAnsiString(128).Nullable()
                .WithColumn(nameof(AssetsMemberCard.LockRemark)).AsString(128).Nullable()

                .WithColumn(nameof(AssetsMemberCard.ExpireTimeOnUtc)).AsDateTime2().Nullable()
                .WithColumn(nameof(AssetsMemberCard.UpgradeTimeOnUtc)).AsDateTime2().Nullable()

                ;
        }

        #endregion

    }
}