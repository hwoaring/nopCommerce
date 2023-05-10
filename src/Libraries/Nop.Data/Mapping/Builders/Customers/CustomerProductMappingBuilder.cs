using FluentMigrator.Builders.Create.Table;
using Nop.Core.Domain.Common;
using Nop.Core.Domain.Customers;
using Nop.Core.Domain.Catalog;
using Nop.Data.Extensions;

namespace Nop.Data.Mapping.Builders.Customers
{
    /// <summary>
    /// 用户对产品的收藏
    /// </summary>
    public partial class CustomerProductMappingBuilder : NopEntityBuilder<CustomerProductMapping>
    {
        #region Methods

        /// <summary>
        /// Apply entity configuration
        /// </summary>
        /// <param name="table">Create table expression builder</param>
        public override void MapEntity(CreateTableExpressionBuilder table)
        {
            table
                .WithColumn(nameof(CustomerProductMapping.CustomerId)).AsInt32().ForeignKey<Customer>()
                .WithColumn(nameof(CustomerProductMapping.ProductId)).AsInt32().ForeignKey<Product>()
                ;
        }

        #endregion
    }
}