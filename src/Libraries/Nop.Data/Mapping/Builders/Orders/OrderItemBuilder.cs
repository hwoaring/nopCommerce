using FluentMigrator.Builders.Create.Table;
using Nop.Core.Domain.Catalog;
using Nop.Core.Domain.Orders;
using Nop.Data.Extensions;

namespace Nop.Data.Mapping.Builders.Orders;

/// <summary>
/// Represents a order item entity builder
/// </summary>
public partial class OrderItemBuilder : NopEntityBuilder<OrderItem>
{
    #region Methods

        /// <summary>
        /// Apply entity configuration
        /// </summary>
        /// <param name="table">Create table expression builder</param>
        public override void MapEntity(CreateTableExpressionBuilder table)
        {
            table
                .WithColumn(nameof(OrderItem.OrderId)).AsInt32().ForeignKey<Order>()
                .WithColumn(nameof(OrderItem.ProductId)).AsInt32().ForeignKey<Product>()

                //新增属性
                .WithColumn(nameof(OrderItem.GoodsTag)).AsString(32).Nullable()
                .WithColumn(nameof(OrderItem.Notes)).AsString(128).Nullable()
                .WithColumn(nameof(OrderItem.OrderShippingNumber)).AsString(64).Nullable()
                .WithColumn(nameof(OrderItem.ProductOrderNoticeIdList)).AsAnsiString(128).Nullable()
                .WithColumn(nameof(OrderItem.DelayPaymentExpireDateUtc)).AsDateTime2().Nullable()
                ;
        }

    #endregion
}