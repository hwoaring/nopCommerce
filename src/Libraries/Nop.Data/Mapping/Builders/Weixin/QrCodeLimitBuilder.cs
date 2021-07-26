using System.Data;
using FluentMigrator.Builders.Create.Table;
using Nop.Core.Domain.Stores;
using Nop.Core.Domain.Weixin;
using Nop.Data.Extensions;

namespace Nop.Data.Mapping.Builders.Weixin
{
    /// <summary>
    /// Represents a QrCodeLimitBuilder
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
                .WithColumn(nameof(QrCodeLimit.SysName)).AsString(64).NotNullable()
                .WithColumn(nameof(QrCodeLimit.Description)).AsString(255).Nullable()
                .WithColumn(nameof(QrCodeLimit.Ticket)).AsAnsiString(255).Nullable()
                .WithColumn(nameof(QrCodeLimit.Url)).AsAnsiString(255).Nullable()
                .WithColumn(nameof(QrCodeLimit.SceneStr)).AsAnsiString(64).Nullable()
                .WithColumn(nameof(QrCodeLimit.TagIdList)).AsAnsiString(64).Nullable()
                ;
        }

        #endregion
    }
}
