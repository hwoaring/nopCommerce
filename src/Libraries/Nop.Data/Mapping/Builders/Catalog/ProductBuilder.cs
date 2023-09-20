using FluentMigrator.Builders.Create.Table;
using Nop.Core.Domain.Catalog;
using Nop.Core.Domain.News;

namespace Nop.Data.Mapping.Builders.Catalog
{
    /// <summary>
    /// Represents a product entity builder
    /// </summary>
    public partial class ProductBuilder : NopEntityBuilder<Product>
    {
        #region Methods

        /// <summary>
        /// Apply entity configuration
        /// </summary>
        /// <param name="table">Create table expression builder</param>
        public override void MapEntity(CreateTableExpressionBuilder table)
        {
            table
                .WithColumn(nameof(Product.Name)).AsString(400).NotNullable()
                .WithColumn(nameof(Product.Slogan)).AsString(128).Nullable()
                .WithColumn(nameof(Product.SloganUrl)).AsString(128).Nullable()
                .WithColumn(nameof(Product.SloganUrlText)).AsString(32).Nullable()
                .WithColumn(nameof(Product.CoverImageUrl)).AsAnsiString(512).Nullable()
                .WithColumn(nameof(Product.CoverThumbImageUrl)).AsAnsiString(512).Nullable()
                .WithColumn(nameof(Product.Url)).AsAnsiString(512).Nullable()
                .WithColumn(nameof(Product.PurchaseUrl)).AsAnsiString(512).Nullable()

                .WithColumn(nameof(Product.MetaKeywords)).AsString(400).Nullable()
                .WithColumn(nameof(Product.MetaTitle)).AsString(400).Nullable()
                .WithColumn(nameof(Product.ProductSecretId)).AsAnsiString(16).Nullable()

                .WithColumn(nameof(Product.ShareTitle)).AsString(128).Nullable()
                .WithColumn(nameof(Product.ShareDesc)).AsString(512).Nullable()
                .WithColumn(nameof(Product.ShareLink)).AsAnsiString(1024).Nullable()
                .WithColumn(nameof(Product.ShareImgUrl)).AsAnsiString(1024).Nullable()

                .WithColumn(nameof(Product.Sku)).AsString(400).Nullable()
                .WithColumn(nameof(Product.ManufacturerPartNumber)).AsString(400).Nullable()
                .WithColumn(nameof(Product.Gtin)).AsString(400).Nullable()
                .WithColumn(nameof(Product.RequiredProductIds)).AsString(1000).Nullable()
                .WithColumn(nameof(Product.AllowedQuantities)).AsString(1000).Nullable();
        }

        #endregion
    }
}