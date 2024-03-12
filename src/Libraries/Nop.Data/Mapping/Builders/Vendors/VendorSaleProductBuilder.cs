using FluentMigrator.Builders.Create.Table;
using Nop.Core.Domain.Catalog;
using Nop.Core.Domain.Vendors;
using Nop.Data.Extensions;

namespace Nop.Data.Mapping.Builders.Vendors;

/// <summary>
/// Represents a vendor entity builder
/// </summary>
public partial class VendorSaleProductBuilder : NopEntityBuilder<VendorSaleProduct>
{
    #region Methods

    /// <summary>
    /// Apply entity configuration
    /// </summary>
    /// <param name="table">Create table expression builder</param>
    public override void MapEntity(CreateTableExpressionBuilder table)
    {
        table
            .WithColumn(nameof(VendorSaleProduct.VendorId)).AsInt32().ForeignKey<Vendor>()
            .WithColumn(nameof(VendorSaleProduct.ProductId)).AsInt32().ForeignKey<Product>()

            ;
    }

    #endregion

}
