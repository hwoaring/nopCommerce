using FluentMigrator.Builders.Create.Table;
using Nop.Core.Domain.Customers;
using Nop.Core.Domain.Vendors;
using Nop.Data.Extensions;

namespace Nop.Data.Mapping.Builders.Vendors;

/// <summary>
/// Represents a vendor entity builder
/// </summary>
public partial class VendorStoreMemberBuilder : NopEntityBuilder<VendorStoreMember>
{
    #region Methods

    /// <summary>
    /// Apply entity configuration
    /// </summary>
    /// <param name="table">Create table expression builder</param>
    public override void MapEntity(CreateTableExpressionBuilder table)
    {
        table
            .WithColumn(nameof(VendorStoreMember.CustomerId)).AsInt32().ForeignKey<Customer>()
            .WithColumn(nameof(VendorStoreMember.VendorStoreId)).AsInt32().ForeignKey<VendorStore>()
            .WithColumn(nameof(VendorStoreMember.Name)).AsString(32).Nullable()
            .WithColumn(nameof(VendorStoreMember.Notes)).AsString(512).Nullable()
            .WithColumn(nameof(VendorStoreMember.IDCardNumber)).AsString(32).Nullable()
            .WithColumn(nameof(VendorStoreMember.CourtesyName)).AsString(32).Nullable()
            .WithColumn(nameof(VendorStoreMember.HeaderImage)).AsAnsiString(512).Nullable()
            .WithColumn(nameof(VendorStoreMember.PhoneNumber)).AsAnsiString(32).Nullable()
            .WithColumn(nameof(VendorStoreMember.OtherPhoneNumbers)).AsAnsiString(128).Nullable()
            .WithColumn(nameof(VendorStoreMember.Description)).AsString(1024).Nullable()
            .WithColumn(nameof(VendorStoreMember.ExpireTimeOnUtc)).AsDateTime2().Nullable()
            .WithColumn(nameof(VendorStoreMember.BirthOfDateUtc)).AsDateTime2().Nullable()
            .WithColumn(nameof(VendorStoreMember.UpgradeTimeOnUtc)).AsDateTime2().Nullable()
            .WithColumn(nameof(VendorStoreMember.LunarBirthOfDateUtc)).AsDateTime2().Nullable()
            ;
    }

    #endregion
}