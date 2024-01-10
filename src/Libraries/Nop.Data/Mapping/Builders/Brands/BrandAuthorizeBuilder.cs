using FluentMigrator.Builders.Create.Table;
using Nop.Core.Domain.Brands;
using Nop.Core.Domain.Stores;
using Nop.Core.Domain.Media;
using Nop.Data.Extensions;

namespace Nop.Data.Mapping.Builders.Brands
{
    /// <summary>
    /// 品牌商标授权
    /// </summary>
    public partial class BrandAuthorizeBuilder : NopEntityBuilder<BrandAuthorize>
    {
        #region Methods

        /// <summary>
        /// 商标
        /// </summary>
        /// <param name="table">Create table expression builder</param>
        public override void MapEntity(CreateTableExpressionBuilder table)
        {
            table
                .WithColumn(nameof(BrandAuthorize.StoreId)).AsInt32().ForeignKey<Store>()
                .WithColumn(nameof(BrandAuthorize.BrandId)).AsInt32().ForeignKey<Brand>()
                .WithColumn(nameof(BrandAuthorize.AuthorizePictureId)).AsInt32().ForeignKey<Picture>()
                .WithColumn(nameof(BrandAuthorize.AuthorizeDateUtc)).AsDateTime2().Nullable()

                ;
        }

        #endregion
    }
}