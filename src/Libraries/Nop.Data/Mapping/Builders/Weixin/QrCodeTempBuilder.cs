using FluentMigrator.Builders.Create.Table;
using Nop.Core.Domain.Customers;
using Nop.Core.Domain.Weixin;
using Nop.Data.Extensions;

namespace Nop.Data.Mapping.Builders.Weixin
{
    /// <summary>
    /// Represents a QrCodeTempBuilder
    /// </summary>
    public partial class QrCodeTempBuilder : NopEntityBuilder<QrCodeTemp>
    {
        #region Methods

        /// <summary>
        /// Apply entity configuration
        /// </summary>
        /// <param name="table">Create table expression builder</param>
        public override void MapEntity(CreateTableExpressionBuilder table)
        {
            table
                .WithColumn(nameof(QrCodeTemp.CustomerId)).AsInt32().ForeignKey<Customer>()
                .WithColumn(nameof(QrCodeTemp.SceneValue)).AsAnsiString(64).Nullable()
                .WithColumn(nameof(QrCodeTemp.Ticket)).AsAnsiString(255).Nullable()
                .WithColumn(nameof(QrCodeTemp.Url)).AsAnsiString(255).Nullable()
                ;
        }

        #endregion
    }
}
