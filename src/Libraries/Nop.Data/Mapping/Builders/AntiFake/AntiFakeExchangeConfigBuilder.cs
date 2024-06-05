using System.Data;
using FluentMigrator.Builders.Create.Table;
using Nop.Core.Domain.AntiFake;
using Nop.Data.Extensions;

namespace Nop.Data.Mapping.Builders.AntiFake;

/// <summary>
/// Represents a affiliate entity builder
/// </summary>
public partial class AntiFakeExchangeConfigBuilder : NopEntityBuilder<AntiFakeExchangeConfig>
{
    #region Methods

    /// <summary>
    /// Apply entity configuration
    /// </summary>
    /// <param name="table">Create table expression builder</param>
    public override void MapEntity(CreateTableExpressionBuilder table)
    {
        table
            .WithColumn(nameof(AntiFakeExchangeConfig.Title)).AsString(128).NotNullable()
            .WithColumn(nameof(AntiFakeExchangeConfig.Description)).AsString(512).Nullable()
            .WithColumn(nameof(AntiFakeExchangeConfig.LimitToRegionCode)).AsAnsiString(4000).Nullable()
            .WithColumn(nameof(AntiFakeExchangeConfig.Message)).AsString(512).Nullable()
            .WithColumn(nameof(AntiFakeExchangeConfig.RewardProductUnitName)).AsString(128).Nullable()
            .WithColumn(nameof(AntiFakeExchangeConfig.HashCode)).AsAnsiString(128).Nullable()
            .WithColumn(nameof(AntiFakeExchangeConfig.ConfirmDateUtc)).AsDateTime2().Nullable()
            .WithColumn(nameof(AntiFakeExchangeConfig.StartDateUtc)).AsDateTime2().Nullable()
            .WithColumn(nameof(AntiFakeExchangeConfig.EndDateUtc)).AsDateTime2().Nullable()

            ;
    }

    #endregion

}
