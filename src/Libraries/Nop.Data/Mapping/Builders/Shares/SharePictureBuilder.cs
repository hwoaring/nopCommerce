using FluentMigrator.Builders.Create.Table;
using Nop.Core.Domain.Shares;
using Nop.Core.Domain.Media;
using Nop.Data.Extensions;
using Nop.Core.Domain.Stores;
using Microsoft.AspNetCore.Rewrite;

namespace Nop.Data.Mapping.Builders.Shares
{
    /// <summary>
    /// Represents a product picture entity builder
    /// </summary>
    public partial class SharePictureBuilder : NopEntityBuilder<SharePicture>
    {
        #region Methods

        /// <summary>
        /// 分享设置图片映射
        /// </summary>
        /// <param name="table">Create table expression builder</param>
        public override void MapEntity(CreateTableExpressionBuilder table)
        {
            table
                .WithColumn(nameof(SharePicture.StoreId)).AsInt32().ForeignKey<Store>()
                .WithColumn(nameof(SharePicture.PictureId)).AsInt32().ForeignKey<Picture>()
                .WithColumn(nameof(SharePicture.DownloadId)).AsInt32().ForeignKey<Download>(onDelete: System.Data.Rule.SetNull).Nullable()
                .WithColumn(nameof(SharePicture.DownloadUrl)).AsAnsiString(1024).Nullable()
                .WithColumn(nameof(SharePicture.Name)).AsString(64).Nullable()
                .WithColumn(nameof(SharePicture.Slogan)).AsString(64).Nullable()
                .WithColumn(nameof(SharePicture.Description)).AsString(1024).Nullable()
                .WithColumn(nameof(SharePicture.Tags)).AsString(64).Nullable()
                .WithColumn(nameof(SharePicture.QrCodeText)).AsString(64).Nullable()


                ;
        }

        #endregion
    }
}