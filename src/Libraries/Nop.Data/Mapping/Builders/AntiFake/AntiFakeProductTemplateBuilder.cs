using FluentMigrator.Builders.Create.Table;
using Nop.Core.Domain.AntiFake;

namespace Nop.Data.Mapping.Builders.AntiFake
{
    /// <summary>
    /// Represents a affiliate entity builder
    /// </summary>
    public partial class AntiFakeProductTemplateBuilder : NopEntityBuilder<AntiFakeProductTemplate>
    {
        #region Methods

        /// <summary>
        /// Apply entity configuration
        /// </summary>
        /// <param name="table">Create table expression builder</param>
        public override void MapEntity(CreateTableExpressionBuilder table)
        {
            table
                .WithColumn(nameof(AntiFakeProductTemplate.Name)).AsString(128).NotNullable()
                .WithColumn(nameof(AntiFakeProductTemplate.ViewPath)).AsAnsiString(128).NotNullable()

                ;
        }

        #endregion
    }
}
