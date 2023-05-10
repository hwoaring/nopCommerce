using FluentMigrator.Builders.Create.Table;
using Nop.Core.Domain.Localization;
using Nop.Core.Domain.Customers;
using Nop.Core.Domain.News;
using Nop.Data.Extensions;

namespace Nop.Data.Mapping.Builders.News
{
    /// <summary>
    /// Represents a news item entity builder
    /// </summary>
    public partial class NewsCommentFavoriteMappingBuilder : NopEntityBuilder<NewsCommentFavoriteMapping>
    {
        #region Methods

        /// <summary>
        /// 文章收藏
        /// </summary>
        /// <param name="table">Create table expression builder</param>
        public override void MapEntity(CreateTableExpressionBuilder table)
        {
            table
                .WithColumn(nameof(NewsCommentFavoriteMapping.NewsCommentId)).AsInt32().ForeignKey<NewsComment>()
                ;
        }

        #endregion
    }
}