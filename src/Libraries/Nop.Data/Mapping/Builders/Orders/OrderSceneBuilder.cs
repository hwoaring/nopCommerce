using FluentMigrator.Builders.Create.Table;
using Nop.Core.Domain.Catalog;
using Nop.Core.Domain.Orders;
using Nop.Data.Extensions;

namespace Nop.Data.Mapping.Builders.Orders;

/// <summary>
/// Represents a order item entity builder
/// </summary>
public partial class OrderSceneBuilder : NopEntityBuilder<OrderScene>
{
    #region Methods

        /// <summary>
        /// Apply entity configuration
        /// </summary>
        /// <param name="table">Create table expression builder</param>
        public override void MapEntity(CreateTableExpressionBuilder table)
        {
            table
                .WithColumn(nameof(OrderScene.OrderId)).AsInt32().ForeignKey<Order>()
                .WithColumn(nameof(OrderScene.PayerClientIp)).AsAnsiString(64).NotNullable()
                .WithColumn(nameof(OrderScene.DeviceId)).AsString(32).Nullable()
                .WithColumn(nameof(OrderScene.StoreId)).AsString(32).NotNullable()
                .WithColumn(nameof(OrderScene.StoreName)).AsString(256).Nullable()
                .WithColumn(nameof(OrderScene.AreaCode)).AsString(32).Nullable()
                .WithColumn(nameof(OrderScene.Address)).AsString(512).Nullable()
                .WithColumn(nameof(OrderScene.SceneType)).AsString(32).NotNullable()
                .WithColumn(nameof(OrderScene.AppName)).AsString(64).Nullable()
                .WithColumn(nameof(OrderScene.AppUrl)).AsString(128).Nullable()
                .WithColumn(nameof(OrderScene.BundleId)).AsString(128).Nullable()
                .WithColumn(nameof(OrderScene.PackageName)).AsString(128).Nullable()
                ;
        }

    #endregion
}