using FluentMigrator.Builders.Create.Table;
using Nop.Core.Domain.Directory;
using Nop.Data.Extensions;

namespace Nop.Data.Mapping.Builders.Directory
{
    /// <summary>
    /// 中国区划表
    /// </summary>
    public partial class RegionCodeBuilder : NopEntityBuilder<RegionCode>
    {
        #region Methods

        /// <summary>
        /// Apply entity configuration
        /// </summary>
        /// <param name="table">Create table expression builder</param>
        public override void MapEntity(CreateTableExpressionBuilder table)
        {
            table
                .WithColumn(nameof(RegionCode.CountryId)).AsInt32().ForeignKey<Country>()
                .WithColumn(nameof(RegionCode.Code)).AsAnsiString(16).NotNullable()
                .WithColumn(nameof(RegionCode.Name)).AsString(64).NotNullable()
                .WithColumn(nameof(RegionCode.NameIndex)).AsAnsiString(64).Nullable()
                .WithColumn(nameof(RegionCode.FullName)).AsString(128).Nullable()
                

                ;
        }

        #endregion
    }
}