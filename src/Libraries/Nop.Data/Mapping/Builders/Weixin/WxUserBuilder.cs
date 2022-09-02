using FluentMigrator.Builders.Create.Table;
using Nop.Core.Domain.Weixin;
using Nop.Core.Domain.Customers;

namespace Nop.Data.Mapping.Builders.Weixin
{
    /// <summary>
    /// Represents a WxUser entity builder
    /// </summary>
    public partial class WxUserBuilder : NopEntityBuilder<WxUser>
    {
        #region Methods

        /// <summary>
        /// Apply entity configuration
        /// </summary>
        /// <param name="table">Create table expression builder</param>
        public override void MapEntity(CreateTableExpressionBuilder table)
        {
            table
                .WithColumn(nameof(WxUser.CustomerId)).AsInt32().ForeignKey<Customer>()
                .WithColumn(nameof(WxUser.OpenId)).AsAnsiString(64).NotNullable()
                .WithColumn(nameof(WxUser.UnionId)).AsAnsiString(64).Nullable()
                .WithColumn(nameof(WxUser.SysName)).AsString(64).Nullable()
                .WithColumn(nameof(WxUser.SysRemark)).AsString(64).Nullable()
                .WithColumn(nameof(WxUser.QrSceneStr)).AsAnsiString(64).Nullable()
                .WithColumn(nameof(WxUser.NickName)).AsString(64).Nullable()
                .WithColumn(nameof(WxUser.Province)).AsString(32).Nullable()
                .WithColumn(nameof(WxUser.City)).AsString(32).Nullable()
                .WithColumn(nameof(WxUser.Country)).AsString(32).Nullable()
                .WithColumn(nameof(WxUser.Remark)).AsString(30).Nullable()
                .WithColumn(nameof(WxUser.GroupId)).AsAnsiString(15).Nullable()
                .WithColumn(nameof(WxUser.TagIdList)).AsAnsiString(255).Nullable()
                .WithColumn(nameof(WxUser.HeadImgUrl)).AsAnsiString(1024).Nullable()
                .WithColumn(nameof(WxUser.HeadImgUrlShort)).AsAnsiString(1024).Nullable()
                ;
        }

        #endregion
    }
}