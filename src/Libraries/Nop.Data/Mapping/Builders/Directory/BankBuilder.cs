using FluentMigrator.Builders.Create.Table;
using Nop.Core.Domain.Directory;
using Nop.Data.Extensions;


namespace Nop.Data.Mapping.Builders.Directory;

/// <summary>
/// Represents a affiliate entity builder
/// </summary>
public partial class BankBuilder : NopEntityBuilder<Bank>
{
    #region Methods

    /// <summary>
    /// Apply entity configuration
    /// </summary>
    /// <param name="table">Create table expression builder</param>
    public override void MapEntity(CreateTableExpressionBuilder table)
    {
        table
            .WithColumn(nameof(Bank.Name)).AsString(64).NotNullable()
            .WithColumn(nameof(Bank.SimpleCode)).AsAnsiString(64).NotNullable()
            ;
    }

    #endregion

}
