using FluentMigrator.Builders.Create.Table;
using Nop.Core.Domain.Common;

namespace Nop.Data.Mapping.Builders.Common
{
    /// <summary>
    /// Represents a Divisions Code entity builder
    /// </summary>
    public partial class DivisionsCodeBuilder : NopEntityBuilder<DivisionsCode>
    {
        #region Methods

        /// <summary>
        /// Apply entity configuration
        /// </summary>
        /// <param name="table">Create table expression builder</param>
        public override void MapEntity(CreateTableExpressionBuilder table)
        {
            table
                .WithColumn(nameof(DivisionsCode.AreaCode)).AsAnsiString(15).NotNullable()
                .WithColumn(nameof(DivisionsCode.AreaName)).AsString(64).NotNullable()
                .WithColumn(nameof(DivisionsCode.Abbreviation)).AsString(15).Nullable()
                ;
        }

        #endregion
    }
}
