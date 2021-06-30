using FluentMigrator.Builders.Create.Table;
using Nop.Core.Domain.Catalog;

namespace Nop.Data.Mapping.Builders.Catalog
{
    /// <summary>
    /// Represents a product tag entity builder
    /// </summary>
    public partial class ProductLableGroupBuilder : NopEntityBuilder<ProductLableGroup>
    {
        #region Methods

        /// <summary>
        /// Apply entity configuration
        /// </summary>
        /// <param name="table">Create table expression builder</param>
        public override void MapEntity(CreateTableExpressionBuilder table)
        {
            table
                .WithColumn(nameof(ProductLableGroup.Name)).AsString(64).NotNullable()
                .WithColumn(nameof(ProductLableGroup.CssName)).AsAnsiString(64).Nullable()
                .WithColumn(nameof(ProductLableGroup.IcoName)).AsAnsiString(64).Nullable()
                ;
        }

        #endregion
    }
}