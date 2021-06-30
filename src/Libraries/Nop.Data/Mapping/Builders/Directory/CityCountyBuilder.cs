using FluentMigrator.Builders.Create.Table;
using Nop.Core.Domain.Directory;
using Nop.Data.Extensions;

namespace Nop.Data.Mapping.Builders.Directory
{
    /// <summary>
    /// Represents a City and County entity builder
    /// </summary>
    public partial class CityCountyBuilder : NopEntityBuilder<CityCounty>
    {
        #region Methods

        /// <summary>
        /// Apply entity configuration
        /// </summary>
        /// <param name="table">Create table expression builder</param>
        public override void MapEntity(CreateTableExpressionBuilder table)
        {
            table
                .WithColumn(nameof(CityCounty.Name)).AsString(100).NotNullable()
                .WithColumn(nameof(CityCounty.Abbreviation)).AsString(100).Nullable()
                .WithColumn(nameof(CityCounty.AreaCode)).AsAnsiString(64).Nullable()
                .WithColumn(nameof(CityCounty.StateProvinceId)).AsInt32().ForeignKey<StateProvince>()
                ;
        }

        #endregion
    }
}