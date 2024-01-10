using FluentMigrator.Builders.Create.Table;
using Nop.Core.Domain.Customers;
using Nop.Core.Domain.Vendors;
using Nop.Data.Extensions;

namespace Nop.Data.Mapping.Builders.Vendors
{
    /// <summary>
    /// Represents a vendor entity builder
    /// </summary>
    public partial class VendorStoreMemberFollowupBuilder : NopEntityBuilder<VendorStoreMemberFollowup>
    {
        #region Methods

        /// <summary>
        /// Apply entity configuration
        /// </summary>
        /// <param name="table">Create table expression builder</param>
        public override void MapEntity(CreateTableExpressionBuilder table)
        {
            table
                .WithColumn(nameof(VendorStoreMemberFollowup.CustomerId)).AsInt32().ForeignKey<Customer>()
                .WithColumn(nameof(VendorStoreMemberFollowup.Content)).AsString(512).Nullable()

                ;
        }

        #endregion

    }
}
