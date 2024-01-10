using FluentMigrator.Builders.Create.Table;
using Nop.Core.Domain.Customers;
using Nop.Core.Domain.Topics;
using Nop.Core.Domain.Stores;
using Nop.Data.Extensions;

namespace Nop.Data.Mapping.Builders.Topics
{
    /// <summary>
    /// 主题点赞
    /// </summary>
    public partial class TopicFavoriteMappingBuilder : NopEntityBuilder<TopicFavoriteMapping>
    {
        #region Methods

        /// <summary>
        /// Apply entity configuration
        /// </summary>
        /// <param name="table">Create table expression builder</param>
        public override void MapEntity(CreateTableExpressionBuilder table)
        {
            table
                .WithColumn(nameof(TopicFavoriteMapping.TopicId)).AsInt32().ForeignKey<Topic>()
                .WithColumn(nameof(TopicFavoriteMapping.CustomerId)).AsInt32().ForeignKey<Customer>()
                ;
        }

        #endregion
    }
}