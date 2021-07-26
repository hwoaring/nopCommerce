using FluentMigrator.Builders.Create.Table;
using Nop.Core.Domain.Stores;
using Nop.Core.Domain.Weixin;
using Nop.Data.Extensions;

namespace Nop.Data.Mapping.Builders.Weixin
{
    /// <summary>
    /// Represents a vendor note entity builder
    /// </summary>
    public partial class QrCodeChannelBuilder : NopEntityBuilder<QrCodeChannel>
    {
        #region Methods

        /// <summary>
        /// Apply entity configuration
        /// </summary>
        /// <param name="table">Create table expression builder</param>
        public override void MapEntity(CreateTableExpressionBuilder table)
        {
            table
                .WithColumn(nameof(QrCodeChannel.StoreId)).AsInt32().ForeignKey<Store>()
                .WithColumn(nameof(QrCodeChannel.Title)).AsString(64).NotNullable()
                .WithColumn(nameof(QrCodeChannel.Description)).AsString(512).Nullable()
                ;
        }

        #endregion
    }
}
