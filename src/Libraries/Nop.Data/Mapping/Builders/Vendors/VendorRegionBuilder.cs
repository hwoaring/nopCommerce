using FluentMigrator.Builders.Create.Table;
using Nop.Core.Domain.Vendors;
using Nop.Data.Extensions;

namespace Nop.Data.Mapping.Builders.Vendors
{
    /// <summary>
    /// Represents a Vendor Region entity builder
    /// </summary>
    public partial class VendorRegionBuilder : NopEntityBuilder<VendorRegion>
    {
        #region Methods

        /// <summary>
        /// Apply entity configuration
        /// </summary>
        /// <param name="table">Create table expression builder</param>
        public override void MapEntity(CreateTableExpressionBuilder table)
        {
            table
                .WithColumn(nameof(VendorRegion.VendorId)).AsInt32().ForeignKey<Vendor>()
                .WithColumn(nameof(VendorRegion.ProvinceCode)).AsString(15).Nullable()
                .WithColumn(nameof(VendorRegion.CityCode)).AsString(15).Nullable()
                .WithColumn(nameof(VendorRegion.CountyCode)).AsString(15).Nullable()
                .WithColumn(nameof(VendorRegion.ProvinceName)).AsString(15).Nullable()
                .WithColumn(nameof(VendorRegion.CityName)).AsString(15).Nullable()
                .WithColumn(nameof(VendorRegion.CountyName)).AsString(15).Nullable()
                .WithColumn(nameof(VendorRegion.TimeRuleValue)).AsAnsiString(128).Nullable()
                ;
        }

        #endregion
    }
}
