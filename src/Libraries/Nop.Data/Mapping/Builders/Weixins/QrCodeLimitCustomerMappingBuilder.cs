using FluentMigrator.Builders.Create.Table;
using Nop.Core.Domain.Customers;
using Nop.Core.Domain.Weixins;
using Nop.Data.Extensions;

namespace Nop.Data.Mapping.Builders.Weixins
{
    /// <summary>
    /// Represents a vendor entity builder
    /// </summary>
    public partial class QrCodeLimitCustomerMappingBuilder : NopEntityBuilder<QrCodeLimitCustomerMapping>
    {
        #region Methods

        /// <summary>
        /// Apply entity configuration
        /// </summary>
        /// <param name="table">Create table expression builder</param>
        public override void MapEntity(CreateTableExpressionBuilder table)
        {
            table
                .WithColumn(nameof(QrCodeLimitCustomerMapping.QrCodeLimitId)).AsInt32().ForeignKey<QrCodeLimit>()
                .WithColumn(nameof(QrCodeLimitCustomerMapping.CustomerId)).AsInt32().ForeignKey<Customer>()
                .WithColumn(nameof(QrCodeLimitCustomerMapping.Name)).AsString(64).Nullable()
                .WithColumn(nameof(QrCodeLimitCustomerMapping.Description)).AsString(128).Nullable()
                .WithColumn(nameof(QrCodeLimitCustomerMapping.Url)).AsAnsiString(512).Nullable()
                .WithColumn(nameof(QrCodeLimitCustomerMapping.StartDateOnUtc)).AsDateTime2().Nullable()
                .WithColumn(nameof(QrCodeLimitCustomerMapping.EndDateOnUtc)).AsDateTime2().Nullable()

                ;
        }

        #endregion
    }
}