using FluentMigrator.Builders.Create.Table;
using Nop.Core.Domain.Orders;
using Nop.Core.Domain.Shipping;
using Nop.Data.Extensions;

namespace Nop.Data.Mapping.Builders.Shipping;

/// <summary>
/// Represents a shipment entity builder
/// </summary>
public partial class ShippingCompanyBuilder : NopEntityBuilder<ShippingCompany>
{
    #region Methods

    /// <summary>
    /// Apply entity configuration
    /// </summary>
    /// <param name="table">Create table expression builder</param>
    public override void MapEntity(CreateTableExpressionBuilder table)
    {
        table
            .WithColumn(nameof(ShippingCompany.Name)).AsString(32).NotNullable()
            .WithColumn(nameof(ShippingCompany.TrackingNumberRegEx)).AsAnsiString(128).Nullable()

            ;
    }

    #endregion
}