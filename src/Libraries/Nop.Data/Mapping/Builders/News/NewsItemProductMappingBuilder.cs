using FluentMigrator.Builders.Create.Table;
using Nop.Core.Domain.News;
using Nop.Core.Domain.Catalog;
using Nop.Data.Extensions;

namespace Nop.Data.Mapping.Builders.News
{
    /// <summary>
    /// 新闻相关产品
    /// </summary>
    public partial class NewsItemProductMappingBuilder : NopEntityBuilder<NewsItemProductMapping>
    {
        #region Methods

        /// <summary>
        /// Apply entity configuration
        /// </summary>
        /// <param name="table">Create table expression builder</param>
        public override void MapEntity(CreateTableExpressionBuilder table)
        {
            table
                .WithColumn(nameof(NewsItemProductMapping.NewsItemId)).AsInt32().PrimaryKey().ForeignKey<NewsItem>()
                .WithColumn(nameof(NewsItemProductMapping.ProductId)).AsInt32().PrimaryKey().ForeignKey<Product>()
                ;
        }

        #endregion
    }
}