using FluentMigrator.Builders.Create.Table;
using Nop.Core.Domain.AntiFake;
using Nop.Core.Domain.News;
using Nop.Data.Extensions;

namespace Nop.Data.Mapping.Builders.AntiFake
{
    /// <summary>
    /// Represents a affiliate entity builder
    /// </summary>
    public partial class AntiFakeProductRelatedNewsBuilder : NopEntityBuilder<AntiFakeProductRelatedNews>
    {
        #region Methods

        /// <summary>
        /// Apply entity configuration
        /// </summary>
        /// <param name="table">Create table expression builder</param>
        public override void MapEntity(CreateTableExpressionBuilder table)
        {
            table
                .WithColumn(nameof(AntiFakeProductRelatedNews.AntiFakeProductId)).AsInt32().ForeignKey<AntiFakeProduct>()
                .WithColumn(nameof(AntiFakeProductRelatedNews.NewsItemId)).AsInt32().ForeignKey<NewsItem>()
                ;
        }

        #endregion
    }
}
