using FluentMigrator.Builders.Create.Table;
using Nop.Core.Domain.Orders;
using Nop.Core.Domain.Shipping;
using Nop.Data.Extensions;

namespace Nop.Data.Mapping.Builders.Shipping
{
    /// <summary>
    /// Represents a shipment entity builder
    /// </summary>
    public partial class ExpressCompanyBuilder : NopEntityBuilder<ExpressCompany>
    {
        #region Methods

        /// <summary>
        /// Apply entity configuration
        /// </summary>
        /// <param name="table">Create table expression builder</param>
        public override void MapEntity(CreateTableExpressionBuilder table)
        {
            table
                .WithColumn(nameof(ExpressCompany.Name)).AsString(64).NotNullable()
                .WithColumn(nameof(ExpressCompany.NameCode)).AsString(64).Nullable()
                .WithColumn(nameof(ExpressCompany.Description)).AsString(1024).Nullable()
                .WithColumn(nameof(ExpressCompany.Url)).AsAnsiString(1024).Nullable()
                ;
        }

        #endregion
    }
}