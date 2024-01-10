using FluentMigrator.Builders.Create.Table;
using Nop.Core.Domain.SMS;
using Nop.Data.Extensions;

namespace Nop.Data.Mapping.Builders.SMS
{
    /// <summary>
    /// Represents a store entity builder
    /// </summary>
    public partial class SmsPublicCombinationBuilder : NopEntityBuilder<SmsPublicCombination>
    {
        #region Methods

        /// <summary>
        /// Apply entity configuration
        /// </summary>
        /// <param name="table">Create table expression builder</param>
        public override void MapEntity(CreateTableExpressionBuilder table)
        {
            table
                .WithColumn(nameof(SmsPublicCombination.SmsSignId)).AsInt32().ForeignKey<SmsSign>()
                .WithColumn(nameof(SmsPublicCombination.SmsTemplateId)).AsInt32().ForeignKey<SmsTemplate>()

                ;
        }

        #endregion

    }
}
