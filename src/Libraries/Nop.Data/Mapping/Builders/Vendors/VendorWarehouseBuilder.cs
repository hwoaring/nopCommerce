using FluentMigrator.Builders.Create.Table;
using Nop.Core.Domain.Vendors;
using Nop.Data.Extensions;

namespace Nop.Data.Mapping.Builders.Vendors;

/// <summary>
/// Represents a vendor entity builder
/// </summary>
public partial class VendorWarehouseBuilder : NopEntityBuilder<VendorWarehouse>
{
    #region Methods

    /// <summary>
    /// Apply entity configuration
    /// </summary>
    /// <param name="table">Create table expression builder</param>
    public override void MapEntity(CreateTableExpressionBuilder table)
    {
        table
            .WithColumn(nameof(VendorWarehouse.VendorId)).AsInt32().ForeignKey<Vendor>()
            .WithColumn(nameof(VendorWarehouse.SelfPickupPhone)).AsString(32).Nullable()
            .WithColumn(nameof(VendorWarehouse.Longitude)).AsDecimal(9,6).Nullable()
            .WithColumn(nameof(VendorWarehouse.Latitude)).AsDecimal(9, 6).Nullable()

            ;
    }

    #endregion

}
