using System.Data;
using FluentMigrator.Builders.Create.Table;

using Nop.Core.Domain.AntiFake;
using Nop.Core.Domain.Common;
using Nop.Data.Extensions;

namespace Nop.Data.Mapping.Builders.AntiFake
{
    /// <summary>
    /// Represents a affiliate entity builder
    /// </summary>
    public partial class AntiFakeCompanyBuilder : NopEntityBuilder<AntiFakeCompany>
    {
        #region Methods

        /// <summary>
        /// Apply entity configuration
        /// </summary>
        /// <param name="table">Create table expression builder</param>
        public override void MapEntity(CreateTableExpressionBuilder table)
        {
            table
                .WithColumn(nameof(AntiFakeCompany.Name)).AsString(128).NotNullable()
                .WithColumn(nameof(AntiFakeCompany.Address)).AsString(128).NotNullable()
                .WithColumn(nameof(AntiFakeCompany.ProducingArea)).AsString(128).NotNullable()
                .WithColumn(nameof(AntiFakeCompany.Phone)).AsString(128).Nullable()
                .WithColumn(nameof(AntiFakeCompany.Name)).AsString(128).Nullable()
                .WithColumn(nameof(AntiFakeCompany.BusinessLicenseCode)).AsAnsiString(128).Nullable()
                .WithColumn(nameof(AntiFakeCompany.ProductionLicenseCode)).AsAnsiString(128).Nullable()

                ;
        }

        #endregion
    }
}
