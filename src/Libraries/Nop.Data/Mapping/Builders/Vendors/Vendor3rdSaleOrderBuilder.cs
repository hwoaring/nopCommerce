using FluentMigrator.Builders.Create.Table;
using Nop.Core.Domain.Catalog;
using Nop.Core.Domain.Vendors;
using Nop.Data.Extensions;

namespace Nop.Data.Mapping.Builders.Vendors
{
    /// <summary>
    /// Represents a vendor entity builder
    /// </summary>
    public partial class Vendor3rdSaleOrderBuilder : NopEntityBuilder<Vendor3rdSaleOrder>
    {
        #region Methods

        /// <summary>
        /// Apply entity configuration
        /// </summary>
        /// <param name="table">Create table expression builder</param>
        public override void MapEntity(CreateTableExpressionBuilder table)
        {
            table
                .WithColumn(nameof(Vendor3rdSaleOrder.VendorId)).AsInt32().ForeignKey<Vendor>()
                .WithColumn(nameof(Vendor3rdSaleOrder.Product3rdSalePlatformId)).AsInt32().ForeignKey<Product3rdSalePlatform>()
                .WithColumn(nameof(Vendor3rdSaleOrder.OrderSerialNumber)).AsAnsiString(128).NotNullable()

                ;
        }

        #endregion

    }
}
