using FluentMigrator.Builders.Create.Table;
using Nop.Core.Domain.Customers;
using Nop.Core.Domain.Catalog;
using Nop.Data.Extensions;
using Nop.Core.Domain.Stores;

namespace Nop.Data.Mapping.Builders.Catalog
{
    /// <summary>
    /// Represents a vendor entity builder
    /// </summary>
    public partial class ProductFavoriteMappingBuilder : NopEntityBuilder<ProductFavoriteMapping>
    {
        #region Methods

        /// <summary>
        /// Apply entity configuration
        /// </summary>
        /// <param name="table">Create table expression builder</param>
        public override void MapEntity(CreateTableExpressionBuilder table)
        {
            table
                .WithColumn(nameof(ProductFavoriteMapping.ProductId)).AsInt32().PrimaryKey().ForeignKey<Product>()
                .WithColumn(nameof(ProductFavoriteMapping.CustomerId)).AsInt32().PrimaryKey().ForeignKey<Customer>()
                ;
        }

        #endregion
    }
}