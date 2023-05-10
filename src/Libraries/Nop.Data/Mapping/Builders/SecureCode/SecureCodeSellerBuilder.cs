using FluentMigrator.Builders.Create.Table;
using Nop.Core.Domain.SecureCode;
using Nop.Data.Extensions;

namespace Nop.Data.Mapping.Builders.SecureCode
{
    /// <summary>
    /// Represents a SecureCodeSeller entity builder
    /// </summary>
    public partial class SecureCodeSellerBuilder : NopEntityBuilder<SecureCodeSeller>
    {
        #region Methods

        /// <summary>
        /// Apply entity configuration
        /// </summary>
        /// <param name="table">Create table expression builder</param>
        public override void MapEntity(CreateTableExpressionBuilder table)
        {
            table
                .WithColumn(nameof(SecureCodeSeller.Name)).AsString(64).NotNullable()
                .WithColumn(nameof(SecureCodeSeller.ServicePhoneNumber)).AsAnsiString(32).Nullable()
                .WithColumn(nameof(SecureCodeSeller.ContactNumber)).AsAnsiString(32).Nullable()
                .WithColumn(nameof(SecureCodeSeller.Address)).AsString(128).Nullable()
                .WithColumn(nameof(SecureCodeSeller.QrCodeUrl)).AsAnsiString(1024).Nullable()
                .WithColumn(nameof(SecureCodeSeller.ShoppingUrl)).AsAnsiString(1024).Nullable()
                .WithColumn(nameof(SecureCodeSeller.ImageUrl)).AsAnsiString(1024).Nullable()
                .WithColumn(nameof(SecureCodeSeller.BusinessLicense)).AsAnsiString(512).Nullable()
                .WithColumn(nameof(SecureCodeSeller.BusinessCode)).AsAnsiString(64).Nullable()
                .WithColumn(nameof(SecureCodeSeller.BusinessLicenseUtc)).AsDateTime2().Nullable()
                .WithColumn(nameof(SecureCodeSeller.ProductionLicense)).AsAnsiString(512).Nullable()
                .WithColumn(nameof(SecureCodeSeller.ProductionCode)).AsAnsiString(64).Nullable()
                .WithColumn(nameof(SecureCodeSeller.ProductionLicenseUtc)).AsDateTime2().Nullable()
                .WithColumn(nameof(SecureCodeSeller.FoodLicense)).AsAnsiString(512).Nullable()
                .WithColumn(nameof(SecureCodeSeller.FoodCode)).AsAnsiString(64).Nullable()
                .WithColumn(nameof(SecureCodeSeller.FoodLicenseUtc)).AsDateTime2().Nullable()
                .WithColumn(nameof(SecureCodeSeller.Description)).AsString(1024).Nullable()
                .WithColumn(nameof(SecureCodeSeller.ExpirationDateUtc)).AsDateTime2().Nullable()
                ;
        }

        #endregion
    }
}