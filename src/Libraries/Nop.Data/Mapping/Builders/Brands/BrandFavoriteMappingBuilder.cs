using FluentMigrator.Builders.Create.Table;
using Nop.Core.Domain.Customers;
using Nop.Core.Domain.Brands;
using Nop.Core.Domain.Stores;
using Nop.Data.Extensions;

namespace Nop.Data.Mapping.Builders.Brands
{
    /// <summary>
    /// 品牌订阅，点赞，收藏等
    /// </summary>
    public partial class BrandFavoriteMappingBuilder : NopEntityBuilder<BrandFavoriteMapping>
    {
        #region Methods

        /// <summary>
        /// Apply entity configuration
        /// </summary>
        /// <param name="table">Create table expression builder</param>
        public override void MapEntity(CreateTableExpressionBuilder table)
        {
            table
                .WithColumn(nameof(BrandFavoriteMapping.BrandId)).AsInt32().ForeignKey<Brand>()
                .WithColumn(nameof(BrandFavoriteMapping.CustomerId)).AsInt32().ForeignKey<Customer>()
                ;
        }

        #endregion
    }
}