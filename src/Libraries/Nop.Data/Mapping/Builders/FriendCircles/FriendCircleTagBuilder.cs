using FluentMigrator.Builders.Create.Table;
using Nop.Core.Domain.FriendCircles;

namespace Nop.Data.Mapping.Builders.FriendCircles
{
    /// <summary>
    /// 朋友圈标签
    /// </summary>
    public partial class FriendCircleTagBuilder : NopEntityBuilder<FriendCircleTag>
    {
        #region Methods

        /// <summary>
        /// Apply entity configuration
        /// </summary>
        /// <param name="table">Create table expression builder</param>
        public override void MapEntity(CreateTableExpressionBuilder table)
        {
            table.WithColumn(nameof(FriendCircleTag.Name)).AsString(32).NotNullable();
        }

        #endregion
    }
}