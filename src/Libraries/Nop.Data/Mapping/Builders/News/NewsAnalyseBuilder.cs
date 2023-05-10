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
    public partial class NewsAnalyseBuilder : NopEntityBuilder<NewsAnalyse>
    {
        #region Methods

        /// <summary>
        /// Apply entity configuration
        /// </summary>
        /// <param name="table">Create table expression builder</param>
        public override void MapEntity(CreateTableExpressionBuilder table)
        {
            table
                .WithColumn(nameof(NewsAnalyse.NewsItemId)).AsInt32().ForeignKey<NewsItem>()
                .WithColumn(nameof(NewsAnalyse.CustomerId)).AsInt32().ForeignKey<Customer>()
                ;
        }

        #endregion
    }
}