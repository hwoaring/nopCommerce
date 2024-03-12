using FluentMigrator.Builders.Create.Table;
using Nop.Core.Domain.AntiFake;

namespace Nop.Data.Mapping.Builders.AntiFake
{
    /// <summary>
    /// Represents a affiliate entity builder
    /// </summary>
    public partial class AntiFakeVendorCompanyBuilder : NopEntityBuilder<AntiFakeVendorCompany>
    {
        #region Methods

        /// <summary>
        /// Apply entity configuration
        /// </summary>
        /// <param name="table">Create table expression builder</param>
        public override void MapEntity(CreateTableExpressionBuilder table)
        {
            table
                .WithColumn(nameof(AntiFakeVendorCompany.Name)).AsString(128).NotNullable()
                .WithColumn(nameof(AntiFakeVendorCompany.Code)).AsAnsiString(32).Nullable()
                .WithColumn(nameof(AntiFakeVendorCompany.Address)).AsString(128).Nullable()
                .WithColumn(nameof(AntiFakeVendorCompany.Phone)).AsAnsiString(32).Nullable()
                .WithColumn(nameof(AntiFakeVendorCompany.BusinessLicenseCode)).AsAnsiString(64).Nullable()
                .WithColumn(nameof(AntiFakeVendorCompany.FoodLicenseCode)).AsAnsiString(64).Nullable()
                .WithColumn(nameof(AntiFakeVendorCompany.Remark)).AsString(512).Nullable()
                .WithColumn(nameof(AntiFakeVendorCompany.StartDateUtc)).AsDateTime2().Nullable()
                .WithColumn(nameof(AntiFakeVendorCompany.EndDateUtc)).AsDateTime2().Nullable()
                ;
        }

        #endregion
    }
}
