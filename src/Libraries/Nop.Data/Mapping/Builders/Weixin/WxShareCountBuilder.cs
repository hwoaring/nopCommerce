using System.Data;
using FluentMigrator.Builders.Create.Table;
using Nop.Core.Domain.Customers;
using Nop.Core.Domain.Weixin;
using Nop.Data.Extensions;

namespace Nop.Data.Mapping.Builders.Weixin
{
    /// <summary>
    /// Represents a WShare Count entity builder
    /// </summary>
    public partial class WxShareCountBuilder : NopEntityBuilder<WxShareCount>
    {
        #region Methods

        /// <summary>
        /// Apply entity configuration
        /// </summary>
        /// <param name="table">Create table expression builder</param>
        public override void MapEntity(CreateTableExpressionBuilder table)
        {
            table
                .WithColumn(nameof(WxShareCount.CustomerId)).AsInt32().ForeignKey<Customer>()
                .WithColumn(nameof(WxShareCount.WxShareLinkId)).AsInt32().ForeignKey<WxShareLink>()
                ;
        }

        #endregion
    }
}
