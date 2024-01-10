using System.Data;
using FluentMigrator.Builders.Create.Table;
using Nop.Core.Domain.Customers;
using Nop.Core.Domain.Orders;
using Nop.Data.Extensions;

namespace Nop.Data.Mapping.Builders.Orders
{
    /// <summary>
    /// Represents a gift card entity builder
    /// </summary>
    public partial class OrderInvoiceBuilder : NopEntityBuilder<OrderInvoice>
    {
        #region Methods

        /// <summary>
        /// Apply entity configuration
        /// </summary>
        /// <param name="table">Create table expression builder</param>
        public override void MapEntity(CreateTableExpressionBuilder table)
        {
            table
                .WithColumn(nameof(OrderInvoice.CustomerId)).AsInt32().ForeignKey<Customer>()
                .WithColumn(nameof(OrderInvoice.Name)).AsString(128).Nullable()
                .WithColumn(nameof(OrderInvoice.TaxNumber)).AsAnsiString(64).Nullable()
                .WithColumn(nameof(OrderInvoice.BankAccount)).AsAnsiString(64).Nullable()
                .WithColumn(nameof(OrderInvoice.Address)).AsString(128).Nullable()
                .WithColumn(nameof(OrderInvoice.Phone)).AsAnsiString(32).Nullable()

                ;
        }

        #endregion

    }
}
