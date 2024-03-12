using FluentMigrator.Builders.Create.Table;
using Nop.Core.Domain.Customers;
using Nop.Core.Domain.FriendCircles;
using Nop.Core.Domain.Stores;
using Nop.Data.Extensions;

namespace Nop.Data.Mapping.Builders.FriendCircles
{
    /// <summary>
    /// 朋友圈评论点赞
    /// </summary>
    public partial class FriendCircleFavoriteMappingBuilder : NopEntityBuilder<FriendCircleFavoriteMapping>
    {
        #region Methods

        /// <summary>
        /// Apply entity configuration
        /// </summary>
        /// <param name="table">Create table expression builder</param>
        public override void MapEntity(CreateTableExpressionBuilder table)
        {
            table
                .WithColumn(nameof(FriendCircleFavoriteMapping.FriendCircleId)).AsInt32().ForeignKey<FriendCircle>()
                ;
        }

        #endregion
    }
}