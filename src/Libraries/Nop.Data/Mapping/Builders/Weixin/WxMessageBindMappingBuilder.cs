using System.Data;
using FluentMigrator.Builders.Create.Table;
using Nop.Core.Domain.Weixin;
using Nop.Data.Extensions;

namespace Nop.Data.Mapping.Builders.Weixin
{
    /// <summary>
    /// Represents a WxMessageBindMappingBuilder
    /// </summary>
    public partial class WxMessageBindMappingBuilder : NopEntityBuilder<WxMessageBindMapping>
    {
        #region Methods

        /// <summary>
        /// Apply entity configuration
        /// </summary>
        /// <param name="table">Create table expression builder</param>
        public override void MapEntity(CreateTableExpressionBuilder table)
        {
            table
                .WithColumn(nameof(WxMessageBindMapping.WxMessageId)).AsInt32().ForeignKey<WxMessage>();
                ;
        }

        #endregion
    }
}
