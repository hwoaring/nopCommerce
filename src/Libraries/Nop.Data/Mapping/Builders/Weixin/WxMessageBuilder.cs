using FluentMigrator.Builders.Create.Table;
using Nop.Core.Domain.Stores;
using Nop.Core.Domain.Weixin;
using Nop.Data.Extensions;

namespace Nop.Data.Mapping.Builders.Weixin
{
    /// <summary>
    /// Represents a vendor note entity builder
    /// </summary>
    public partial class WxMessageBuilder : NopEntityBuilder<WxMessage>
    {
        #region Methods

        /// <summary>
        /// Apply entity configuration
        /// </summary>
        /// <param name="table">Create table expression builder</param>
        public override void MapEntity(CreateTableExpressionBuilder table)
        {
            table
                .WithColumn(nameof(WxMessage.StoreId)).AsInt32().ForeignKey<Store>()
                .WithColumn(nameof(WxMessage.MediaId)).AsAnsiString(255).Nullable()
                .WithColumn(nameof(WxMessage.Title)).AsString(64).Nullable()
                .WithColumn(nameof(WxMessage.Keywords)).AsString(64).Nullable()
                .WithColumn(nameof(WxMessage.KfAccount)).AsAnsiString(32).Nullable()
                .WithColumn(nameof(WxMessage.ThumbMediaId)).AsAnsiString(255).Nullable()
                .WithColumn(nameof(WxMessage.CoverUrl)).AsAnsiString(512).Nullable()
                .WithColumn(nameof(WxMessage.PicUrl)).AsAnsiString(512).Nullable()
                .WithColumn(nameof(WxMessage.ThumbPicUrl)).AsAnsiString(1024).Nullable()
                .WithColumn(nameof(WxMessage.Description)).AsString(1024).Nullable()
                .WithColumn(nameof(WxMessage.Digest)).AsString(255).Nullable()
                .WithColumn(nameof(WxMessage.Author)).AsString(50).Nullable()
                .WithColumn(nameof(WxMessage.MusicUrl)).AsAnsiString(1024).Nullable()
                .WithColumn(nameof(WxMessage.HqMusicUrl)).AsAnsiString(1024).Nullable()
                .WithColumn(nameof(WxMessage.Url)).AsAnsiString(1024).Nullable()
                .WithColumn(nameof(WxMessage.SourceUrl)).AsAnsiString(1024).Nullable()
                .WithColumn(nameof(WxMessage.AppId)).AsAnsiString(128).Nullable()
                .WithColumn(nameof(WxMessage.PagePath)).AsAnsiString(1024).Nullable()
                ;
        }

        #endregion
    }
}
