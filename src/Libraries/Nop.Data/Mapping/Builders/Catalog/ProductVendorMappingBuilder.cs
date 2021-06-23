using FluentMigrator.Builders.Create.Table;
using Nop.Core.Domain.Catalog;
using Nop.Core.Domain.Vendors;
using Nop.Data.Extensions;

namespace Nop.Data.Mapping.Builders.Catalog
{
    /// <summary>
    /// Represents a product vendor mapping entity builder
    /// </summary>
    public partial class ProductVendorMappingBuilder : NopEntityBuilder<ProductVendorMapping>
    {
        #region Methods

        /// <summary>
        /// Apply entity configuration
        /// </summary>
        /// <param name="table">Create table expression builder</param>
        public override void MapEntity(CreateTableExpressionBuilder table)
        {
            table
                .WithColumn(NameCompatibilityManager.GetColumnName(typeof(ProductVendorMapping), nameof(ProductVendorMapping.ProductId)))
                    .AsInt32().PrimaryKey().ForeignKey<Product>()
                .WithColumn(NameCompatibilityManager.GetColumnName(typeof(ProductVendorMapping), nameof(ProductVendorMapping.VendorId)))
                    .AsInt32().PrimaryKey().ForeignKey<Vendor>();
        }

        #endregion
    }
}