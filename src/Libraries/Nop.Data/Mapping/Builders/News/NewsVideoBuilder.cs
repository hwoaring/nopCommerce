using FluentMigrator.Builders.Create.Table;
using Nop.Core.Domain.News;
using Nop.Core.Domain.Media;
using Nop.Data.Extensions;

namespace Nop.Data.Mapping.Builders.News
{
    /// <summary>
    /// Represents a product video mapping entity builder
    /// </summary>
    public partial class NewsVideoBuilder : NopEntityBuilder<NewsVideo>
    {
        #region Methods

        /// <summary>
        /// 朋友圈视频映射
        /// </summary>
        /// <param name="table">Create table expression builder</param>
        public override void MapEntity(CreateTableExpressionBuilder table)
        {
            table
                .WithColumn(nameof(NewsVideo.VideoId)).AsInt32().ForeignKey<Video>()
                .WithColumn(nameof(NewsVideo.NewsItemId)).AsInt32().ForeignKey<NewsItem>()
                .WithColumn(nameof(NewsVideo.Name)).AsString(64).Nullable()
                .WithColumn(nameof(NewsVideo.Description)).AsString(1024).Nullable()
                ;
        }

        #endregion
    }
}
