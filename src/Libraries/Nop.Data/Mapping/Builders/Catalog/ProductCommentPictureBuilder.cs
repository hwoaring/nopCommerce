using FluentMigrator.Builders.Create.Table;
using Nop.Core.Domain.Catalog;
using Nop.Core.Domain.Customers;
using Nop.Core.Domain.Stores;
using Nop.Core.Domain.Media;
using Nop.Data.Extensions;

namespace Nop.Data.Mapping.Builders.Catalog
{
    /// <summary>
    /// Represents a Product Comment entity builder
    /// </summary>
    public class ProductCommentPictureBuilder : NopEntityBuilder<ProductCommentPicture>
    {
        #region Methods

        /// <summary>
        /// Apply entity configuration
        /// </summary>
        /// <param name="table">Create table expression builder</param>
        public override void MapEntity(CreateTableExpressionBuilder table) 
        {
            table
                .WithColumn(nameof(ProductCommentPicture.CommentId)).AsInt32().ForeignKey<Customer>()
                .WithColumn(nameof(ProductCommentPicture.StoreId)).AsInt32().ForeignKey<Store>()
                .WithColumn(nameof(ProductCommentPicture.PictureId)).AsInt32().ForeignKey<Picture>()
                ;
        }

        #endregion
    }
}