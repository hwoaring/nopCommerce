using FluentMigrator.Builders.Create.Table;
using Nop.Core.Domain.SMS;
using Nop.Data.Extensions;

namespace Nop.Data.Mapping.Builders.SMS
{
    /// <summary>
    /// Represents a store entity builder
    /// </summary>
    public partial class SmsTemplateBuilder : NopEntityBuilder<SmsTemplate>
    {
        #region Methods

        /// <summary>
        /// Apply entity configuration
        /// </summary>
        /// <param name="table">Create table expression builder</param>
        public override void MapEntity(CreateTableExpressionBuilder table)
        {
            table
                .WithColumn(nameof(SmsTemplate.SmsAccountId)).AsInt32().ForeignKey<SmsAccount>()
                .WithColumn(nameof(SmsTemplate.TemplateId)).AsString(128).NotNullable()
                .WithColumn(nameof(SmsTemplate.Name)).AsString(64).NotNullable()
                .WithColumn(nameof(SmsTemplate.Content)).AsString(512).NotNullable()
                ;
        }

        #endregion

    }
}
