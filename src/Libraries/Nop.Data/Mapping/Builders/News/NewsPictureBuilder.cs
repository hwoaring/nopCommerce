using FluentMigrator.Builders.Create.Table;
using Nop.Core.Domain.News;
using Nop.Core.Domain.Media;
using Nop.Data.Extensions;

namespace Nop.Data.Mapping.Builders.News
{
    /// <summary>
    /// Represents a product picture entity builder
    /// </summary>
    public partial class NewsPictureBuilder : NopEntityBuilder<NewsPicture>
    {
        #region Methods

        /// <summary>
        /// 朋友圈图片映射
        /// </summary>
        /// <param name="table">Create table expression builder</param>
        public override void MapEntity(CreateTableExpressionBuilder table)
        {
            table
                .WithColumn(nameof(NewsPicture.PictureId)).AsInt32().ForeignKey<Picture>()
                .WithColumn(nameof(NewsPicture.NewsItemId)).AsInt32().ForeignKey<NewsItem>()
                .WithColumn(nameof(NewsPicture.Name)).AsString(64).Nullable()
                .WithColumn(nameof(NewsPicture.Description)).AsString(1024).Nullable()

                ;
        }

        #endregion
    }
}