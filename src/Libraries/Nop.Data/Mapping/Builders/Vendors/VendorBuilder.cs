using FluentMigrator.Builders.Create.Table;
using Nop.Core.Domain.Vendors;

namespace Nop.Data.Mapping.Builders.Vendors
{
    /// <summary>
    /// Represents a vendor entity builder
    /// </summary>
    public partial class VendorBuilder : NopEntityBuilder<Vendor>
    {
        #region Methods

        /// <summary>
        /// Apply entity configuration
        /// </summary>
        /// <param name="table">Create table expression builder</param>
        public override void MapEntity(CreateTableExpressionBuilder table)
        {
            table
                .WithColumn(nameof(Vendor.Name)).AsString(400).NotNullable()
                .WithColumn(nameof(Vendor.Email)).AsString(400).Nullable()
                .WithColumn(nameof(Vendor.StoreName)).AsString(512).Nullable()
                .WithColumn(nameof(Vendor.ContactNumber)).AsAnsiString(64).Nullable()
                .WithColumn(nameof(Vendor.ContactAddress)).AsString(1024).Nullable()
                .WithColumn(nameof(Vendor.ShoppingMallLink)).AsAnsiString(1024).Nullable()
                .WithColumn(nameof(Vendor.OpenHours)).AsString(512).Nullable()
                .WithColumn(nameof(Vendor.MetaKeywords)).AsString(400).Nullable()
                .WithColumn(nameof(Vendor.MetaTitle)).AsString(400).Nullable()
                .WithColumn(nameof(Vendor.MetaImageUrl)).AsAnsiString(1024).Nullable()
                .WithColumn(nameof(Vendor.MetaLinkUrl)).AsAnsiString(1024).Nullable()
                .WithColumn(nameof(Vendor.ShareImageUrl)).AsAnsiString(1024).Nullable()
                .WithColumn(nameof(Vendor.ShareLinkUrl)).AsAnsiString(1024).Nullable()
                .WithColumn(nameof(Vendor.PageSizeOptions)).AsString(200).Nullable();
        }

        #endregion
    }
}