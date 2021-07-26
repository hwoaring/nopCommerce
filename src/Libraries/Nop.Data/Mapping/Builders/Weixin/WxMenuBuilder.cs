using FluentMigrator.Builders.Create.Table;
using Nop.Core.Domain.Stores;
using Nop.Core.Domain.Weixin;
using Nop.Data.Extensions;

namespace Nop.Data.Mapping.Builders.Weixin
{
    /// <summary>
    /// Represents a vendor note entity builder
    /// </summary>
    public partial class WxMenuBuilder : NopEntityBuilder<WxMenu>
    {
        #region Methods

        /// <summary>
        /// Apply entity configuration
        /// </summary>
        /// <param name="table">Create table expression builder</param>
        public override void MapEntity(CreateTableExpressionBuilder table)
        {
            table
                .WithColumn(nameof(WxMenu.StoreId)).AsInt32().ForeignKey<Store>()
                .WithColumn(nameof(WxMenu.SystemName)).AsString(50).Nullable()
                .WithColumn(nameof(WxMenu.Description)).AsString(255).Nullable()
                .WithColumn(nameof(WxMenu.TagId)).AsAnsiString(255).Nullable()
                .WithColumn(nameof(WxMenu.Sex)).AsAnsiString(5).Nullable()
                .WithColumn(nameof(WxMenu.ClientPlatformType)).AsAnsiString(15).Nullable()
                .WithColumn(nameof(WxMenu.Country)).AsString(15).Nullable()
                .WithColumn(nameof(WxMenu.Province)).AsString(15).Nullable()
                .WithColumn(nameof(WxMenu.City)).AsString(15).Nullable()
                ;
        }

        #endregion
    }
}
