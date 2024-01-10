using FluentMigrator.Builders.Create.Table;
using Nop.Core.Domain.Customers;
using Nop.Core.Domain.Catalog;
using Nop.Data.Extensions;

namespace Nop.Data.Mapping.Builders.Catalog
{
    /// <summary>
    /// Represents a customer password entity builder
    /// </summary>
    public partial class ProductCustomerViewsBuilder : NopEntityBuilder<ProductCustomerViews>
    {
        #region Methods

        /// <summary>
        /// Apply entity configuration
        /// </summary>
        /// <param name="table">Create table expression builder</param>
        public override void MapEntity(CreateTableExpressionBuilder table)
        {
            table
                .WithColumn(nameof(ProductCustomerViews.CustomerId)).AsInt32().ForeignKey<Customer>()
                .WithColumn(nameof(ProductCustomerViews.ProductId)).AsInt32().ForeignKey<Product>()
                ;
        }

        #endregion
    }
}