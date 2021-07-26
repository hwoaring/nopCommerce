using FluentMigrator.Builders.Create.Table;
using Nop.Core.Domain.Customers;
using Nop.Core.Domain.Weixin;
using Nop.Data.Extensions;

namespace Nop.Data.Mapping.Builders.Weixin
{
    /// <summary>
    /// Represents a QrCodeLimitUserMappingBuilder
    /// </summary>
    public partial class QrCodeLimitUserMappingBuilder : NopEntityBuilder<QrCodeLimitUserMapping>
    {
        #region Methods

        /// <summary>
        /// Apply entity configuration
        /// </summary>
        /// <param name="table">Create table expression builder</param>
        public override void MapEntity(CreateTableExpressionBuilder table)
        {
            table
                .WithColumn(nameof(QrCodeLimitUserMapping.CustomerId)).AsInt32().ForeignKey<Customer>()
                .WithColumn(nameof(QrCodeLimitUserMapping.QrCodeLimitId)).AsInt32().ForeignKey<QrCodeLimit>()
                .WithColumn(nameof(QrCodeLimitUserMapping.UserName)).AsString(32).Nullable()
                .WithColumn(nameof(QrCodeLimitUserMapping.Description)).AsString(1024).Nullable()
                .WithColumn(nameof(QrCodeLimitUserMapping.TelNumber)).AsString(512).Nullable()
                .WithColumn(nameof(QrCodeLimitUserMapping.AddressInfo)).AsString(1024).Nullable()
                ;
        }

        #endregion
    }
}
