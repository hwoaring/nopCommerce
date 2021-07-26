using FluentMigrator.Builders.Create.Table;
using Nop.Core.Domain.Stores;
using Nop.Core.Domain.Weixin;
using Nop.Data.Extensions;

namespace Nop.Data.Mapping.Builders.Weixin
{
    /// <summary>
    /// Represents a WxAutoreplyNewsInfoBuilder
    /// </summary>
    public partial class WxAutoreplyNewsInfoBuilder : NopEntityBuilder<WxAutoreplyNewsInfo>
    {
        #region Methods

        /// <summary>
        /// Apply entity configuration
        /// </summary>
        /// <param name="table">Create table expression builder</param>
        public override void MapEntity(CreateTableExpressionBuilder table)
        {
            table
                .WithColumn(nameof(WxAutoreplyNewsInfo.StoreId)).AsInt32().ForeignKey<Store>()
                .WithColumn(nameof(WxAutoreplyNewsInfo.Title)).AsString(64).NotNullable()
                .WithColumn(nameof(WxAutoreplyNewsInfo.Digest)).AsString(64).Nullable()
                .WithColumn(nameof(WxAutoreplyNewsInfo.Author)).AsString(64).Nullable()
                .WithColumn(nameof(WxAutoreplyNewsInfo.CoverUrl)).AsString(1024).Nullable()
                .WithColumn(nameof(WxAutoreplyNewsInfo.CoverUrlThumb)).AsString(1024).Nullable()
                .WithColumn(nameof(WxAutoreplyNewsInfo.ContentUrl)).AsString(1024).Nullable()
                .WithColumn(nameof(WxAutoreplyNewsInfo.SourceUrl)).AsString(1024).Nullable()
                ;
        }

        #endregion
    }
}
