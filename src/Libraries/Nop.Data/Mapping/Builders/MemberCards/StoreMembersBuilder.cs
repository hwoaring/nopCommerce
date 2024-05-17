using FluentMigrator.Builders.Create.Table;
using Nop.Core.Domain.Customers;
using Nop.Core.Domain.MemberCards;
using Nop.Core.Domain.Vendors;
using Nop.Data.Extensions;

namespace Nop.Data.Mapping.Builders.MemberCards;

/// <summary>
/// Represents a vendor entity builder
/// </summary>
public partial class StoreMembersBuilder : NopEntityBuilder<StoreMembers>
{
    #region Methods

    /// <summary>
    /// Apply entity configuration
    /// </summary>
    /// <param name="table">Create table expression builder</param>
    public override void MapEntity(CreateTableExpressionBuilder table)
    {
        table
            .WithColumn(nameof(StoreMembers.CustomerId)).AsInt32().ForeignKey<Customer>()
            .WithColumn(nameof(StoreMembers.VendorStoreId)).AsInt32().ForeignKey<VendorStore>()
            .WithColumn(nameof(StoreMembers.Name)).AsString(32).Nullable()
            .WithColumn(nameof(StoreMembers.Notes)).AsString(512).Nullable()
            .WithColumn(nameof(StoreMembers.IDCardNumber)).AsString(32).Nullable()
            .WithColumn(nameof(StoreMembers.CourtesyName)).AsString(32).Nullable()
            .WithColumn(nameof(StoreMembers.HeaderImage)).AsAnsiString(512).Nullable()
            .WithColumn(nameof(StoreMembers.PhoneNumber)).AsAnsiString(32).Nullable()
            .WithColumn(nameof(StoreMembers.OtherPhoneNumbers)).AsAnsiString(128).Nullable()
            .WithColumn(nameof(StoreMembers.Description)).AsString(512).Nullable()

            ;
    }

    #endregion
}