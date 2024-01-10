using System.Data;
using FluentMigrator.Builders.Create.Table;
using Nop.Core.Domain.AntiFake;
using Nop.Data.Extensions;

namespace Nop.Data.Mapping.Builders.AntiFake
{
    /// <summary>
    /// Represents a affiliate entity builder
    /// </summary>
    public partial class AntiFakeCashRewardsConfigBuilder : NopEntityBuilder<AntiFakeCashRewardsConfig>
    {
        #region Methods

        /// <summary>
        /// Apply entity configuration
        /// </summary>
        /// <param name="table">Create table expression builder</param>
        public override void MapEntity(CreateTableExpressionBuilder table)
        {
            table
                .WithColumn(nameof(AntiFakeCashRewardsConfig.AntiFakeVendorCompanyId)).AsInt32().ForeignKey<AntiFakeVendorCompany>().OnDelete(Rule.None)
                .WithColumn(nameof(AntiFakeCashRewardsConfig.Title)).AsString(128).NotNullable()
                .WithColumn(nameof(AntiFakeCashRewardsConfig.Description)).AsString(512).Nullable()
                .WithColumn(nameof(AntiFakeCashRewardsConfig.Message)).AsString(512).Nullable()
                .WithColumn(nameof(AntiFakeCashRewardsConfig.ConfirmDateUtc)).AsDateTime2().Nullable()
                .WithColumn(nameof(AntiFakeCashRewardsConfig.StartDateUtc)).AsDateTime2().Nullable()
                .WithColumn(nameof(AntiFakeCashRewardsConfig.EndDateUtc)).AsDateTime2().Nullable()
                ;
        }

        #endregion

    }
}
