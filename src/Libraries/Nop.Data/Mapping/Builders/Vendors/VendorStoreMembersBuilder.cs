using FluentMigrator.Builders.Create.Table;
using Nop.Core.Domain.Customers;
using Nop.Core.Domain.Vendors;
using Nop.Data.Extensions;

namespace Nop.Data.Mapping.Builders.Vendors;

/// <summary>
/// Represents a vendor entity builder
/// </summary>
public partial class VendorStoreMembersBuilder : NopEntityBuilder<VendorStoreMembers>
{
    #region Methods

    /// <summary>
    /// Apply entity configuration
    /// </summary>
    /// <param name="table">Create table expression builder</param>
    public override void MapEntity(CreateTableExpressionBuilder table)
    {
        table
            .WithColumn(nameof(VendorStoreMembers.CustomerId)).AsInt32().ForeignKey<Customer>()
            .WithColumn(nameof(VendorStoreMembers.Name)).AsString(32).Nullable()
            .WithColumn(nameof(VendorStoreMembers.Notes)).AsString(512).Nullable()
            .WithColumn(nameof(VendorStoreMembers.IDCardNumber)).AsString(32).Nullable()
            .WithColumn(nameof(VendorStoreMembers.CourtesyName)).AsString(32).Nullable()
            .WithColumn(nameof(VendorStoreMembers.HeaderImage)).AsAnsiString(512).Nullable()
            .WithColumn(nameof(VendorStoreMembers.PhoneNumber)).AsAnsiString(32).Nullable()
            .WithColumn(nameof(VendorStoreMembers.OtherPhoneNumbers)).AsAnsiString(128).Nullable()
            .WithColumn(nameof(VendorStoreMembers.Description)).AsString(512).Nullable()

            ;
    }

    #endregion
}