using FluentMigrator.Builders.Create.Table;
using Nop.Core.Domain.SMS;
using Nop.Data.Extensions;

namespace Nop.Data.Mapping.Builders.SMS
{
    /// <summary>
    /// Represents a store entity builder
    /// </summary>
    public partial class SmsSignBuilder : NopEntityBuilder<SmsSign>
    {
        #region Methods

        /// <summary>
        /// Apply entity configuration
        /// </summary>
        /// <param name="table">Create table expression builder</param>
        public override void MapEntity(CreateTableExpressionBuilder table)
        {
            table
                .WithColumn(nameof(SmsSign.SmsAccountId)).AsInt32().ForeignKey<SmsAccount>()
                .WithColumn(nameof(SmsSign.SignId)).AsString(64).NotNullable()
                .WithColumn(nameof(SmsSign.SignName)).AsString(64).NotNullable()
                ;
        }

        #endregion

    }
}
