using FluentMigrator.Builders.Create.Table;
using Nop.Core.Domain.Catalog;
using Nop.Data.Extensions;

namespace Nop.Data.Mapping.Builders.Catalog
{
    /// <summary>
    /// Represents a product entity builder
    /// </summary>
    public partial class Product3rdSalePlatformMappingBuilder : NopEntityBuilder<Product3rdSalePlatformMapping>
    {
        #region Methods

        /// <summary>
        /// Apply entity configuration
        /// </summary>
        /// <param name="table">Create table expression builder</param>
        public override void MapEntity(CreateTableExpressionBuilder table)
        {
            table
                .WithColumn(nameof(Product3rdSalePlatformMapping.ProductId)).AsInt32().PrimaryKey().ForeignKey<Product>()
                .WithColumn(nameof(Product3rdSalePlatformMapping.Product3rdSalePlatformId)).AsInt32().PrimaryKey().ForeignKey<Product3rdSalePlatform>()

                .WithColumn(nameof(Product3rdSalePlatformMapping.Url)).AsAnsiString(1024).Nullable()

                ;
        }

        #endregion
  
    }
}