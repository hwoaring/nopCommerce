using FluentMigrator.Builders.Create.Table;
using Nop.Core.Domain.Catalog;
using Nop.Data.Extensions;

namespace Nop.Data.Mapping.Builders.Catalog;

/// <summary>
/// Represents a product product tag mapping entity builder
/// </summary>
public partial class ProductProductServiceTagMappingBuilder : NopEntityBuilder<ProductProductServiceTagMapping>
{
    #region Methods

    /// <summary>
    /// Apply entity configuration
    /// </summary>
    /// <param name="table">Create table expression builder</param>
    public override void MapEntity(CreateTableExpressionBuilder table)
    {
        table
            .WithColumn(nameof(ProductProductServiceTagMapping.ProductId)).AsInt32().PrimaryKey().ForeignKey<Product>()
            .WithColumn(nameof(ProductProductServiceTagMapping.ProductServiceTagId)).AsInt32().PrimaryKey().ForeignKey<ProductServiceTag>()

            ;
    }

    #endregion
}