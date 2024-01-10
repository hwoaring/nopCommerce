using FluentMigrator.Builders.Create.Table;
using Nop.Core.Domain.Customers;
using Nop.Core.Domain.News;
using Nop.Core.Domain.Stores;
using Nop.Data.Extensions;

namespace Nop.Data.Mapping.Builders.News
{
    /// <summary>
    /// 新闻评论点赞
    /// </summary>
    public partial class NewsCommentFavoriteMappingBuilder : NopEntityBuilder<NewsCommentFavoriteMapping>
    {
        #region Methods

        /// <summary>
        /// Apply entity configuration
        /// </summary>
        /// <param name="table">Create table expression builder</param>
        public override void MapEntity(CreateTableExpressionBuilder table)
        {
            table
                .WithColumn(nameof(NewsCommentFavoriteMapping.NewsCommentId)).AsInt32().ForeignKey<NewsComment>()
                .WithColumn(nameof(NewsCommentFavoriteMapping.CustomerId)).AsInt32().ForeignKey<Customer>()
                ;
        }

        #endregion
    }
}