using FluentMigrator.Builders.Create.Table;
using Nop.Core.Domain.SMS;

namespace Nop.Data.Mapping.Builders.SMS
{
    /// <summary>
    /// Represents a store entity builder
    /// </summary>
    public partial class SmsPlatformBuilder : NopEntityBuilder<SmsPlatform>
    {
        #region Methods

        /// <summary>
        /// Apply entity configuration
        /// </summary>
        /// <param name="table">Create table expression builder</param>
        public override void MapEntity(CreateTableExpressionBuilder table)
        {
            table
                .WithColumn(nameof(SmsPlatform.Name)).AsString(128).NotNullable()
                .WithColumn(nameof(SmsPlatform.Url)).AsAnsiString(512).Nullable()

                ;
        }

        #endregion

    }
}
