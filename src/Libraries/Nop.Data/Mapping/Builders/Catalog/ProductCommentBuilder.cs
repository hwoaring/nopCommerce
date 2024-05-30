using FluentMigrator.Builders.Create.Table;
using Nop.Core.Domain.Catalog;
using Nop.Core.Domain.Customers;
using Nop.Data.Extensions;

namespace Nop.Data.Mapping.Builders.Catalog;

/// <summary>
/// Represents a product entity builder
/// </summary>
public partial class ProductCommentBuilder : NopEntityBuilder<ProductComment>
{
    #region Methods

    /// <summary>
    /// Apply entity configuration
    /// </summary>
    /// <param name="table">Create table expression builder</param>
    public override void MapEntity(CreateTableExpressionBuilder table)
    {
        table
            .WithColumn(nameof(ProductComment.ProductId)).AsInt32().ForeignKey<Product>()
            .WithColumn(nameof(ProductComment.CustomerId)).AsInt32().ForeignKey<Customer>()

            .WithColumn(nameof(ProductComment.CommentTitle)).AsString(128).Nullable()
            .WithColumn(nameof(ProductComment.CommentText)).AsString(1024).Nullable()
            .WithColumn(nameof(ProductComment.ReplyCommentText)).AsString(1024).Nullable()
            .WithColumn(nameof(ProductComment.PublishArea)).AsString(32).Nullable()
            .WithColumn(nameof(ProductComment.PublishIp)).AsString(32).Nullable()
            ;
    }

    #endregion

}