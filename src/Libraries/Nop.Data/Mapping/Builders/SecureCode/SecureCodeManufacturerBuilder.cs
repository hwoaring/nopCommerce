using FluentMigrator.Builders.Create.Table;
using Nop.Core.Domain.SecureCode;
using Nop.Data.Extensions;

namespace Nop.Data.Mapping.Builders.SecureCode
{
    /// <summary>
    /// Represents a SecureCodeManufacturer entity builder
    /// </summary>
    public partial class SecureCodeManufacturerBuilder : NopEntityBuilder<SecureCodeManufacturer>
    {
        #region Methods

        /// <summary>
        /// Apply entity configuration
        /// </summary>
        /// <param name="table">Create table expression builder</param>
        public override void MapEntity(CreateTableExpressionBuilder table)
        {
            table
                .WithColumn(nameof(SecureCodeManufacturer.Name)).AsString(32).NotNullable()
                .WithColumn(nameof(SecureCodeManufacturer.ServicePhoneNumber)).AsAnsiString(32).Nullable()
                .WithColumn(nameof(SecureCodeManufacturer.MobilePhone)).AsAnsiString(32).Nullable()
                .WithColumn(nameof(SecureCodeManufacturer.Address)).AsString(64).Nullable()
                .WithColumn(nameof(SecureCodeManufacturer.QrCodeUrl)).AsAnsiString(1024).Nullable()
                .WithColumn(nameof(SecureCodeManufacturer.ImageUrl)).AsAnsiString(512).Nullable()
                .WithColumn(nameof(SecureCodeManufacturer.BusinessLicense)).AsAnsiString(512).Nullable()
                .WithColumn(nameof(SecureCodeManufacturer.BusinessCode)).AsAnsiString(64).Nullable()
                .WithColumn(nameof(SecureCodeManufacturer.BusinessLicenseUtc)).AsDateTime2().Nullable()
                .WithColumn(nameof(SecureCodeManufacturer.ProductionLicense)).AsAnsiString(512).Nullable()
                .WithColumn(nameof(SecureCodeManufacturer.ProductionCode)).AsAnsiString(64).Nullable()
                .WithColumn(nameof(SecureCodeManufacturer.ProductionLicenseUtc)).AsDateTime2().Nullable()
                .WithColumn(nameof(SecureCodeManufacturer.FoodLicense)).AsAnsiString(512).Nullable()
                .WithColumn(nameof(SecureCodeManufacturer.FoodCode)).AsAnsiString(64).Nullable()
                .WithColumn(nameof(SecureCodeManufacturer.FoodLicenseUtc)).AsDateTime2().Nullable()
                .WithColumn(nameof(SecureCodeManufacturer.Description)).AsString(1024).Nullable()
                ;
        }

        #endregion
    }
}