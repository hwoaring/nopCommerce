using System.Data;
using FluentMigrator.Builders.Create.Table;
using Nop.Core.Domain.AntiFake;
using Nop.Data.Extensions;

namespace Nop.Data.Mapping.Builders.AntiFake;

/// <summary>
/// Represents a affiliate entity builder
/// </summary>
public partial class AntiFakeRewardsConfigBuilder : NopEntityBuilder<AntiFakeRewardsConfig>
{
    #region Methods

    /// <summary>
    /// Apply entity configuration
    /// </summary>
    /// <param name="table">Create table expression builder</param>
    public override void MapEntity(CreateTableExpressionBuilder table)
    {
        table
            .WithColumn(nameof(AntiFakeRewardsConfig.Title)).AsString(128).NotNullable()
            .WithColumn(nameof(AntiFakeRewardsConfig.Description)).AsString(512).Nullable()
            .WithColumn(nameof(AntiFakeRewardsConfig.Message)).AsString(512).Nullable()
            .WithColumn(nameof(AntiFakeRewardsConfig.PaymenTitle)).AsString(512).Nullable()
            .WithColumn(nameof(AntiFakeRewardsConfig.PaymenDescription)).AsString(512).Nullable()
            .WithColumn(nameof(AntiFakeRewardsConfig.LimitToRegionCode)).AsAnsiString(4000).Nullable()
            .WithColumn(nameof(AntiFakeRewardsConfig.HashCode)).AsAnsiString(128).Nullable()
            .WithColumn(nameof(AntiFakeRewardsConfig.ConfirmDateUtc)).AsDateTime2().Nullable()
            .WithColumn(nameof(AntiFakeRewardsConfig.StartDateUtc)).AsDateTime2().Nullable()
            .WithColumn(nameof(AntiFakeRewardsConfig.EndDateUtc)).AsDateTime2().Nullable()

            .WithColumn(nameof(AntiFakeRewardsConfig.TierShareCount)).AsAnsiString(512).Nullable()
            ;
    }

    #endregion

}
