using FluentMigrator.Builders.Create.Table;
using Nop.Core.Domain.Catalog;
using Nop.Data.Extensions;

namespace Nop.Data.Mapping.Builders.Catalog
{
    /// <summary>
    /// Represents a product entity builder
    /// </summary>
    public partial class ProductCouponsAttributeBuilder : NopEntityBuilder<ProductCouponsAttribute>
    {
        #region Methods

        /// <summary>
        /// Apply entity configuration
        /// </summary>
        /// <param name="table">Create table expression builder</param>
        public override void MapEntity(CreateTableExpressionBuilder table)
        {
            table
                .WithColumn(nameof(ProductCouponsAttribute.ProductId)).AsInt32().ForeignKey<Product>()
                .WithColumn(nameof(ProductCouponsAttribute.AgeDiscountRules)).AsAnsiString(512).Nullable()

                ;
        }

        #endregion

    }
}
