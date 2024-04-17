using FluentMigrator.Builders.Create.Table;
using Nop.Core.Domain.Vendors;

namespace Nop.Data.Mapping.Builders.Vendors;

/// <summary>
/// Represents a vendor entity builder
/// </summary>
public partial class VendorStoreTemplateBuilder : NopEntityBuilder<VendorStoreTemplate>
{
    #region Methods

    /// <summary>
    /// Apply entity configuration
    /// </summary>
    /// <param name="table">Create table expression builder</param>
    public override void MapEntity(CreateTableExpressionBuilder table)
    {
        table
            .WithColumn(nameof(VendorStoreTemplate.Name)).AsString(64).NotNullable()
            .WithColumn(nameof(VendorStoreTemplate.Discription)).AsString(512).Nullable()
            .WithColumn(nameof(VendorStoreTemplate.ViewPath)).AsAnsiString(1024).NotNullable()

            ;
    }

    #endregion
}
