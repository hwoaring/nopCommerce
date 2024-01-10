using FluentMigrator.Builders.Create.Table;
using Nop.Core.Domain.FriendCircles;
using Nop.Core.Domain.Media;
using Nop.Data.Extensions;

namespace Nop.Data.Mapping.Builders.FriendCircles
{
    /// <summary>
    /// Represents a product video mapping entity builder
    /// </summary>
    public partial class FriendCircleVideoBuilder : NopEntityBuilder<FriendCircleVideo>
    {
        #region Methods

        /// <summary>
        /// 朋友圈视频映射
        /// </summary>
        /// <param name="table">Create table expression builder</param>
        public override void MapEntity(CreateTableExpressionBuilder table)
        {
            table
                .WithColumn(nameof(FriendCircleVideo.VideoId)).AsInt32().ForeignKey<Video>()
                .WithColumn(nameof(FriendCircleVideo.FriendCircleId)).AsInt32().ForeignKey<FriendCircle>()
                .WithColumn(nameof(FriendCircleVideo.Name)).AsString(64).Nullable()
                .WithColumn(nameof(FriendCircleVideo.Description)).AsString(1024).Nullable()
                ;
        }

        #endregion
    }
}
