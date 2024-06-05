using System.Data;
using FluentMigrator.Builders.Create.Table;
using Nop.Core.Domain.Vendors;
using Nop.Data.Extensions;

namespace Nop.Data.Mapping.Builders.Vendors;

/// <summary>
/// Represents a vendor entity builder
/// </summary>
public partial class VendorStoreBuilder : NopEntityBuilder<VendorStore>
{
    #region Methods

    /// <summary>
    /// Apply entity configuration
    /// </summary>
    /// <param name="table">Create table expression builder</param>
    public override void MapEntity(CreateTableExpressionBuilder table)
    {
        table
            .WithColumn(nameof(VendorStore.VendorId)).AsInt32().ForeignKey<Vendor>()
            .WithColumn(nameof(VendorStore.Name)).AsString(128).NotNullable()
            .WithColumn(nameof(VendorStore.Slogan)).AsString(128).Nullable()
            .WithColumn(nameof(VendorStore.Description)).AsString(512).Nullable()
            .WithColumn(nameof(VendorStore.Content)).AsString(4000).Nullable()
            .WithColumn(nameof(VendorStore.DomainUrl)).AsAnsiString(512).Nullable()
            .WithColumn(nameof(VendorStore.ContactName)).AsString(32).Nullable()
            .WithColumn(nameof(VendorStore.SecurityEmail)).AsAnsiString(128).Nullable()
            .WithColumn(nameof(VendorStore.SecurityPhone)).AsAnsiString(64).Nullable()
            .WithColumn(nameof(VendorStore.ContractPhone)).AsAnsiString(64).Nullable()
            .WithColumn(nameof(VendorStore.ContractFax)).AsString(64).Nullable()
            .WithColumn(nameof(VendorStore.FinancePhone)).AsString(64).Nullable()
            .WithColumn(nameof(VendorStore.BookingPhone)).AsString(64).Nullable()
            .WithColumn(nameof(VendorStore.OpeningTime)).AsString(512).Nullable()
            .WithColumn(nameof(VendorStore.BusinessName)).AsString(128).Nullable()
            .WithColumn(nameof(VendorStore.BusinessCode)).AsString(64).Nullable()
            .WithColumn(nameof(VendorStore.FoodCode)).AsString(64).Nullable()
            .WithColumn(nameof(VendorStore.AdminComment)).AsString(512).Nullable()
            .WithColumn(nameof(VendorStore.BankCode)).AsAnsiString(64).Nullable()
            .WithColumn(nameof(VendorStore.BankNumber)).AsAnsiString(32).Nullable()
            .WithColumn(nameof(VendorStore.BankAccount)).AsAnsiString(64).Nullable()
            .WithColumn(nameof(VendorStore.BankOperatorPhone)).AsAnsiString(64).Nullable()
            .WithColumn(nameof(VendorStore.BankVerifierPhone)).AsAnsiString(64).Nullable()
            .WithColumn(nameof(VendorStore.BankAccountName)).AsString(128).Nullable()
            .WithColumn(nameof(VendorStore.StoreCloseNotice)).AsString(512).Nullable()
            .WithColumn(nameof(VendorStore.MetaKeywords)).AsString(128).Nullable()
            .WithColumn(nameof(VendorStore.MetaDescription)).AsString(512).Nullable()
            .WithColumn(nameof(VendorStore.MetaTitle)).AsString(128).Nullable()

            ;
    }

    #endregion

}
