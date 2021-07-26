using FluentMigrator.Builders.Create.Table;
using Nop.Core.Domain.Customers;
using Nop.Core.Domain.Weixin;
using Nop.Data.Extensions;

namespace Nop.Data.Mapping.Builders.Weixin
{
    /// <summary>
    /// Represents a WxLocationBuilder
    /// </summary>
    public partial class WxLocationBuilder : NopEntityBuilder<WxLocation>
    {
        #region Methods

        /// <summary>
        /// Apply entity configuration
        /// </summary>
        /// <param name="table">Create table expression builder</param>
        public override void MapEntity(CreateTableExpressionBuilder table)
        {
            table
                .WithColumn(nameof(WxLocation.CustomerId)).AsInt32().ForeignKey<Customer>()
                .WithColumn(nameof(WxLocation.Latitude)).AsDecimal(9, 6)
                .WithColumn(nameof(WxLocation.Longitude)).AsDecimal(9, 6)
                .WithColumn(nameof(WxLocation.Precision)).AsDecimal(9, 6)
                ;
        }

        #endregion
    }
}
