﻿using System.Data;
using FluentMigrator.Builders.Create.Table;
using Nop.Core.Domain.Weixin;
using Nop.Data.Extensions;

namespace Nop.Data.Mapping.Builders.Weixin
{
    /// <summary>
    /// Represents a vendor note entity builder
    /// </summary>
    public partial class WUserSysTagBuilder : NopEntityBuilder<WUserSysTag>
    {
        #region Methods

        /// <summary>
        /// Apply entity configuration
        /// </summary>
        /// <param name="table">Create table expression builder</param>
        public override void MapEntity(CreateTableExpressionBuilder table)
        {
            table
                .WithColumn(nameof(WUserSysTag.Name)).AsString(50).NotNullable()
                .WithColumn(nameof(WUserSysTag.Description)).AsString(512).Nullable()
                ;
        }

        #endregion
    }
}
