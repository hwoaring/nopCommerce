using FluentMigrator.Builders.Create.Table;
using Nop.Core.Domain.Brands;
using Nop.Core.Domain.Media;
using Nop.Data.Extensions;

namespace Nop.Data.Mapping.Builders.Brands
{
    /// <summary>
    /// 商标相关图片
    /// </summary>
    public partial class BrandPictureBuilder : NopEntityBuilder<BrandPicture>
    {
        #region Methods

        /// <summary>
        /// Apply entity configuration
        /// </summary>
        /// <param name="table">Create table expression builder</param>
        public override void MapEntity(CreateTableExpressionBuilder table)
        {
            table
                .WithColumn(nameof(BrandPicture.PictureId)).AsInt32().ForeignKey<Picture>()
                .WithColumn(nameof(BrandPicture.BrandId)).AsInt32().ForeignKey<Brand>()
                .WithColumn(nameof(BrandPicture.Name)).AsString(512).Nullable()

                ;
        }

        #endregion
    }
}