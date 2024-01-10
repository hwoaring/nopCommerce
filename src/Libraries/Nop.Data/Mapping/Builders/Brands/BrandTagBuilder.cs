using FluentMigrator.Builders.Create.Table;
using Nop.Core.Domain.Brands;

namespace Nop.Data.Mapping.Builders.Brands
{
    /// <summary>
    /// 品牌标签
    /// </summary>
    public partial class BrandTagBuilder : NopEntityBuilder<BrandTag>
    {
        #region Methods

        /// <summary>
        /// Apply entity configuration
        /// </summary>
        /// <param name="table">Create table expression builder</param>
        public override void MapEntity(CreateTableExpressionBuilder table)
        {
            table.WithColumn(nameof(BrandTag.Name)).AsString(400).NotNullable();
        }

        #endregion
    }
}