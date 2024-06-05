using FluentMigrator.Builders.Create.Table;
using Nop.Core.Domain.Vendors;
using Nop.Data.Extensions;

namespace Nop.Data.Mapping.Builders.Vendors;

/// <summary>
/// Represents a vendor entity builder
/// </summary>
public partial class VendorStockProductBuilder : NopEntityBuilder<VendorStockProduct>
{
    #region Methods

    /// <summary>
    /// Apply entity configuration
    /// </summary>
    /// <param name="table">Create table expression builder</param>
    public override void MapEntity(CreateTableExpressionBuilder table)
    {
        table
            .WithColumn(nameof(VendorStockProduct.VendorId)).AsInt32().ForeignKey<Vendor>()
            .WithColumn(nameof(VendorStockProduct.Name)).AsString(64).NotNullable()
            .WithColumn(nameof(VendorStockProduct.UnitName)).AsAnsiString(32).NotNullable()

            ;
    }

    #endregion

}
