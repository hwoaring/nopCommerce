using FluentMigrator.Builders.Create.Table;
using Nop.Core.Domain.Customers;
using Nop.Core.Domain.Stores;
using Nop.Core.Domain.Weixins;
using Nop.Data.Extensions;

namespace Nop.Data.Mapping.Builders.Weixins
{
    /// <summary>
    /// Represents a vendor entity builder
    /// </summary>
    public partial class WeixinMessageResponseBuilder : NopEntityBuilder<WeixinMessageResponse>
    {
        #region Methods

        /// <summary>
        /// Apply entity configuration
        /// </summary>
        /// <param name="table">Create table expression builder</param>
        public override void MapEntity(CreateTableExpressionBuilder table)
        {
            table
                .WithColumn(nameof(WeixinMessageResponse.StoreId)).AsInt32().ForeignKey<Store>()
                .WithColumn(nameof(WeixinMessageResponse.Title)).AsString(64).Nullable()
                .WithColumn(nameof(WeixinMessageResponse.Description)).AsString(128).Nullable()
                .WithColumn(nameof(WeixinMessageResponse.Content)).AsString(1024).Nullable()
                .WithColumn(nameof(WeixinMessageResponse.MediaId)).AsAnsiString(64).Nullable()
                .WithColumn(nameof(WeixinMessageResponse.MusicURL)).AsAnsiString(512).Nullable()
                .WithColumn(nameof(WeixinMessageResponse.HQMusicUrl)).AsAnsiString(512).Nullable()
                .WithColumn(nameof(WeixinMessageResponse.ThumbMediaId)).AsAnsiString(64).Nullable()
                .WithColumn(nameof(WeixinMessageResponse.PicUrl)).AsAnsiString(512).Nullable()
                .WithColumn(nameof(WeixinMessageResponse.ThumbPicUrl)).AsAnsiString(512).Nullable()
                .WithColumn(nameof(WeixinMessageResponse.Url)).AsAnsiString(512).Nullable()
                ;
        }

        #endregion
    }
}