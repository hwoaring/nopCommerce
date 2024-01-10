using FluentMigrator.Builders.Create.Table;
using Nop.Core.Domain.Customers;
using Nop.Core.Domain.Vendors;
using Nop.Data.Extensions;

namespace Nop.Data.Mapping.Builders.Vendors
{
    /// <summary>
    /// Represents a vendor entity builder
    /// </summary>
    public partial class VendorStoreBookingSeatBuilder : NopEntityBuilder<VendorStoreBookingSeat>
    {
        #region Methods

        /// <summary>
        /// Apply entity configuration
        /// </summary>
        /// <param name="table">Create table expression builder</param>
        public override void MapEntity(CreateTableExpressionBuilder table)
        {
            table
                .WithColumn(nameof(VendorStoreBookingSeat.VendorStoreId)).AsInt32().ForeignKey<VendorStore>()
                .WithColumn(nameof(VendorStoreBookingSeat.CustomerId)).AsInt32().ForeignKey<Customer>()
                .WithColumn(nameof(VendorStoreBookingSeat.Name)).AsString(32).Nullable()
                .WithColumn(nameof(VendorStoreBookingSeat.Content)).AsString(128).Nullable()

                ;
        }

        #endregion

    }
}
