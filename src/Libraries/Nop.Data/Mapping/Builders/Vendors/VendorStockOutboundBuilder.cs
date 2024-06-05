using FluentMigrator.Builders.Create.Table;
using Nop.Core.Domain.Vendors;
using Nop.Data.Extensions;

namespace Nop.Data.Mapping.Builders.Vendors;

/// <summary>
/// Represents a vendor entity builder
/// </summary>
public partial class VendorStockOutboundBuilder : NopEntityBuilder<VendorStockOutbound>
{
    #region Methods

    /// <summary>
    /// Apply entity configuration
    /// </summary>
    /// <param name="table">Create table expression builder</param>
    public override void MapEntity(CreateTableExpressionBuilder table)
    {
        table
            .WithColumn(nameof(VendorStockOutbound.VendorId)).AsInt32().ForeignKey<Vendor>()
            .WithColumn(nameof(VendorStockOutbound.OutboundAntiCodeBox)).AsAnsiString(int.MaxValue).Nullable()
            .WithColumn(nameof(VendorStockOutbound.OutboundAntiCodeItem)).AsAnsiString(int.MaxValue).Nullable()
            .WithColumn(nameof(VendorStockOutbound.Notes)).AsString(64).Nullable()

            ;
    }

    #endregion

}
