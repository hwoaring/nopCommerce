using FluentMigrator.Builders.Create.Table;
using Nop.Core.Domain.Customers;
using Nop.Core.Domain.Vendors;
using Nop.Data.Extensions;

namespace Nop.Data.Mapping.Builders.Vendors;

/// <summary>
/// Represents a vendor entity builder
/// </summary>
public partial class VendorStoreCustomerAuthorityBuilder : NopEntityBuilder<VendorStoreCustomerAuthority>
{
    #region Methods

    /// <summary>
    /// Apply entity configuration
    /// </summary>
    /// <param name="table">Create table expression builder</param>
    public override void MapEntity(CreateTableExpressionBuilder table)
    {
        table
            .WithColumn(nameof(VendorStoreCustomerAuthority.VendorStoreId)).AsInt32().ForeignKey<VendorStore>()
            .WithColumn(nameof(VendorStoreCustomerAuthority.CustomerId)).AsInt32().ForeignKey<Customer>()

            ;
    }

    #endregion

}
