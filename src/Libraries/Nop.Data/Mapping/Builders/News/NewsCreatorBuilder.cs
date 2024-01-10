using FluentMigrator.Builders.Create.Table;
using Nop.Core.Domain.Customers;
using Nop.Core.Domain.News;
using Nop.Data.Extensions;

namespace Nop.Data.Mapping.Builders.News
{
    /// <summary>
    /// Represents a news item entity builder
    /// </summary>
    public partial class NewsCreatorBuilder : NopEntityBuilder<NewsCreator>
    {
        #region Methods

        /// <summary>
        /// Apply entity configuration
        /// </summary>
        /// <param name="table">Create table expression builder</param>
        public override void MapEntity(CreateTableExpressionBuilder table)
        {
            table
                .WithColumn(nameof(NewsCreator.CustomerId)).AsInt32().ForeignKey<Customer>()
                .WithColumn(nameof(NewsCreator.NickName)).AsString(32).NotNullable()
                ;
        }

        #endregion
    }
}