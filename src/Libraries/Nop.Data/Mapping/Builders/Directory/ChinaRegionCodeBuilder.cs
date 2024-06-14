using FluentMigrator.Builders.Create.Table;
using Nop.Core.Domain.Directory;
using Nop.Data.Extensions;

namespace Nop.Data.Mapping.Builders.Directory
{
    /// <summary>
    /// 中国区划表
    /// </summary>
    public partial class ChinaRegionCodeBuilder : NopEntityBuilder<ChinaRegionCode>
    {
        #region Methods

        /// <summary>
        /// Apply entity configuration
        /// </summary>
        /// <param name="table">Create table expression builder</param>
        public override void MapEntity(CreateTableExpressionBuilder table)
        {
            table
                .WithColumn(nameof(ChinaRegionCode.Name)).AsString(64).NotNullable()
                .WithColumn(nameof(ChinaRegionCode.NameIndex)).AsAnsiString(64).Nullable()
                .WithColumn(nameof(ChinaRegionCode.FullName)).AsString(128).Nullable()
                

                ;
        }

        #endregion
    }
}