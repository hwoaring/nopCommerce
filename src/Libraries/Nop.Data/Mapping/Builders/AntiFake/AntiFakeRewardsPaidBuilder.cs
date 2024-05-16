using FluentMigrator.Builders.Create.Table;
using Nop.Core.Domain.AntiFake;
using Nop.Core.Domain.Customers;
using Nop.Data.Extensions;

namespace Nop.Data.Mapping.Builders.AntiFake;

/// <summary>
/// Represents a affiliate entity builder
/// </summary>
public partial class AntiFakeRewardsPaidBuilder : NopEntityBuilder<AntiFakeRewardsPaid>
{
    #region Methods

    /// <summary>
    /// Apply entity configuration
    /// </summary>
    /// <param name="table">Create table expression builder</param>
    public override void MapEntity(CreateTableExpressionBuilder table)
    {
        table
            .WithColumn(nameof(AntiFakeRewardsPaid.AntiFakeRewardsCodeId)).AsInt32().ForeignKey<AntiFakeRewardsCode>()
            .WithColumn(nameof(AntiFakeRewardsPaid.CustomerId)).AsInt32().ForeignKey<Customer>()
            .WithColumn(nameof(AntiFakeRewardsPaid.PhoneNumber)).AsAnsiString(64).Nullable()
            .WithColumn(nameof(AntiFakeRewardsPaid.OutTradeNo)).AsAnsiString(128).Nullable()
            .WithColumn(nameof(AntiFakeRewardsPaid.TransactionId)).AsAnsiString(128).Nullable()
            .WithColumn(nameof(AntiFakeRewardsPaid.Latitude)).AsDecimal(9, 6).Nullable()
            .WithColumn(nameof(AntiFakeRewardsPaid.Longitude)).AsDecimal(9, 6).Nullable()

            ;
    }

    #endregion
}
