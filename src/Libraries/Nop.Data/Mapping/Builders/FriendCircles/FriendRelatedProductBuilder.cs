using FluentMigrator.Builders.Create.Table;
using Nop.Core.Domain.FriendCircles;

namespace Nop.Data.Mapping.Builders.FriendCircles
{
    /// <summary>
    /// 朋友圈相关产品
    /// </summary>
    public partial class FriendRelatedProductBuilder : NopEntityBuilder<FriendRelatedProduct>
    {
        #region Methods

        /// <summary>
        /// Apply entity configuration
        /// </summary>
        /// <param name="table">Create table expression builder</param>
        public override void MapEntity(CreateTableExpressionBuilder table)
        {
        }

        #endregion
    }
}