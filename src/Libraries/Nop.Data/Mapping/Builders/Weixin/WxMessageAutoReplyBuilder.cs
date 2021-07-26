using FluentMigrator.Builders.Create.Table;
using Nop.Core.Domain.Stores;
using Nop.Core.Domain.Weixin;
using Nop.Data.Extensions;

namespace Nop.Data.Mapping.Builders.Weixin
{
    /// <summary>
    /// Represents a vendor note entity builder
    /// </summary>
    public partial class WxMessageAutoReplyBuilder : NopEntityBuilder<WxMessageAutoReply>
    {
        #region Methods

        /// <summary>
        /// Apply entity configuration
        /// </summary>
        /// <param name="table">Create table expression builder</param>
        public override void MapEntity(CreateTableExpressionBuilder table)
        {
            table
                .WithColumn(nameof(WxMessageAutoReply.StoreId)).AsInt32().ForeignKey<Store>()
                .WithColumn(nameof(WxMessageAutoReply.AddFriendAutoreplyContent)).AsString(600).Nullable()
                .WithColumn(nameof(WxMessageAutoReply.AutoreplyContent)).AsString(600).Nullable()
                ;
        }

        #endregion
    }
}
