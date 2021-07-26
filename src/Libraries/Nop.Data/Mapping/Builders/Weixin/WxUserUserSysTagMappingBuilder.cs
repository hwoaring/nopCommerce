using System.Data;
using FluentMigrator.Builders.Create.Table;
using Nop.Core.Domain.Customers;
using Nop.Core.Domain.Weixin;
using Nop.Data.Extensions;

namespace Nop.Data.Mapping.Builders.Weixin
{
    /// <summary>
    /// Represents a WxUserUserSysTagMappingBuilder
    /// </summary>
    public partial class WxUserUserSysTagMappingBuilder : NopEntityBuilder<WxUserUserSysTagMapping>
    {
        #region Methods

        /// <summary>
        /// Apply entity configuration
        /// </summary>
        /// <param name="table">Create table expression builder</param>
        public override void MapEntity(CreateTableExpressionBuilder table)
        {
            table
                .WithColumn(NameCompatibilityManager.GetColumnName(typeof(WxUserUserSysTagMapping), nameof(WxUserUserSysTagMapping.CustomerId)))
                    .AsInt32().PrimaryKey().ForeignKey<Customer>()
                .WithColumn(NameCompatibilityManager.GetColumnName(typeof(WxUserUserSysTagMapping), nameof(WxUserUserSysTagMapping.WxUserSysTagId)))
                    .AsInt32().PrimaryKey().ForeignKey<WxUserSysTag>()
                ;
        }

        #endregion
    }
}
