using FluentMigrator.Builders.Create.Table;
using Nop.Core.Domain.Vendors;
using Nop.Data.Extensions;

namespace Nop.Data.Mapping.Builders.Vendors
{
    /// <summary>
    /// Represents a vendor entity builder
    /// </summary>
    public partial class VendorSmsBuilder : NopEntityBuilder<VendorSms>
    {
        #region Methods

        /// <summary>
        /// Apply entity configuration
        /// </summary>
        /// <param name="table">Create table expression builder</param>
        public override void MapEntity(CreateTableExpressionBuilder table)
        {
            table
                .WithColumn(nameof(VendorSms.VendorId)).AsInt32().ForeignKey<Vendor>()
                .WithColumn(nameof(VendorSms.Phones)).AsAnsiString(4000).Nullable()

                ;
        }

        #endregion

    }
}
