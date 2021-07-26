using FluentMigrator.Builders.Create.Table;
using Nop.Core.Domain.Weixin;
using Nop.Data.Extensions;

namespace Nop.Data.Mapping.Builders.Weixin
{
    /// <summary>
    /// Represents a vendor note entity builder
    /// </summary>
    public partial class WxMenuButtonBuilder : NopEntityBuilder<WxMenuButton>
    {
        #region Methods

        /// <summary>
        /// Apply entity configuration
        /// </summary>
        /// <param name="table">Create table expression builder</param>
        public override void MapEntity(CreateTableExpressionBuilder table)
        {
            table
                .WithColumn(nameof(WxMenuButton.WxMenuId)).AsInt32().ForeignKey<WxMenu>()
                .WithColumn(nameof(WxMenuButton.Name)).AsString(20).NotNullable()
                .WithColumn(nameof(WxMenuButton.Value)).AsAnsiString(128).Nullable()
                .WithColumn(nameof(WxMenuButton.Url)).AsAnsiString(1024).Nullable()
                .WithColumn(nameof(WxMenuButton.Key)).AsAnsiString(128).Nullable()
                .WithColumn(nameof(WxMenuButton.MediaId)).AsAnsiString(128).Nullable()
                .WithColumn(nameof(WxMenuButton.AppId)).AsAnsiString(128).Nullable()
                .WithColumn(nameof(WxMenuButton.PagePath)).AsAnsiString(1024).Nullable()
                .WithColumn(nameof(WxMenuButton.WAutoreplyNewsInfoIds)).AsAnsiString(512).Nullable()
                ;
        }

        #endregion
    }
}
