using System.Data;
using FluentMigrator.Builders.Create.Table;
using Nop.Core.Domain.Stores;
using Nop.Core.Domain.Weixin;
using Nop.Data.Extensions;

namespace Nop.Data.Mapping.Builders.Weixin
{
    /// <summary>
    /// Represents a WxUserTagBuilder
    /// </summary>
    public partial class WxUserTagBuilder : NopEntityBuilder<WxUserTag>
    {
        #region Methods

        /// <summary>
        /// Apply entity configuration
        /// </summary>
        /// <param name="table">Create table expression builder</param>
        public override void MapEntity(CreateTableExpressionBuilder table)
        {
            table
                .WithColumn(nameof(WxUserTag.StoreId)).AsInt32().ForeignKey<Store>()
                .WithColumn(nameof(WxUserTag.Name)).AsString(32).NotNullable()
                ;
        }

        #endregion
    }
}
