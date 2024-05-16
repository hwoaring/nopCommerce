using FluentMigrator.Builders.Create.Table;
using Nop.Core.Domain.AntiFake;
using Nop.Data.Extensions;

namespace Nop.Data.Mapping.Builders.AntiFake;

/// <summary>
/// Represents a affiliate entity builder
/// </summary>
public partial class AntiFakeRewardsCodeBuilder : NopEntityBuilder<AntiFakeRewardsCode>
{
    #region Methods

    /// <summary>
    /// Apply entity configuration
    /// </summary>
    /// <param name="table">Create table expression builder</param>
    public override void MapEntity(CreateTableExpressionBuilder table)
    {
        table
            .WithColumn(nameof(AntiFakeRewardsCode.AntiFakeRewardsConfigId)).AsInt32().ForeignKey<AntiFakeRewardsConfig>()
            .WithColumn(nameof(AntiFakeRewardsCode.SplitedAmount)).AsAnsiString(512).Nullable()
            .WithColumn(nameof(AntiFakeRewardsCode.HashCode)).AsAnsiString(128).Nullable()
            ;
    }

    #endregion
}
