using FluentMigrator.Builders.Create.Table;
using Nop.Core.Domain.Catalog;
using Nop.Core.Domain.News;
using Nop.Data.Extensions;

namespace Nop.Data.Mapping.Builders.News
{
    /// <summary>
    /// 新闻标签映射
    /// </summary>
    public partial class NewsItemNewsTagMappingBuilder : NopEntityBuilder<NewsItemNewsTagMapping>
    {
        #region Methods

        /// <summary>
        /// Apply entity configuration
        /// </summary>
        /// <param name="table">Create table expression builder</param>
        public override void MapEntity(CreateTableExpressionBuilder table)
        {
            table
                .WithColumn(nameof(NewsItemNewsTagMapping.NewsItemId)).AsInt32().PrimaryKey().ForeignKey<NewsItem>()
                .WithColumn(nameof(NewsItemNewsTagMapping.NewsTagId)).AsInt32().PrimaryKey().ForeignKey<NewsTag>()
                ;
        }

        #endregion
    }
}