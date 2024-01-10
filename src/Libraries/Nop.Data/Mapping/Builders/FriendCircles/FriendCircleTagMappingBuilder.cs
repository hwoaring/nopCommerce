using FluentMigrator.Builders.Create.Table;
using Nop.Core.Domain.Catalog;
using Nop.Core.Domain.FriendCircles;
using Nop.Core.Domain.Media;
using Nop.Data.Extensions;

namespace Nop.Data.Mapping.Builders.FriendCircles
{
    /// <summary>
    /// 朋友圈标签映射
    /// </summary>
    public partial class FriendCircleTagMappingBuilder : NopEntityBuilder<FriendCircleTagMapping>
    {
        #region Methods

        /// <summary>
        /// Apply entity configuration
        /// </summary>
        /// <param name="table">Create table expression builder</param>
        public override void MapEntity(CreateTableExpressionBuilder table)
        {
            table
                .WithColumn(nameof(FriendCircleTagMapping.FriendCircleId)).AsInt32().PrimaryKey().ForeignKey<FriendCircle>()
                .WithColumn(nameof(FriendCircleTagMapping.FriendCircleTagId)).AsInt32().PrimaryKey().ForeignKey<FriendCircleTag>()
                
                ;
        }

        #endregion
    }
}