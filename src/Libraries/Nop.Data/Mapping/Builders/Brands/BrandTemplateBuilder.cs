using FluentMigrator.Builders.Create.Table;
using Nop.Core.Domain.Brands;

namespace Nop.Data.Mapping.Builders.Brands
{
    /// <summary>
    /// Represents a product template entity builder
    /// </summary>
    public partial class BrandTemplateBuilder : NopEntityBuilder<BrandTemplate>
    {
        #region Methods

        /// <summary>
        /// 品牌介绍模板
        /// </summary>
        /// <param name="table">Create table expression builder</param>
        public override void MapEntity(CreateTableExpressionBuilder table)
        {
            table
                .WithColumn(nameof(BrandTemplate.Name)).AsString(400).NotNullable()
                .WithColumn(nameof(BrandTemplate.ViewPath)).AsString(512).NotNullable();
        }

        #endregion
    }
}