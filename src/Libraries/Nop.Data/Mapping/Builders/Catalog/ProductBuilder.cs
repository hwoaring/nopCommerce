﻿using FluentMigrator.Builders.Create.Table;
using Nop.Core.Domain.Catalog;

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
                .WithColumn(nameof(Product.PromotionName)).AsString(512).Nullable()
                .WithColumn(nameof(Product.SubTitle)).AsString(512).Nullable()
                .WithColumn(nameof(Product.MetaKeywords)).AsString(400).Nullable()
                .WithColumn(nameof(Product.MetaTitle)).AsString(400).Nullable()
                .WithColumn(nameof(Product.MetaImageUrl)).AsAnsiString(1024).Nullable()
                .WithColumn(nameof(Product.MetaLinkUrl)).AsAnsiString(1024).Nullable()
                .WithColumn(nameof(Product.ShareImageUrl)).AsAnsiString(1024).Nullable()
                .WithColumn(nameof(Product.Sku)).AsString(400).Nullable()
                .WithColumn(nameof(Product.ManufacturerPartNumber)).AsString(400).Nullable()
                .WithColumn(nameof(Product.Gtin)).AsString(400).Nullable()
                .WithColumn(nameof(Product.CoverImageUrl)).AsAnsiString(1024).Nullable()
                .WithColumn(nameof(Product.CoverThumbImageUrl)).AsAnsiString(1024).Nullable()
                .WithColumn(nameof(Product.VirtualCurrency)).AsDecimal(9,2)
                .WithColumn(nameof(Product.RequiredProductIds)).AsString(1000).Nullable()
                .WithColumn(nameof(Product.AllowedQuantities)).AsString(1000).Nullable();
        }

        #endregion
    }
}