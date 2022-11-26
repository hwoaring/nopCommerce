using FluentMigrator.Builders.Create.Table;
using Nop.Core.Domain.Directory;
using Nop.Data.Extensions;

namespace Nop.Data.Mapping.Builders.Directory
{
    /// <summary>
    /// Represents a DivisionCode entity builder
    /// </summary>
    public partial class DivisionCodeBuilder : NopEntityBuilder<DivisionCode>
    {
        #region Methods

        /// <summary>
        /// Apply entity configuration
        /// </summary>
        /// <param name="table">Create table expression builder</param>
        public override void MapEntity(CreateTableExpressionBuilder table)
        {
            table
                .WithColumn(nameof(DivisionCode.AreaName)).AsString(100).NotNullable()
                .WithColumn(nameof(DivisionCode.Abbreviation)).AsString(100).Nullable()
                .WithColumn(nameof(DivisionCode.AreaCode)).AsAnsiString(15).Nullable()
                .WithColumn(nameof(DivisionCode.CountryId)).AsInt32().ForeignKey<Country>();
        }

        #endregion
    }
}