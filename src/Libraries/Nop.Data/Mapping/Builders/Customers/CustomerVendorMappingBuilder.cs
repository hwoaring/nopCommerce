using FluentMigrator.Builders.Create.Table;
using Nop.Core.Domain.Common;
using Nop.Core.Domain.Customers;
using Nop.Core.Domain.Vendors;
using Nop.Data.Extensions;

namespace Nop.Data.Mapping.Builders.Customers
{
    /// <summary>
    /// 用户对供应商的收藏
    /// </summary>
    public partial class CustomerVendorMappingBuilder : NopEntityBuilder<CustomerVendorMapping>
    {
        #region Methods

        /// <summary>
        /// Apply entity configuration
        /// </summary>
        /// <param name="table">Create table expression builder</param>
        public override void MapEntity(CreateTableExpressionBuilder table)
        {
            table
                .WithColumn(nameof(CustomerVendorMapping.CustomerId)).AsInt32().ForeignKey<Customer>()
                .WithColumn(nameof(CustomerVendorMapping.VendorId)).AsInt32().ForeignKey<Vendor>()
                ;
        }

        #endregion
    }
}