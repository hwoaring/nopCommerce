using FluentMigrator.Builders.Create.Table;
using Nop.Core.Domain.Vendors;
using Nop.Data.Extensions;

namespace Nop.Data.Mapping.Builders.Vendors
{
    /// <summary>
    /// Represents a vendor note entity builder
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
                .WithColumn(nameof(VendorStore.RelatedStoreIds)).AsAnsiString(1024).Nullable()
                .WithColumn(nameof(VendorStore.Name)).AsString(16).Nullable()
                .WithColumn(nameof(VendorStore.Slogan)).AsString(32).Nullable()
                .WithColumn(nameof(VendorStore.Address)).AsString(128).Nullable()
                .WithColumn(nameof(VendorStore.ContractNumber)).AsAnsiString(32).Nullable()
                .WithColumn(nameof(VendorStore.ImageUrl)).AsAnsiString(1024).Nullable()
                .WithColumn(nameof(VendorStore.QrCode)).AsAnsiString(1024).Nullable()
                .WithColumn(nameof(VendorStore.Description)).AsString(1024).Nullable()
                .WithColumn(nameof(VendorStore.BusinessName)).AsString(64).Nullable()
                .WithColumn(nameof(VendorStore.BusinessLicense)).AsAnsiString(512).Nullable()
                .WithColumn(nameof(VendorStore.BusinessCode)).AsAnsiString(64).Nullable()
                .WithColumn(nameof(VendorStore.BusinessLicenseUtc)).AsDateTime2().Nullable()
                .WithColumn(nameof(VendorStore.FoodLicense)).AsAnsiString(512).Nullable()
                .WithColumn(nameof(VendorStore.FoodCode)).AsAnsiString(64).Nullable()
                .WithColumn(nameof(VendorStore.FoodLicenseUtc)).AsDateTime2().Nullable()
                .WithColumn(nameof(VendorStore.Province)).AsString(32).Nullable()
                .WithColumn(nameof(VendorStore.City)).AsString(32).Nullable()
                .WithColumn(nameof(VendorStore.County)).AsString(32).Nullable()
                .WithColumn(nameof(VendorStore.Longitude)).AsDecimal(10,6)
                .WithColumn(nameof(VendorStore.Province)).AsDecimal(10,6)
                .WithColumn(nameof(VendorStore.ShareTitle)).AsString(128).Nullable()
                .WithColumn(nameof(VendorStore.ShareLink)).AsAnsiString(512).Nullable()
                .WithColumn(nameof(VendorStore.ShareDesc)).AsString(128).Nullable()
                .WithColumn(nameof(VendorStore.ShareImgUrl)).AsAnsiString(512).Nullable()
                .WithColumn(nameof(VendorStore.VendorId)).AsInt32().ForeignKey<Vendor>();
        }

        #endregion
    }
}