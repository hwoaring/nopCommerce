using FluentMigrator.Builders.Create.Table;
using Nop.Core.Domain.Brands;
using Nop.Core.Domain.Media;
using Nop.Data.Extensions;

namespace Nop.Data.Mapping.Builders.Brands
{
    /// <summary>
    /// 商标相关视频
    /// </summary>
    public partial class BrandVideoBuilder : NopEntityBuilder<BrandVideo>
    {
        #region Methods

        /// <summary>
        /// Apply entity configuration
        /// </summary>
        /// <param name="table">Create table expression builder</param>
        public override void MapEntity(CreateTableExpressionBuilder table)
        {
            table
                .WithColumn(nameof(BrandVideo.VideoId)).AsInt32().ForeignKey<Video>()
                .WithColumn(nameof(BrandVideo.BrandId)).AsInt32().ForeignKey<Brand>()
                .WithColumn(nameof(BrandVideo.Name)).AsString(512).Nullable()

                ;
        }

        #endregion
    }
}
