using FluentMigrator.Builders.Create.Table;
using Nop.Core.Domain.AntiFake;
using Nop.Data.Extensions;

namespace Nop.Data.Mapping.Builders.AntiFake
{
    /// <summary>
    /// Represents a affiliate entity builder
    /// </summary>
    public partial class AntiFakeCashRewardsBuilder : NopEntityBuilder<AntiFakeCashRewards>
    {
        #region Methods

        /// <summary>
        /// Apply entity configuration
        /// </summary>
        /// <param name="table">Create table expression builder</param>
        public override void MapEntity(CreateTableExpressionBuilder table)
        {
            table
                .WithColumn(nameof(AntiFakeCashRewards.AntiFakeCashRewardsConfigId)).AsInt32().ForeignKey<AntiFakeCashRewardsConfig>()
                .WithColumn(nameof(AntiFakeCashRewards.HashCode)).AsAnsiString(128).Nullable()
                .WithColumn(nameof(AntiFakeCashRewards.Latitude)).AsDecimal(9, 6).Nullable()
                .WithColumn(nameof(AntiFakeCashRewards.Longitude)).AsDecimal(9, 6).Nullable()
                .WithColumn(nameof(AntiFakeCashRewards.ReceivedDateUtc)).AsDateTime2().Nullable()
                .WithColumn(nameof(AntiFakeCashRewards.ExchangeDateUtc)).AsDateTime2().Nullable()
                ;
        }

        #endregion
    }
}
