using System.Data;
using FluentMigrator.Builders.Create.Table;
using Nop.Core.Domain.Catalog;
using Nop.Core.Domain.Customers;
using Nop.Core.Domain.Orders;
using Nop.Data.Extensions;

namespace Nop.Data.Mapping.Builders.Orders
{
    /// <summary>
    /// Represents a gift card entity builder
    /// </summary>
    public partial class OrderPhoneBlackListBuilder : NopEntityBuilder<OrderPhoneBlackList>
    {
        #region Methods

        /// <summary>
        /// Apply entity configuration
        /// </summary>
        /// <param name="table">Create table expression builder</param>
        public override void MapEntity(CreateTableExpressionBuilder table)
        {
            table
                .WithColumn(nameof(OrderPhoneBlackList.ProductId)).AsInt32().ForeignKey<Product>()
                .WithColumn(nameof(OrderPhoneBlackList.PhoneNumber)).AsAnsiString(32).NotNullable()
                .WithColumn(nameof(OrderPhoneBlackList.Notes)).AsString(64).Nullable()

                ;
        }

        #endregion

    }
}
