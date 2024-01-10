using FluentMigrator.Builders.Create.Table;
using Nop.Core.Domain.FriendCircles;
using Nop.Core.Domain.Media;
using Nop.Data.Extensions;

namespace Nop.Data.Mapping.Builders.FriendCircles
{
    /// <summary>
    /// Represents a product picture entity builder
    /// </summary>
    public partial class FriendCirclePictureBuilder : NopEntityBuilder<FriendCirclePicture>
    {
        #region Methods

        /// <summary>
        /// 朋友圈图片映射
        /// </summary>
        /// <param name="table">Create table expression builder</param>
        public override void MapEntity(CreateTableExpressionBuilder table)
        {
            table
                .WithColumn(nameof(FriendCirclePicture.PictureId)).AsInt32().ForeignKey<Picture>()
                .WithColumn(nameof(FriendCirclePicture.FriendCircleId)).AsInt32().ForeignKey<FriendCircle>()
                .WithColumn(nameof(FriendCirclePicture.Name)).AsString(64).Nullable()
                .WithColumn(nameof(FriendCirclePicture.Description)).AsString(1024).Nullable()

                ;
        }

        #endregion
    }
}