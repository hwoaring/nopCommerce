using FluentMigrator.Builders.Create.Table;
using Nop.Core.Domain.AntiFake;
using Nop.Data.Extensions;

namespace Nop.Data.Mapping.Builders.AntiFake;

/// <summary>
/// Represents a affiliate entity builder
/// </summary>
public partial class AntiFakeExchangeCodeBuilder : NopEntityBuilder<AntiFakeExchangeCode>
{
    #region Methods

    /// <summary>
    /// Apply entity configuration
    /// </summary>
    /// <param name="table">Create table expression builder</param>
    public override void MapEntity(CreateTableExpressionBuilder table)
    {
        table
            .WithColumn(nameof(AntiFakeExchangeCode.AntiFakeExchangeConfigId)).AsInt32().ForeignKey<AntiFakeExchangeConfig>()
            .WithColumn(nameof(AntiFakeExchangeCode.ExchangedDateOnUtc)).AsDateTime2().Nullable()

            ;
    }

    #endregion
}
