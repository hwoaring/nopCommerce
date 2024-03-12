using FluentMigrator.Builders.Create.Table;
using Nop.Core.Domain.Customers;
using Nop.Core.Domain.Weixins;
using Nop.Data.Extensions;

namespace Nop.Data.Mapping.Builders.Weixins
{
    /// <summary>
    /// Represents a vendor entity builder
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
                .WithColumn(nameof(WeixinUser.CustomerId)).AsInt32().ForeignKey<Customer>()
                .WithColumn(nameof(WeixinUser.OpenId)).AsAnsiString(64).NotNullable()
                .WithColumn(nameof(WeixinUser.WeixinId)).AsAnsiString(64).Nullable()
                .WithColumn(nameof(WeixinUser.UnionId)).AsAnsiString(64).Nullable()
                .WithColumn(nameof(WeixinUser.NickName)).AsString(64).Nullable()
                .WithColumn(nameof(WeixinUser.Province)).AsString(32).Nullable()
                .WithColumn(nameof(WeixinUser.City)).AsString(32).Nullable()
                .WithColumn(nameof(WeixinUser.Country)).AsString(32).Nullable()
                .WithColumn(nameof(WeixinUser.HeadimgUrl)).AsAnsiString(1024).Nullable()
                .WithColumn(nameof(WeixinUser.Privilege)).AsString(512).Nullable()
                .WithColumn(nameof(WeixinUser.Remark)).AsString(64).Nullable()
                .WithColumn(nameof(WeixinUser.SystemRemark)).AsString(64).Nullable()
                .WithColumn(nameof(WeixinUser.GroupId)).AsAnsiString(512).Nullable()
                .WithColumn(nameof(WeixinUser.TagidList)).AsAnsiString(512).Nullable()
                .WithColumn(nameof(WeixinUser.CustomSceneValue)).AsString(64).Nullable()
                .WithColumn(nameof(WeixinUser.QrScene)).AsString(64).Nullable()
                .WithColumn(nameof(WeixinUser.QrSceneStr)).AsString(64).Nullable()
                .WithColumn(nameof(WeixinUser.SubscribeTime)).AsDateTime2().Nullable()
                .WithColumn(nameof(WeixinUser.UnSubscribeTime)).AsDateTime2().Nullable()
                .WithColumn(nameof(WeixinUser.UpdatedOnUtc)).AsDateTime2().Nullable()
                ;
        }

        #endregion
    }
}