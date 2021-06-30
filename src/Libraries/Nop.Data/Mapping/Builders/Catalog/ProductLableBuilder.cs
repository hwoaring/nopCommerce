using FluentMigrator.Builders.Create.Table;
using Nop.Core.Domain.Catalog;
using Nop.Core.Domain.Media;
using Nop.Data.Extensions;

namespace Nop.Data.Mapping.Builders.Catalog
{
    /// <summary>
    /// Represents a product picture entity builder
    /// </summary>
    public partial class ProductLableBuilder : NopEntityBuilder<ProductLable>
    {
        #region Methods

        /// <summary>
        /// Apply entity configuration
        /// </summary>
        /// <param name="table">Create table expression builder</param>
        public override void MapEntity(CreateTableExpressionBuilder table)
        {
            table
                .WithColumn(nameof(ProductLable.ProductLableGroupId)).AsInt32().ForeignKey<ProductLableGroup>()
                .WithColumn(nameof(ProductLable.Name)).AsString(64).NotNullable()
                .WithColumn(nameof(ProductLable.CssName)).AsAnsiString(64).Nullable()
                .WithColumn(nameof(ProductLable.IcoName)).AsAnsiString(64).Nullable()
                ;
        }

        #endregion
    }
}