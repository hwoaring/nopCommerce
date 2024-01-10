using FluentMigrator.Builders.Create.Table;
using Nop.Core.Domain.Customers;
using Nop.Core.Domain.Vendors;
using Nop.Data.Extensions;

namespace Nop.Data.Mapping.Builders.Vendors
{
    /// <summary>
    /// Represents a vendor entity builder
    /// </summary>
    public partial class VendorFavoriteMappingBuilder : NopEntityBuilder<VendorFavoriteMapping>
    {
        #region Methods

        /// <summary>
        /// Apply entity configuration
        /// </summary>
        /// <param name="table">Create table expression builder</param>
        public override void MapEntity(CreateTableExpressionBuilder table)
        {
            table
                .WithColumn(nameof(VendorFavoriteMapping.VendorId)).AsInt32().ForeignKey<Vendor>()
                .WithColumn(nameof(VendorFavoriteMapping.CustomerId)).AsInt32().ForeignKey<Customer>()

                ;
        }

        #endregion

    }
}