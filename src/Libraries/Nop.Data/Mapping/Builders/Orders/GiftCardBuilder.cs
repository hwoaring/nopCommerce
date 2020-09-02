using System.Data;
using FluentMigrator.Builders.Create.Table;
using Nop.Core.Domain.Orders;
using Nop.Data.Extensions;

namespace Nop.Data.Mapping.Builders.Orders
{
    /// <summary>
    /// Represents a gift card entity builder
    /// </summary>
    public partial class GiftCardBuilder : NopEntityBuilder<GiftCard>
    {
        #region Methods

        /// <summary>
        /// Apply entity configuration
        /// </summary>
        /// <param name="table">Create table expression builder</param>
        public override void MapEntity(CreateTableExpressionBuilder table)
        {
            table
                .WithColumn(nameof(GiftCard.PurchasedWithOrderItemId)).AsInt32().Nullable().ForeignKey<OrderItem>(onDelete: Rule.None)
                .WithColumn(nameof(GiftCard.RecipientPhone)).AsAnsiString(32).Nullable()
                .WithColumn(nameof(GiftCard.SenderPhone)).AsAnsiString(32).Nullable()
                .WithColumn(nameof(GiftCard.GiftCardCouponCode)).AsAnsiString(128).Nullable()
                .WithColumn(nameof(GiftCard.GiftCardPassword)).AsAnsiString(32).Nullable()
                .WithColumn(nameof(GiftCard.RecipientName)).AsString(128).Nullable()
                .WithColumn(nameof(GiftCard.SenderName)).AsString(128).Nullable()
                .WithColumn(nameof(GiftCard.RecipientEmail)).AsString(128).Nullable()
                .WithColumn(nameof(GiftCard.SenderEmail)).AsString(128).Nullable()
                .WithColumn(nameof(GiftCard.GiftCardStartUseDateTimeUtc)).AsDateTime2().Nullable()
                .WithColumn(nameof(GiftCard.GiftCardEndUseDateTimeUtc)).AsDateTime2().Nullable()
                ;
        }

        #endregion
    }
}