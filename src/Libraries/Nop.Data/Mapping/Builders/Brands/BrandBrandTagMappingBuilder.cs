using FluentMigrator.Builders.Create.Table;
using Nop.Core.Domain.Brands;
using Nop.Data.Extensions;

namespace Nop.Data.Mapping.Builders.Brands
{
    /// <summary>
    /// 品牌标签
    /// </summary>
    public partial class BrandBrandTagMappingBuilder : NopEntityBuilder<BrandBrandTagMapping>
    {
        #region Methods

        /// <summary>
        /// Apply entity configuration
        /// </summary>
        /// <param name="table">Create table expression builder</param>
        public override void MapEntity(CreateTableExpressionBuilder table)
        {
            table
                .WithColumn(nameof(BrandBrandTagMapping.BrandId)).AsInt32().PrimaryKey().ForeignKey<Brand>()
                .WithColumn(nameof(BrandBrandTagMapping.BrandTagId)).AsInt32().PrimaryKey().ForeignKey<BrandTag>()

                ;
        }

        #endregion
    }
}