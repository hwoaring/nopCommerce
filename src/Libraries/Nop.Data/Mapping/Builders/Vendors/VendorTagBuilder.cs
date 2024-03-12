using FluentMigrator.Builders.Create.Table;
using Nop.Core.Domain.Vendors;

namespace Nop.Data.Mapping.Builders.Vendors;

/// <summary>
/// Represents a vendor entity builder
/// </summary>
public partial class VendorTagBuilder : NopEntityBuilder<VendorTag>
{
    #region Methods

    /// <summary>
    /// Apply entity configuration
    /// </summary>
    /// <param name="table">Create table expression builder</param>
    public override void MapEntity(CreateTableExpressionBuilder table)
    {
        table
            .WithColumn(nameof(VendorTag.Name)).AsString(32).NotNullable()

            ;
    }

    #endregion
}
