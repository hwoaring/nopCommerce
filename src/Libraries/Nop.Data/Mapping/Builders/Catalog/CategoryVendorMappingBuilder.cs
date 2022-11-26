using FluentMigrator.Builders.Create.Table;
using Nop.Core.Domain.Catalog;
using Nop.Core.Domain.Vendors;
using Nop.Data.Extensions;

namespace Nop.Data.Mapping.Builders.Catalog
{
    /// <summary>
    /// Represents a category vendor mapping entity builder
    /// </summary>
    public partial class CategoryVendorMappingBuilder : NopEntityBuilder<CategoryVendorMapping>
    {
        #region Methods

        /// <summary>
        /// Apply entity configuration
        /// </summary>
        /// <param name="table">Create table expression builder</param>
        public override void MapEntity(CreateTableExpressionBuilder table)
        {
            table
                .WithColumn(NameCompatibilityManager.GetColumnName(typeof(CategoryVendorMapping), nameof(CategoryVendorMapping.CategoryId)))
                    .AsInt32().PrimaryKey().ForeignKey<Category>()
                .WithColumn(NameCompatibilityManager.GetColumnName(typeof(CategoryVendorMapping), nameof(CategoryVendorMapping.VendorId)))
                    .AsInt32().PrimaryKey().ForeignKey<Vendor>();
        }

        #endregion
    }
}