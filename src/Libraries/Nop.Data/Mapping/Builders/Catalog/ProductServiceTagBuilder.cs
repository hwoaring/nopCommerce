using FluentMigrator.Builders.Create.Table;
using Nop.Core.Domain.Catalog;

namespace Nop.Data.Mapping.Builders.Catalog;

/// <summary>
/// Represents a product tag entity builder
/// </summary>
public partial class ProductServiceTagBuilder : NopEntityBuilder<ProductServiceTag>
{
    #region Methods

    /// <summary>
    /// Apply entity configuration
    /// </summary>
    /// <param name="table">Create table expression builder</param>
    public override void MapEntity(CreateTableExpressionBuilder table)
    {
        table
            .WithColumn(nameof(ProductServiceTag.Name)).AsString(32).NotNullable()
            .WithColumn(nameof(ProductServiceTag.UrlText)).AsString(32).Nullable()
            .WithColumn(nameof(ProductServiceTag.Url)).AsAnsiString(1024).Nullable()

            ;
    }

    #endregion
}