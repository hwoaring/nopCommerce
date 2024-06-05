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
    public partial class OrderIDBlackListBuilder : NopEntityBuilder<OrderIDBlackList>
    {
        #region Methods

        /// <summary>
        /// Apply entity configuration
        /// </summary>
        /// <param name="table">Create table expression builder</param>
        public override void MapEntity(CreateTableExpressionBuilder table)
        {
            table
                .WithColumn(nameof(OrderIDBlackList.ProductId)).AsInt32().ForeignKey<Product>()
                .WithColumn(nameof(OrderIDBlackList.IDNumber)).AsAnsiString().NotNullable()
                .WithColumn(nameof(OrderIDBlackList.IDName)).AsString(64).Nullable()
                .WithColumn(nameof(OrderIDBlackList.Notes)).AsString(64).Nullable()
                ;
        }

        #endregion

    }
}
