﻿using FluentMigrator.Builders.Create.Table;
using Nop.Core.Domain.Weixin;

namespace Nop.Data.Mapping.Builders.Weixin
{
    /// <summary>
    /// Represents a vendor note entity builder
    /// </summary>
    public partial class WUserBuilder : NopEntityBuilder<WUser>
    {
        #region Methods

        /// <summary>
        /// Apply entity configuration
        /// </summary>
        /// <param name="table">Create table expression builder</param>
        public override void MapEntity(CreateTableExpressionBuilder table)
        {
            table
                .WithColumn(nameof(WUser.OpenId)).AsAnsiString(64).NotNullable()
                .WithColumn(nameof(WUser.UnionId)).AsAnsiString(64).Nullable()
                .WithColumn(nameof(WUser.SysName)).AsString(64).Nullable()
                .WithColumn(nameof(WUser.SysRemark)).AsString(64).Nullable()
                .WithColumn(nameof(WUser.QrSceneStr)).AsAnsiString(64).Nullable()
                .WithColumn(nameof(WUser.NickName)).AsString(30).Nullable()
                .WithColumn(nameof(WUser.Province)).AsString(15).Nullable()
                .WithColumn(nameof(WUser.City)).AsString(15).Nullable()
                .WithColumn(nameof(WUser.Country)).AsString(15).Nullable()
                .WithColumn(nameof(WUser.Remark)).AsString(30).Nullable()
                .WithColumn(nameof(WUser.GroupId)).AsAnsiString(15).Nullable()
                .WithColumn(nameof(WUser.TagIdList)).AsAnsiString(255).Nullable()
                .WithColumn(nameof(WUser.HeadImgUrl)).AsAnsiString(1024).Nullable()
                .WithColumn(nameof(WUser.HeadImgUrlShort)).AsAnsiString(1024).Nullable()
                ;
        }

        #endregion
    }
}
