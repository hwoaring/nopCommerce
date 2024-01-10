using FluentMigrator.Builders.Create.Table;
using Nop.Core.Domain.SMS;
using Nop.Data.Extensions;

namespace Nop.Data.Mapping.Builders.SMS
{
    /// <summary>
    /// Represents a store entity builder
    /// </summary>
    public partial class SmsSendRecordsBuilder : NopEntityBuilder<SmsSendRecords>
    {
        #region Methods

        /// <summary>
        /// Apply entity configuration
        /// </summary>
        /// <param name="table">Create table expression builder</param>
        public override void MapEntity(CreateTableExpressionBuilder table)
        {
            table
                .WithColumn(nameof(SmsSendRecords.SerialNumber)).AsAnsiString(128).Nullable()
                .WithColumn(nameof(SmsSendRecords.SmsAccountId)).AsInt32().ForeignKey<SmsAccount>()
                .WithColumn(nameof(SmsSendRecords.Phones)).AsAnsiString(int.MaxValue).Nullable()
                .WithColumn(nameof(SmsSendRecords.Parameters)).AsString(512).Nullable()

                ;
        }

        #endregion

    }
}
