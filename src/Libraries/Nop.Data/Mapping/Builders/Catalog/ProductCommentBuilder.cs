using FluentMigrator.Builders.Create.Table;
using Nop.Core.Domain.Catalog;
using Nop.Core.Domain.Customers;
using Nop.Data.Extensions;

namespace Nop.Data.Mapping.Builders.Catalog
{
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


        /// <summary>
        /// 评论标题
        /// </summary>
        public string CommentTitle { get; set; }

        /// <summary>
        /// 评论内容
        /// </summary>
        public string CommentText { get; set; }

        /// <summary>
        /// 回复内容
        /// </summary>
        public string ReplyCommentText { get; set; }

        /// <summary>
        /// 回复时间
        /// </summary>
        public DateTime? ReplyDateOnUtc { get; set; }

        /// <summary>
        /// 评论发布IP位置
        /// </summary>
        public string PublishArea { get; set; }

        /// <summary>
        /// 评论人IP
        /// </summary>
        public string PublishIp { get; set; }

        /// <summary>
        /// 服务星级
        /// </summary>
        public byte ServiceStars { get; set; }
        /// <summary>
        /// 产品星级
        /// </summary>
        public byte ProductStars { get; set; }
        /// <summary>
        /// 环境星级
        /// </summary>
        public byte EnvStars { get; set; }
        /// <summary>
        /// 邮递星级
        /// </summary>
        public byte ShippingStars { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether the comment is approved
        /// </summary>
        public bool IsApproved { get; set; }

        /// <summary>
        /// Gets or sets the store identifier
        /// </summary>
        public int StoreId { get; set; }

        /// <summary>
        /// Gets or sets the date and time of instance creation
        /// </summary>
        public DateTime CreatedOnUtc { get; set; }
    }
}