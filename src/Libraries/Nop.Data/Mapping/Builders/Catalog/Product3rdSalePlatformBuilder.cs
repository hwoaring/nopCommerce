using FluentMigrator.Builders.Create.Table;
using Nop.Core.Domain.Catalog;

namespace Nop.Data.Mapping.Builders.Catalog
{
    /// <summary>
    /// Represents a product entity builder
    /// </summary>
    public partial class Product3rdSalePlatformBuilder : NopEntityBuilder<Product3rdSalePlatform>
    {
        #region Methods

        /// <summary>
        /// Apply entity configuration
        /// </summary>
        /// <param name="table">Create table expression builder</param>
        public override void MapEntity(CreateTableExpressionBuilder table)
        {
            table
                .WithColumn(nameof(Product3rdSalePlatform.Name)).AsString(128).NotNullable()
                .WithColumn(nameof(Product3rdSalePlatform.Description)).AsString(512).Nullable()
                .WithColumn(nameof(Product3rdSalePlatform.RegularExpression)).AsAnsiString(400).Nullable()

                ;
        }

        #endregion
    }
}
