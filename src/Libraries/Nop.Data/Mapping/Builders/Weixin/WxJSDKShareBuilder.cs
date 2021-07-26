using FluentMigrator.Builders.Create.Table;
using Nop.Core.Domain.Weixin;
using Nop.Core.Domain.Catalog;
using Nop.Data.Extensions;

namespace Nop.Data.Mapping.Builders.Weixin
{
    /// <summary>
    /// Represents a WJSDKShare entity builder
    /// </summary>
    public partial class WxJSDKShareBuilder : NopEntityBuilder<WxJSDKShare>
    {
        #region Methods

        /// <summary>
        /// Apply entity configuration
        /// </summary>
        /// <param name="table">Create table expression builder</param>
        public override void MapEntity(CreateTableExpressionBuilder table)
        {
            table
                .WithColumn(nameof(WxJSDKShare.ProductId)).AsInt32().ForeignKey<Product>()
                .WithColumn(nameof(WxJSDKShare.Title)).AsString(64).Nullable()
                .WithColumn(nameof(WxJSDKShare.Description)).AsString(512).Nullable()
                .WithColumn(nameof(WxJSDKShare.Link)).AsString(1024).Nullable()
                .WithColumn(nameof(WxJSDKShare.ImageUrl)).AsString(1024).Nullable()
                .WithColumn(nameof(WxJSDKShare.Type)).AsAnsiString(15).Nullable()
                .WithColumn(nameof(WxJSDKShare.DataUrl)).AsString(1024).Nullable()
                ;
        }

        #endregion
    }
}
