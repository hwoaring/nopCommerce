using FluentMigrator.Builders.Create.Table;
using Nop.Core.Domain.Customers;
using Nop.Core.Domain.News;
using Nop.Core.Domain.Stores;
using Nop.Data.Extensions;

namespace Nop.Data.Mapping.Builders.News
{
    /// <summary>
    /// 新闻文章点赞
    /// </summary>
    public partial class NewsItemFavoriteMappingBuilder : NopEntityBuilder<NewsItemFavoriteMapping>
    {
        #region Methods

        /// <summary>
        /// Apply entity configuration
        /// </summary>
        /// <param name="table">Create table expression builder</param>
        public override void MapEntity(CreateTableExpressionBuilder table)
        {
            table
                .WithColumn(nameof(NewsItemFavoriteMapping.NewsItemId)).AsInt32().ForeignKey<NewsItem>()
                .WithColumn(nameof(NewsItemFavoriteMapping.CustomerId)).AsInt32().ForeignKey<Customer>()
                ;
        }

        #endregion
    }
}