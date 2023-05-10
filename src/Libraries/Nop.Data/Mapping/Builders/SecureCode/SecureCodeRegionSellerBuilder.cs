using FluentMigrator.Builders.Create.Table;
using Nop.Core.Domain.SecureCode;
using Nop.Data.Extensions;

namespace Nop.Data.Mapping.Builders.SecureCode
{
    /// <summary>
    /// Represents a SecureCodeRegionSeller entity builder
    /// </summary>
    public partial class SecureCodeRegionSellerBuilder : NopEntityBuilder<SecureCodeRegionSeller>
    {
        #region Methods

        /// <summary>
        /// Apply entity configuration
        /// </summary>
        /// <param name="table">Create table expression builder</param>
        public override void MapEntity(CreateTableExpressionBuilder table)
        {
            table
                .WithColumn(nameof(SecureCodeRegionSeller.Name)).AsString(32).Nullable()
                .WithColumn(nameof(SecureCodeRegionSeller.ContactNumber)).AsAnsiString(16).Nullable()
                .WithColumn(nameof(SecureCodeRegionSeller.Address)).AsString(128).Nullable()
                .WithColumn(nameof(SecureCodeRegionSeller.RegionCodes)).AsAnsiString(5120).Nullable()
                .WithColumn(nameof(SecureCodeRegionSeller.Description)).AsString(1024).Nullable()
                .WithColumn(nameof(SecureCodeRegionSeller.Longitude)).AsDecimal(10, 6)
                .WithColumn(nameof(SecureCodeRegionSeller.Latitude)).AsDecimal(10, 6)
                ;
        }

        #endregion
    }
}