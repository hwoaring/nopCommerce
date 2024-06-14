using System.Data;
using FluentMigrator.Builders.Create.Table;
using Nop.Core.Domain.Common;
using Nop.Core.Domain.Customers;
using Nop.Core.Domain.Orders;
using Nop.Data.Extensions;

namespace Nop.Data.Mapping.Builders.Orders;

/// <summary>
/// Represents a order entity builder
/// </summary>
public partial class OrderBuilder : NopEntityBuilder<Order>
{
    #region Methods

        /// <summary>
        /// Apply entity configuration
        /// </summary>
        /// <param name="table">Create table expression builder</param>
        public override void MapEntity(CreateTableExpressionBuilder table)
        {
            table
                .WithColumn(nameof(Order.CustomOrderNumber)).AsString(int.MaxValue).NotNullable()
                .WithColumn(nameof(Order.BillingAddressId)).AsInt32().ForeignKey<Address>(onDelete: Rule.None)
                .WithColumn(nameof(Order.CustomerId)).AsInt32().ForeignKey<Customer>(onDelete: Rule.None)
                .WithColumn(nameof(Order.PickupAddressId)).AsInt32().Nullable().ForeignKey<Address>(onDelete: Rule.None)
                .WithColumn(nameof(Order.ShippingAddressId)).AsInt32().Nullable().ForeignKey<Address>(onDelete: Rule.None)
                .WithColumn(nameof(Order.CustomerIp)).AsString(100).Nullable()

                //新增属性
                .WithColumn(nameof(Order.OpenId)).AsAnsiString(128).Nullable()
                .WithColumn(nameof(Order.OutTradeNo)).AsAnsiString(64).Nullable()
                .WithColumn(nameof(Order.MerchantNo)).AsAnsiString(64).Nullable()
                .WithColumn(nameof(Order.Attach)).AsString(128).Nullable()
                .WithColumn(nameof(Order.Notes)).AsString(128).Nullable()
                .WithColumn(nameof(Order.GoodsTag)).AsString(32).Nullable()
                .WithColumn(nameof(Order.InvoiceId)).AsString(32).Nullable()
                .WithColumn(nameof(Order.OrderShippingNumber)).AsString(64).Nullable()
                .WithColumn(nameof(Order.OutRefundNo)).AsAnsiString(64).Nullable()
                .WithColumn(nameof(Order.RefundReason)).AsString(64).Nullable()
                .WithColumn(nameof(Order.BankTypeId)).AsAnsiString(64).Nullable()
                .WithColumn(nameof(Order.TransactionId)).AsAnsiString(128).Nullable()
                .WithColumn(nameof(Order.PrepayId)).AsAnsiString(64).Nullable()
                .WithColumn(nameof(Order.PrepayUrl)).AsAnsiString(512).Nullable()
                .WithColumn(nameof(Order.PrepayExpireDateUtc)).AsDateTime2().Nullable()
                ;
        }

    #endregion
}