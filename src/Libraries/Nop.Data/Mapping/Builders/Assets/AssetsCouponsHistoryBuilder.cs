using FluentMigrator.Builders.Create.Table;
using Nop.Core.Domain.Assets;
using Nop.Core.Domain.Customers;
using Nop.Data.Extensions;


namespace Nop.Data.Mapping.Builders.Assets
{
    /// <summary>
    /// Represents a affiliate entity builder
    /// </summary>
    public partial class AssetsCouponsHistoryBuilder : NopEntityBuilder<AssetsCouponsHistory>
    {
        #region Methods

        /// <summary>
        /// Apply entity configuration
        /// </summary>
        /// <param name="table">Create table expression builder</param>
        public override void MapEntity(CreateTableExpressionBuilder table)
        {
            table
                .WithColumn(nameof(AssetsCouponsHistory.CustomerId)).AsInt32().ForeignKey<Customer>()
                .WithColumn(nameof(AssetsCouponsHistory.Name)).AsString(128).NotNullable()
                .WithColumn(nameof(AssetsCouponsHistory.CardNumber)).AsAnsiString(128).NotNullable()
                .WithColumn(nameof(AssetsCouponsHistory.ExchangeUnit)).AsString(32).Nullable()
                .WithColumn(nameof(AssetsCouponsHistory.BindIDNationality)).AsString(32).Nullable()
                .WithColumn(nameof(AssetsCouponsHistory.BindIDNumber)).AsAnsiString(64).Nullable()
                .WithColumn(nameof(AssetsCouponsHistory.BindIDName)).AsString(64).Nullable()
                .WithColumn(nameof(AssetsCouponsHistory.BindPhone)).AsAnsiString(64).Nullable()
                .WithColumn(nameof(AssetsCouponsHistory.RefundReason)).AsString(512).Nullable()
                .WithColumn(nameof(AssetsCouponsHistory.IssuedCardNumber)).AsAnsiString(128).Nullable()
                .WithColumn(nameof(AssetsCouponsHistory.Remark)).AsString(512).Nullable()
                .WithColumn(nameof(AssetsCouponsHistory.HashCode)).AsAnsiString(128).Nullable()
                .WithColumn(nameof(AssetsCouponsHistory.LockRemark)).AsString(512).Nullable()

                .WithColumn(nameof(AssetsCouponsHistory.UsedWithOrderString)).AsAnsiString(8000).Nullable()
                .WithColumn(nameof(AssetsCouponsHistory.PassWordExpireDateUtc)).AsDateTime2().Nullable()
                .WithColumn(nameof(AssetsCouponsHistory.StartDateUtc)).AsDateTime2().Nullable()
                .WithColumn(nameof(AssetsCouponsHistory.EndDateUtc)).AsDateTime2().Nullable()
                .WithColumn(nameof(AssetsCouponsHistory.UsedDateUtc)).AsDateTime2().Nullable()
                .WithColumn(nameof(AssetsCouponsHistory.LatestRefundDateUtc)).AsDateTime2().Nullable()
                .WithColumn(nameof(AssetsCouponsHistory.ExpiredRefundDateUtc)).AsDateTime2().Nullable()
                .WithColumn(nameof(AssetsCouponsHistory.RefundDateUtc)).AsDateTime2().Nullable()
                .WithColumn(nameof(AssetsCouponsHistory.ReSellDateOnUtc)).AsDateTime2().Nullable()
                ;
        }

        #endregion

    }
}
