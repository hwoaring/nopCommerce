using FluentMigrator.Builders.Create.Table;
using Nop.Core.Domain.Vendors;
using Nop.Data.Extensions;

namespace Nop.Data.Mapping.Builders.Vendors
{
    /// <summary>
    /// Represents a vendor entity builder
    /// </summary>
    public partial class VendorStoreSeatBuilder : NopEntityBuilder<VendorStoreSeat>
    {
        #region Methods

        /// <summary>
        /// Apply entity configuration
        /// </summary>
        /// <param name="table">Create table expression builder</param>
        public override void MapEntity(CreateTableExpressionBuilder table)
        {
            table
                .WithColumn(nameof(VendorStoreSeat.VendorStoreId)).AsInt32().ForeignKey<VendorStore>()
                .WithColumn(nameof(VendorStoreSeat.SeatName)).AsString(64).Nullable()
                .WithColumn(nameof(VendorStoreSeat.SeatNumber)).AsString(32).Nullable()

                ;
        }

        #endregion

    }
}
