using System.Data;
using FluentMigrator.Builders.Create.Table;
using Nop.Core.Domain.Common;
using Nop.Core.Domain.Weixin;
using Nop.Core.Domain.Directory;
using Nop.Core.Domain.Localization;
using Nop.Data.Extensions;
using Nop.Core.Domain.Customers;

namespace Nop.Data.Mapping.Builders.Weixin
{
    /// <summary>
    /// Represents a customer entity builder
    /// </summary>
    public partial class WeixinUserBuilder : NopEntityBuilder<WeixinUser>
    {
        #region Methods

        /// <summary>
        /// Apply entity configuration
        /// </summary>
        /// <param name="table">Create table expression builder</param>
        public override void MapEntity(CreateTableExpressionBuilder table)
        {
            table
                .WithColumn(nameof(WeixinUser.OpenId)).AsAnsiString(64).NotNullable()
                .WithColumn(nameof(WeixinUser.NickName)).AsString(64).Nullable()
                .WithColumn(nameof(WeixinUser.Province)).AsString(15).Nullable()
                .WithColumn(nameof(WeixinUser.City)).AsString(15).Nullable()
                .WithColumn(nameof(WeixinUser.Country)).AsString(15).Nullable()
                .WithColumn(nameof(WeixinUser.HeadimgUrl)).AsAnsiString(512).Nullable()
                .WithColumn(nameof(WeixinUser.Privilege)).AsString(32).Nullable()
                .WithColumn(nameof(WeixinUser.Language)).AsAnsiString(16).Nullable()
                .WithColumn(nameof(WeixinUser.SubscribeTime)).AsDateTime2().Nullable()
                .WithColumn(nameof(WeixinUser.UnSubscribeTime)).AsDateTime2().Nullable()
                .WithColumn(nameof(WeixinUser.UnionId)).AsAnsiString(64).Nullable()
                .WithColumn(nameof(WeixinUser.Remark)).AsString(64).Nullable()
                .WithColumn(nameof(WeixinUser.SystemRemark)).AsString(512).Nullable()
                .WithColumn(nameof(WeixinUser.GroupId)).AsAnsiString(16).Nullable()
                .WithColumn(nameof(WeixinUser.TagidList)).AsAnsiString(128).Nullable()
                .WithColumn(nameof(WeixinUser.CustomSceneValue)).AsString(512).Nullable()
                .WithColumn(nameof(WeixinUser.QrScene)).AsAnsiString(128).Nullable()
                .WithColumn(nameof(WeixinUser.QrSceneStr)).AsAnsiString(128).Nullable()
                .WithColumn(nameof(WeixinUser.CustomerId)).AsInt32().ForeignKey<Customer>(onDelete: Rule.SetNull).Nullable()
                ;
        }

        #endregion
    }
}