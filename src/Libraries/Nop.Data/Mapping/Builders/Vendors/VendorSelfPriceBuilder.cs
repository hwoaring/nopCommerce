using FluentMigrator.Builders.Create.Table;
using Nop.Core.Domain.Vendors;
using Nop.Core.Domain.Catalog;
using Nop.Data.Extensions;

namespace Nop.Data.Mapping.Builders.Vendors
{
    /// <summary>
    /// Represents a vendor note entity builder
    /// </summary>
    public partial class VendorSelfPriceBuilder : NopEntityBuilder<VendorSelfPrice>
    {
        #region Methods

        /// <summary>
        /// Apply entity configuration
        /// </summary>
        /// <param name="table">Create table expression builder</param>
        public override void MapEntity(CreateTableExpressionBuilder table)
        {
            table
                .WithColumn(nameof(VendorSelfPrice.VendorId)).AsInt32().ForeignKey<Vendor>()
                .WithColumn(nameof(VendorSelfPrice.ProductId)).AsInt32().ForeignKey<Product>()
                ;
        }

        #endregion
    }
}