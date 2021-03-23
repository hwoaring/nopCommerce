using FluentMigrator.Builders.Create.Table;
using Nop.Core.Domain.Weixin;
using Nop.Core.Domain.Stores;
using Nop.Data.Extensions;

namespace Nop.Data.Mapping.Builders.Weixin
{
    /// <summary>
    /// Represents a vendor note entity builder
    /// </summary>
    public partial class WAppBuilder : NopEntityBuilder<WApp>
    {
        #region Methods

        /// <summary>
        /// Apply entity configuration
        /// </summary>
        /// <param name="table">Create table expression builder</param>
        public override void MapEntity(CreateTableExpressionBuilder table)
        {
            table
                .WithColumn(nameof(WApp.StoreId)).AsInt32().ForeignKey<Store>()
                .WithColumn(nameof(WApp.AppId)).AsAnsiString(50).NotNullable()
                .WithColumn(nameof(WApp.AppSecret)).AsAnsiString(50).NotNullable()
                .WithColumn(nameof(WApp.MchId)).AsAnsiString(50).NotNullable()
                .WithColumn(nameof(WApp.ApiKey)).AsAnsiString(255).NotNullable()
                .WithColumn(nameof(WApp.UpdateTimeUtc)).AsDateTime2().Nullable()
                ;
        }

        #endregion
    }
}
