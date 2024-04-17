using FluentMigrator.Builders.Create.Table;
using Nop.Core.Domain.Catalog;
using Nop.Core.Domain.Orders;
using Nop.Data.Extensions;

namespace Nop.Data.Mapping.Builders.Orders;

/// <summary>
/// Represents a order item entity builder
/// </summary>
public partial class OrderPromotionBuilder : NopEntityBuilder<OrderPromotion>
{
    #region Methods

        /// <summary>
        /// Apply entity configuration
        /// </summary>
        /// <param name="table">Create table expression builder</param>
        public override void MapEntity(CreateTableExpressionBuilder table)
        {
            table
                .WithColumn(nameof(OrderPromotion.OrderId)).AsInt32().ForeignKey<Order>()
                .WithColumn(nameof(OrderPromotion.CouponId)).AsAnsiString(64).NotNullable()
                .WithColumn(nameof(OrderPromotion.Name)).AsString(64).Nullable()
                .WithColumn(nameof(OrderPromotion.PromotionScopeId)).AsAnsiString(32).Nullable()
                .WithColumn(nameof(OrderPromotion.PromotionTypeId)).AsAnsiString(32).Nullable()
                .WithColumn(nameof(OrderPromotion.Currency)).AsAnsiString(16).Nullable()
                ;
        }

    #endregion
}