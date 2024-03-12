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
    public partial class QrCodeLimitBuilder : NopEntityBuilder<QrCodeLimit>
    {
        #region Methods

        /// <summary>
        /// Apply entity configuration
        /// </summary>
        /// <param name="table">Create table expression builder</param>
        public override void MapEntity(CreateTableExpressionBuilder table)
        {
            table
                .WithColumn(nameof(QrCodeLimit.StoreId)).AsInt32().ForeignKey<Store>()
                .WithColumn(nameof(QrCodeLimit.SceneStr)).AsAnsiString(64).Nullable()
                .WithColumn(nameof(QrCodeLimit.Name)).AsString(64).Nullable()
                .WithColumn(nameof(QrCodeLimit.Description)).AsString(128).Nullable()
                .WithColumn(nameof(QrCodeLimit.Ticket)).AsAnsiString(64).Nullable()
                .WithColumn(nameof(QrCodeLimit.Url)).AsAnsiString(512).Nullable()
                .WithColumn(nameof(QrCodeLimit.TagIdList)).AsString(64).Nullable()

                ;
        }

        #endregion
    }
}