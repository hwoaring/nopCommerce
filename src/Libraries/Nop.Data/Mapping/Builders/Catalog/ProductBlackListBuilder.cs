using FluentMigrator.Builders.Create.Table;
using Nop.Core.Domain.Catalog;
using Nop.Core.Domain.Customers;
using Nop.Data.Extensions;

namespace Nop.Data.Mapping.Builders.Catalog;

/// <summary>
/// Represents a product entity builder
/// </summary>
public partial class ProductBlackListBuilder : NopEntityBuilder<ProductBlackList>
{
    #region Methods

        /// <summary>
        /// Apply entity configuration
        /// </summary>
        /// <param name="table">Create table expression builder</param>
        public override void MapEntity(CreateTableExpressionBuilder table)
        {
            table
                .WithColumn(nameof(ProductBlackList.CustomerId)).AsInt32().ForeignKey<Customer>()
                .WithColumn(nameof(ProductBlackList.ProductId)).AsInt32().ForeignKey<Product>()
                .WithColumn(nameof(ProductBlackList.Notes)).AsString(64).Nullable()

                ;
        }

    #endregion
}