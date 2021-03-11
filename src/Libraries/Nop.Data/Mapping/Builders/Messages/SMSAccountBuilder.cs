using FluentMigrator.Builders.Create.Table;
using Nop.Core.Domain.Messages;

namespace Nop.Data.Mapping.Builders.Messages
{
    /// <summary>
    /// Represents an SMS account entity builder
    /// </summary>
    public partial class SMSAccountBuilder : NopEntityBuilder<SMSAccount>
    {
        #region Methods

        /// <summary>
        /// Apply entity configuration
        /// </summary>
        /// <param name="table">Create table expression builder</param>
        public override void MapEntity(CreateTableExpressionBuilder table)
        {
            table
                .WithColumn(nameof(SMSAccount.AccessKeyId)).AsString(255).Nullable()
                .WithColumn(nameof(SMSAccount.AccessKeySecret)).AsString(255).Nullable()
                .WithColumn(nameof(SMSAccount.SMSServiceUrl)).AsString(512).Nullable()
                ;
        }

        #endregion
    }
}