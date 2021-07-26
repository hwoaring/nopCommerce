using FluentMigrator.Builders.Create.Table;
using Nop.Core.Domain.Vendors;
using Nop.Data.Extensions;

namespace Nop.Data.Mapping.Builders.Vendors
{
    /// <summary>
    /// Represents a Vendor Page Analyse entity builder
    /// </summary>
    public partial class VendorPageAnalyseBuilder : NopEntityBuilder<VendorPageAnalyse>
    {
        #region Methods

        /// <summary>
        /// Apply entity configuration
        /// </summary>
        /// <param name="table">Create table expression builder</param>
        public override void MapEntity(CreateTableExpressionBuilder table)
        {
            table
                .WithColumn(nameof(VendorPageAnalyse.VendorId)).AsInt32().ForeignKey<Vendor>()
                ;
        }

        #endregion
    }
}