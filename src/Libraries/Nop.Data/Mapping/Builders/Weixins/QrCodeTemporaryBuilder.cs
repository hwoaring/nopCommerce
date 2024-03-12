using FluentMigrator.Builders.Create.Table;
using Nop.Core.Domain.Customers;
using Nop.Core.Domain.Stores;
using Nop.Core.Domain.Weixins;
using Nop.Data.Extensions;

namespace Nop.Data.Mapping.Builders.Weixins
{
    /// <summary>
    /// Represents a vendor entity builder
    /// </summary>
    public partial class QrCodeTemporaryBuilder : NopEntityBuilder<QrCodeTemporary>
    {
        #region Methods

        /// <summary>
        /// Apply entity configuration
        /// </summary>
        /// <param name="table">Create table expression builder</param>
        public override void MapEntity(CreateTableExpressionBuilder table)
        {
            table
                .WithColumn(nameof(QrCodeTemporary.StoreId)).AsInt32().ForeignKey<Store>()
                .WithColumn(nameof(QrCodeTemporary.CustomerId)).AsInt32().ForeignKey<Customer>()
                .WithColumn(nameof(QrCodeTemporary.SceneStr)).AsAnsiString(64).Nullable()
                .WithColumn(nameof(QrCodeTemporary.Ticket)).AsAnsiString(128).Nullable()
                .WithColumn(nameof(QrCodeTemporary.Url)).AsAnsiString(512).Nullable()
                ;
        }

        #endregion
    }
}