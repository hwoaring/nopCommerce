using FluentMigrator.Builders.Create.Table;
using Nop.Core.Domain.Vendors;
using Nop.Data.Extensions;

namespace Nop.Data.Mapping.Builders.Vendors;

/// <summary>
/// Represents a vendor entity builder
/// </summary>
public partial class VendorStockInboundBuilder : NopEntityBuilder<VendorStockInbound>
{
    #region Methods

    /// <summary>
    /// Apply entity configuration
    /// </summary>
    /// <param name="table">Create table expression builder</param>
    public override void MapEntity(CreateTableExpressionBuilder table)
    {
        table
            .WithColumn(nameof(VendorStockInbound.VendorId)).AsInt32().ForeignKey<Vendor>()
            .WithColumn(nameof(VendorStockInbound.InboundAntiCodeBox)).AsAnsiString(int.MaxValue).Nullable()
            .WithColumn(nameof(VendorStockInbound.InboundAntiCodeItem)).AsAnsiString(int.MaxValue).Nullable()
            .WithColumn(nameof(VendorStockInbound.Notes)).AsString(64).Nullable()
            .WithColumn(nameof(VendorStockInbound.ReturnOrderNumber)).AsAnsiString(64).Nullable()
            ;
    }

    #endregion

}
