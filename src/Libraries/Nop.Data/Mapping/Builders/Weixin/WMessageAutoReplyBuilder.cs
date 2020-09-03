﻿using FluentMigrator.Builders.Create.Table;
using Nop.Core.Domain.Weixin;
using Nop.Data.Extensions;

namespace Nop.Data.Mapping.Builders.Weixin
{
    /// <summary>
    /// Represents a vendor note entity builder
    /// </summary>
    public partial class WMessageAutoReplyBuilder : NopEntityBuilder<WMessageAutoReply>
    {
        #region Methods

        /// <summary>
        /// Apply entity configuration
        /// </summary>
        /// <param name="table">Create table expression builder</param>
        public override void MapEntity(CreateTableExpressionBuilder table)
        {
            table
                .WithColumn(nameof(WMessageAutoReply.AddFriendAutoreplyContent)).AsString(600).Nullable()
                .WithColumn(nameof(WMessageAutoReply.AutoreplyContent)).AsString(600).Nullable()
                ;
        }

        #endregion
    }
}
