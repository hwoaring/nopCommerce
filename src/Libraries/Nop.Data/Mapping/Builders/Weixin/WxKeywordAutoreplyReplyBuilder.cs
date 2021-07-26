using FluentMigrator.Builders.Create.Table;
using Nop.Core.Domain.Stores;
using Nop.Core.Domain.Weixin;
using Nop.Data.Extensions;

namespace Nop.Data.Mapping.Builders.Weixin
{
    /// <summary>
    /// Represents a WxKeywordAutoreplyReplyBuilder
    /// </summary>
    public partial class WxKeywordAutoreplyReplyBuilder : NopEntityBuilder<WxKeywordAutoreplyReply>
    {
        #region Methods

        /// <summary>
        /// Apply entity configuration
        /// </summary>
        /// <param name="table">Create table expression builder</param>
        public override void MapEntity(CreateTableExpressionBuilder table)
        {
            table
                .WithColumn(nameof(WxKeywordAutoreplyReply.StoreId)).AsInt32().ForeignKey<Store>()
                .WithColumn(nameof(WxKeywordAutoreplyReply.Content)).AsString(1024).Nullable()
                .WithColumn(nameof(WxKeywordAutoreplyReply.WxAutoreplyNewsInfoIds)).AsAnsiString(512).Nullable()
                ;
        }

        #endregion
    }
}
